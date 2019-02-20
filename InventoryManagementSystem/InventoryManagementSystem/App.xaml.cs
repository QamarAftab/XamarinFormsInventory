using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

using Xamarin.Forms;

namespace InventoryManagementSystem
{
    public partial class App : Application
    {
        private SQLiteConnection conn;
        public App()
        {
            InitializeComponent();
            Task.Run(() => InitTables());
            try
            {
                InitNavigation();
            }
            catch (Exception e)
            {
            }
            // MainPage = new MainPage();
        }

        private void InitTables()
        {
            #region GET CONNECTION STRING 
            conn = DependencyService.Get<Helper.Database.ISQLite>().GetConnection();
            #endregion

            #region INIT TABLES
            conn.CreateTable<Helper.Database.Brand>();
            conn.CreateTable<Helper.Database.Category>();
            conn.CreateTable<Helper.Database.Product>();
            #endregion

        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        public void InitNavigation()
        {
            try
            {
                var _masterPage = new MasterPage()
                {
                    Title = "Main Page"
                };
                var detailPage = new MasterDetailPage()
                {
                    Master = _masterPage,
                    Detail = new NavigationPage(new Home.Dashboard())
                    {
                    }
                };
                detailPage.MasterBehavior = MasterBehavior.SplitOnLandscape;
                Application.Current.MainPage = detailPage;
            }
            catch (Exception e)
            {
            }
        }
    }
}
