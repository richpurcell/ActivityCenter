using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http; // This is needed to use Session
using Newtonsoft.Json; // This is used to serialize/deserialize stuff into JSON 
using Microsoft.AspNetCore.Identity;
using ActivityCenter.Models;
using Microsoft.EntityFrameworkCore;

namespace ActivityCenter.Controllers
{
    public class HomeController : Controller
    {
        private MyContext dbContext;
        public HomeController(MyContext context)
        {
            dbContext = context;
        }
        [HttpGet("")]
        public IActionResult blank()
        {
            return View("index");
        }
        [HttpGet("signin")]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult MyLogin(Login myLogin) // This is the method where the form data from the LoginPartial goes to
        {
            if(ModelState.IsValid)
            {
                // If initial ModelState is valid, query for user with provided email
                var userInDb = dbContext.users.FirstOrDefault(u => u.Email == myLogin.LoginEmail);
                if(userInDb == null) // if User object returned is not defined (i.e. The User with myLogin.Password doesn't exist)
                {
                    // Add a ModelState Error and return to the LoginRegistration page
                    ModelState.AddModelError("LoginEmail", "Invalid Email/Password");
                    return View("index");
                }
                // Initialize the hasher object
                var hasher = new PasswordHasher<Login>();
                // verify provided password against hash stored in db
                var result = hasher.VerifyHashedPassword(myLogin, userInDb.Password, myLogin.LoginPassword);
                // result can be compared to 0 for failure
                if(result == 0)
                {
                    ModelState.AddModelError("LoginPassword", "Invalid Email/Password");
                    return View("index");
                }
                // Add UserId to the session. Done!
                HttpContext.Session.SetInt32("UserId", userInDb.UserId);
                return RedirectToAction("success"); // This is the page that the results will go to if the form is valid
            } else {
                return View("index"); // This is the action (method) that will be performed is the form is invalid
            }
        }
        [HttpPost] // This is the Post where we Register a new User
        public IActionResult AddUser(User myUser) // This is the method where the form data from the UserPartial goes to
        {
            if(ModelState.IsValid)
            {
                // Check if the Email is already in use
                if(dbContext.users.Any(u => u.Email == myUser.Email))
                {
                    ModelState.AddModelError("Email", "Email already in use!");
                    return View("index");
                }
                // If the ModelState is valid
                PasswordHasher<User> Hasher = new PasswordHasher<User>(); // instantiate a PasswordHasher
                myUser.Password = Hasher.HashPassword(myUser, myUser.Password); // Create Passwword Hash
                dbContext.Add(myUser); // Add the new User to the database
                dbContext.SaveChanges(); // Don't forget to save
                // Level II: (Optional): Log user in directly, obtaining UserId from newly created User. Done!
                // Then, redirect to Success page. Done!
                User userInDb = dbContext.users.FirstOrDefault(u => u.Email == myUser.Email);
                HttpContext.Session.SetInt32("UserId", userInDb.UserId);
                return RedirectToAction("success");
            } else {
                return View("index"); // This is the action (method) that will be performed is the form is invalid
            }
        }
        [HttpGet("login")]
        public IActionResult login()
        {
            return View("index"); // Level I: Redirect to Login page. Done!
        }
        [HttpGet("success")]
        public IActionResult success()
        {
            // Only logged-in users should be able to see this page. If no user is in session, redirect to Login page. Done!
            int? UserId = HttpContext.Session.GetInt32("UserId");
            if(UserId == null)
            {
                return RedirectToAction("signin");
            }
            return RedirectToAction("home");
        }
        [HttpGet("logout")]
        public IActionResult logout()
        {
            // On logout clear Session
            HttpContext.Session.Clear();
            return View("index");
        }
        [HttpGet("new")]
        public IActionResult NewActivity()
        {
            int? UserId = HttpContext.Session.GetInt32("UserId");
            if(UserId == null)
            {
                return RedirectToAction("index");
            }
            return View();
        }
        [HttpPost]
        public IActionResult AddActivity(DojoActivity newActivity)
        {
            int? UserId = HttpContext.Session.GetInt32("UserId");
            newActivity.OrganizerId = (int)UserId;
            if(ModelState.IsValid)
            {
                dbContext.Add(newActivity);
                dbContext.SaveChanges();
                int x = newActivity.ActivityId;
                return RedirectToAction("ViewActivity", new {ActivityId=$"{newActivity.ActivityId}"});
            } 
            return View("NewActivity");
        }
        [HttpGet("activity/{ActivityId}")]
        public IActionResult ViewActivity(int ActivityId)
        {
            int? UserId = HttpContext.Session.GetInt32("UserId");
            if(UserId == null)
            {
                return RedirectToAction("index");
            }
            DojoActivity ThisActivity = dbContext.dojoactivities.FirstOrDefault(u => u.ActivityId == ActivityId);
            ViewBag.ThisActivity = ThisActivity;
            var ActivityWithParticipants = dbContext.dojoactivities
                .Include(w=>w.Attendees)
                .ThenInclude(a=>a.Attendee)
                .FirstOrDefault(w=>w.ActivityId == ActivityId);
            ViewBag.AllParticipants = ActivityWithParticipants;
            ViewBag.Organizer = dbContext.users.FirstOrDefault(o=>o.UserId == ThisActivity.OrganizerId);
            return View("ViewActivity", ActivityWithParticipants);
        }
        [HttpGet("delete/{ActivityId}")]
        public IActionResult Delete(int ActivityId)
        {
            int? UserId = HttpContext.Session.GetInt32("UserId");
            if(UserId == null)
            {
                return RedirectToAction("index");
            }
            var thisActivity = dbContext.dojoactivities.FirstOrDefault(w=>w.ActivityId == ActivityId);
            dbContext.Remove(thisActivity);
            dbContext.SaveChanges();
            return RedirectToAction("home");
        }
        [HttpGet("home")]
        public IActionResult Home()
        {
            int? UserId = HttpContext.Session.GetInt32("UserId");
            if(UserId == null)
            {
                return RedirectToAction("index");
            }
            ViewBag.User = dbContext.users.FirstOrDefault(u=>u.UserId == UserId);
            List<User> AllUsers = dbContext.users.ToList();
            var ActivitiesWithParticipants = dbContext.dojoactivities
                .Where(a=>a.ActivityDate > DateTime.Now)
                .Include(w => w.Attendees)
                .ThenInclude(a=>a.Attendee)
                .OrderBy(act => act.ActivityDate)
                .ToList();
            var AllAssociations = dbContext.associations.ToList();
            Wrapper MyWrapper = new Wrapper();
            MyWrapper.AllActivities = ActivitiesWithParticipants;
            MyWrapper.AllEvents = AllAssociations;
            MyWrapper.AllUsers = AllUsers;
            ViewBag.UserId = (int)UserId;
            ViewBag.AllUsers = AllUsers;
            return View("home", MyWrapper);
        }
        [HttpGet("join/{ActivityId}")]
        public IActionResult Join(int ActivityId)
        {
            int? UserId = HttpContext.Session.GetInt32("UserId");
            if(UserId == null)
            {
                return RedirectToAction("index");
            }
            var IsAttending = dbContext.associations
                .Where(a=>a.ActivityId == ActivityId && a.AttendeeId == UserId).ToList();
            if(IsAttending.Count() == 0)
            {
                Association Attending = new Association();
                Attending.AttendeeId = (int)UserId;
                Attending.ActivityId = ActivityId;
                dbContext.Add(Attending);
                dbContext.SaveChanges();
            }
            return RedirectToAction("home");
        }
        [HttpGet("leave/{ActivityId}")]
        public IActionResult Leave(int ActivityId)
        {
            int? UserId = HttpContext.Session.GetInt32("UserId");
            if(UserId == null)
            {
                return RedirectToAction("index");
            }
            var IsAttending = dbContext.associations
                .Where(a=>a.ActivityId == ActivityId)
                .FirstOrDefault(a=>a.AttendeeId == UserId);
            dbContext.Remove(IsAttending);
            dbContext.SaveChanges();
            return RedirectToAction("home");
        }
    }
    public static class SessionExtensions
    {
        public static void SetObjectAsJson(this ISession session, string key, object value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }
        // generic type T is a stand-in indicating that we need to specify the type on retrieval
        public static T GetObjectFromJson<T>(this ISession session, string key)
        {
            string value = session.GetString(key);
            // Upon retrieval the object is deserialized based on the type specified
            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
        }
    }
}
