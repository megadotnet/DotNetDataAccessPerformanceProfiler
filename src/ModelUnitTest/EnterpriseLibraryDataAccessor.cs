// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EnterpriseLibraryDataAccessor.cs" company="Megadotnet">
//   EnterpriseLibraryDataAccessor
// </copyright>
// <summary>
//   The enterprise library data accessor.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ModelUnitTest
{
    using System;
    using System.Data;
    using System.Data.Common;

    using Microsoft.Practices.EnterpriseLibrary.Data;

    /// <summary>
    /// The enterprise library data accessor.
    /// </summary>
    public class EnterpriseLibraryDataAccessor : IDataAccessor
    {
        #region Constants and Fields

        /// <summary>
        /// The database.
        /// </summary>
        private readonly Database database;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="EnterpriseLibraryDataAccessor"/> class.
        /// </summary>
        public EnterpriseLibraryDataAccessor()
        {
            this.database = DatabaseFactory.CreateDatabase();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EnterpriseLibraryDataAccessor"/> class.
        /// </summary>
        /// <param name="dataname">
        /// The dataname.
        /// </param>
        public EnterpriseLibraryDataAccessor(string dataname)
        {
            this.database = DatabaseFactory.CreateDatabase(dataname);
        }

        #endregion

        #region Implemented Interfaces

        #region IDataAccessor

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
        /// <exception cref="NotImplementedException">
        /// </exception>
        public DataSet ExecuteDataSet(DbCommand command, params object[] parameters)
        {
            throw new NotImplementedException();
        }

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
        public int ExecuteNonQuery(string sqlstatement, params DbParameter[] parameters)
        {
            DbCommand sqlcmd = this.database.GetSqlStringCommand(sqlstatement);
            foreach (DbParameter para in parameters)
            {
                if (para.Direction == ParameterDirection.Input)
                {
                    this.database.AddInParameter(sqlcmd, para.ParameterName, para.DbType, para.Value);
                }
                else
                {
                    this.database.AddOutParameter(sqlcmd, para.ParameterName, para.DbType, para.Size);
                }
            }

            return this.database.ExecuteNonQuery(sqlcmd);
        }

        /// <summary>
        /// The execute non query.
        /// </summary>
        /// <param name="sqlstatement">
        /// The sqlstatement.
        /// </param>
        /// <returns>
        /// The execute non query.
        /// </returns>
        public int ExecuteNonQuery(string sqlstatement)
        {
            return this.database.ExecuteNonQuery(this.database.GetSqlStringCommand(sqlstatement));
        }

        /// <summary>
        /// The execute non query.
        /// </summary>
        /// <param name="command">
        /// The command.
        /// </param>
        /// <returns>
        /// The execute non query.
        /// </returns>
        public int ExecuteNonQuery(DbCommand command)
        {
            return this.database.ExecuteNonQuery(command);
        }

        /// <summary>
        /// The execute non query.
        /// </summary>
        /// <param name="spocname">
        /// The spocname.
        /// </param>
        /// <param name="parameters">
        /// The parameters.
        /// </param>
        /// <returns>
        /// The execute non query.
        /// </returns>
        public int ExecuteNonQuery(string spocname, params object[] parameters)
        {
            return this.database.ExecuteNonQuery(spocname, parameters);
        }

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
        public IDataReader ExecuteReader(DbCommand command, params object[] parameters)
        {
            return this.database.ExecuteReader(command);
        }

        #endregion

        #endregion
    }
}