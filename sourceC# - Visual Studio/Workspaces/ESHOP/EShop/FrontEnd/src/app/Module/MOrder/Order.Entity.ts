import { IEntity } from "../IEntity.Entity";
import { InventoryEntity } from "../MInventory/Inventory.Entity";
import { SupplierEntity } from "../MSupplier/Supplier.Entity";
import { WareHouseEntity } from "../MWareHouse/WareHouse.Entity";
import { ProductEntity } from "../MProduct/Product.Entity";
import { CustomerEntity } from "../MCustomer/Customer.Entity";
import { ShipmentDetailEntity } from "../MShipmentDetail/ShipmentDetail.Entity";

export class OrderEntity extends IEntity {

  CustomerId: number = null;
  Code: string = null;
  CreatedDate: Date = null;
  UpdatedDate: Date = null;
  Status: number = null;
  Total: number = 0;
  OnPaid: boolean = false;
  Method: string = null;
  ShipmentDetailId: number = null;
  CustomerEntity: CustomerEntity = null;
  ShipmentDetailEntity: ShipmentDetailEntity = null;
  public constructor() {
    super();
  }
}
