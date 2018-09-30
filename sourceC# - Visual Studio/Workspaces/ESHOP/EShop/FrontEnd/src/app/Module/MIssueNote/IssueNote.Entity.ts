import { IEntity } from "../IEntity.Entity";
import { InventoryEntity } from "../MInventory/Inventory.Entity";
import { SupplierEntity } from "../MSupplier/Supplier.Entity";
import { WareHouseEntity } from "../MWareHouse/WareHouse.Entity";
import { ProductEntity } from "../MProduct/Product.Entity";

export class IssueNoteEntity extends IEntity {
    Id: number = 0;
    InventoryId: number = null;
    SupplierId: number = null;
    WareHouseId: number = null;
    ProductId: number = null;
    Quantity: number = null;
    UnitPrice: number = null;
    Description: string = null;
    IsDeleted: boolean = false;
    InventoryEntity: InventoryEntity = null;
    SupplierEntity: SupplierEntity = null;
    WareHouseEntity: WareHouseEntity = null;
    ProductEntity: ProductEntity = null;
    public constructor() {
        super();
    }
}
