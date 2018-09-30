import { FilterEntity } from "../FilterEntity";
export class SupplierSearchEntity extends FilterEntity {
  Id: string;
    Name: string;
    TaxCode: string;
    Address: string;
    Phone: string;
    Origin: string;
    IsActive: boolean;
    Description: string;

    constructor(Entity: any = null) {
        super(Entity);
        this.Id = Entity == null ? null : Entity.Id;
        this.Name = Entity == null ? null : Entity.Name;
        this.TaxCode = Entity == null ? null : Entity.TaxCode;
        this.Address = Entity == null ? null : Entity.Address;
        this.Phone = Entity == null ? null : Entity.Phone;
        this.Origin = Entity == null ? null : Entity.Origin;
        this.IsActive = Entity == null ? null : Entity.IsActive;
        this.Description = Entity == null ? null : Entity.Description;
    }
}

