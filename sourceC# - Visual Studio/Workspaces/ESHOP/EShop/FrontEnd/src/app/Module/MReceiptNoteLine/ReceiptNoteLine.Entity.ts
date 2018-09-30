import { IEntity } from "../IEntity.Entity";
import { ProductEntity } from "../MProduct/Product.Entity";
import { ReceiptNoteEntity } from "../MReceiptNote/ReceiptNote.Entity";


export class ReceiptNoteLineEntity extends IEntity {

  Id: number = 0;
  ReceiptNoteId: string = null;
  ProductId: string = null;
  Quantity: number = 0;
  UnitPrice: number = 0;
  Price: number = 0;
  ManufactureDate: Date = null;
  ExpirationDate: Date = null;
  Shipment: string = null;
  Note: string = null;
  Lock: boolean = false;
  CX: boolean = false;
  ProductEntity: ProductEntity = null;
  ReceiptNoteEntity: ReceiptNoteEntity = null;
  //ProductEntity: ProductEntity = new ProductEntity();
  public constructor() {
    super();
  }
}
