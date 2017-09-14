using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using CoolBlue.PointofSale.Core.Model;
using CoolBlue.PointofSale.Infrastructure;
using CoolBlue.PointofSale.Core.Interfaces;
using Microsoft.Practices.Unity;

namespace CoolBlue.PointofSale.Controllers
{
    public class OrdersController : ApiController
    {
       
        private IOrderRepository _orderRepository;

        public OrdersController()
        {

        }

        IUnityContainer _container;

        public OrdersController(IUnityContainer Container)
        {
            this._container = Container;
            _orderRepository = this._container.Resolve<IOrderRepository>();

        }


        
      
       
    }
}