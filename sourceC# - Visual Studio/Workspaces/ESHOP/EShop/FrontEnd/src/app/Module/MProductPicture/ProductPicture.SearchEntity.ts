import { FilterEntity } from "../FilterEntity";

export class ProductPictureSearchEntity extends FilterEntity {
  Id: string = null;
  Path: string = null;
  ProductId: number = null;
  IsDefault: boolean = false;

  constructor(Entity: any = null) {
    super(Entity);
    this.Id = Entity == null ? null : Entity.Id;
    this.Path = Entity == null ? null : Entity.Path;
    this.ProductId = Entity == null ? null : Entity.ProductId;
    this.IsDefault = Entity == null ? false : Entity.IsDefault;
  }
}
