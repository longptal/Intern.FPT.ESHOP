import { FilterEntity } from "../FilterEntity";

export class CitySearchEntity extends FilterEntity {
  Code: string = null;
  Name: string = null;
  CountryId: number = null;
  constructor(Entity: any = null) {
    super(Entity);
    this.Code = Entity == null ? null : Entity.Code;
    this.Name = Entity == null ? null : Entity.Name;
    this.CountryId = Entity == null ? null : Entity.CountryId;
  }
}
