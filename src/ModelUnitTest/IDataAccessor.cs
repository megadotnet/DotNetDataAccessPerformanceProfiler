// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IDataAccessor.cs" company="Megadotnet">
//   IDataAccessor
// </copyright>
// <summary>
//   The interface of  data accessor.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ModelUnitTest
{
    using System.Data;
    using System.Data.Common;

    /// <summary>
    /// The interface of  data accessor.
    /// </summary>
    public interface IDataAccessor
    {
        #region Public Methods

        /// <summary>
        /// The execute data set.
        /// </summary>
        /// <param name="command">
        /// The command.
        /// </param>
        /// <param name="parameters">
        /// The parameters.
        /// </param>
        /// <returns>
        /// </returns>
        DataSet ExecuteDataSet(DbCommand command, params object[] parameters);

        /// <summary>
        /// The execute non query.
        /// </summary>
        /// <param name="sqlstatement">
        /// The sqlstatement.
        /// </param>
        /// <param name="parameters">
        /// The parameters.
        /// </param>
        /// <returns>
        /// The execute non query.
        /// </returns>
        int ExecuteNonQuery(string sqlstatement, params DbParameter[] parameters);

        /// <summary>
        /// The execute non query.
        /// </summary>
        /// <param name="sqlstatement">
        /// The sqlstatement.
        /// </param>
        /// <returns>
        /// The execute non query.
        /// </returns>
        int ExecuteNonQuery(string sqlstatement);

        /// <summary>
        /// The execute non query.
        /// </summary>
        /// <param name="command">
        /// The command.
        /// </param>
        /// <returns>
        /// The execute non query.
        /// </returns>
        int ExecuteNonQuery(DbCommand command);

        /// <summary>
        /// The execute non query.
        /// </summary>
        /// <param name="sprocname">
        /// The sprocname.
        /// </param>
        /// <param name="parameters">
        /// The parameters.
        /// </param>
        /// <returns>
        /// The execute non query.
        /// </returns>
        int ExecuteNonQuery(string sprocname, params object[] parameters);

        /// <summary>
        /// The execute reader.
        /// </summary>
        /// <param name="command">
        /// The command.
        /// </param>
        /// <param name="parameters">
        /// The parameters.
        /// </param>
        /// <returns>
        /// </returns>
        IDataReader ExecuteReader(DbCommand command, params object[] parameters);

        #endregion

        // Add as many more DAAB-like members as you want
    }
}