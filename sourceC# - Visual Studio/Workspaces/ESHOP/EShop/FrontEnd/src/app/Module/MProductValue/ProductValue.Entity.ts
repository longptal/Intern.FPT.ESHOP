import { IEntity } from "../IEntity.Entity";
import { ProductEntity } from "../MProduct/Product.Entity";
import { ProductAttributeEntity } from "../MProductAttribute/ProductAttribute.Entity";
import { LanguageEntity } from "../MLanguage/Language.Entity";

export class ProductValueEntity extends IEntity {
  Id: number = 0;
  ProductId: string = null;
  LanguageId: string = null;
  AttributeId: string = null;
  Value: string = null;
  Cx: number = null;

  AttributeEntities: ProductAttributeEntity = null;
  LanguageEntity: LanguageEntity = null;
  ProductEntity: ProductEntity = null;
  public constructor() {
    super();
  }
}
