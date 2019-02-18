﻿using Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace InventoryManagementSystem
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();

            AdmobControl admobControl = new AdmobControl()
            {
                AdUnitId = AppConstants.BannerId
            };
            Label adLabel = new Label() { Text = "Ads will be displayed here!" };

            Button showInterstitialAdsButton = new Button();
            showInterstitialAdsButton.Clicked += ShowInterstitialAdsButton_Clicked;
            showInterstitialAdsButton.Text = "Show Interstitial Ads";

            Content = new StackLayout()
            {
                Children = { adLabel, admobControl, showInterstitialAdsButton }
            };

            this.Title = "Admob Page";
        }

        async void ShowInterstitialAdsButton_Clicked(object sender, EventArgs e)
        {
            if (AppConstants.ShowAds)
            {
                await DependencyService.Get<IAdmobInterstitialAds>().Display(AppConstants.InterstitialAdId);
            }
            //Debug.WriteLine("Continue button click implementation");
        }
    }
}
