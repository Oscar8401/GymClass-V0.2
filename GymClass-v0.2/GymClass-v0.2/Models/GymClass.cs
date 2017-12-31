using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GymClass_v0._2.Models
{
    public class GymClass
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [DataType(DataType.Date)]
        public DateTime StartTime { get; set; }

        [DataType(DataType.Time)]
        public TimeSpan Duration { get; set; }

        public DateTime EndTime { get { return StartTime + Duration; } }

        public string Description { get; set; }

        public virtual ICollection<GymClass> AttendingMembers { get; set; }

    }
}