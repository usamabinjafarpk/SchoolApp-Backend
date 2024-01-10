using System.ComponentModel.DataAnnotations;

namespace HandsOnWebApiUsingModelValidation.Models
{
    public class Login
    {
        [Required(ErrorMessage ="Please Enter Username")]
        public string Username { get; set; }
        [Required(ErrorMessage ="Please enter password")]
        public string Password { get; set; }
    }
}
