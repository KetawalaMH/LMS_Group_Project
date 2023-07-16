using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Group_Project
{
    public class Module
    {
        [Key]
        public string ModuleCode { get; set; }
        public string? ModuleName {get; set; }
        public string? Department { get; set; }
        public string Semester{get; set; }
        public int Credits {get; set; }

        public Module(string modulecode, string modulename, string department, string semester, int credits)
        {
            ModuleCode = modulecode;
            ModuleName = modulename;
            Department = department;
            Semester = semester;
            Credits = credits;

        }
        public Module()
        {

        }
    }
    
  
}
