using EShop.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using EShop.Entities;

namespace EShop.MAdmin.MOrder
{
    public interface IOrderRepository
    {
        int Count(OrderSearchEntity OrderSearchEntity);
        List<Order> List(OrderSearchEntity OrderSearchEntity);
        Order Get(Guid Id);
        void AddOrUpdate(Order Order);
        void Delete(Guid Id);
    }
    public class OrderRepository : CommonRepository<Order>, IOrderRepository
    {
        public OrderRepository(EShopContext context) : base(context)
        {

        }

        public int Count(OrderSearchEntity OrderSearchEntity)
        {
            if (OrderSearchEntity == null) OrderSearchEntity = new OrderSearchEntity();
            IQueryable<Order> Orders = context.Orders;
            Apply(Orders, OrderSearchEntity);
            return Orders.Count();
        }

        public List<Order> List(OrderSearchEntity OrderSearchEntity)
        {
            if (OrderSearchEntity == null) OrderSearchEntity = new OrderSearchEntity();
            IQueryable<Order> Orders = context.Orders
                .Include(o => o.OrderDetails);
            Apply(Orders, OrderSearchEntity);
            SkipAndTake(Orders, OrderSearchEntity);
            return Orders.ToList();
        }

        public Order Get(Guid Id)
        {
            Order Order = context.Orders.Where(c => c.Id == Id )
                .Include(o => o.OrderDetails)
                .FirstOrDefault();
            if (Order == null)
                throw new NotFoundException();
            return Order;
        }

        public void AddOrUpdate(Order Order)
        {
            if (context.Entry(Order).State == EntityState.Detached)
                context.Set<Order>().Add(Order);
        }

        public void Delete(Guid Id)
        {
            Order Order = Get(Id);
            context.Orders.Remove(Order);
        }

        private IQueryable<Order> Apply(IQueryable<Order> Orders, OrderSearchEntity OrderSearchEntity)
        {
            if (OrderSearchEntity.Id.HasValue)
                Orders = Orders.Where(wh => wh.Id == OrderSearchEntity.Id.Value);
            if (OrderSearchEntity.CustomerId.HasValue)
                Orders = Orders.Where(wh => wh.CustomerId == OrderSearchEntity.CustomerId.Value);
            if (OrderSearchEntity.Status.HasValue)
                Orders = Orders.Where(wh => wh.Status == OrderSearchEntity.Status.Value);
            if (OrderSearchEntity.Total.HasValue)
                Orders = Orders.Where(wh => wh.Total == OrderSearchEntity.Total.Value);
            if (OrderSearchEntity.OnPaid.HasValue)
                Orders = Orders.Where(wh => wh.OnPaid == OrderSearchEntity.OnPaid.Value);
            if (OrderSearchEntity.ShipmentDetailId.HasValue)
                Orders = Orders.Where(wh => wh.ShipmentDetailId == OrderSearchEntity.ShipmentDetailId.Value);
            if (!string.IsNullOrEmpty(OrderSearchEntity.Code))
                Orders = Orders.Where(wh => wh.Code.ToLower().Contains(OrderSearchEntity.Code.ToLower()));
            if (!string.IsNullOrEmpty(OrderSearchEntity.Method))
                Orders = Orders.Where(wh => wh.Method.ToLower().Contains(OrderSearchEntity.Method.ToLower()));

            return Orders;
        }
    }
}
