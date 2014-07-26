using System;
using NHibernate;
using NH;

namespace NH
{
	public class ObjectBroker 
	{
		private ObjectBroker() { }

		public static void Load( object obj, object id )
		{
			ISession s = Sessions.GetSession(); 
			try 
			{
				s.Load( obj, id );
			}
			finally 
			{
				s.Close();
			}
		}

		public static void Create( object obj ) 
		{
			ISession s = Sessions.GetSession();
			ITransaction trans = null;
			try 
			{
				trans = s.BeginTransaction();
				s.Save( obj );
				trans.Commit();
			}
			finally 
			{
				s.Close();
			} 
		}

		public static void Update( object obj ) 
		{
			ISession s = Sessions.GetSession();
			ITransaction trans = null; 
			try 
			{
				trans = s.BeginTransaction();
				s.Update( obj );
				trans.Commit();
			}
			finally 
			{
				s.Close();
			}
		}

		public static void Delete( object obj ) 
		{
			ISession s = Sessions.GetSession();
			ITransaction trans = null; 
			try 
			{
				trans = s.BeginTransaction();
				s.Delete( obj );
				trans.Commit();
			}
			finally 
			{
				s.Close();
			}
		}
	}

}
