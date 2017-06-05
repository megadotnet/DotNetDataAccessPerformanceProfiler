using CtripDAL.Model.Interface.IDao;
using CtripDAL.Model.Dao;

namespace CtripDAL.Model
{
	/// <summary>
    /// DALFactory
    /// </summary>
	public partial class DALFactory
	{
        private static readonly IProductsGenDao productsGenDao = new ProductsGenDao();

        private static readonly ICategoriesGenDao categoriesGenDao = new CategoriesGenDao();

        private static readonly ICustomersGenDao customersGenDao = new CustomersGenDao();


        /// <summary>
        /// Property ProductsGenDao
        /// </summary>
        public static IProductsGenDao ProductsGenDao
        {
            get
            {
                return productsGenDao;
            }
        }

        /// <summary>
        /// Property CategoriesGenDao
        /// </summary>
        public static ICategoriesGenDao CategoriesGenDao
        {
            get
            {
                return categoriesGenDao;
            }
        }

        /// <summary>
        /// Property CustomersGenDao
        /// </summary>
        public static ICustomersGenDao CustomersGenDao
        {
            get
            {
                return customersGenDao;
            }
        }

	}
}