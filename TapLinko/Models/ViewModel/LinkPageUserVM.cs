namespace TapLinko.Models.ViewModel
{
    public class LinkPageUserVM
    {
        public int LinkPageId { get; set; }
        public int UserId { get; set; }

        public string? LinkPageTitle { get; set; }
        public string? Bio { get; set; }
        public string? ProfileImageUrl { get; set; }
        public string? BannerImageUrl { get; set; }

        public string? Name { get; set; }
  
    }
}
