import { IEntity } from "../IEntity.Entity";
import { ProductEntity } from "../MProduct/Product.Entity";
//import { OrderDetailEntity } from "../MOrderDetail/OrderDetail.Entity";

export class PackEntity extends IEntity {
  Id: number = null;
    ProductId: number = null;
    UnitPrice: number = null;
    Quantity: number = null;
    IsDefault: boolean = false;
    Cx: number = null;
    ProductEntity: ProductEntity = null;
  //OrderDetailEntities: Array<OrderDetailEntity> = null;
    public constructor() {
        super();
    }

}
