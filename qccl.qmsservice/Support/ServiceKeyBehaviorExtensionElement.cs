using System;
using System.ServiceModel.Configuration;

namespace qccl.qmsservice
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="System.ServiceModel.Configuration.BehaviorExtensionElement" />
    public class ServiceKeyBehaviorExtensionElement : BehaviorExtensionElement
    {
        /// <summary>
        /// Gets the type of behavior.
        /// </summary>
        public override Type BehaviorType
        {
            get { return typeof(ServiceKeyEndpointBehavior); }
        }

        /// <summary>
        /// Creates a behavior extension based on the current configuration settings.
        /// </summary>
        /// <returns>
        /// The behavior extension.
        /// </returns>
        protected override object CreateBehavior()
        {
            return new ServiceKeyEndpointBehavior();
        }
    }
}