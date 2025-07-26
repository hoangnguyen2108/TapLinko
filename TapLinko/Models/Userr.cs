using System.ComponentModel.DataAnnotations;

namespace TapLinko.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }

        // 1-1 Relationship to LinkPage
        public LinkPage? LinkPage { get; set; }
    }
}
