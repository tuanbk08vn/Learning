using System.ComponentModel.DataAnnotations;

namespace News.ViewModel
{
    public class LoginViewModel
    {
        [Required, Display(Name = "Enter your user name")]
        public string UserName { get; set; }
        [Required, Display(Name = "Password"),MaxLength(20),MinLength(3), DataType((DataType.Password))]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}