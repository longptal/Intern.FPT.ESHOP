import { FilterEntity } from "../FilterEntity";
export class OpeningBalanceSearchEntity extends FilterEntity {
    ProductId: number;
    Code: string;

    constructor(Entity: any = null) {
        super(Entity);
        this.ProductId = Entity == null ? null : Entity.ProductId;
        this.Code = Entity == null ? null : Entity.Code;
    }
}
