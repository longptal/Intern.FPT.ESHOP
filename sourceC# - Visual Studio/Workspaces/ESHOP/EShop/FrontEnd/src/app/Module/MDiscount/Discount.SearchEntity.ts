import {FilterEntity} from '../FilterEntity';

export class DiscountSearchEntity extends FilterEntity {
  Min: number = 0;
  Max: number = null;
  IsDeleted: boolean = null;
  ProductId: number = null;
  constructor(Entity: any = null) {
    super(Entity);
    this.Min = Entity == null ? null : Entity.Min;
    this.Max = Entity == null ? null : Entity.Max;
    this.IsDeleted = Entity == null ? null : Entity.IsDeleted;
    this.ProductId = Entity == null ? null : Entity.ProductId;
  }
}
