using System.ComponentModel.DataAnnotations;

namespace OnlineShopping.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required(ErrorMessage="Username cannot be blank")]
        [EmailAddress(ErrorMessage="Email format is invalid")]
        
        public string Username { get; set; }
        [Required(ErrorMessage ="Password is required")]
        [MinLength(8)]
        public string Password { get; set; }
    }
}
