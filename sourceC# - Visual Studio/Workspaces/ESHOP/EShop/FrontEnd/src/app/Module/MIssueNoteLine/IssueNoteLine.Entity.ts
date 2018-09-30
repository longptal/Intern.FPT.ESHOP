import { IEntity } from "../IEntity.Entity";
import { ProductEntity } from "../MProduct/Product.Entity";


export class IssueNoteLineEntity extends IEntity {

  Id: number = 0;
  ReceiptNoteId: number = 0;
  ProductId: number = 0;
  Quantity: number = 0;
  UnitPrice: number = 0;
  Price: number = 0;
  ManufactureDate: Date = null;
  ExpirationDate: Date = null;
  Shipment: string = null;
  Note: string = null;
  ProductEntity: ProductEntity = null;
  public constructor() {
    super();
  }
}
