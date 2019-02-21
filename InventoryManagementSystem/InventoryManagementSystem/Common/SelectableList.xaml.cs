using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace InventoryManagementSystem.Common
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SelectableList : ContentPage
    {
        public class DataList
        {
            public long Id { get; set; }
            public string Name { get; set; }
        }

        private List<DataList> data = new List<DataList>();
        public DataList select;

        public SelectableList(List<DataList> _data)
        {
            InitializeComponent();
            data = _data;
            BindList();
        }

        private void TxtSearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void LstData_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            select = (DataList)e.SelectedItem;
            Navigation.PopAsync();
        }


        protected void BindList()
        {
            if(data != null && data.Any())
            {
                data = data.OrderBy(ee=>ee.Name).ToList();
                LstData.ItemsSource = data;
            }
        }
    }
}