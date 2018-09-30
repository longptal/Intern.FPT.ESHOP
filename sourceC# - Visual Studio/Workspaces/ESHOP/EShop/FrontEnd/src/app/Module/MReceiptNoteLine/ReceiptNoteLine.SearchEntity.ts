import { FilterEntity } from "../FilterEntity";

export class ReceiptNoteLineSearchEntity extends FilterEntity {
  Id: string = null;
  ReceiptNoteId: number = null;
  ProductId: string = null;
  Quantity: string = null;
  UnitPrice: number = null;
  Price: number = null;
  ManufactureDate: Date = null;
  ExpirationDate: Date = null;
  Shipment: string = null;
  Note: string = null;
  Lock: boolean = false;
  constructor(Entity: any = null) {
    super();
    this.Id = Entity == null ? null : Entity.Id;
    this.ReceiptNoteId = Entity == null ? null : Entity.ReceiptNoteId;
    this.ProductId = Entity == null ? null : Entity.ProductId;
    this.Quantity = Entity == null ? null : Entity.Quantity;
    this.UnitPrice = Entity == null ? null : Entity.UnitPrice;
    this.Price = Entity == null ? null : Entity.Price;
    this.ManufactureDate = Entity == null ? null : Entity.ManufactureDate;
    this.ExpirationDate = Entity == null ? null : Entity.ExpirationDate;
    this.Shipment = Entity == null ? null : Entity.Shipment;
    this.Note = Entity == null ? null : Entity.Note;
    this.Lock = Entity == null ? null : Entity.Lock;

  }
}
