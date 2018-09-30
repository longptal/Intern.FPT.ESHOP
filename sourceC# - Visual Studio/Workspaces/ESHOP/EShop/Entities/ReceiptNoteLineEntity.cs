using EShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EShop.Entities
{
    public class ReceiptNoteLineEntity : BaseEntity
    {
        public Guid Id { get; set; }
        public Int32 Quantity { get; set; }
        public Decimal UnitPrice { get; set; }
        public Decimal Price { get; set; }
        public DateTime? ManufactureDate { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public String Shipment { get; set; }
        public String Note { get; set; }
        public Boolean Lock { get; set; }
        public Guid ReceiptNoteId { get; set; }
        public Guid ProductId { get; set; }
        public ProductEntity ProductEntity { get; set; }
        public ReceiptNoteEntity ReceiptNoteEntity { get; set; }

        public ReceiptNoteLineEntity():base() { }

        public ReceiptNoteLineEntity(ReceiptNoteLine ReceiptNoteLine, params object[] args) :base(ReceiptNoteLine)
        {
		    foreach(object arg in args)
			{
                if (arg is Product Product)
                    ProductEntity = new ProductEntity(Product);				
                if (arg is ReceiptNote ReceiptNote)
                    ReceiptNoteEntity = new ReceiptNoteEntity(ReceiptNote);				
			}
        }
    }

    public class ReceiptNoteLineSearchEntity : FilterEntity
    {
        public Guid? Id { get; set; }
        public Int32? Quantity { get; set; }
        public Decimal? UnitPrice { get; set; }
        public Decimal? Price { get; set; }
        public DateTime? ManufactureDate { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public String Shipment { get; set; }
        public String Note { get; set; }
        public Boolean? Lock { get; set; }
        public Guid? ReceiptNoteId { get; set; }
        public Guid? ProductId { get; set; }
    }
}
