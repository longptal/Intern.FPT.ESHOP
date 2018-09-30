import { IEntity } from "../IEntity.Entity";
import { CountryEntity } from "../MCountry/Country.Entity";

export class CityEntity extends IEntity {
  Code: string = null;
  Name: string = null;
  CountryId: number = null;
  CountryEntity: CountryEntity = null;
  public constructor() {
    super();
  }

}
