import { IEntity } from "../IEntity.Entity";

export class CustomerGroupEntity extends IEntity {
  Id: number;
  Code: string = null;
  Name: string = null;
  Description: string = null;
  IsActive: boolean = null;

  public constructor() {
    super();
  }

}
