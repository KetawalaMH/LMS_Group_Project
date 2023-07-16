using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Group_Project
{
    public class Result
    {
        [Key]
        public float marks { get; set; }
        public string Pass { get; set; }
        public float Gpa { get; set; }
    }
}
