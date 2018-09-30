import { FilterEntity } from "../FilterEntity";

export class StockTransferLineSearchEntity extends FilterEntity {
  StockTransferId: number = null;
  ProductId: number = null;
  Quantity: number = null;
  UnitPrice: number = null;
  Price: number = null;
  ManufactureDate: Date = null;
  ExpirationDate: Date = null;
  Shipment: string = null;
  Note: string = null;
  constructor() {
    super();
  }
}
