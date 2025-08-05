using System.ComponentModel.DataAnnotations;
using TapLinko.Models;

namespace TapLinko.Models
{
    public class LinkPage
    {
        [Key]
        public int LinkPageId { get; set; }

        // 1 -1 Relationship to ApplicationUser
       
        

        public string? UserId {  get; set; }
        public ApplicationUser? ApplicationUser { get; set; }
        public string? Email { get; set; }
        public string? LinkPageTitle { get; set; }
        public string? Bio {  get; set; }
        public string? ProfileImageUrl { get; set; }
        public string? BannerImageUrl { get; set; }
        public string? PublicSlug { get; set; }

        // 1 - many LinkItems
        public List<LinkItem> LinkItems { get; set; } = new List<LinkItem>();

    }
}
