using GymClass_v0._2.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GymClass_v0._2.ViewModel
{
    public class Members
    {
        public string Id { get; set; }

        [Required(ErrorMessage = "Please enter your first name.")]
        [DisplayName("First Name")]
        [DisplayFormat(NullDisplayText = "Undefined")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please enter your last name.")]
        [DisplayName("Last Name")]
        [DisplayFormat(NullDisplayText = "Undefined")]
        public string LastName { get; set; }

        [Column(TypeName ="datetime2")]
        public DateTime TimeOfregistration { get; set; }

        [Display(Name = "Email address")]
        [Required(ErrorMessage = "The email address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        public ICollection<GymClass> AttendedClasses { get; set; }

        public ICollection<string> MemberRole { get; set; }

        public Members() {}
        public Members(ApplicationUser x)
        {
            Id = x.Id;
            FirstName = x.FirstName;
            LastName = x.LastName;
            AttendedClasses = x.AttendedClasses;
            TimeOfregistration = x.TimeOfRegistration;
            Email = x.Email;
        }
    }
}