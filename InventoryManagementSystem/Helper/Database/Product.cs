using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace Helper.Database
{
    public class Product
    {
        [PrimaryKey, AutoIncrement]
        public long Id { get; set; }
        public long? BrandId { get; set; }
        public long? CategoryId { get; set; }
        public string Name { get; set; }
        public DateTime DateCreated { get; set; }
        public decimal? Price { get; set; }
        public decimal Stock { get; set; }
        public bool Status { get; set; }
    }

    public class GetProduct
    {
        public long Id { get; set; }
        public long? BrandId { get; set; }
        public string BrandName { get; set; }
        public long? CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Name { get; set; }
        public DateTime DateCreated { get; set; }
        public decimal? Price { get; set; }
        public decimal Stock { get; set; }
        public bool Status { get; set; }
    }
    public class ProductMVVM
    {
        private static ProductMVVM instance = null;
        private static readonly object padlock = new object();
        private static SQLiteConnection conn = null;
        private ProductMVVM()
        { }
        public static ProductMVVM GetInstance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new ProductMVVM();
                        conn = DependencyService.Get<ISQLite>().GetConnection();
                    }
                    return instance;
                }
            }
        }

        public Helpers.Common.Result Add(Product b)
        {
            var result = new Helpers.Common.Result();
            try
            {
                result.Status = true;
                if (b.BrandId == null || b.BrandId == 0)
                {
                    result.Status = false;
                    result.Message = result.Message + "Brand is required.";
                }

                if (b.CategoryId == null || b.CategoryId == 0)
                {
                    result.Status = false;
                    result.Message = result.Message + "\nCategory is required.";
                }

                if (Helpers.CommonHelper.CheckIsNull(b.Name))
                {
                    result.Status = false;
                    result.Message = result.Message + "\nName is required.";
                }

                if (result.Status)
                {
                    conn.Insert(b);
                    result.Status = true;
                    result.Message = "Save successfully.";
                }
            }
            catch (Exception e)
            {
                result.Status = false;
                result.Message = e.Message;
            }
            return result;
        }

        public Helpers.Common.Result Edit(Product b)
        {
            var result = new Helpers.Common.Result();
            try
            {
                result.Status = true;
                if (b.BrandId == null || b.BrandId == 0)
                {
                    result.Status = false;
                    result.Message = result.Message + "Brand is required.";
                }

                if (b.CategoryId == null || b.CategoryId == 0)
                {
                    result.Status = false;
                    result.Message = result.Message + "\nCategory is required.";
                }

                if (Helpers.CommonHelper.CheckIsNull(b.Name))
                {
                    result.Status = false;
                    result.Message = result.Message + "\nName is required.";
                }
                if (result.Status)
                {
                    conn.Update(b);
                    result.Status = true;
                    result.Message = "Update successfully.";
                }
            }
            catch (Exception e)
            {
                result.Status = false;
                result.Message = e.Message;
            }
            return result;
        }
        public IEnumerable<GetProduct> GetProduct(string product = "")
        {
            try
            {
                product = product ?? "";
                //return (from stu in conn.Table<Product>() select stu).Where(ee => ee.Name.Contains(product)).ToList().OrderByDescending(ee => ee.Id);
                var result = (from pd in conn.Table<Product>()
                              join cat in conn.Table<Category>() on pd.CategoryId equals cat.Id
                              join br in conn.Table<Brand>() on pd.BrandId equals br.Id
                              select new GetProduct()
                              {
                                  BrandId = pd.BrandId,
                                  BrandName = br.Name,
                                  CategoryId = pd.CategoryId,
                                  CategoryName = cat.Name,
                                  Name = pd.Name,
                                  Id = pd.Id,
                                  Price = pd.Price,
                                  DateCreated = pd.DateCreated,
                                  Status = pd.Status,
                                  Stock = pd.Id
                              }).ToList().OrderByDescending(ee => ee.Id);
                return result;
            }
            catch (Exception e)
            { }
            return null;
        }
    }
}
