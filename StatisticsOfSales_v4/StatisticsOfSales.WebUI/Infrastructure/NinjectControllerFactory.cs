using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Ninject;
using StatisticsOfSales.Domain.Entities;
using StatisticsOfSales.Domain.Abstract;
using StatisticsOfSales.Domain.Concrete;

namespace StatisticsOfSales.WebUI.Infrastructure
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        private IKernel ninjectKernel;

        public NinjectControllerFactory()
        {
            // create contaener 
            ninjectKernel = new StandardKernel();
            AddBindings();
        }

        protected override IController GetControllerInstance(RequestContext requestContext,
            Type controllerType)
        {
            // получение объекта контроллера из контейнера  
            // используя его тип 
            return controllerType == null
                ? null
                : (IController)ninjectKernel.Get(controllerType);
        }

        private void AddBindings()
        {
            ninjectKernel.Bind<ISalesRepository>().To<EFSaleRepository>();
        }
    }

}