using System;
using System.Data.Objects;
namespace EntityFrameworkTest
{
	public interface IUnitOfWork
	{
		void Save();
	}
	
	public interface IObjectContext : IDisposable
    {
        IObjectSet<T> CreateObjectSet<T>() where T : class;
        void SaveChanges();
    }

    public class ObjectContextAdapter : IObjectContext
    {
        private readonly ObjectContext _context;

        public ObjectContextAdapter(ObjectContext context)
        {
            _context = context;
        }

        #region IObjectContext Members

        public void Dispose()
        {
            _context.Dispose();
        }

        public IObjectSet<T> CreateObjectSet<T>() where T : class
        {
            return _context.CreateObjectSet<T>();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        #endregion
    }
}