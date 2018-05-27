using System.ComponentModel.DataAnnotations;

namespace Gilligan.MVC.ViewModels.User
{
    public class Account
    {
        [Required]
        public string Username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
