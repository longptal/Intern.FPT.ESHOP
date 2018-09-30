import { FilterEntity } from "../FilterEntity";
export class RoleSearchEntity extends FilterEntity {
    Id: number;
  Name: string;
  Code: string;

    constructor(Entity: any = null) {
        super(Entity);
        this.Id = Entity == null ? null : Entity.Id;
      this.Name = Entity == null ? null : Entity.Name;
      this.Code = Entity == null ? null : Entity.Code;

    }
}
