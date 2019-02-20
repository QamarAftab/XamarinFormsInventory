﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace InventoryManagementSystem
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterPage : ContentPage
    {
        public MasterPage()
        {
            InitializeComponent();
        }

        async public void Tapped(object sender, EventArgs e)
        {
            var mdp = GetMaster();
            var navPage = GetNavigation(mdp);
            mdp.IsPresented = false;

            //var stack = (StackLayout)sender;
            //var a = (TapGestureRecognizer)stack.GestureRecognizers.FirstOrDefault();
            //var commandParameter = a.CommandParameter.ToString().ToLower();
            var commandParameter = await Task.Run(() => GetCommandParameter(sender));
            //NAVIGATE TO BRAND PAGE
            if (commandParameter == "brand")
            {
                await navPage.PushAsync(new Brand.Index());
            }
            else if (commandParameter == "category")
            {
                await navPage.PushAsync(new Category.Index());
            }
            else if (commandParameter == "product")
            {
                await navPage.PushAsync(new Product.Index());
            }
        }

        string GetCommandParameter(object sender)
        {
            try
            {
                var stack = (StackLayout)sender;
                var a = (TapGestureRecognizer)stack.GestureRecognizers.FirstOrDefault();
                return a.CommandParameter.ToString().ToLower();
            }
            catch (Exception e)
            { }
            return "";
        }

        public MasterDetailPage GetMaster()
        {
            return (Application.Current.MainPage as MasterDetailPage);
        }

        public NavigationPage GetNavigation(MasterDetailPage master)
        {
            return master.Detail as NavigationPage;
        }
    }
}