import { IEntity } from "../IEntity.Entity";
//import { ModuleRoleEntity } from "../MModuleRole/ModuleRole.Entity";
import { PermissionEntity } from "../MPermission/Permission.Entity";

export class RoleEntity extends IEntity {
  Id: number = null;
  Code: string = null;
  Name: string = null;
  Cx: number = null;
  //ModuleRoleEntities = Array <ModuleRoleEntity> =[];
  PermissionEntities: Array<PermissionEntity> = [];
    public constructor() {
        super();
    }

}
