import { IEntity } from "../IEntity.Entity";
import { CategoryEntity } from "../MCategory/Category.Entity";
//import { ProductAttributeNameEntity } from "../MProductAttributeName/ProductAttributeName.Entity";
import { ProductValueEntity } from "../MProductValue/ProductValue.Entity";


export class ProductAttributeEntity extends IEntity {
  CategoryId: number = null;
  Code: string = null;
  Id: number = null;
  Cx: number = null;
  CategoryEntity: CategoryEntity = null;
  //ProductAttributeNameEntities: Array<ProductAttributeNameEntity> = [];
  ProductValueEntities: Array<ProductValueEntity> = [];
    public constructor() {
        super();
    }

}

