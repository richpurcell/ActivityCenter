using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
 
namespace ActivityCenter.Models
{
    public class MyContext : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public MyContext(DbContextOptions options) : base(options) { }
        public DbSet<User> users {get;set;} // Notice "<User>" reffers to the Model (i.e. Models/User.cs) but "user" reffers to the table name
        public DbSet<DojoActivity> dojoactivities {get;set;}
        public DbSet<Association> associations {get;set;}
    }
}
