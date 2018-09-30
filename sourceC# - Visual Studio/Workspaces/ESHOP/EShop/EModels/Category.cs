using EShop.Entities;
using System;
using System.Collections.Generic;

namespace EShop.Models
{
    public partial class Category : Base
    {

        public Category (CategoryEntity CategoryEntity) : base(CategoryEntity)
        {

			if (CategoryEntity.CategoryNameEntities != null)
            {
                this.CategoryNames = new HashSet<CategoryName>();
                foreach (CategoryNameEntity CategoryNameEntity in CategoryEntity.CategoryNameEntities)
                {
					CategoryNameEntity.CategoryId = CategoryEntity.Id;
                    this.CategoryNames.Add(new CategoryName(CategoryNameEntity));
                }
            }

			if (CategoryEntity.InverseParentEntities != null)
            {
                this.InverseParent = new HashSet<Category>();
                foreach (CategoryEntity InverseParentEntity in CategoryEntity.InverseParentEntities)
                {
					InverseParentEntity.ParentId = CategoryEntity.Id;
                    this.InverseParent.Add(new Category(InverseParentEntity));
                }
            }

			if (CategoryEntity.ProductAttributeEntities != null)
            {
                this.ProductAttributes = new HashSet<ProductAttribute>();
                foreach (ProductAttributeEntity ProductAttributeEntity in CategoryEntity.ProductAttributeEntities)
                {
					ProductAttributeEntity.CategoryId = CategoryEntity.Id;
                    this.ProductAttributes.Add(new ProductAttribute(ProductAttributeEntity));
                }
            }

			if (CategoryEntity.ProductEntities != null)
            {
                this.Products = new HashSet<Product>();
                foreach (ProductEntity ProductEntity in CategoryEntity.ProductEntities)
                {
					ProductEntity.CategoryId = CategoryEntity.Id;
                    this.Products.Add(new Product(ProductEntity));
                }
            }

			if (CategoryEntity.TaxEntities != null)
            {
                this.Taxes = new HashSet<Tax>();
                foreach (TaxEntity TaxEntity in CategoryEntity.TaxEntities)
                {
					TaxEntity.CategoryId = CategoryEntity.Id;
                    this.Taxes.Add(new Tax(TaxEntity));
                }
            }
		}

        public override bool Equals(Base other)
        {		
            if (other == null) return false;
            if (other is Category Category)
            {
                return Id.Equals(Category.Id);
            }

            return false;
        }
    }
}
