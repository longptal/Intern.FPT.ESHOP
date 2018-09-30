import { FilterEntity } from "../FilterEntity";

export class InvoiceSearchEntity extends FilterEntity {
  OrderId: number = 0;
  Number: string = null;
  Seri: string = null;
  constructor(Entity: any = null) {
    super(Entity);
    this.OrderId = Entity == null ? null : Entity.OrderId;
    this.Number = Entity == null ? null : Entity.Number;
    this.Seri = Entity == null ? null : Entity.Seri;
  }
}
