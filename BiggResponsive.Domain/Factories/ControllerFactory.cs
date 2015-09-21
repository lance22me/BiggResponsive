using System;
using System.Web.Mvc;
using System.Web.Routing;
using Ninject;

namespace BiggResponsive.Domain.Factories
{
    public class ControllerFactory : DefaultControllerFactory
    {
        /// <summary>
        /// Gets the kernel that will be used to create controllers.
        /// </summary>
        public IKernel Kernel { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="NinjectControllerFactory"/> class.
        /// </summary>
        /// <param name="kernel">The kernel that should be used to create controllers.</param>
        public ControllerFactory(IKernel kernel)
        {
            Kernel = kernel;
        }

         protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return (controllerType == null) ? null : (IController)Kernel.Get(controllerType);
        }
    }
}
