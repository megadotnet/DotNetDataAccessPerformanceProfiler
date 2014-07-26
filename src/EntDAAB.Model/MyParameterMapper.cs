// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MyParameterMapper.cs" company="Megadotnet">
//   MyParameterMapper
// </copyright>
// <summary>
//   The my parameter mapper.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace EntDAAB.Model
{
    using System.Data.Common;

    using Microsoft.Practices.EnterpriseLibrary.Data;

    /// <summary>
    /// The my parameter mapper.
    /// </summary>
    public class MyParameterMapper : IParameterMapper
    {
        #region Implemented Interfaces

        #region IParameterMapper

        /// <summary>
        /// The assign parameters.
        /// </summary>
        /// <param name="command">
        /// The command.
        /// </param>
        /// <param name="parameterValues">
        /// The parameter values.
        /// </param>
        public void AssignParameters(DbCommand command, object[] parameterValues)
        {
            DbParameter parameter = command.CreateParameter();
            parameter.ParameterName = "@Id";
            parameter.Value = parameterValues[0];
            command.Parameters.Add(parameter);
        }

        #endregion

        #endregion
    }
}