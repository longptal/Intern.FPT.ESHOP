import { IEntity } from "../IEntity.Entity";
import { PriceListEntity } from "../MPriceList/PriceList.Entity";
import { InventoryEntity } from "../MInventory/Inventory.Entity";
import { PackEntity } from "../MPack/Pack.Entity";
import { DiscountEntity } from "../MDiscount/Discount.Entity";
import { CategoryEntity } from "../MCategory/Category.Entity";
import { ManufacturerEntity } from "../MManufacturer/Manufacturer.Entity";
import { IssueNoteLineEntity } from "../MIssueNoteLine/IssueNoteLine.Entity";
import { ProductPictureEntity } from "../MProductPicture/ProductPicture.Entity";
import { ProductValueEntity } from "../MProductValue/ProductValue.Entity";
import { ReceiptNoteLineEntity } from "../MReceiptNoteLine/ReceiptNoteLine.Entity";

export class ProductEntity extends IEntity {
    Id: number = null;
    Code: string = null;
    CategoryId: string = null;
  Unit: string = null;
  Picture: string = null;
  ManufacturerId: string = null;
  Cx: number = null;

  CategoryEntity: CategoryEntity = null;
  ManufacturerEntity: ManufacturerEntity = null;
  InventoryEntities: InventoryEntity[] = [];
    PackEntities: PackEntity[] = [];
    DiscountEntities: DiscountEntity[] = [];
  IssueNoteLineEntities: IssueNoteLineEntity[] = [];
  ProductPictureEntities: ProductPictureEntity[] = [];
  ProductValueEntities: ProductValueEntity[] = [];
  ReceiptNoteLineEntities: ReceiptNoteLineEntity[] = [];

    public constructor() {
        super();
    }

}
export class ExtraEntity {
    Id: number = null;
    Code: string = null;
    Name: string = null;
    Value: string = null;
}

