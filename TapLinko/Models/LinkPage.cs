using System.ComponentModel.DataAnnotations;

namespace TapLinko.Models
{
    public class LinkPage
    {
        [Key]
        public int LinkPageId { get; set; }

        // 1 -1 Relationship to User
        public User? User { get; set; }
        public int UserId { get; set; }

        public string? LinkPageTitle { get; set; }
        public string? Bio {  get; set; }
        public string? ProfileImageUrl { get; set; }
        public string? BannerImageUrl { get; set; }

        // 1 - many LinkItems
        public List<LinkItem> LinkItems { get; set; } = new List<LinkItem>();

    }
}
