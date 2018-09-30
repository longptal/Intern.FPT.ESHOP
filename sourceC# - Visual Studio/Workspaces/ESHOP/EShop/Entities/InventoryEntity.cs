using EShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EShop.Entities
{
    public class InventoryEntity : BaseEntity
    {
        public Guid Id { get; set; }
        public Guid WareHouseId { get; set; }
        public Guid ProductId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public ProductEntity ProductEntity { get; set; }
        public WareHouseEntity WareHouseEntity { get; set; }
        public List<InputEntity> InputEntities { get; set; }
        public List<InventoryCheckpointEntity> InventoryCheckpointEntities { get; set; }
        public List<OutputEntity> OutputEntities { get; set; }

        public InventoryEntity():base() { }

        public InventoryEntity(Inventory Inventory, params object[] args) :base(Inventory)
        {
		    foreach(object arg in args)
			{
                if (arg is Product Product)
                    ProductEntity = new ProductEntity(Product);				
                if (arg is WareHouse WareHouse)
                    WareHouseEntity = new WareHouseEntity(WareHouse);				
                if (arg is ICollection<Input> Inputs)
                    InputEntities = Inputs.Select(model => new InputEntity(model)).ToList();				
                if (arg is ICollection<InventoryCheckpoint> InventoryCheckpoints)
                    InventoryCheckpointEntities = InventoryCheckpoints.Select(model => new InventoryCheckpointEntity(model)).ToList();				
                if (arg is ICollection<Output> Outputs)
                    OutputEntities = Outputs.Select(model => new OutputEntity(model)).ToList();				
			}
        }
    }

    public class InventorySearchEntity : FilterEntity
    {
        public Guid? Id { get; set; }
        public Guid? WareHouseId { get; set; }
        public Guid? ProductId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
