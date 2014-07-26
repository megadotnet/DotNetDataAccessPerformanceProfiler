using System;

namespace EntityFrameworkTest
{
    public class EFUnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly IObjectContext _objectContext;

        public EFUnitOfWork(IObjectContext objectContext)
        {
            _objectContext = objectContext;
        }

        #region IUnitOfWork Members

        public void Save()
        {
            _objectContext.SaveChanges();
        }

        #endregion

        public void Dispose()
        {
            if (_objectContext != null)
            {
                _objectContext.Dispose();
            }
            GC.SuppressFinalize(this);
        }
    }
}
