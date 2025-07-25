﻿namespace TapLinko.Models.ViewModel
{
    public class ViewModel
    {
        public List<LinkPageUserVM> LinkPageUserVMs { get; set; } 
        public List<LinkPageLinkItemVM> LinkPageLinkItemVMs { get;set; }

        public List<ClickEvent> ClickEvents { get; set; }
        public List<LinkItemAnalyticsVM> LinkItemAnalyticsVMs { get;set;}
    }
}
