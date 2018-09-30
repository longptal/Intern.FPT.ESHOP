using EShop.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using EShop.Entities;
using static EShop.Entities.DiscountEntity;

namespace EShop.MAdmin.MDiscount
{
    public interface IDiscountRepository
    {
        int Count(DiscountSearchEntity DiscountSearchEntity);
        List<Discount> List(DiscountSearchEntity DiscountSearchEntity);
        Discount Get(Guid Id);
        void AddOrUpdate(Discount Discount);
        void Delete(Guid Id);
    }
    public class DiscountRepository : CommonRepository<Discount>, IDiscountRepository
    {
        public DiscountRepository(EShopContext context) : base(context)
        {

        }

        public int Count(DiscountSearchEntity DiscountSearchEntity)
        {
            if (DiscountSearchEntity == null) DiscountSearchEntity = new DiscountSearchEntity();
            IQueryable<Discount> Discounts = context.Discounts;
            Apply(Discounts, DiscountSearchEntity);
            return Discounts.Count();
        }

        public List<Discount> List(DiscountSearchEntity DiscountSearchEntity)
        {
            if (DiscountSearchEntity == null) DiscountSearchEntity = new DiscountSearchEntity();
            IQueryable<Discount> Discounts = context.Discounts;
            Apply(Discounts, DiscountSearchEntity);
            SkipAndTake(Discounts, DiscountSearchEntity);
            return Discounts.ToList();
        }

        public Discount Get(Guid Id)
        {
            Discount Discount = context.Discounts.Where(c => c.Id == Id ).FirstOrDefault();
            if (Discount == null)
                throw new NotFoundException();
            return Discount;
        }

        public void AddOrUpdate(Discount Discount)
        {
            if (context.Entry(Discount).State == EntityState.Detached)
                context.Set<Discount>().Add(Discount);
        }

        public void Delete(Guid Id)
        {
            Discount Discount = Get(Id);
            context.Discounts.Remove(Discount);
        }

        private IQueryable<Discount> Apply(IQueryable<Discount> Discounts, DiscountSearchEntity DiscountSearchEntity)
        {
            if (DiscountSearchEntity.Id.HasValue)
                Discounts = Discounts.Where(wh => wh.Id == DiscountSearchEntity.Id.Value);
            if (DiscountSearchEntity.Min.HasValue)
                Discounts = Discounts.Where(wh => wh.Min == DiscountSearchEntity.Min.Value);
            if (DiscountSearchEntity.Max.HasValue)
                Discounts = Discounts.Where(wh => wh.Max == DiscountSearchEntity.Max.Value);
            if (DiscountSearchEntity.ProductId.HasValue)
                Discounts = Discounts.Where(wh => wh.ProductId == DiscountSearchEntity.ProductId.Value);
            return Discounts;
        }
    }
}
