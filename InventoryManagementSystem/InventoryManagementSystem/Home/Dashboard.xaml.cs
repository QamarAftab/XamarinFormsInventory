using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.RadialMenu.Enumerations;
using Xamarin.Forms.RadialMenu.Models;
using Xamarin.Forms.RadialMenu.ViewModels;
using Xamarin.Forms.Xaml;

namespace InventoryManagementSystem.Home
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Dashboard : ContentPage
    {
        public Dashboard()
        {
            InitializeComponent();
            var lstNumber = new List<NumberClass>() { };
            for (int i = 0; i < 100; i++)
            {
                lstNumber.Add(new NumberClass()
                {
                    Number = i
                });
            }
            Lst.ItemsSource = lstNumber;

            var vm = new MainMenuViewModel();
            BindingContext = vm;
            vm.MenuItems = new ObservableCollection<RadialMenuItem>()
            {
                new RadialMenuItem()
                {
                    Source = "menu_paint.png",
                    Title="Edit",
                    WidthRequest = 38,
                    HeightRequest = 38,
                    VerticalOptions = LayoutOptions.Center,
                    HorizontalOptions = LayoutOptions.Center,
                    Location = Enumerations.RadialMenuLocation.N
                }
            };
            vm.MenuItems.Add(new RadialMenuItem()
            {
                Title="Delete",
                Source = "menu_lorry.png",
                WidthRequest = 38,
                HeightRequest = 38,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
                Location = Enumerations.RadialMenuLocation.Ne
            });

        }

        public class NumberClass
        {
            public long Number { get; set; }
        }
    }
}