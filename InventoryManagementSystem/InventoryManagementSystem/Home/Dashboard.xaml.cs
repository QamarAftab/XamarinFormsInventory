using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
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
        }

        public class NumberClass
        {
            public long Number { get; set; }
        }
    }
}