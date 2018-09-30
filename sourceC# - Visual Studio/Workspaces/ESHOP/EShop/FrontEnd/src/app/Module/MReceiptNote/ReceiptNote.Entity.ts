import { IEntity } from "../IEntity.Entity";
import { InventoryEntity } from "../MInventory/Inventory.Entity";
import { SupplierEntity } from "../MSupplier/Supplier.Entity";
import { WareHouseEntity } from "../MWareHouse/WareHouse.Entity";
import { ProductEntity } from "../MProduct/Product.Entity";
import { EmployeeEntity } from "../MEmployee/Employee.Entity";
import { ReceiptNoteLineEntity } from "../MReceiptNoteLine/ReceiptNoteLine.Entity";

import { Data } from "@angular/router";

export class ReceiptNoteEntity extends IEntity {
    Id: number = 0;
    SupplierId: string = null;
    WareHouseId: string = null;
    EmployeeId: string = null;
    InvoiceDate: Date = null;
    Lock: boolean = null;
    Title: string = null;
    CreatedDate: Date = null;
    UpdatedDate: Date = null;
    ReceiptNoteNo: number = null;
    ReceiptDate: Date = null;
    SystemDate: Date = null;
    Address: string = null;
    PhoneNumber: string = null;
    Comment: string = null;
    Cx: number = null;
    SupplierEntity: SupplierEntity = new SupplierEntity();
    WareHouseEntity: WareHouseEntity = new WareHouseEntity();
    EmployeeEntity: EmployeeEntity = new EmployeeEntity();
    ReceiptNoteLineEntities: Array<ReceiptNoteLineEntity> = [];
    public constructor() {
        super();
    }
}
