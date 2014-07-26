using System;
using NHibernate;
using NHibernate.Expression;
using System.Collections;

namespace NH
{
	public class ObjectLoader 
	{
		private ObjectLoader() 
		{
		}
		public static IList Find(ICriterion crit, Type type) 
		{
			return Find(crit, type, null);
		}
		public static IList Find(ICriterion crit, Type type, PagerInfo pi) 
		{
			ISession s = Sessions.GetSession();
			try 
			{
				ICriteria c = s.CreateCriteria(type); 
				if (crit != null ) c.Add(crit);
				if (pi != null ) 
				{
					c.SetFirstResult(pi.FirstResult);
					c.SetMaxResults(pi.MaxResults);
				}
				return c.List();
			}
			finally 
			{
				s.Close();
			}
		}
		public static IList Find( string query, ICollection paramInfos ) 
		{
			return Find( query, paramInfos, null );
		}
		public static IList Find(string query, ICollection paramInfos, PagerInfo pi) 
		{
			ISession s = Sessions.GetSession();
			try 
			{
				IQuery q = s.CreateQuery( query );
				if ( paramInfos != null ) 
				{
					foreach (ParamInfo info in paramInfos) 
					{
						if (info.Value is ICollection)
							q.SetParameterList(info.Name, (ICollection)info.Value, info.Type);
						else
							q.SetParameter(info.Name, info.Value, info.Type);
					} 
				}
				if (pi != null ) 
				{
					q.SetFirstResult( pi.FirstResult );
					q.SetMaxResults( pi.MaxResults );
				}
				return q.List();
			}
			finally 
			{
				s.Close();
			}
		}

	}

}
