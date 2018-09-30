using EShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EShop.Entities
{
    public class ProductEntity : BaseEntity
    {
        public Guid Id { get; set; }
        public String Code { get; set; }
        public String Unit { get; set; }
        public Guid CategoryId { get; set; }
        public Guid ManufacturerId { get; set; }
        public CategoryEntity CategoryEntity { get; set; }
        public ManufacturerEntity ManufacturerEntity { get; set; }
        public List<DiscountEntity> DiscountEntities { get; set; }
        public List<InventoryEntity> InventoryEntities { get; set; }
        public List<IssueNoteLineEntity> IssueNoteLineEntities { get; set; }
        public List<PackEntity> PackEntities { get; set; }
        public List<ProductPictureEntity> ProductPictureEntities { get; set; }
        public List<ProductValueEntity> ProductValueEntities { get; set; }
        public List<ReceiptNoteLineEntity> ReceiptNoteLineEntities { get; set; }

        public ProductEntity():base() { }

        public ProductEntity(Product Product, params object[] args) :base(Product)
        {
		    foreach(object arg in args)
			{
                if (arg is Category Category)
                    CategoryEntity = new CategoryEntity(Category);				
                if (arg is Manufacturer Manufacturer)
                    ManufacturerEntity = new ManufacturerEntity(Manufacturer);				
                if (arg is ICollection<Discount> Discounts)
                    DiscountEntities = Discounts.Select(model => new DiscountEntity(model)).ToList();				
                if (arg is ICollection<Inventory> Inventories)
                    InventoryEntities = Inventories.Select(model => new InventoryEntity(model, model.WareHouse)).ToList();				
                if (arg is ICollection<IssueNoteLine> IssueNoteLines)
                    IssueNoteLineEntities = IssueNoteLines.Select(model => new IssueNoteLineEntity(model, model.IssueNote)).ToList();				
                if (arg is ICollection<Pack> Packs)
                    PackEntities = Packs.Select(model => new PackEntity(model)).ToList();				
                if (arg is ICollection<ProductPicture> ProductPictures)
                    ProductPictureEntities = ProductPictures.Select(model => new ProductPictureEntity(model)).ToList();				
                if (arg is ICollection<ProductValue> ProductValues)
                    ProductValueEntities = ProductValues.Select(model => new ProductValueEntity(model, model.Attribute, model.Language)).ToList();				
                if (arg is ICollection<ReceiptNoteLine> ReceiptNoteLines)
                    ReceiptNoteLineEntities = ReceiptNoteLines.Select(model => new ReceiptNoteLineEntity(model, model.ReceiptNote)).ToList();				
			}
        }
    }

    public class ProductSearchEntity : FilterEntity
    {
        public Guid? Id { get; set; }
        public String Code { get; set; }
        public String Unit { get; set; }
        public Guid? CategoryId { get; set; }
        public Guid? ManufacturerId { get; set; }
    }
}
