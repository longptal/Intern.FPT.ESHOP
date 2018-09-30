import { IEntity } from "../IEntity.Entity";

export class ManufacturerEntity extends IEntity {
  Code: string = null;
  Name: string = null;
  Address: string = null;
  Origin: string = null;
  TaxCode: string = null;
  IsActive: boolean = true;

  public constructor(entity?: any, isSample?: boolean) {
    super();
  }
}
