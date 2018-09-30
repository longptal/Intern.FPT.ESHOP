using EShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EShop.Entities
{
    public class CustomerEntity : BaseEntity
    {
        public Guid Id { get; set; }
        public String Username { get; set; }
        public String Password { get; set; }
        public String Display { get; set; }
        public String Picture { get; set; }
        public String FacebookId { get; set; }
        public String FacebookEmail { get; set; }
        public String GoogleId { get; set; }
        public String GoogleEmail { get; set; }
        public Guid CustomerGroupId { get; set; }
        public CustomerGroupEntity CustomerGroupEntity { get; set; }
        public List<IssueNoteEntity> IssueNoteEntities { get; set; }
        public List<OrderEntity> OrderEntities { get; set; }
        public List<ShipmentDetailEntity> ShipmentDetailEntities { get; set; }

        public CustomerEntity():base() { }

        public CustomerEntity(Customer Customer, params object[] args) :base(Customer)
        {
		    foreach(object arg in args)
			{
                if (arg is CustomerGroup CustomerGroup)
                    CustomerGroupEntity = new CustomerGroupEntity(CustomerGroup);				
                if (arg is ICollection<IssueNote> IssueNotes)
                    IssueNoteEntities = IssueNotes.Select(model => new IssueNoteEntity(model, model.Invoice, model.WareHouse)).ToList();				
                if (arg is ICollection<Order> Orders)
                    OrderEntities = Orders.Select(model => new OrderEntity(model, model.ShipmentDetail)).ToList();				
                if (arg is ICollection<ShipmentDetail> ShipmentDetails)
                    ShipmentDetailEntities = ShipmentDetails.Select(model => new ShipmentDetailEntity(model, model.City, model.Country)).ToList();				
			}
        }
    }

    public class CustomerSearchEntity : FilterEntity
    {
        public Guid? Id { get; set; }
        public String Username { get; set; }
        public String Password { get; set; }
        public String Display { get; set; }
        public String Picture { get; set; }
        public String FacebookId { get; set; }
        public String FacebookEmail { get; set; }
        public String GoogleId { get; set; }
        public String GoogleEmail { get; set; }
        public Guid? CustomerGroupId { get; set; }
    }
}
