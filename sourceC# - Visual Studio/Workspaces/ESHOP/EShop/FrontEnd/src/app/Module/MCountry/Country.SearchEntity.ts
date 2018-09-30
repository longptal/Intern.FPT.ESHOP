import { FilterEntity } from "../FilterEntity";

export class CountrySearchEntity extends FilterEntity {
  Code: string = null;
  Name: string = null;
  Note: string = null;
  constructor(Entity: any = null) {
    super(Entity);
    this.Code = Entity == null ? null : Entity.Code;
    this.Name = Entity == null ? null : Entity.Name;
    this.Note = Entity == null ? null : Entity.Note;
  }
}
