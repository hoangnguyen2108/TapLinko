using System.ComponentModel.DataAnnotations;

namespace TapLinko.Models
{
    public class LinkItem
    {
        [Key]
        public int LinkItemId { get; set; }

        public string? Label { get; set; }
        public string? Url { get; set; }
        public int Order { get; set; }
        public int ClickCount { get; set; }

        // 1 - many LinkPage
        public int LinkPageId {  get; set; }
        public LinkPage? LinkPage { get; set; }

        // 1- Many ClieckEvent

        public List<ClickEvent> ClickEvents { get; set; } = new List<ClickEvent>();
    }
}
