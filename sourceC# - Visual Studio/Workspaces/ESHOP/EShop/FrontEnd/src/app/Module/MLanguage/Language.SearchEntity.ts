import { FilterEntity } from "../FilterEntity";
export class LanguageSearchEntity extends FilterEntity {
    Code: string;
    Name: string;

    constructor(Entity: any = null) {
        super(Entity);
        this.Code = Entity == null ? null : Entity.Code;
        this.Name = Entity == null ? null : Entity.Name;
    }
}
