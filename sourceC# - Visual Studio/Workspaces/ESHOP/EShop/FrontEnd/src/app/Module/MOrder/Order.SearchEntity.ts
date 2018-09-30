import { FilterEntity } from "../FilterEntity";

export class OrderSearchEntity extends FilterEntity {
  CustomerId: number = null;
  Code: string = null;
  CreatedDate: Date = null;
  UpdatedDate: Date = null;
  Status: number = null;
  Total: number = 0;
  OnPaid: boolean = false;
  Method: string = null;
  ShipmentDetailId: number = null;
  constructor() {
    super();
  }
}
