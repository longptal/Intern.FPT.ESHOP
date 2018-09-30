using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EShop.Entities;

namespace EShop.MAdmin.MOrder
{
    [Route("api/Orders")]
    public class OrderController : CommonController
    {
        private IOrderService OrderService;
        public OrderController(IOrderService OrderService)
        {
            this.OrderService = OrderService;
        }

        [Route("Count"), HttpGet]
        public long Count(OrderSearchEntity SearchOrderEntity)
        {
            return OrderService.Count(EmployeeEntity, SearchOrderEntity);
        }

        [Route(""), HttpGet]
        public List<OrderEntity> Get(OrderSearchEntity SearchOrderEntity)
        {
            return OrderService.Get(EmployeeEntity, SearchOrderEntity);
        }
        [Route("{OrderId}"), HttpGet]
        public OrderEntity Get(Guid OrderId)
        {
            return OrderService.Get(EmployeeEntity, OrderId);
        }
        [Route(""), HttpPost]
        public OrderEntity Create([FromBody]OrderEntity OrderEntity)
        {
            return OrderService.Create(EmployeeEntity, OrderEntity);
        }
        [Route("{OrderId}"), HttpPut]
        public OrderEntity Update(Guid OrderId, [FromBody]OrderEntity OrderEntity)
        {
            return OrderService.Update(EmployeeEntity, OrderId, OrderEntity);
        }
        [Route("{OrderId}"), HttpDelete]
        public bool Delete(Guid OrderId)
        {
            return OrderService.Delete(EmployeeEntity, OrderId);
        }
    }
}