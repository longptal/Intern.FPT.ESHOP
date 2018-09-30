using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EShop.MAdmin.MEmployee;
using EShop.Models;
using Microsoft.EntityFrameworkCore;
using EShop.Entities;

namespace EShop.MAdmin.MProduct
{
    public interface IProductService : ITransientService
    {
        int Count(EmployeeEntity EmployeeEntity, ProductSearchEntity ProductSearchEntity);
        List<ProductEntity> Get(EmployeeEntity EmployeeEntity, ProductSearchEntity ProductSearchEntity);
        ProductEntity Get(EmployeeEntity EmployeeEntity, Guid ProductId);
        ProductEntity Create(EmployeeEntity EmployeeEntity, ProductEntity ProductEntity);
        ProductEntity Update(EmployeeEntity EmployeeEntity, Guid ProductId, ProductEntity ProductEntity);
        bool Delete(EmployeeEntity EmployeeEntity, Guid ProductId);
    }
    public class ProductService : CommonService, IProductService
    {
        public ProductService(IUnitOfWork UnitOfWork):base(UnitOfWork)
        {

        }
        public int Count(EmployeeEntity EmployeeEntity, ProductSearchEntity ProductSearchEntity)
        {
            return UnitOfWork.ProductRepository.Count(ProductSearchEntity);
        }
        public List<ProductEntity> Get(EmployeeEntity EmployeeEntity, ProductSearchEntity ProductSearchEntity)
        {
            if (ProductSearchEntity == null) ProductSearchEntity = new ProductSearchEntity();

            List<Product> Products = UnitOfWork.ProductRepository.List(ProductSearchEntity);
            return Products.ToList().Select(p => new ProductEntity(p, p.Category, p.Category.ProductAttributes, p.Discounts, p.Packs, p.ProductPictures, p.ProductValues)).ToList();
        }

        public ProductEntity Get(EmployeeEntity EmployeeEntity, Guid ProductId)
        {
            Product Product = UnitOfWork.ProductRepository.Get(ProductId);
            ProductEntity ProductEntity = new ProductEntity(Product, Product.Category, Product.Category.ProductAttributes , Product.Discounts, Product.Packs,
                Product.ProductPictures, Product.ProductValues);
            return ProductEntity;
        }
        public ProductEntity Create(EmployeeEntity EmployeeEntity, ProductEntity ProductEntity)
        {
            if (ProductEntity == null)
                throw new NotFoundException();
            Product Product = new Product(ProductEntity);
            UnitOfWork.ProductRepository.Add(Product);
            UnitOfWork.Complete();
            return Get(EmployeeEntity, Product.Id);
        }
        public ProductEntity Update(EmployeeEntity EmployeeEntity, Guid ProductId, ProductEntity ProductEntity)
        {
            if (ProductEntity == null)
                throw new NotFoundException();
            Product Product = UnitOfWork.ProductRepository.Get(ProductId);
            ProductEntity.Id = ProductId;
            Product = new Product(ProductEntity);
            UnitOfWork.ProductRepository.Update(Product);
            UnitOfWork.Complete();

            return Get(EmployeeEntity, Product.Id);
        }
        public bool Delete(EmployeeEntity EmployeeEntity, Guid ProductId)
        {
            UnitOfWork.ProductRepository.Delete(ProductId);
            UnitOfWork.Complete();
            return true;
        }
        public bool Validate(EmployeeEntity EmployeeEntity, ProductEntity ProductEntity)
        {
            if (string.IsNullOrEmpty(ProductEntity.Code))
                ProductEntity.AddError(nameof(ProductEntity.Code), "Must fill data.");
            if (string.IsNullOrEmpty(ProductEntity.Unit))
                ProductEntity.AddError(nameof(ProductEntity.Unit), "Must fill data.");

            foreach (ProductValueEntity ProductValueEntity in ProductEntity.ProductValueEntities)
            {
                if (string.IsNullOrEmpty(ProductValueEntity.Value))
                {
                    ProductValueEntity.AddError(nameof(ProductValueEntity.Value), "Must fill data.");
                }
            }
            return true;
        }
    }
}
