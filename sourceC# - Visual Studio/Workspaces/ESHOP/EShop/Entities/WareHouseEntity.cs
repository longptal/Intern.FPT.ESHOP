using EShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EShop.Entities
{
    public class WareHouseEntity : BaseEntity
    {
        public Guid Id { get; set; }
        public String Code { get; set; }
        public String Name { get; set; }
        public String StorageLocation { get; set; }
        public Boolean IsDefault { get; set; }
        public Guid StockkeeperId { get; set; }
        public EmployeeEntity StockkeeperEntity { get; set; }
        public List<InventoryEntity> InventoryEntities { get; set; }
        public List<IssueNoteEntity> IssueNoteEntities { get; set; }
        public List<ReceiptNoteEntity> ReceiptNoteEntities { get; set; }

        public WareHouseEntity():base() { }

        public WareHouseEntity(WareHouse WareHouse, params object[] args) :base(WareHouse)
        {
		    foreach(object arg in args)
			{
                if (arg is Employee Stockkeeper)
                    StockkeeperEntity = new EmployeeEntity(Stockkeeper);				
                if (arg is ICollection<Inventory> Inventories)
                    InventoryEntities = Inventories.Select(model => new InventoryEntity(model, model.Product)).ToList();				
                if (arg is ICollection<IssueNote> IssueNotes)
                    IssueNoteEntities = IssueNotes.Select(model => new IssueNoteEntity(model, model.Customer, model.Invoice)).ToList();				
                if (arg is ICollection<ReceiptNote> ReceiptNotes)
                    ReceiptNoteEntities = ReceiptNotes.Select(model => new ReceiptNoteEntity(model, model.Employee, model.Supplier)).ToList();				
			}
        }
    }

    public class WareHouseSearchEntity : FilterEntity
    {
        public Guid? Id { get; set; }
        public String Code { get; set; }
        public String Name { get; set; }
        public String StorageLocation { get; set; }
        public Boolean? IsDefault { get; set; }
        public Guid? StockkeeperId { get; set; }
    }
}
