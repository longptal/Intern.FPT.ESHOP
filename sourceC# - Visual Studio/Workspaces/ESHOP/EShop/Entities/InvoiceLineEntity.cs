using EShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EShop.Entities
{
    public class InvoiceLineEntity : BaseEntity
    {
        public Guid Id { get; set; }
        public Guid InvoiceId { get; set; }
        public String ProductName { get; set; }
        public String Unit { get; set; }
        public Int32? Quantity { get; set; }
        public InvoiceEntity InvoiceEntity { get; set; }

        public InvoiceLineEntity():base() { }

        public InvoiceLineEntity(InvoiceLine InvoiceLine, params object[] args) :base(InvoiceLine)
        {
		    foreach(object arg in args)
			{
                if (arg is Invoice Invoice)
                    InvoiceEntity = new InvoiceEntity(Invoice);				
			}
        }
    }

    public class InvoiceLineSearchEntity : FilterEntity
    {
        public Guid? Id { get; set; }
        public Guid? InvoiceId { get; set; }
        public String ProductName { get; set; }
        public String Unit { get; set; }
        public Int32? Quantity { get; set; }
    }
}
