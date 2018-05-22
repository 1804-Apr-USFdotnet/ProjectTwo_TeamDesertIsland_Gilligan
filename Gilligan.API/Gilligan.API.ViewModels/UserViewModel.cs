using System;

namespace Gilligan.API.ViewModels
{
    public class UserViewModel
    {
        public Guid UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public int ZipCode { get; set; }
        public string Email { get; set; }
    }
}
