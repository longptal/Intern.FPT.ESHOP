using EShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EShop.Entities
{
    public class ReceiptNoteEntity : BaseEntity
    {
        public Guid Id { get; set; }
        public Int32 ReceiptNoteNo { get; set; }
        public DateTime InvoiceDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public Boolean Lock { get; set; }
        public String Title { get; set; }
        public DateTime? ReceiptDate { get; set; }
        public DateTime? SystemDate { get; set; }
        public String Address { get; set; }
        public String PhoneNumber { get; set; }
        public String Comment { get; set; }
        public Guid WareHouseId { get; set; }
        public Guid SupplierId { get; set; }
        public Guid EmployeeId { get; set; }
        public EmployeeEntity EmployeeEntity { get; set; }
        public SupplierEntity SupplierEntity { get; set; }
        public WareHouseEntity WareHouseEntity { get; set; }
        public List<ReceiptNoteLineEntity> ReceiptNoteLineEntities { get; set; }

        public ReceiptNoteEntity():base() { }

        public ReceiptNoteEntity(ReceiptNote ReceiptNote, params object[] args) :base(ReceiptNote)
        {
		    foreach(object arg in args)
			{
                if (arg is Employee Employee)
                    EmployeeEntity = new EmployeeEntity(Employee);				
                if (arg is Supplier Supplier)
                    SupplierEntity = new SupplierEntity(Supplier);				
                if (arg is WareHouse WareHouse)
                    WareHouseEntity = new WareHouseEntity(WareHouse);				
                if (arg is ICollection<ReceiptNoteLine> ReceiptNoteLines)
                    ReceiptNoteLineEntities = ReceiptNoteLines.Select(model => new ReceiptNoteLineEntity(model, model.Product)).ToList();				
			}
        }
    }

    public class ReceiptNoteSearchEntity : FilterEntity
    {
        public Guid? Id { get; set; }
        public Int32? ReceiptNoteNo { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public Boolean? Lock { get; set; }
        public String Title { get; set; }
        public DateTime? ReceiptDate { get; set; }
        public DateTime? SystemDate { get; set; }
        public String Address { get; set; }
        public String PhoneNumber { get; set; }
        public String Comment { get; set; }
        public Guid? WareHouseId { get; set; }
        public Guid? SupplierId { get; set; }
        public Guid? EmployeeId { get; set; }
    }
}
