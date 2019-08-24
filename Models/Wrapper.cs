using System;
using System.Collections.Generic;

namespace ActivityCenter.Models
{
    public class Wrapper
    {
        public List<DojoActivity> AllActivities { get; set; }

        public List<Association> AllEvents {get;set;}
        public List<User> AllUsers {get;set;}
    }
}