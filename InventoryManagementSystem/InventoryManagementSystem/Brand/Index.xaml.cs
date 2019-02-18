using Helper.Helpers;
using Rg.Plugins.Popup.Services;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace InventoryManagementSystem.Brand
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Index : ContentPage
    {
        Helper.Database.BrandMvvm objBrand;
        public Index()
        {
            objBrand = Helper.Database.BrandMvvm.GetInstance;
            InitializeComponent();
            MessagingCenter.Subscribe<Add>(this, "BrandIndex", (sender) =>
            {
                BindListAsync();
            });
        }

        protected override void OnAppearing()
        {
            BindListAsync();
            DependencyService.Get<Helper.IAdmobInterstitialAds>().Display(Helper.AppConstants.InterstitialAdId);
        }

        protected void LstBrand_Refresh(object sender, EventArgs e)
        {
            BindListAsync();
        }

        protected async void BindListAsync()
        {
            LstBrand.IsRefreshing = true;
            var data = await Task.Run(() => objBrand.GetBrand(TxtSearchBar.Text));
            if (data != null && data.Any())
            {
                LstBrand.ItemsSource = data;
            }
            else
            {
                LstBrand.ItemsSource = null;
            }
            LstBrand.IsRefreshing = false;
        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            PopupNavigation.Instance.PushAsync(new Add());
        }

        void OnEdit(object sender, EventArgs e)
        {
            var obj = ((MenuItem)sender);
            var Brand = (Helper.Database.Brand)obj.CommandParameter;
            PopupNavigation.Instance.PushAsync(new Add(Brand));
        }

        async void OnDelete(object sender, EventArgs e)
        {
            var obj = ((MenuItem)sender);
            var data = await DisplayAlert("Confirm", "Are you sure?","Ok","Cancel");
            if(data)
            {
                var Brand = (Helper.Database.Brand)obj.CommandParameter;
                var result = objBrand.Delete(Brand);
                if (!result.Status)
                {
                    ControlsHelper.Toast(result.Message, System.Drawing.Color.Red);
                }
                else
                {
                    ControlsHelper.Toast(result.Message, System.Drawing.Color.Green);
                    BindListAsync();
                }
            }
        }

        private void TxtSearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            BindListAsync();
        }
    }
}