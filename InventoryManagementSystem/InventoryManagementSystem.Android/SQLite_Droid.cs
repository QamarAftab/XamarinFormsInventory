using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xamarin.Forms;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Helper.Database;
using InventoryManagementSystem.Droid;
using SQLite;

[assembly:Dependency(typeof(SQLite_Droid))]
namespace InventoryManagementSystem.Droid
{
    class SQLite_Droid : ISQLite
    {
        public SQLiteConnection GetConnection()
        {
            string dbName = "InventoryManagementSystem.sqlite";
            var dbPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData);
            string _path = Path.Combine(dbPath,dbName);
            return new SQLiteConnection(_path);
        }
    }
}