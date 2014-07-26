// ***********************************************************************
// Assembly         : TestMain
// Author           : PeterLiu
// Created          : 07-26-2014
//
// Last Modified By : PeterLiu
// Last Modified On : 07-07-2014
// ***********************************************************************
// <copyright file="ServiceLocatorTestWithConfig.cs" company="Megadotnet">
//     Copyright (c) Megadotnet. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace TestMain
{
    using System.Collections.Generic;
    using System.Configuration;

    using DBPerformanceTest.Core;

    using Microsoft.Practices.ServiceLocation;
    using Microsoft.Practices.Unity;
    using Microsoft.Practices.Unity.Configuration;
    using Microsoft.Practices.Unity.InterceptionExtension;

    /// <summary>
    /// ServiceLocatorConfig
    /// </summary>
    /// <remarks>http://wintersun.cnblogs.com/</remarks>
    public class ServiceLocatorConfig
    {
        #region Constants and Fields

        /// <summary>
        /// IServiceLocator
        /// </summary>
        protected readonly IServiceLocator locator;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ServiceLocatorConfig" /> class.
        /// </summary>
        /// <remarks>http://wintersun.cnblogs.com/</remarks>
        public ServiceLocatorConfig()
        {
            this.locator = this.CreateServiceLocator();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// The generic overload_ get all instances.
        /// </summary>
        /// <returns>List{IPerformanceTest}.</returns>
        /// <remarks>http://wintersun.cnblogs.com/</remarks>
        public List<IPerformanceTest> GenericOverload_GetAllInstances()
        {
            return new List<IPerformanceTest>(this.locator.GetAllInstances<IPerformanceTest>());
        }

        #endregion

        #region Methods

        /// <summary>
        /// Creates the service locator.
        /// </summary>
        /// <returns>IServiceLocator.</returns>
        /// <remarks>http://wintersun.cnblogs.com/</remarks>
        protected IServiceLocator CreateServiceLocator()
        {
            IUnityContainer container = new UnityContainer().AddNewExtension<Interception>();
            var map = new ExeConfigurationFileMap();
            map.ExeConfigFilename = "EntLib.Config";

            Configuration config = ConfigurationManager.OpenMappedExeConfiguration(map, ConfigurationUserLevel.None);
            var section = (UnityConfigurationSection)config.GetSection("unity");

            section.Configure(container, "DefContainer");
            return new UnityServiceLocator(container);
        }

        #endregion
    }
}