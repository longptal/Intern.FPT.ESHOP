import { IEntity } from "../IEntity.Entity";

export class InvoiceEntity extends IEntity {
  Id: number = 0;
  OrderId: number = 0;
  Number: string = null;
  Seri: string = null;
  CreatedDate: Date = null;
  UpdatedDate: Date = null;

  public constructor() {
    super();
  }

}
