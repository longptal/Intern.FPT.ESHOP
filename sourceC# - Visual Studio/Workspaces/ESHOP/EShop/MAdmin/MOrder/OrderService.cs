using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EShop.MAdmin.MEmployee;
using EShop.Models;
using EShop.Entities;

namespace EShop.MAdmin.MOrder
{
    public interface IOrderService : ITransientService
    {
        int Count(EmployeeEntity EmployeeEntity, OrderSearchEntity OrderSearchEntity);
        List<OrderEntity> Get(EmployeeEntity EmployeeEntity, OrderSearchEntity OrderSearchEntity);
        OrderEntity Get(EmployeeEntity EmployeeEntity, Guid OrderId);
        OrderEntity Create(EmployeeEntity EmployeeEntity, OrderEntity OrderEntity);
        OrderEntity Update(EmployeeEntity EmployeeEntity, Guid OrderId, OrderEntity OrderEntity);
        bool Delete(EmployeeEntity EmployeeEntity, Guid OrderId);
    }
    public class OrderService : CommonService, IOrderService
    {
        public OrderService(IUnitOfWork UnitOfWork) : base(UnitOfWork)
        {

        }
        public int Count(EmployeeEntity EmployeeEntity, OrderSearchEntity OrderSearchEntity)
        {
            return UnitOfWork.OrderRepository.Count(OrderSearchEntity);
        }
        public List<OrderEntity> Get(EmployeeEntity EmployeeEntity, OrderSearchEntity OrderSearchEntity)
        {
            List<Order> Orders = UnitOfWork.OrderRepository.List(OrderSearchEntity);
            return Orders.ToList().Select(od => new OrderEntity(od, od.OrderDetails)).ToList();
        }

        public OrderEntity Get(EmployeeEntity EmployeeEntity, Guid OrderId)
        {
            Order Order = UnitOfWork.OrderRepository.Get(OrderId);
            return new OrderEntity(Order, Order.OrderDetails);
        }
        public OrderEntity Create(EmployeeEntity EmployeeEntity, OrderEntity OrderEntity)
        {
            if (OrderEntity == null)
                throw new NotFoundException();
            Order Order = new Order(OrderEntity);
            UnitOfWork.OrderRepository.AddOrUpdate(Order);
            UnitOfWork.Complete();
            return Get(EmployeeEntity, Order.Id);
        }
        public OrderEntity Update(EmployeeEntity EmployeeEntity, Guid OrderId, OrderEntity OrderEntity)
        {
            OrderEntity.Id = OrderId;
            Order Order = new Order(OrderEntity);
            UnitOfWork.OrderRepository.AddOrUpdate(Order);
            UnitOfWork.Complete();
            return Get(EmployeeEntity, Order.Id);
        }
        public bool Delete(EmployeeEntity EmployeeEntity, Guid OrderId)
        {
            UnitOfWork.OrderRepository.Delete(OrderId);
            UnitOfWork.Complete();
            return true;
        }
    }
}
