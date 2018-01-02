using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GymClass_v0._2.Models.ViewModel
{
    public class GymClassViewModel
    {
        public int Id { get; set; }

        public string ClassName { get; set; }

        public string Description { get; set; }

        public TimeSpan Duration { get; set; }

        [DataType(DataType.Date)]
        public string Date { get; set; }

        [DataType(DataType.Time)]
        public string Time { get; set; }

        public string Name { get; set; }

        public int ClassType { get; set; }

        public string DateTime { get { return Date + " " + Time; } }

        public string EndTime { get { return DateTime + Duration; } }

        public IEnumerable<GymClass> ClassTypes { get; set; }
    }
}