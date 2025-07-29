using Microsoft.AspNetCore.Identity;
using TapLinko.Models;

namespace TapLinko.Data
{
    public class ApplicationUser: IdentityUser
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateOnly? DateofBirth { get; set; }

        public LinkPage? LinkPage { get; set; }

    }
}
