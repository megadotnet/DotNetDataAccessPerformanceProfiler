using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace EntityFrameworkTest
{
	public class EFRepository<T> : IRepository<T> where T : class
	{
		public IUnitOfWork UnitOfWork { get; set; }
		private IObjectSet<T> _objectset;
		private IObjectSet<T> ObjectSet
		{
            get
			{
				return _objectset;
			}

		}
		
		public EFRepository(IObjectContext objectContext)
    {
      _objectset = objectContext.CreateObjectSet<T>();
    }

		public virtual IEnumerable<T> All()
		{
			return ObjectSet.AsQueryable();
		}

		public IEnumerable<T> Find(Expression<Func<T, bool>> expression)
		{
			return ObjectSet.Where(expression);
		}

		public void Add(T entity)
		{
			ObjectSet.AddObject(entity);
		}
		
		public void Attach(T entity)
		{
			ObjectSet.Attach(entity);
		}

		public void Delete(T entity)
		{
			ObjectSet.DeleteObject(entity);
		}

		public void Save()
		{
			UnitOfWork.Save();
		}
		
		public T Single(Expression<Func<T, bool>> where)
    {
      return ObjectSet.Single(where);
    }
	}
}