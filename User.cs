using System.ComponentModel.DataAnnotations;

namespace Group_Project
{
    public class User
    {
        [Key]
        public int User_Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
    }
}