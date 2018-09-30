import { IEntity } from "../IEntity.Entity";

export class CategoryEntity extends IEntity {
    Code: string = null;
    ParentId: number = null;
    ParentEntity: CategoryEntity = null;
    Names: { [Id: number]: string; } = {}; 
    public constructor() {
        super();
    }
}
