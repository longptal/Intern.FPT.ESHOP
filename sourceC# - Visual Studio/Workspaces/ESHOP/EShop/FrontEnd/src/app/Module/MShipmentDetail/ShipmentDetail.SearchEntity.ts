import { FilterEntity } from "../FilterEntity";

export class ShipmentDetailSearchEntity extends FilterEntity {
  Id: string = null;
  FullName: string = null;
  CountryId: string = null;
  CityId: string = null;
  Address: string = null;
  Phone: string = null;
  Note: string = null;
  CustomerId: string = null;
  constructor(Entity: any = null) {
    super(Entity);
    this.Id = Entity == null ? null : Entity.Id;
    this.FullName = Entity == null ? null : Entity.FullName;
    this.CountryId = Entity == null ? null : Entity.CountryId;
    this.CityId = Entity == null ? null : Entity.CityId;
    this.Address = Entity == null ? null : Entity.Address;
    this.Phone = Entity == null ? null : Entity.Phone;
    this.Note = Entity == null ? null : Entity.Note;
    this.CustomerId = Entity == null ? null : Entity.CustomerId;
  }
}
