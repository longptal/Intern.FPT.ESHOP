using EShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EShop.Entities
{
    public class EmployeeEntity : BaseEntity
    {
        public Guid Id { get; set; }
        public String Username { get; set; }
        public String Password { get; set; }
        public String Display { get; set; }
        public String Phone { get; set; }
        public String IdentityCard { get; set; }
        public DateTime? BirthDay { get; set; }
        public String Picture { get; set; }
        public List<PermissionEntity> PermissionEntities { get; set; }
        public List<ReceiptNoteEntity> ReceiptNoteEntities { get; set; }
        public List<WareHouseEntity> WarehouseEntities { get; set; }

        public EmployeeEntity():base() { }

        public EmployeeEntity(Employee Employee, params object[] args) :base(Employee)
        {
		    foreach(object arg in args)
			{
                if (arg is ICollection<Permission> Permissions)
                    PermissionEntities = Permissions.Select(model => new PermissionEntity(model, model.Role)).ToList();				
                if (arg is ICollection<ReceiptNote> ReceiptNotes)
                    ReceiptNoteEntities = ReceiptNotes.Select(model => new ReceiptNoteEntity(model, model.Supplier, model.WareHouse)).ToList();				
                if (arg is ICollection<WareHouse> WareHouses)
                    WarehouseEntities = WareHouses.Select(model => new WareHouseEntity(model)).ToList();				
			}
        }
    }

    public class EmployeeSearchEntity : FilterEntity
    {
        public Guid? Id { get; set; }
        public String Username { get; set; }
        public String Password { get; set; }
        public String Display { get; set; }
        public String Phone { get; set; }
        public String IdentityCard { get; set; }
        public DateTime? BirthDay { get; set; }
        public String Picture { get; set; }
    }
}
