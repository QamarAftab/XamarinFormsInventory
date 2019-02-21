using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace InventoryManagementSystem.Droid
{
    [Activity(Label = "InventoryManagementSystem", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            InitControls(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());
            XFGloss.Droid.Library.Init(this, bundle);
            Xamarin.Forms.Forms.Init(this, bundle);
        }

        void InitControls(Bundle bundle)
        {
            Acr.UserDialogs.UserDialogs.Init(() => (Activity)Xamarin.Forms.Forms.Context);
            Plugin.CurrentActivity.CrossCurrentActivity.Current.Activity = this;
            Rg.Plugins.Popup.Popup.Init(this, bundle);
        }
    }
}

