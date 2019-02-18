using Helper.Helpers;
using Rg.Plugins.Popup.Services;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace InventoryManagementSystem.Category
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Index : ContentPage
	{
        Helper.Database.CategoryMvvm objCategory;
        public Index()
        {
            objCategory = Helper.Database.CategoryMvvm.GetInstance;
            InitializeComponent();
            MessagingCenter.Subscribe<Add>(this, "CategoryIndex", (sender) =>
            {
                BindListAsync();
            });
        }

        protected override void OnAppearing()
        {
            BindListAsync();
            DependencyService.Get<Helper.IAdmobInterstitialAds>().Display(Helper.AppConstants.InterstitialAdId);
        }

        protected void LstCategory_Refresh(object sender, EventArgs e)
        {
            BindListAsync();
        }

        protected async void BindListAsync()
        {
            LstCategory.IsRefreshing = true;
            var data = await Task.Run(() => objCategory.GetCategory(TxtSearchBar.Text));
            if (data != null && data.Any())
            {
                LstCategory.ItemsSource = data;
            }
            else
            {
                LstCategory.ItemsSource = null;
            }
            LstCategory.IsRefreshing = false;
        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            PopupNavigation.Instance.PushAsync(new Add());
        }

        void OnEdit(object sender, EventArgs e)
        {
            var obj = ((MenuItem)sender);
            var Category = (Helper.Database.Category)obj.CommandParameter;
            PopupNavigation.Instance.PushAsync(new Add(Category));
        }

        async void OnDelete(object sender, EventArgs e)
        {
            var obj = ((MenuItem)sender);
            var data = await DisplayAlert("Confirm", "Are you sure?", "Ok", "Cancel");
            if (data)
            {
                var Category = (Helper.Database.Category)obj.CommandParameter;
                var result = objCategory.Delete(Category);
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