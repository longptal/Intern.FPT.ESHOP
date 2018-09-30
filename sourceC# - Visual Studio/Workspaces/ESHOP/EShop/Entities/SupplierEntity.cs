using EShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EShop.Entities
{
    public class SupplierEntity : BaseEntity
    {
        public Guid Id { get; set; }
        public String TaxCode { get; set; }
        public String Name { get; set; }
        public String Address { get; set; }
        public String Description { get; set; }
        public String Phone { get; set; }
        public String Origin { get; set; }
        public Boolean IsActive { get; set; }
        public List<ReceiptNoteEntity> ReceiptNoteEntities { get; set; }

        public SupplierEntity():base() { }

        public SupplierEntity(Supplier Supplier, params object[] args) :base(Supplier)
        {
		    foreach(object arg in args)
			{
                if (arg is ICollection<ReceiptNote> ReceiptNotes)
                    ReceiptNoteEntities = ReceiptNotes.Select(model => new ReceiptNoteEntity(model, model.Employee, model.WareHouse)).ToList();				
			}
        }
    }

    public class SupplierSearchEntity : FilterEntity
    {
        public Guid? Id { get; set; }
        public String TaxCode { get; set; }
        public String Name { get; set; }
        public String Address { get; set; }
        public String Description { get; set; }
        public String Phone { get; set; }
        public String Origin { get; set; }
        public Boolean? IsActive { get; set; }
    }
}
