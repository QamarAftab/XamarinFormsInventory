using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using InventoryManagementSystem.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Helper;
using Android.Gms.Ads;
using Helper.CustomControls;
using System.ComponentModel;

[assembly: ExportRenderer(typeof(AdMobView), typeof(AdBanner_Droid))]
namespace InventoryManagementSystem.Droid
{
    
    class AdBanner_Droid: ViewRenderer<AdMobView, AdView>
    {
        string appId = "ca-app-pub-3940256099942544/6300978111";
        Context context;
        public AdBanner_Droid(Context _context):base(_context)
        {
            context = _context;
        }

        //protected override void OnElementChanged(ElementChangedEventArgs<AdBanner> e)
        //{
        //    base.OnElementChanged(e);

        //    if (e.NewElement != null && Control == null)
        //    {
        //        SetNativeControl(CreateAdView());
        //    }
        //}


        protected override void OnElementChanged(ElementChangedEventArgs<AdMobView> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement != null && Control == null)
            {
                SetNativeControl(CreateAdView());
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == nameof(appId))
                Control.AdUnitId = Element.AdUnitId;
        }

        private AdView CreateAdView()
        {
            var adView = new AdView(Context)
            {
                AdSize = AdSize.SmartBanner,
                AdUnitId = appId
            };

            adView.LayoutParameters = new LinearLayout.LayoutParams(LayoutParams.MatchParent, LayoutParams.MatchParent);

            adView.LoadAd(new AdRequest
                            .Builder()
                            .Build());

            return adView;
        }
    }
}