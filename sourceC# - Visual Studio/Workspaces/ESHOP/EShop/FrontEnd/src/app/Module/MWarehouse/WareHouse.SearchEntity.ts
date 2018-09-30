import { FilterEntity } from "../FilterEntity";

export class WareHouseSearchEntity extends FilterEntity {
    Id: string;
    Name: string;
    Code: string;
    IsDefault: boolean;
    StorageLocation: string;
    StockkeeperId: string;
    constructor(Entity: any = null) {
      super(Entity);
      this.Id = Entity == null ? null : Entity.Id;
      this.Name = Entity == null ? null : Entity.Name;
      this.Code = Entity == null ? null : Entity.Code;
      this.IsDefault = Entity == null ? null : Entity.IsDefault;
      this.StorageLocation = Entity == null ? null : Entity.StorageLocation;
      this.StockkeeperId = Entity == null ? null : Entity.StockkeeperId;
    }
}
