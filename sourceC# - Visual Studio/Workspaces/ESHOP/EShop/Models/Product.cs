using System;
using System.Collections.Generic;

namespace EShop.Models
{
    public partial class Product
    {
        public Product()
        {
            Discounts = new HashSet<Discount>();
            Inventories = new HashSet<Inventory>();
            IssueNoteLines = new HashSet<IssueNoteLine>();
            Packs = new HashSet<Pack>();
            ProductPictures = new HashSet<ProductPicture>();
            ProductValues = new HashSet<ProductValue>();
            ReceiptNoteLines = new HashSet<ReceiptNoteLine>();
        }

        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Unit { get; set; }
        public Guid CategoryId { get; set; }
        public Guid ManufacturerId { get; set; }
        public long Cx { get; set; }

        public Category Category { get; set; }
        public Manufacturer Manufacturer { get; set; }
        public ICollection<Discount> Discounts { get; set; }
        public ICollection<Inventory> Inventories { get; set; }
        public ICollection<IssueNoteLine> IssueNoteLines { get; set; }
        public ICollection<Pack> Packs { get; set; }
        public ICollection<ProductPicture> ProductPictures { get; set; }
        public ICollection<ProductValue> ProductValues { get; set; }
        public ICollection<ReceiptNoteLine> ReceiptNoteLines { get; set; }
    }
}
