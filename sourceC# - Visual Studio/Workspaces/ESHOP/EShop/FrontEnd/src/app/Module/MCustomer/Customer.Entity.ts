import { IEntity } from "../IEntity.Entity";
import { CustomerGroupEntity } from "../MCustomerGroup/CustomerGroup.Entity";

export class CustomerEntity extends IEntity {
  Id: number;
  Username: string = null;
  Password: string = null;
  Display: string = null;
  Picture: string = null;
  FacebookId: string = null;
  FacebookEmail: string = null;
  GoogleId: string = null;
  GoogleEmail: string = null;
  CustomerGroupId: number = null;
  CustomerGroupEntity: CustomerGroupEntity = null;

  public constructor() {
    super();
  }

}
