using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLite;
using Xamarin.Forms;

namespace Helper.Database
{
    public class Brand
    {
        [PrimaryKey, AutoIncrement]
        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime DateCreated { get; set; }
        public bool Status { get; set; }
    }

    public class BrandMvvm
    {
        private static BrandMvvm instance = null;
        private static readonly object padlock = new object();
        private static SQLiteConnection conn = null;
        private BrandMvvm() { }
        public static BrandMvvm GetInstance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new BrandMvvm();
                        conn = DependencyService.Get<ISQLite>().GetConnection();
                     //   conn.CreateTable<Helper.Database.Brand>();
                    }
                    return instance;
                }
            }
        }

        public Helpers.Common.Result Add(Brand b)
        {
            var result = new Helpers.Common.Result();
            try
            {
                if (!Helpers.CommonHelper.CheckIsNull(b.Name))
                {
                    conn.Insert(b);
                    result.Status = true;
                    result.Message = "Save successfully.";
                }
                else
                {
                    result.Status = false;
                    result.Message = "Name is required.";
                }
            }
            catch (Exception e)
            {
                result.Status = false;
                result.Message = e.Message;
            }
            return result;
        }

        public Helpers.Common.Result Edit(Brand b)
        {
            var result = new Helpers.Common.Result();
            try
            {
                conn.Update(b);
                result.Status = true;
                result.Message = "Update successfully.";
            }
            catch (Exception e)
            {
                result.Status = false;
                result.Message = e.Message;
            }
            return result;
        }

        public Brand GetBrand(long? Id)
        {
            try
            {
                return (from stu in conn.Table<Helper.Database.Brand>() select stu).FirstOrDefault(ee => ee.Id == Id);
            }
            catch (Exception e)
            { }
            return null;
        }

        public IEnumerable<Brand> GetBrand(string brand = "")
        {
            try
            {
                brand = brand ?? "";
                return (from stu in conn.Table<Brand>() select stu).Where(ee=>ee.Name.Contains(brand)).ToList().OrderByDescending(ee => ee.Id);
            }
            catch (Exception e)
            { }
            return null;
        }

        public Helpers.Common.Result Delete(Brand b)
        {
            var result = new Helpers.Common.Result();
            try
            {
                conn.Table<Brand>().Delete(e => e.Id == b.Id);
                result.Status = true;
                result.Message = "Delete successfully.";
            }
            catch (Exception e)
            {
                result.Status = false;
                result.Message = e.Message;
            }
            return result;
        }
    }
}
