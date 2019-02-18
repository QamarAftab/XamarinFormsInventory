using System;
using System.Collections.Generic;
using System.Text;

namespace Helper.CustomControls
{
    public class AdBanner : Xamarin.Forms.View
    {
        public enum Sizes { Standardbanner, LargeBanner, MediumRectangle, FullBanner, Leaderboard, SmartBannerPortrait };
        public Sizes sizes { get; set; }
        public AdBanner()
        {
            this.BackgroundColor = Xamarin.Forms.Color.Accent;
        }
    }
}
