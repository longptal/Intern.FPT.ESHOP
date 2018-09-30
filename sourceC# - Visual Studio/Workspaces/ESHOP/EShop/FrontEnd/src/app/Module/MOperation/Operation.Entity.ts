import { IEntity } from "../IEntity.Entity";

export class OperationEntity extends IEntity {
    Code: string = null;
    Name: string = null;
    ParentId: number = null;
    Path: string = null;
    Method: string = null;

    public constructor() {
        super();
    }

}