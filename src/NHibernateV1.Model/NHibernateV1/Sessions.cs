using NHibernate;
using NHibernate.Cfg;

namespace NH
{
    public class Sessions
    {
        private static readonly object lockObj = new object();
        private static ISessionFactory _factory;

        public static ISessionFactory Factory
        {
            get
            {
                if (_factory == null)
                {
                    lock (lockObj)
                    {
                        if (_factory == null)
                        {
                            var cfg = new Configuration();
                            cfg.AddXmlFile("Category.hbm.xml");
                            cfg.AddXmlFile("Customer.hbm.xml");
                            cfg.AddXmlFile("Product.hbm.xml");
                            _factory = cfg.BuildSessionFactory();
                        }
                    }
                }
                return _factory;
            }
        }
        public static ISession GetSession()
        {
            return Factory.OpenSession();
        }

    }
}
