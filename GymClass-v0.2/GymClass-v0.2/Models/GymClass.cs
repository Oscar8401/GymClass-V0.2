using GymClass_v0._2.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GymClass_v0._2.Models
{
    public class GymClass
    {
        public int Id { get; set; }

        [DisplayName("First Name")]
        public string Name { get; set; }

        [DataType(DataType.Date)]
        public DateTime StartTime { get; set; }

        [DataType(DataType.Time)]
        public TimeSpan Duration { get; set; }

         public DateTime EndTime { get { return StartTime + Duration; } }

        [Required(ErrorMessage = "Please enter something.")]
        [DisplayName("Desccription")]
        [MaxWords(2)]
        public string Description { get; set; }

        public virtual ICollection<ApplicationUser> AttendingMembers { get; set; }

    }
}