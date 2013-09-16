using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Reflection;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Utility;

namespace MvcUnityBootstrapperTest.UnityExtensions
{
    public static class UnityHelpers
    {
        private static readonly Type[] EmptyTypes = new Type[0];

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", MessageId = "implementationType", Justification = "Need to match signature Func<Type, IEnumerable<Type>>")]       
        public static IEnumerable<Type> FromAllInterfacesWith_PerRequestLifetimeAttribute(Type implementationType)
        {
            Guard.ArgumentNotNull(implementationType, "implementationType");

            if (implementationType.GetCustomAttributes(typeof(UnityIoCPerRequestLifetimeAttribute), true).Length > 0)
            {
                var implementationTypeAssembly = implementationType.GetTypeInfo().Assembly;
                var typeInfo = implementationType.GetTypeInfo();
                return typeInfo.ImplementedInterfaces;
            }
            else
            {
                return EmptyTypes;
            }
        }

        /// <summary>
        /// Returns no types.
        /// </summary>
        /// <param name="implementationType">The type to register.</param>
        /// <returns>An empty enumeration.</returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", MessageId = "implementationType", Justification = "Need to match signature Func<Type, IEnumerable<Type>>")]
        public static IEnumerable<Type> None(Type implementationType)
        {
            return EmptyTypes;
        }
    }
}
