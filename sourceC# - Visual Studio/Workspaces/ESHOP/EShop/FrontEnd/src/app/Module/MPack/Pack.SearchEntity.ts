import { FilterEntity } from "../FilterEntity";
export class PackSearchEntity extends FilterEntity {
    Id: string;
    ProductId: number;
    UnitPrice: number;
    Quantity: number;
    IsDefault: boolean;

    constructor(Entity: any = null) {
        super(Entity);
        this.Id = Entity == null ? null : Entity.Id;
        this.ProductId = Entity == null ? null : Entity.ProductId;
        this.UnitPrice = Entity == null ? null : Entity.UnitPrice;
        this.Quantity = Entity == null ? null : Entity.Quantity;
        this.IsDefault = Entity == null ? null : Entity.IsDefault;
    }
}
