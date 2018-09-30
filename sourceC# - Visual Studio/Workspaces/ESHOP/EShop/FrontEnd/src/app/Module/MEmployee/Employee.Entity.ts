import {IEntity} from '../IEntity.Entity';

export class EmployeeEntity extends IEntity {
  Username: string = null;
  Password: string = null;
  Display: string = null;
  Phone: string = null;
  IdentityCard: string = null;
  Birthday: string = null;
  Picture: string = '';

  public constructor(entity?: any, isSample?: boolean) {
    super();
  }
}
