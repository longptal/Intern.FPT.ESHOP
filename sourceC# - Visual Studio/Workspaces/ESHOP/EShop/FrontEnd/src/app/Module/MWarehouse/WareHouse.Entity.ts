import { IEntity } from "../IEntity.Entity";
import { EmployeeEntity } from "../MEmployee/Employee.Entity";
import { InventoryEntity } from "../MInventory/Inventory.Entity";
import { IssueNoteEntity } from "../MIssueNote/IssueNote.Entity";
import { ReceiptNoteEntity } from "../MReceiptNote/ReceiptNote.Entity";

export class WareHouseEntity extends IEntity {
    Id: number = null;
    Code: string = null;
    Name: string = null;
    IsDefault: boolean = false;
    Cx: number = null;
    StorageLocation: string = null;
    StockkeeperId: number = null;
    StockkeeperEntity: EmployeeEntity = null;
    InventoryEntities: Array<InventoryEntity> = [];
    IssueNoteEntities: Array<IssueNoteEntity> = [];
    ReceiptNoteEntities: Array<ReceiptNoteEntity> = [];
    public constructor() {
          super();
      }
}
