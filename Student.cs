using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group_Project
{
    public class Student 
    {
       

        [Key]
        public string StudentID { get; set; }
        public string StudentName { get; set; }
        //public DateTime DateOfBirth { get; set; }
        public string age { get; set; }
        public double GPA { get; set; }
        public string Semester { get; set; }

        public string StudentAddress { get; set; }

        public List<Module> Modules { get; set; } = new List<Module>();


        public List<Result> Results { get; set; } = new List<Result>();
      
    }
}
