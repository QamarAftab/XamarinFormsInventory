using Helper.Helpers;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace InventoryManagementSystem.Brand
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Add : PopupPage
    {
        Helper.Database.BrandMvvm objBrand;
        Helper.Database.Brand brand;
        public Add(Helper.Database.Brand _brand = null)
        {
            InitializeComponent();
            brand = _brand;
            objBrand = Helper.Database.BrandMvvm.GetInstance;
            if (brand != null)
            {
                BtnSave.Text = "Update";
                TxtBrandName.Text = brand.Name;
            }
            else
            {
                BtnSave.Text = "Add";
            }
        }

        private void BtnSave_Clicked(object sender, EventArgs e)
        {
            var result = new Helper.Helpers.Common.Result();
            if (brand != null)
            {
                result = objBrand.Edit(new Helper.Database.Brand()
                {
                    DateCreated = DateTime.UtcNow,
                    Name = TxtBrandName.Text,
                    Status = true,
                    Id = brand.Id
                });
            }
            else
            {
                result = objBrand.Add(new Helper.Database.Brand()
                {
                    DateCreated = DateTime.UtcNow,
                    Name = TxtBrandName.Text,
                    Status = true
                });
            }

            if (!result.Status)
            {
                ControlsHelper.Toast(result.Message, System.Drawing.Color.Red);
            }
            else
            {
                PopupNavigation.Instance.PopAsync();
                ControlsHelper.Toast(result.Message, System.Drawing.Color.Green);
                MessagingCenter.Send<Add>(this, "BrandIndex");
            }
        }
        protected override bool OnBackgroundClicked()
        {
            return false;
        }

        private void BtnCancel_Clicked(object sender, EventArgs e)
        {
            PopupNavigation.Instance.PopAsync();
        }

        protected override void OnAppearing()
        {
            DependencyService.Get<Helper.IAdmobInterstitialAds>().Display(Helper.AppConstants.InterstitialAdId);
        }
    }
}