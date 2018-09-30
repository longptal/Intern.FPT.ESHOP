import { IEntity } from "../IEntity.Entity";
import { RoleEntity } from "../MRole/Role.Entity";
import { EmployeeEntity } from "../MEmployee/Employee.Entity";

export class PermissionEntity extends IEntity {
  Id: number = null;
  EmployeeId: string = null;
  RoleId: string = null;
  Cx: number = null;
  RoleEntity: RoleEntity = null;
  EmployeeEntity: EmployeeEntity = null;

    public constructor() {
        super();
    }

}
