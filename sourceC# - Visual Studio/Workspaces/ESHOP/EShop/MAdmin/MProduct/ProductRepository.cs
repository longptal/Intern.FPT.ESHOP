using EShop.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using EShop.Entities;

namespace EShop.MAdmin.MProduct
{
    public interface IProductRepository
    {
        int Count(ProductSearchEntity ProductSearchEntity);
        List<Product> List(ProductSearchEntity ProductSearchEntity);
        Product Get(Guid Id);
        bool Add(Product Product);
        bool Update(Product Product);
        bool Delete(Guid Id);
    }
    public class ProductRepository : CommonRepository<Product>, IProductRepository
    {
        public ProductRepository(EShopContext context) : base(context)
        {

        }

        public int Count(ProductSearchEntity ProductSearchEntity)
        {
            if (ProductSearchEntity == null) ProductSearchEntity = new ProductSearchEntity();
            IQueryable<Product> Products = context.Products;
            Apply(Products, ProductSearchEntity);
            return Products.Count();
        }

        public List<Product> List(ProductSearchEntity ProductSearchEntity)
        {
            if (ProductSearchEntity == null) ProductSearchEntity = new ProductSearchEntity();
            IQueryable<Product> Products = context.Products
                .Include(p => p.Category).ThenInclude(c => c.ProductAttributes)
                .Include(p => p.Discounts)
                .Include(p => p.Packs)
                .Include(p => p.ProductPictures)
                .Include(p => p.ProductValues); ;
            Apply(Products, ProductSearchEntity);
            SkipAndTake(Products, ProductSearchEntity);
            return Products.ToList();
        }

        public Product Get(Guid Id)
        {
            Product Product = context.Products.Where(c => c.Id == Id ).FirstOrDefault();
            if (Product == null)
                throw new NotFoundException();
            return Product;
        }

        public bool Add(Product Product)
        {
            context.Products.Add(Product);
            foreach(ProductValue ProductValue in Product.ProductValues)
                context.ProductValues.Add(ProductValue);
            foreach (Pack Pack in Product.Packs)
                context.Packs.Add(Pack);
            foreach (Discount Discount in Product.Discounts)
                context.Discounts.Add(Discount);
            foreach (ProductPicture ProductPicture in Product.ProductPictures)
                context.ProductPictures.Add(ProductPicture);
            context.SaveChanges();
            return true;
        }

        public bool Update(Product Product)
        {
            Product Current = Get(Product.Id);
            if (Current == null) return false;
            Common<Product>.Copy(Product, Current);

            List<Discount> Discounts = context.Discounts.Where(cn => cn.ProductId == Product.Id).ToList();
            List<Discount> InsertDiscounts, UpdateDiscounts, DeleteDiscounts;
            Common<Discount>.Split(Product.Discounts, Discounts, out InsertDiscounts, out UpdateDiscounts, out DeleteDiscounts);
            foreach (Discount Discount in InsertDiscounts)
            {
                Discount.Id = Guid.NewGuid();
                Discount.ProductId = Product.Id;
                context.Discounts.Add(Discount);
            }
            foreach (Discount Discount in UpdateDiscounts)
            {
                Discount CN = Discounts.Where(cn => cn.Id == Discount.Id).FirstOrDefault();
                Common<Discount>.Copy(Discount, CN);
            }
            foreach (Discount Discount in DeleteDiscounts)
                context.Discounts.Remove(Discount);
            return true;
        }


        public bool Delete(Guid Id)
        {
            Product Product = Get(Id);
            if (Product == null) return false;
            context.Products.Remove(Product);
            return true;
        }

        private IQueryable<Product> Apply(IQueryable<Product> Products, ProductSearchEntity ProductSearchEntity)
        {
            if (ProductSearchEntity.Id.HasValue)
                Products = Products.Where(wh => wh.Id == ProductSearchEntity.Id.Value);
            if (ProductSearchEntity.CategoryId.HasValue)
                Products = Products.Where(wh => wh.CategoryId == ProductSearchEntity.CategoryId.Value);
            if (ProductSearchEntity.ManufacturerId.HasValue)
                Products = Products.Where(wh => wh.ManufacturerId == ProductSearchEntity.ManufacturerId.Value);
            if (!string.IsNullOrEmpty(ProductSearchEntity.Code))
                Products = Products.Where(wh => wh.Code.ToLower().Contains(ProductSearchEntity.Code.ToLower()));
            if (!string.IsNullOrEmpty(ProductSearchEntity.Unit))
                Products = Products.Where(wh => wh.Unit.ToLower().Contains(ProductSearchEntity.Unit.ToLower()));
            return Products;
        }
    }
}
