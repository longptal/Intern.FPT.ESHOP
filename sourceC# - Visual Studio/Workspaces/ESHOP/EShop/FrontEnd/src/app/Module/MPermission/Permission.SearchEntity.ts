import { FilterEntity } from "../FilterEntity";
export class PermissionSearchEntity extends FilterEntity {
  Id: string;
  UserId: string;
  RoleId: string;

    constructor(Entity: any = null) {
        super(Entity);
        this.Id = Entity == null ? null : Entity.Id;
        this.UserId = Entity == null ? null : Entity.UserId;
        this.RoleId = Entity == null ? null : Entity.RoleId;
    }
}
