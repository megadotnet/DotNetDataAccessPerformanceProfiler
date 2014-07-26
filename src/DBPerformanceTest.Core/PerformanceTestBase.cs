// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PerformanceTestBase.cs" company="Megadotnet">
//   PerformanceTestBase
// </copyright>
// <summary>
//   The performance test base.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DBPerformanceTest.Core
{
    /// <summary>
    /// The performance test base.
    /// </summary>
    public abstract class PerformanceTestBase : IPerformanceTest
    {
        #region Public Methods

        /// <summary>
        /// The add category.
        /// </summary>
        public abstract void AddCategory();

        /// <summary>
        /// The add customer.
        /// </summary>
        public abstract void AddCustomer();

        /// <summary>
        /// The add product.
        /// </summary>
        public abstract void AddProduct();

        /// <summary>
        /// The delete category.
        /// </summary>
        public abstract void DeleteCategory();

        /// <summary>
        /// The delete customer.
        /// </summary>
        public abstract void DeleteCustomer();

        /// <summary>
        /// The delete product.
        /// </summary>
        public abstract void DeleteProduct();

        /// <summary>
        /// The get all category.
        /// </summary>
        public abstract void GetAllCategory();

        /// <summary>
        /// The get all customer.
        /// </summary>
        public abstract void GetAllCustomer();

        /// <summary>
        /// The get all product.
        /// </summary>
        public abstract void GetAllProduct();

        /// <summary>
        /// The get sinlge category.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        public abstract void GetSinlgeCategory(int id);

        /// <summary>
        /// The get sinlge customer.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        public abstract void GetSinlgeCustomer(int id);

        /// <summary>
        /// The get sinlge product.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        public abstract void GetSinlgeProduct(int id);

        /// <summary>
        /// The update category.
        /// </summary>
        public abstract void UpdateCategory();

        /// <summary>
        /// The update customer.
        /// </summary>
        public abstract void UpdateCustomer();

        /// <summary>
        /// The update product.
        /// </summary>
        public abstract void UpdateProduct();

        #endregion

        #region Implemented Interfaces

        #region IPerformanceTest

        /// <summary>
        /// The fetch all test.
        /// </summary>
        /// <param name="repeatTime">
        /// The repeat time.
        /// </param>
        /// <returns>
        /// The fetch all test.
        /// </returns>
        public long FetchAllTest(int repeatTime)
        {
            return Utility.PerformanceWatch(
                () =>
                    {
                        for (int i = 0; i < repeatTime; i++)
                        {
                            this.GetAllCategory();
                            this.GetAllCustomer();
                            this.GetAllProduct();
                        }
                    });
        }

        /// <summary>
        /// The fetch single test.
        /// </summary>
        /// <param name="repeatTime">
        /// The repeat time.
        /// </param>
        /// <returns>
        /// The fetch single test.
        /// </returns>
        public long FetchSingleTest(int repeatTime)
        {
            return Utility.PerformanceWatch(
                () =>
                    {
                        for (int i = 0; i < repeatTime; i++)
                        {
                            this.GetSinlgeCategory(10);
                            this.GetSinlgeCustomer(10);
                            this.GetSinlgeProduct(10);
                        }
                    });
        }

        /// <summary>
        /// The write test.
        /// </summary>
        /// <param name="repeatTime">
        /// The repeat time.
        /// </param>
        /// <returns>
        /// The write test.
        /// </returns>
        public long WriteTest(int repeatTime)
        {
            return Utility.PerformanceWatch(
                () =>
                    {
                        for (int i = 0; i < repeatTime; i++)
                        {
                            this.AddCategory();
                            this.UpdateCategory();

                            this.AddCustomer();
                            this.UpdateCustomer();

                            this.AddProduct();
                            this.UpdateProduct();

                            this.DeleteProduct();
                            this.DeleteCustomer();
                            this.DeleteCategory();
                        }
                    });
        }

        #endregion

        #endregion
    }
}