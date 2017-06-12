// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StoredProcedureFunctionsDAO.cs" company="Megdotnet">
//   Copyright (c) 2010-2011 Petter Liu.  All rights reserved. 
// </copyright>
// <summary>
//   The stored procedure functions dao.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace IronFramework.Model.Repositories
{
    using System;
    using System.Data.Entity.Core.Objects;

    /// <summary>
    /// The stored procedure functions dao.
    /// </summary>
    public partial class StoredProcedureFunctionsDAO : IStoredProcedureFunctionsDAO
    {
	    private readonly IObjectContext  dbObjectcontext;
	   
        public StoredProcedureFunctionsDAO(IObjectContext  _dbObjectcontext)
        {
            dbObjectcontext = _dbObjectcontext;
        }


         }
}
