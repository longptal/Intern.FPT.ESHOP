import { FilterEntity } from "../FilterEntity";
export class TaxSearchEntity extends FilterEntity {
    Id: string;
    Code: string;
    Percentage: number;
    Cx: number;
    constructor(Entity: any = null) {
        super(Entity);
        this.Id = Entity == null ? null : Entity.Id;
        this.Cx = Entity == null ? null : Entity.Cx;
        this.Code = Entity == null ? null : Entity.Code;
        this.Percentage = Entity == null ? null : Entity.Percentage;
    }
}
