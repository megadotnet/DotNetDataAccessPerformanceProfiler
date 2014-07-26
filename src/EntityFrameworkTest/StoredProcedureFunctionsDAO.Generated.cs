using System;
using System.Data.Objects;

namespace EntityFrameworkTest.Repositories
{
    public partial class StoredProcedureFunctionsDAO : IStoredProcedureFunctionsDAO
    {
	    private readonly ObjectContext dbObjectcontext;
	   
        public StoredProcedureFunctionsDAO(ObjectContext _dbObjectcontext)
        {
            dbObjectcontext = _dbObjectcontext;
        }


         }
}
