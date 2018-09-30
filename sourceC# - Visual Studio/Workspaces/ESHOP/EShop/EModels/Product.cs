using EShop.Entities;
using System;
using System.Collections.Generic;

namespace EShop.Models
{
    public partial class Product : Base
    {

        public Product (ProductEntity ProductEntity) : base(ProductEntity)
        {

			if (ProductEntity.DiscountEntities != null)
            {
                this.Discounts = new HashSet<Discount>();
                foreach (DiscountEntity DiscountEntity in ProductEntity.DiscountEntities)
                {
					DiscountEntity.ProductId = ProductEntity.Id;
                    this.Discounts.Add(new Discount(DiscountEntity));
                }
            }

			if (ProductEntity.InventoryEntities != null)
            {
                this.Inventories = new HashSet<Inventory>();
                foreach (InventoryEntity InventoryEntity in ProductEntity.InventoryEntities)
                {
					InventoryEntity.ProductId = ProductEntity.Id;
                    this.Inventories.Add(new Inventory(InventoryEntity));
                }
            }

			if (ProductEntity.IssueNoteLineEntities != null)
            {
                this.IssueNoteLines = new HashSet<IssueNoteLine>();
                foreach (IssueNoteLineEntity IssueNoteLineEntity in ProductEntity.IssueNoteLineEntities)
                {
					IssueNoteLineEntity.ProductId = ProductEntity.Id;
                    this.IssueNoteLines.Add(new IssueNoteLine(IssueNoteLineEntity));
                }
            }

			if (ProductEntity.PackEntities != null)
            {
                this.Packs = new HashSet<Pack>();
                foreach (PackEntity PackEntity in ProductEntity.PackEntities)
                {
					PackEntity.ProductId = ProductEntity.Id;
                    this.Packs.Add(new Pack(PackEntity));
                }
            }

			if (ProductEntity.ProductPictureEntities != null)
            {
                this.ProductPictures = new HashSet<ProductPicture>();
                foreach (ProductPictureEntity ProductPictureEntity in ProductEntity.ProductPictureEntities)
                {
					ProductPictureEntity.ProductId = ProductEntity.Id;
                    this.ProductPictures.Add(new ProductPicture(ProductPictureEntity));
                }
            }

			if (ProductEntity.ProductValueEntities != null)
            {
                this.ProductValues = new HashSet<ProductValue>();
                foreach (ProductValueEntity ProductValueEntity in ProductEntity.ProductValueEntities)
                {
					ProductValueEntity.ProductId = ProductEntity.Id;
                    this.ProductValues.Add(new ProductValue(ProductValueEntity));
                }
            }

			if (ProductEntity.ReceiptNoteLineEntities != null)
            {
                this.ReceiptNoteLines = new HashSet<ReceiptNoteLine>();
                foreach (ReceiptNoteLineEntity ReceiptNoteLineEntity in ProductEntity.ReceiptNoteLineEntities)
                {
					ReceiptNoteLineEntity.ProductId = ProductEntity.Id;
                    this.ReceiptNoteLines.Add(new ReceiptNoteLine(ReceiptNoteLineEntity));
                }
            }
		}

        public override bool Equals(Base other)
        {		
            if (other == null) return false;
            if (other is Product Product)
            {
                return Id.Equals(Product.Id);
            }

            return false;
        }
    }
}
