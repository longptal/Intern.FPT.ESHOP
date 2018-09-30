import { FilterEntity } from "../FilterEntity";

export class CustomerGroupSearchEntity extends FilterEntity {
  Code: string = null;
  Name: string = null;
  Description: string = null;
  IsActive: boolean = true;
  constructor(Entity: any = null) {
    super(Entity);
    this.Code = Entity == null ? null : Entity.Code;
    this.Name = Entity == null ? null : Entity.Name;
    this.Description = Entity == null ? null : Entity.Description;
    this.IsActive = Entity == null ? null : Entity.IsActive;
  }
}
