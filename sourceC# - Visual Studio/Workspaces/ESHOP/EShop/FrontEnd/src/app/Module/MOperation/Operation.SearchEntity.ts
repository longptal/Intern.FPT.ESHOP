import { FilterEntity } from "../FilterEntity";
export class OperationSearchEntity extends FilterEntity {
    Path: string;
    Method: string;

    constructor(Entity: any = null) {
        super(Entity);
        this.Path = Entity == null ? null : Entity.Path;
        this.Method = Entity == null ? null : Entity.Method;
    }
}
