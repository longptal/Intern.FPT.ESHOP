import { FilterEntity } from "../FilterEntity";
export class ProductSearchEntity extends FilterEntity {
    Id: string;
    Code: string;
  Unit: string;
    CategoryId: string;
  ManufacturerId: string;
  Picture: string;

    constructor(Entity: any = null) {
        super(Entity);
      this.Id = Entity == null ? null : Entity.Id;
      this.Picture = Entity == null ? null : Entity.Picture;
        this.Code = Entity == null ? null : Entity.Code;
      this.Unit = Entity == null ? null : Entity.Unit;
        this.CategoryId = Entity == null ? null : Entity.CategoryId;
      this.ManufacturerId = Entity == null ? null : Entity.ManufacturerId;
    }
}
