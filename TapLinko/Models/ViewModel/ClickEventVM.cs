namespace TapLinko.Models.ViewModel
{
    public class ClickEventVM
    {
        public int ClickEventId { get; set; }
        public DateOnly Timestamp { get; set; }
        public string? Ip { get; set; }
        public string? UserAgent { get; set; }

        public int LinkItemId { get; set; }
        public LinkItem? LinkItem { get; set; }
    }
}
