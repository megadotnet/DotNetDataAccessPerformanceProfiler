// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DataAccessorFactory.cs" company="Megadotnet">
//   DataAccessorFactory
// </copyright>
// <summary>
//   The data accessor factory.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ModelUnitTest
{
    /// <summary>
    /// The data accessor factory.
    /// </summary>
    public class DataAccessorFactory
    {
        #region Public Methods

        /// <summary>
        /// The create.
        /// </summary>
        /// <returns>IDataAccessor object
        /// </returns>
        public static IDataAccessor Create()
        {
            return new EnterpriseLibraryDataAccessor();
        }

        /// <summary>
        /// The create.
        /// </summary>
        /// <param name="instanceName">
        /// The instance name.
        /// </param>
        /// <returns>
        /// </returns>
        public static IDataAccessor Create(string instanceName)
        {
            return new EnterpriseLibraryDataAccessor(instanceName);
        }

        #endregion
    }
}