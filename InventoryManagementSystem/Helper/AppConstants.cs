using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Helper
{
    public class AppConstants
    {
        public static string AppId
        {
            get
            {
                switch (Device.RuntimePlatform)
                {
                    case Device.Android:
                        return "";
                    default:
                        return "";
                }
            }
        }

        /// <summary>
        /// These Ids are test Ids from https://developers.google.com/admob/android/test-ads
        /// </summary>
        /// <value>The banner identifier.</value>
        public static string BannerId
        {

            get
            {
                switch (Device.RuntimePlatform)
                {
                    case Device.Android:
                        return "ca-app-pub-4397395161073152/7827201510";
                    default:
                        return "ca-app-pub-4397395161073152/7827201510";
                }
            }
        }

        /// <summary>
        /// These Ids are test Ids from https://developers.google.com/admob/android/test-ads
        /// </summary>
        /// <value>The Interstitial Ad identifier.</value>
        public static string InterstitialAdId
        {
            get
            {
                switch (Device.RuntimePlatform)
                {
                    case Device.Android:
                        return "ca-app-pub-4397395161073152/9659157939";
                    default:
                        return "ca-app-pub-4397395161073152/9659157939";
                }
            }
        }

        public static bool ShowAds
        {
            get
            {
                return true;
                _adCounter++;
                if (_adCounter % 5 == 0)
                {
                    return true;
                }
                return false;
            }
        }

        private static int _adCounter;

    }
}
