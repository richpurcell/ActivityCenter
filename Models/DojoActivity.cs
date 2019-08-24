using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
namespace ActivityCenter.Models
{
    public class DojoActivity
    {
        [Key]
        public int ActivityId {get;set;}
        [Required]
        [Display(Name = "Title:")]
        public string Title {get;set;}
        [Required]
        [FutureDate]
        [DataType(DataType.Date)]
        [Display(Name = "Date:")]
        public DateTime ActivityDate {get;set;}
        [Display(Name="Time:")]
        [DataType(DataType.Time)]
        public DateTime ActivityTime {get;set;}
        [Display(Name="Duration:")]
        [GreaterThan0]
        public int Duration {get;set;}
        [Required]
        public string Multiplier {get;set;}
        [Display(Name="Description:")]
        public string Description {get;set;}
        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;
        public int OrganizerId {get;set;}
        public List<Association> Attendees {get;set;}
    }
    public class FutureDateAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if ((DateTime)value <= DateTime.Now){
                return new ValidationResult("Date must be in the future");
            }
            return ValidationResult.Success;
        }
    }
    public class GreaterThan0Attribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if ((int)value <= 0){
                return new ValidationResult("Duration must be in greater than 0");
            }
            return ValidationResult.Success;
        }
    }
}