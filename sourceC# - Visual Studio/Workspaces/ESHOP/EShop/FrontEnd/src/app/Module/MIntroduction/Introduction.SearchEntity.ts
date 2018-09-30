import { FilterEntity } from "../FilterEntity";
export class IntroductionSearchEntity extends FilterEntity {
    Id: string;
    Content: string;
    Route: string
    constructor(Entity: any = null) {
        super(Entity);
        this.Id = Entity == null ? null : Entity.Id;
        this.Content = Entity == null ? null : Entity.Content;
        this.Route = Entity == null ? null : Entity.Route;
    }
}
