import { FilterEntity } from "../FilterEntity";
export class InventorySearchEntity extends FilterEntity {
  IsDeleted: boolean;
  WareHouseId: number;
  ProductId: number;
  CreatedDate: Date;
  UpdatedDate: Date;

  constructor(InventoryEntity: any = null) {
        super(InventoryEntity);
        this.IsDeleted = InventoryEntity == null ? null : InventoryEntity.IsDeleted;
        this.WareHouseId = InventoryEntity == null ? null : InventoryEntity.WareHouseId;
        this.ProductId = InventoryEntity == null ? null : InventoryEntity.ProductId;
        this.CreatedDate = InventoryEntity == null ? null : InventoryEntity.CreatedDate;
        this.UpdatedDate = InventoryEntity == null ? null : InventoryEntity.UpdatedDate;
    }
}
