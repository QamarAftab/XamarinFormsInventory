using System;

namespace Helper.Helpers
{
    public class Configuration
    {

        public static string DeviceName
        {
            get
            {
                return "";
            }
        }
        public static string ApiUrl
        {
            get
            {
                return "http://192.168.0.107:96/api/";
            }
        }

        public static Xamarin.Forms.Color[] Colors
        {
            get
            {
                Xamarin.Forms.Color[] ColorArray = { Xamarin.Forms.Color.GhostWhite, Xamarin.Forms.Color.WhiteSmoke };
                return ColorArray;
            }
        }
        public static string CloudinayUrl
        {
            get
            {
                return "https://res.cloudinary.com/indistech/image/upload/{options}/iskoolsnow";
            }
        }

        public static int NumberOfTap
        {
            get
            {
                return 1;
            }
        }

        public static string DefaulDetailEmptyMessage
        {
            get
            {
                return "Record Not Found..";
            }
        }

        public static string DefaultErrorMessage
        {
            get
            {
                return "Something went wrong.";
            }
        }

        public static string ArciveMessage
        {
            get
            {
                return "Data archived successfully";
            }
        }

        public static string Loading
        {
            get
            {
                return "loading.gif";
            }
        }

        public static string DateFormat
        {
            get
            {
                return "dd-MM-yyyy";
            }
        }

        public static double HeadingSize
        {
            get
            {
                return 14;
            }
        }

        public static double DetailSize
        {
            get
            {
                return 12;
            }
        }

        public static double HeadingPadding
        {
            get
            {
                return 5;
            }
        }

        public static int CompressionQuality
        {
            get
            {
                return 50;
            }
        }

        public static string DefaultBackGround
        {
            get
            {
                return "default.png";
            }
        }

        [Obsolete("Get Minimum distance for GeoFencing.")]
        public static decimal MinimumDistance
        {
            get
            {
                return 500;
            }
        }
    }
}
