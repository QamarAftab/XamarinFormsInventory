using Helper.CustomControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace InventoryManagementSystem
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AdMob : ContentPage
	{
		public AdMob ()
		{
			InitializeComponent ();
            DependencyService.Get<IAdInterstitial>().ShowAd();
        }

        void InterstitialAdShowClick(object sender, EventArgs e)
        {
            DependencyService.Get<IAdInterstitial>().ShowAd();
        }

    }
}