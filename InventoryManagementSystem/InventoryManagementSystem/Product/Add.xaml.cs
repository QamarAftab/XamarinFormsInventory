using Helper.Helpers;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace InventoryManagementSystem.Product
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Add : PopupPage
    {
        Helper.Database.ProductMVVM objProduct;
        Helper.Database.BrandMvvm objBrand;
        Helper.Database.CategoryMvvm objCategory;
        Helper.Database.Product product;

        public Add()
        {
            InitializeComponent();
            objProduct = Helper.Database.ProductMVVM.GetInstance;
            objCategory = Helper.Database.CategoryMvvm.GetInstance;
            objBrand = Helper.Database.BrandMvvm.GetInstance;
        }

        async private void BtnSave_Clicked(object sender, EventArgs e)
        {
            var result = new Helper.Helpers.Common.Result();
            Helper.Helpers.ControlsHelper.ShowLoading(true);
            result = await Task.Run(() => objProduct.Add(
                 new Helper.Database.Product()
                 {

                 }
                ));
        }

        private void BtnCancel_Clicked(object sender, EventArgs e)
        {
            PopupNavigation.Instance.PopAsync();
        }

        protected override void OnAppearing()
        {
            BindControls();
            DependencyService.Get<Helper.IAdmobInterstitialAds>().Display(Helper.AppConstants.InterstitialAdId);
        }

        protected override bool OnBackgroundClicked()
        {
            return false;
        }


        void BindControls()
        {
            var cat = objCategory.GetCategory();
            var brand = objBrand.GetBrand();
            if(cat != null && cat.Any())
            {
                cat = cat.OrderBy(ee=>ee.Name).ToList();

            }
            else
            {
                DisplayAlert("Error", "Before you create product you must add Catgory", "Ok");
            }
            if (brand != null && brand.Any())
            {

            }
            else
            {
                DisplayAlert("Error", "Before you create product you must add Catgory", "Ok");
            }
        }
    }
}