import { IEntity } from "../IEntity.Entity";

export class TaxEntity extends IEntity {
    Id: number = null;
    Code: string = null;
    Cx: number = null;
    Percentage: number = null;
    public constructor() {
        super();
    }

}

