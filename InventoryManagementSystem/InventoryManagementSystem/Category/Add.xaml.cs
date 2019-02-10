using Helper.Helpers;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace InventoryManagementSystem.Category
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Add : PopupPage
    {
        Helper.Database.CategoryMvvm objCategory;
        Helper.Database.Category category;
        public Add(Helper.Database.Category _category = null)
        {
            InitializeComponent();
            category = _category;
            objCategory = Helper.Database.CategoryMvvm.GetInstance;
            if (category != null)
            {
                BtnSave.Text = "Update";
                TxtCategoryName.Text = category.Name;
            }
            else
            {
                BtnSave.Text = "Add";
            }
        }

        private void BtnSave_Clicked(object sender, EventArgs e)
        {
            var result = new Helper.Helpers.Common.Result();
            if (category != null)
            {
                result = objCategory.Edit(new Helper.Database.Category()
                {
                    DateCreated = DateTime.UtcNow,
                    Name = TxtCategoryName.Text,
                    Status = true,
                    Id = category.Id
                });
            }
            else
            {
                result = objCategory.Add(new Helper.Database.Category()
                {
                    DateCreated = DateTime.UtcNow,
                    Name = TxtCategoryName.Text,
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
                MessagingCenter.Send<Add>(this, "CategoryIndex");
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
    }
}