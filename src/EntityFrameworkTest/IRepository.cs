
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace EntityFrameworkTest
{ 
	public interface IRepository<T> 
    {
		IUnitOfWork UnitOfWork { get; set; }
		IEnumerable<T> All();
	    IEnumerable<T> Find(Expression<Func<T, bool>> expression);
		void Attach(T entity);
		void Add(T entity);
		void Delete(T entity);
		void Save();
		T Single(Expression<Func<T, bool>> where);
    }
}

