using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema; // Add this to use [NotMapped]
namespace ActivityCenter.Models
{
    public class Association
    {
        // Add Id and use [Key] as the validator
        [Key]
        public int AssociationId {get;set;}
        public int AttendeeId {get;set;} // This is UserId
        public int ActivityId {get;set;}
        public User Attendee {get;set;}
        public DojoActivity Event {get;set;}
    }
}