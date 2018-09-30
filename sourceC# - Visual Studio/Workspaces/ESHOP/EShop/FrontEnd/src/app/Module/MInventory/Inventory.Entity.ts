import { IEntity } from "../IEntity.Entity";
import { ProductEntity } from "../MProduct/Product.Entity";
import { WareHouseEntity } from "../MWareHouse/WareHouse.Entity";
import { IssueNoteEntity } from "../MIssueNote/IssueNote.Entity";
import { ReceiptNoteEntity } from "../MReceiptNote/ReceiptNote.Entity";

export class InventoryEntity extends IEntity {
  Id: number = 0;
  IsDeleted: boolean = false;
  WareHouseId: number = 0;
  ProductId: number = 0;
  Current: number = 0;
  ProductEntity: ProductEntity = new ProductEntity();
  WareHouseEntity: WareHouseEntity = new WareHouseEntity();
  public constructor() {
    super();
  }

}
