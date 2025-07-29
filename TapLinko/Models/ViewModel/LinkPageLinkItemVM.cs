namespace TapLinko.Models.ViewModel
{
    public class LinkPageLinkItemVM
    {
        public int LinkPageId { get; set; }
        public int UserId { get; set; }

        public string? LinkPageTitle { get; set; }
        public string? Bio { get; set; }
        public string? ProfileImageUrl { get; set; }
        public string? BannerImageUrl { get; set; }

        public int LinkItemId { get; set; }
        public string? Label { get; set; }
        public string? Url { get; set; }
        public int Order { get; set; }
        public int ClickCount { get; set; }
        public int MaxOrder { get; set; }
    }
}
