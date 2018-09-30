import { IEntity } from "../IEntity.Entity";
import { CityEntity } from "../MCity/City.Entity";

export class CountryEntity extends IEntity {
  Code: string = null;
  Name: string = null;
  Note: string = null;
  CityEntities: CityEntity[] = null;

  public constructor() {
    super();
  }

}
