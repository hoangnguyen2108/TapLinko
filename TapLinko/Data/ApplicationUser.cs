using Microsoft.AspNetCore.Identity;

namespace TapLinko.Data
{
    public class ApplicationUser: IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateOnly? DateofBirth { get; set; }
    }
}
