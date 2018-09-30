using EShop.Entities;
using System;
using System.Collections.Generic;

namespace EShop.Models
{
    public partial class Language : Base
    {

        public Language (LanguageEntity LanguageEntity) : base(LanguageEntity)
        {

			if (LanguageEntity.CategoryNameEntities != null)
            {
                this.CategoryNames = new HashSet<CategoryName>();
                foreach (CategoryNameEntity CategoryNameEntity in LanguageEntity.CategoryNameEntities)
                {
					CategoryNameEntity.LanguageId = LanguageEntity.Id;
                    this.CategoryNames.Add(new CategoryName(CategoryNameEntity));
                }
            }

			if (LanguageEntity.ProductAttributeNameEntities != null)
            {
                this.ProductAttributeNames = new HashSet<ProductAttributeName>();
                foreach (ProductAttributeNameEntity ProductAttributeNameEntity in LanguageEntity.ProductAttributeNameEntities)
                {
					ProductAttributeNameEntity.LanguageId = LanguageEntity.Id;
                    this.ProductAttributeNames.Add(new ProductAttributeName(ProductAttributeNameEntity));
                }
            }

			if (LanguageEntity.ProductValueEntities != null)
            {
                this.ProductValues = new HashSet<ProductValue>();
                foreach (ProductValueEntity ProductValueEntity in LanguageEntity.ProductValueEntities)
                {
					ProductValueEntity.LanguageId = LanguageEntity.Id;
                    this.ProductValues.Add(new ProductValue(ProductValueEntity));
                }
            }
		}

        public override bool Equals(Base other)
        {		
            if (other == null) return false;
            if (other is Language Language)
            {
                return Id.Equals(Language.Id);
            }

            return false;
        }
    }
}
