using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Data.Objects;
using Microsoft.Practices.Unity;
using EntityFrameworkTest;

namespace EntityFrameworkTest
{
    public class ObjectFactory
    {
       private static IUnityContainer container;

       static ObjectFactory()
       {
            container = new UnityContainer();
			      container.RegisterType<IUnitOfWork, EFUnitOfWork>();	
			      container.RegisterType<ObjectContext, TestPerformaceDBEntities>(new InjectionConstructor());
            container.RegisterType<IObjectContext, ObjectContextAdapter>();
		            container.RegisterType<IRepository<Categories>,EFRepository<Categories>>();	
            container.RegisterType<IRepository<Customers>,EFRepository<Customers>>();	
            container.RegisterType<IRepository<Products>,EFRepository<Products>>();	
        }
         
        public static T GetInstance<T>()
        {
            return container.Resolve<T>();
        }
        
        public static T GetInstance<T, U>(U u)
        {
           return container.Resolve<T>(new DependencyOverride<U>(u));
        }

        public static T GetInstance<T, U, Y>(U u, Y y)
        {
            return container.Resolve<T>(new DependencyOverride<U>(u), new DependencyOverride<Y>(y));
        }

    }
	
}