using EShop.Entities;
using System;
using System.Collections.Generic;

namespace EShop.Models
{
    public partial class Employee : Base
    {

        public Employee (EmployeeEntity EmployeeEntity) : base(EmployeeEntity)
        {

			if (EmployeeEntity.PermissionEntities != null)
            {
                this.Permissions = new HashSet<Permission>();
                foreach (PermissionEntity PermissionEntity in EmployeeEntity.PermissionEntities)
                {
					PermissionEntity.EmployeeId = EmployeeEntity.Id;
                    this.Permissions.Add(new Permission(PermissionEntity));
                }
            }

			if (EmployeeEntity.ReceiptNoteEntities != null)
            {
                this.ReceiptNotes = new HashSet<ReceiptNote>();
                foreach (ReceiptNoteEntity ReceiptNoteEntity in EmployeeEntity.ReceiptNoteEntities)
                {
					ReceiptNoteEntity.EmployeeId = EmployeeEntity.Id;
                    this.ReceiptNotes.Add(new ReceiptNote(ReceiptNoteEntity));
                }
            }

			if (EmployeeEntity.WarehouseEntities != null)
            {
                this.WareHouses = new HashSet<WareHouse>();
                foreach (WareHouseEntity WarehouseEntity in EmployeeEntity.WarehouseEntities)
                {
					WarehouseEntity.StockkeeperId = EmployeeEntity.Id;
                    this.WareHouses.Add(new WareHouse(WarehouseEntity));
                }
            }
		}

        public override bool Equals(Base other)
        {		
            if (other == null) return false;
            if (other is Employee Employee)
            {
                return Id.Equals(Employee.Id);
            }

            return false;
        }
    }
}
