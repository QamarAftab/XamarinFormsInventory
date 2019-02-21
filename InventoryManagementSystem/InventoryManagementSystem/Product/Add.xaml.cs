using Helper.Helpers;
using InventoryManagementSystem.Common;
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
    public partial class Add : ContentPage
    {
        Helper.Database.ProductMVVM objProduct;
        Helper.Database.BrandMvvm objBrand;
        Helper.Database.CategoryMvvm objCategory;
        Helper.Database.Product product;
        SelectableList lstCategory;
        SelectableList lstBrand;
        public Add()
        {
            InitializeComponent();
            objProduct = Helper.Database.ProductMVVM.GetInstance;
            objCategory = Helper.Database.CategoryMvvm.GetInstance;
            objBrand = Helper.Database.BrandMvvm.GetInstance;

            BindControls();
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
            Navigation.PopAsync();
        }

        protected override void OnAppearing()
        {
            DependencyService.Get<Helper.IAdmobInterstitialAds>().Display(Helper.AppConstants.InterstitialAdId);
            if(lstCategory != null && lstCategory.select != null)
            {
                LblCategory.Text = lstCategory.select.Name;
            }
            if (lstBrand != null && lstBrand.select != null)
            {
                LblBrand.Text = lstBrand.select.Name;
            }
        }

        void BindControls()
        {
            var cat = objCategory.GetCategory();
            var brand = objBrand.GetBrand();
            if (cat != null && cat.Any())
            {
                cat = cat.OrderBy(ee => ee.Name).ToList();
                lstCategory = new SelectableList(cat.Select(ee => new SelectableList.DataList()
                {
                    Id = ee.Id,
                    Name = ee.Name
                }).ToList());
            }
            else
            {
                DisplayAlert("Error", "Before you create product you must add Catgory", "Ok");
            }
            if (brand != null && brand.Any())
            {
                lstBrand = new SelectableList(brand.Select(ee => new SelectableList.DataList()
                {
                    Id = ee.Id,
                    Name = ee.Name
                }).ToList());
            }
            else
            {
                DisplayAlert("Error", "Before you create product you must add Catgory", "Ok");
            }
        }

        private void LblTapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(lstCategory);
        }

        private void LblBrandTapGestureRecognizer_Tapped(object sender , EventArgs e)
        {
            Navigation.PushAsync(lstBrand);
        }
    }
}