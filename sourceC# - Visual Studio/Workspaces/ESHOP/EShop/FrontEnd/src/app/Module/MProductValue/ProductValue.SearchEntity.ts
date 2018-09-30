import { FilterEntity } from "../FilterEntity";

export class ProductValueSearchEntity extends FilterEntity {
  Id: string;
  ProductId: number;
  LanguageId: number;
  AttributeId: string;
  Value: string = null;

  constructor(Entity: any = null) {
    super(Entity);
    this.Id = Entity == null ? null : Entity.Id;
    this.ProductId = Entity == null ? null : Entity.ProductId;
    this.LanguageId = Entity == null ? null : Entity.LanguageId;
    this.AttributeId = Entity == null ? null : Entity.AttributeId;
    this.Value = Entity == null ? null : Entity.Value;
  }
}
