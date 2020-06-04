using System.ComponentModel.DataAnnotations;

namespace User.Models
{
    public class User
    {
        public User() { }

        [Key]
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public double Balance { get; set; }
    }
}
