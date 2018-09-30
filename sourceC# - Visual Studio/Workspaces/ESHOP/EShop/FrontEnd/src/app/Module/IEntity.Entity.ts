export class IEntity {
  Id: number = 0;
  IsEdit: boolean = false;
  IsSelected: boolean = false;
  IsActive: boolean = false;
  Error:any = {};
  constructor() {

  }

  Clone(Entity: IEntity): IEntity {
    return JSON.parse(JSON.stringify(Entity));
  }
  Init() {
    for (let key in this) {
      if (this.hasOwnProperty(key) && this[key.toString()] != null) {
        this.Error[key] = this[key.toString()];
      }
    }
  }
}

