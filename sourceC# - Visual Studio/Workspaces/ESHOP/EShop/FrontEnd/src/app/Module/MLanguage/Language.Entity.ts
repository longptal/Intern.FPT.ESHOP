import { IEntity } from "../IEntity.Entity";

export class LanguageEntity extends IEntity {
    Code: string = null;
    Name: string = null;
    Icon: string = null;
    IsActive: boolean = null;

    public constructor() {
        super();
    }

}