using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.Mvc;
using Ninject;
using Moq;
using Site.Domain.Entities;
using Site.Domain.Abstract;
using Site.Domain.Concrete;
using Site.WebUI.Infrastructure.Abstract;
using Site.WebUI.Infrastructure.Concrete;

namespace Site.WebUI.Infrastructure
{
    public class NinjectControlerFactory : DefaultControllerFactory
    {
        private IKernel ninjectKernel;
        public NinjectControlerFactory()
        {
            ninjectKernel = new StandardKernel();
            AddBindings();
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return controllerType == null ? null : (IController)ninjectKernel.Get(controllerType);
        }

        private void AddBindings()
        {
            ninjectKernel.Bind<IRemessaRepository>().To<EFRemessaRepository>();
            ninjectKernel.Bind<IMotoristaRepository>().To<EFMotoristaRepository>();
            ninjectKernel.Bind<IMotivoRepository>().To<EFMotivoRepository>();
            ninjectKernel.Bind<IParentescoRepository>().To<EFParentescoRepository>();
            ninjectKernel.Bind<ITransportadoraRepository>().To<EFTransportadoraRepository>();
            ninjectKernel.Bind<IAuthProvider>().To<FormsAuthProvider>();
        }
    }
}