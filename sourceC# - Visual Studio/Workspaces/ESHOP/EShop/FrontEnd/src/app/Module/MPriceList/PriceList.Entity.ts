import { IEntity } from "../IEntity.Entity";
import { ProductEntity } from "../MProduct/Product.Entity";

export class PriceListEntity extends IEntity {
    ProductId: string = null;
    UnitPrice: number = null;
    Quantity: number = null;
    IsDeleted: boolean = false;
    ProductEntity: ProductEntity = null;

    public constructor(entity?: any, isSample?: boolean) {
        super();
    }

}
