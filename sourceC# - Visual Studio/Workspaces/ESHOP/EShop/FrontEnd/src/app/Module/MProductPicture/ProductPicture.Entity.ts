import { IEntity } from "../IEntity.Entity";
import { ProductEntity } from "../MProduct/Product.Entity";

export class ProductPictureEntity extends IEntity {
  Id: number = 0;
  Path: string = null;
  ProductId: number = null;
  IsDefault: boolean = false;
  Cx: number = null;
  ProductEntity: ProductEntity = null;
  public constructor() {
    super();
  }

}
