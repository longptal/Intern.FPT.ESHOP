import { FilterEntity } from "../FilterEntity";
export class ProductAttributeSearchEntity extends FilterEntity {
    Id: number;
    CategoryId: number;
    Code: string;

    constructor(Entity: any = null) {
        super(Entity);
        this.Id = Entity == null ? null : Entity.Id;
        this.CategoryId = Entity == null ? null : Entity.CategoryId;
        this.Code = Entity == null ? null : Entity.Code;
    }
}
