using System;
using Ninject;
using Ninject.Web.WebApi;


namespace BiggResponsive.App_Start
{
    public class NinjectMvcDependencyResolver : NinjectDependencyScope, System.Web.Mvc.IDependencyResolver
    {
        private readonly IKernel kernel;

        public NinjectMvcDependencyResolver(IKernel kernel) : base(kernel)
        {
            this.kernel = kernel;
        }
    }
}