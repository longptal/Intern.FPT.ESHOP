import { IEntity } from "../IEntity.Entity";

export class CouponEntity extends IEntity {
    Code: string = null;
    Name: string = null;
    ParentId: number = null;
    StartDate: Date = null;
    EndDate: Date = null;

    public constructor() {
        super();
    }

}