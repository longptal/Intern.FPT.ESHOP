import { FilterEntity } from "../FilterEntity";

export class CouponSearchEntity extends FilterEntity {
    Code: string;
    StartDate: Date = null;
    EndDate: Date = null;
    constructor(Entity: any = null) {
        super(Entity);
        this.Code = Entity == null ? null : Entity.Code;
        this.StartDate = Entity == null ? null : Entity.StartDate;
        this.EndDate = Entity == null ? null : Entity.EndDate;
    }
}
