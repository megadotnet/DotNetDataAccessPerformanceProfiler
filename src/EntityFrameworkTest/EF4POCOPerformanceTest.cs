using System;
using System.Linq;
using DBPerformanceTest.Core;

namespace EntityFrameworkTest
{
    /// <summary>
    /// EF4POCOPerformanceTest
    /// </summary>
    public class  EF4POCOPerformanceTest:IPerformanceTest
    {
        public long FetchSingleTest(int repeatTime)
        {
            var rproductrepository = RepositoryHelper.GetProductsRepository();
            var categoryrepository = RepositoryHelper.GetCategoriesRepository(rproductrepository.Repository.UnitOfWork);
            var customrepository = RepositoryHelper.GetCustomersRepository(rproductrepository.Repository.UnitOfWork);

            return Utility.PerformanceWatch(() =>
                                                {
                                                    for (int i = 0; i < repeatTime; i++)
                                                    {
                                                        var products =
                                                            rproductrepository.Repository.Find(p => p.ProductID == 10).
                                                                ToList();
                                                        var categories =
                                                            categoryrepository.Repository.Find(c => c.CategoryID == 10).
                                                                ToList();
                                                        var cutomers =
                                                            customrepository.Repository.Find(
                                                                cut => cut.CustomerID == "10").ToList();
                                                    }
                                                });
        }

        public long FetchAllTest(int repeatTime)
        {
            var rproductrepository = RepositoryHelper.GetProductsRepository();
            var categoryrepository = RepositoryHelper.GetCategoriesRepository(rproductrepository.Repository.UnitOfWork);
            var customrepository = RepositoryHelper.GetCustomersRepository(rproductrepository.Repository.UnitOfWork);

            return Utility.PerformanceWatch(() =>
                                                {
                                                    for (int i = 0; i < repeatTime; i++)
                                                    {
                                                        var products = rproductrepository.All().ToList();
                                                        var categories = categoryrepository.All().ToList();
                                                        var cutomers = customrepository.All().ToList();
                                                    }
                                                });
        }

        public long WriteTest(int repeatTime)
        {
            var rproductrepository = RepositoryHelper.GetProductsRepository();
            var categoryrepository = RepositoryHelper.GetCategoriesRepository(rproductrepository.Repository.UnitOfWork);
            var customrepository = RepositoryHelper.GetCustomersRepository(rproductrepository.Repository.UnitOfWork);

            return Utility.PerformanceWatch(() =>
                                                {
                                                    for (int i = 0; i < repeatTime; i++)
                                                    {
                                                        var cus = new Customers
                                                                      {
                                                                          CustomerID = "test",
                                                                          CompanyName = "company name",
                                                                          ContactName = "contact name",
                                                                          Address = "address"
                                                                      };

                                                        customrepository.Add(cus);
                                                        customrepository.Save();

                                                        cus.CompanyName = "update name";
                                                        customrepository.Save();

                                                        var cat = new Categories
                                                                      {
                                                                          CategoryName = "Widgets",
                                                                          Description = "Widgets are the ……"
                                                                      };

                                                        // if we have fk
                                                        //db.AddToCategories(cat);
                                                        // db.SaveChanges();

                                                        var newProduct = new Products
                                                                             {
                                                                                 ProductName = "Blue Widget",
                                                                                 UnitPrice = 34.56M,
                                                                                 Categories = cat

                                                                             };

                                                        rproductrepository.Add(newProduct);
                                                        rproductrepository.Save();

                                                        //Update
                                                        cat.CategoryName = "testupdated";
                                                        rproductrepository.Save();

                                                        newProduct.UnitPrice = 15.8M;
                                                        rproductrepository.Save();

                                                        //Delete
                                                        rproductrepository.Delete(newProduct);
                                                       // rproductrepository.Save();

                                                        customrepository.Delete(cus);
                                                       // customrepository.Save();

                                                       //categoryrepository.Delete(cat);
                                                        customrepository.Save();

                                                    }
                                                });
        }
    }
}