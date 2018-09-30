import { FilterEntity } from "../FilterEntity";

export class CategorySearchEntity extends FilterEntity {
    ParentId: number;
    Code: string;
    constructor(Entity: any = null) {
        super(Entity);
        this.Code = Entity == null ? null : Entity.Code;
        this.ParentId = Entity == null ? null : Entity.ParentId;
    }
}
