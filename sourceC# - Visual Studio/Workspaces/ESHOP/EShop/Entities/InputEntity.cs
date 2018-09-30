using EShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EShop.Entities
{
    public class InputEntity : BaseEntity
    {
        public Guid Id { get; set; }
        public Int32 Quantity { get; set; }
        public Decimal UnitPrice { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public Guid InventoryId { get; set; }
        public String Description { get; set; }
        public InventoryEntity InventoryEntity { get; set; }

        public InputEntity():base() { }

        public InputEntity(Input Input, params object[] args) :base(Input)
        {
		    foreach(object arg in args)
			{
                if (arg is Inventory Inventory)
                    InventoryEntity = new InventoryEntity(Inventory);				
			}
        }
    }

    public class InputSearchEntity : FilterEntity
    {
        public Guid? Id { get; set; }
        public Int32? Quantity { get; set; }
        public Decimal? UnitPrice { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public Guid? InventoryId { get; set; }
        public String Description { get; set; }
    }
}
