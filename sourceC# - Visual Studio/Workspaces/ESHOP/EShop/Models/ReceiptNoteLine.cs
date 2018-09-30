using System;
using System.Collections.Generic;

namespace EShop.Models
{
    public partial class ReceiptNoteLine
    {
        public Guid Id { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Price { get; set; }
        public DateTime? ManufactureDate { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public string Shipment { get; set; }
        public string Note { get; set; }
        public bool Lock { get; set; }
        public long Cx { get; set; }
        public Guid ReceiptNoteId { get; set; }
        public Guid ProductId { get; set; }

        public Product Product { get; set; }
        public ReceiptNote ReceiptNote { get; set; }
    }
}
