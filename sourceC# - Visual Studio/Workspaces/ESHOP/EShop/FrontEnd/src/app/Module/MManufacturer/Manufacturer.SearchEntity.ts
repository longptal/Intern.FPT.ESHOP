import { FilterEntity } from "../FilterEntity";

export class ManufacturerSearchEntity extends FilterEntity {
  Code: string = null;
  Name: string = null;
  Address: string = null;
  Origin: string = null;
  TaxCode: string = null;
  IsActive: boolean = true;

  constructor(Entity: any = null) {
    super(Entity);
    this.Code = Entity == null ? null : Entity.Code;
    this.Name = Entity == null ? null : Entity.Name;
    this.Address = Entity == null ? null : Entity.Address;
    this.Origin = Entity == null ? null : Entity.Origin;
    this.TaxCode = Entity == null ? null : Entity.TaxCode;
    this.IsActive = Entity == null ? null : Entity.IsActive;
  }
}
