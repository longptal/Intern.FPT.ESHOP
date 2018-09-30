import {IEntity} from '../IEntity.Entity';

export class DiscountEntity extends IEntity {
  Id: number = 0;
  Min: number = null;
  Max: number = null;
  IsDeleted: boolean = null;
  ProductId: number = null;

  public constructor() {
    super();
  }

}
