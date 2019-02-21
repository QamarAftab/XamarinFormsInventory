using Helper.Helpers;
using Rg.Plugins.Popup.Services;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace InventoryManagementSystem.Product
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Index : ContentPage
    {
        Helper.Database.ProductMVVM objProduct;
        public Index()
        {
            objProduct = Helper.Database.ProductMVVM.GetInstance;
            InitializeComponent();
            MessagingCenter.Subscribe<Add>(this, "CategoryIndex", (sender) =>
            {
                BindListAsync();
            });
        }

        private void BindListAsync()
        {
            throw new NotImplementedException();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            DependencyService.Get<Helper.IAdmobInterstitialAds>().Display(Helper.AppConstants.InterstitialAdId);
        }

        private void TxtSearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Add());
        }

        private void LstProduct_Refreshing(object sender, EventArgs e)
        {
            BindListAsync();
        }

        void OnEdit(object sender, EventArgs e)
        {

        }

        void OnDelete(object sender, EventArgs e)
        {

        }
    }
}