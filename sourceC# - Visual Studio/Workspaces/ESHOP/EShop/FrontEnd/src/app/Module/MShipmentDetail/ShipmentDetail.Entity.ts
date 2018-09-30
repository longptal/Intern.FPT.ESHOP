import { IEntity } from "../IEntity.Entity";
import { CountryEntity } from "../MCountry/Country.Entity";
import { CustomerEntity } from "../MCustomer/Customer.Entity";
import { CityEntity } from "../MCity/City.Entity";

export class ShipmentDetailEntity extends IEntity {
  Id: number = null;
  FullName: string = null;
  CountryId: number = null;
  CityId: number = null;
  Address: string = null;
  Phone: string = null;
  Note: string = null;
  CustomerId: number = null;
  Cx: number = null;
  CityEntity: CityEntity = null;
  CountryEntity: CountryEntity = null;
  CustomerEntity: CustomerEntity = null;

  public constructor() {
    super();
  }

}
