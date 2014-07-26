// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UnityServiceLocator.cs" company="Megadotnet">
//   Unity ServiceLocator
// </copyright>
// <summary>
//   UnityServiceLocator
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace TestMain
{
    using System;
    using System.Collections.Generic;

    using Microsoft.Practices.ServiceLocation;
    using Microsoft.Practices.Unity;

    /// <summary>
    /// UnityServiceLocator
    /// </summary>
    public class UnityServiceLocator : ServiceLocatorImplBase
    {
        #region Constants and Fields

        /// <summary>
        /// The container.
        /// </summary>
        private readonly IUnityContainer container;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="UnityServiceLocator"/> class.
        /// </summary>
        /// <param name="container">
        /// The container.
        /// </param>
        public UnityServiceLocator(IUnityContainer container)
        {
            this.container = container;
        }

        #endregion

        #region Methods

        /// <summary>
        /// When implemented by inheriting classes, this method will do the actual work of
        ///             resolving all the requested service instances.
        /// </summary>
        /// <param name="serviceType">
        /// Type of service requested.
        /// </param>
        /// <returns>
        /// Sequence of service instance objects.
        /// </returns>
        protected override IEnumerable<object> DoGetAllInstances(Type serviceType)
        {
            return this.container.ResolveAll(serviceType);
        }

        /// <summary>
        /// When implemented by inheriting classes, this method will do the actual work of resolving
        ///             the requested service instance.
        /// </summary>
        /// <param name="serviceType">
        /// Type of instance requested.
        /// </param>
        /// <param name="key">
        /// Name of registered service you want. May be null.
        /// </param>
        /// <returns>
        /// The requested service instance.
        /// </returns>
        protected override object DoGetInstance(Type serviceType, string key)
        {
            return this.container.Resolve(serviceType, key);
        }

        #endregion
    }
}