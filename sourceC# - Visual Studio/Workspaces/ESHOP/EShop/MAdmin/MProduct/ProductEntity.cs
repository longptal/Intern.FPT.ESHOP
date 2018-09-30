using EShop.MAdmin.MCategory;
using EShop.MAdmin.MManufacturer;
using EShop.MAdmin.MDiscount;
using EShop.MAdmin.MPack;
using EShop.MAdmin.MTax;
using EShop.MAdmin.MInventory;
//using EShop.MAdmin.MIssueNoteLine;
//using EShop.MAdmin.MReceiptNoteLine;
using EShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EShop.Entities;

namespace EShop.MAdmin.MProduct
{
    public class ProductEntity : CommonEntity
    {
        internal readonly IEnumerable<ProductAttributeEntity> ProductAttributeEntities;

        public Guid Id { get; set; }
        public string Code { get; set; }
        public Guid CategoryId { get; set; }
        public bool IsDeleted { get; set; }
        public string Unit { get; set; }
        public Guid ManufacturerId { get; set; }
        public CategoryEntity CategoryEntity { get; set; }
        public ManufacturerEntity ManufacturerEntity { get; set; }
        public List<PackEntity> PackEntities { get; set; }
        public List<DiscountEntity> DiscountEntities { get; set; }
        public List<ProductPictureEntity> ProductPictures { get; set; }
        public List<InventoryEntity> InventoryEntities { get; set; }
        //public List<IssueNoteLineEntity> IssueNoteLineEntities { get; set; }
        public List<ProductValueEntity> ProductValueEntities { get; set; }
        public IEnumerable<ProductPictureEntity> ProductPictureEntities { get; internal set; }
        public IEnumerable<ProductAttributeEntity> ExtraEntities { get; internal set; }
        public IEnumerable<ProductAttributeNameEntity> ProductAttributeNameEntities { get; internal set; }

        //public List<ReceiptNoteLineEntity> ReceiptNoteLineEntities { get; set; }

        public ProductEntity():base() { }
        public ProductEntity(Product Product, params object[] args):base(Product)
        {
            foreach (var arg in args)
            {
                if (arg is Category)
                    this.CategoryEntity = new CategoryEntity(arg as Category);
                if (arg is ICollection<Pack>)
                    this.PackEntities =(arg as ICollection<Pack>).Select(p => new PackEntity(p)).ToList();
                if (arg is ICollection<Discount>)
                    this.DiscountEntities = (arg as ICollection<Discount>).Select(p => new DiscountEntity(p)).ToList();
                if (arg is ICollection<ProductPicture>)
                    this.ProductPictures = (arg as ICollection<ProductPicture>).Select(p => new ProductPictureEntity(p)).ToList();
            }
        }
    }

    public class ProductPictureEntity : CommonEntity
    {
        public Guid Id { get; set; }
        public string Path { get; set; }
        public Guid ProductId { get; set; }
        public bool IsDefault { get; set; }
        public ProductPictureEntity() : base() { }
        public ProductPictureEntity(ProductPicture ProductPicture, params object[] args) : base(ProductPicture)
        {
        }
    }

    public class ProductAttributeEntity : CommonEntity
    {
        public Guid Id { get; set; }
        public Guid CategoryId { get; set; }
        public CategoryEntity CategoryEntity { get; set; }
        public string Code { get; set; }
        public Dictionary<Guid, string> Names { get; set; }

        public ProductAttributeEntity() : base() { }
        public ProductAttributeEntity(ProductAttribute ProductAttribute, params object[] args) : base(ProductAttribute)
        {
            this.Id = ProductAttribute.Id;
            this.Code = ProductAttribute.Code;
            this.CategoryId = ProductAttribute.CategoryId;
            this.CategoryEntity = ProductAttribute.Category == null ? null : new CategoryEntity(ProductAttribute.Category);
            if (ProductAttribute.ProductAttributeNames != null)
            {
                this.Names = new Dictionary<Guid, string>();
                foreach (ProductAttributeName ProductAttributeName in ProductAttribute.ProductAttributeNames)
                {
                    if (this.Names.ContainsKey(ProductAttributeName.LanguageId))
                        this.Names[ProductAttributeName.LanguageId] = ProductAttributeName.Name;
                    else
                        this.Names.Add(ProductAttributeName.LanguageId, ProductAttributeName.Name);
                }
            }
        }
    }

    public class ProductAttributeNameEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid LanguageId { get; set; }
        public ProductAttributeNameEntity() { }
        public ProductAttributeNameEntity(ProductAttributeName ProductAttributeName)
        {
            this.Id = ProductAttributeName.Id;
            this.Name = ProductAttributeName.Name;
            this.LanguageId = ProductAttributeName.LanguageId;
        }

        internal void AddError(string v1, string v2)
        {
            throw new NotImplementedException();
        }
    }


    public class ExtraEntity
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }

        internal void AddError(string v1, string v2)
        {
            throw new NotImplementedException();
        }
    }

    public class ProductValueEntity : CommonEntity
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public Guid LanguageId { get; set; }
        public Guid AttributeId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public bool IsDeleted { get; set; }
        public ProductValueEntity() : base() { }
        public ProductValueEntity(ProductValue ProductValue, Guid LanguageId, params object[] args) : base(ProductValue)
        {
            this.Name = ProductValue.Attribute.ProductAttributeNames.Where(pan => pan.LanguageId == LanguageId).Select(pan => pan.Name).FirstOrDefault();
        }
    }

    public class ProductSearchEntity : FilterEntity
    {
        public Guid? Id { get; set; }
        public string Code { get; set; }
        public string Unit { get; set; }
        public Guid? CategoryId { get; set; }
        public Guid? ManufacturerId { get; set; }

    }
}
