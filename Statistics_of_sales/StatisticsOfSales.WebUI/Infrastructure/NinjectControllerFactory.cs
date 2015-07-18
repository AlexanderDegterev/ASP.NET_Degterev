using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;
using Moq;
using Ninject;
using StatisticsOfSales.Domain.Abstract;
using StatisticsOfSales.Domain.Entities;
using StatisticsOfSales.Domain.Concrete;

namespace StatisticsOfSales.WebUI.Infrastructure
{
    // реализация пользовательской фабрики контроллеров,  
    // наследуясь от фабрики используемой по умолчанию 
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        private IKernel ninjectKernel;
        public NinjectControllerFactory()
        {
            // создание контейнера 
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
            // конфигурирование контейнера
            ninjectKernel.Bind<ISaleRepository>().To<EFProductRepository>();
            //Mock<ISaleRepository> mock = new Mock<ISaleRepository>();
            //mock.Setup(m => m.Sales).Returns(new List<Sale> { 
            //    new Sale { Name = "Football", Date = new DateTime(1991, 12, 31), Product = "Product1", Price = 25 }, 
            //    new Sale { Name = "Surf board", Date = new DateTime(2015, 12, 12), Product = "Product2", Price = 179 }, 
            //    new Sale { Name = "Running shoes",Date = new DateTime(2015, 12, 12), Product = "Product3", Price = 95 } 
            //}.AsQueryable());

            //ninjectKernel.Bind<ISaleRepository>().ToConstant(mock.Object);
        }
    }
} 