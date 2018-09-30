import { IEntity } from "../IEntity.Entity";

export class IntroductionEntity extends IEntity {
    Code: string = null;
    Name: string = null;
    ParentId: number = null;
    Content: string = null;
    Route: string = null;

    public constructor() {
        super();
    }

}