import { FilterEntity } from "../FilterEntity";

export class IssueNoteSearchEntity extends FilterEntity {
    Id: number = null;
    InventoryId: number = null;
    SupplierId: number = null;
    WareHouseId: number = null;
    Quantity: string = null;
    UnitPrice: number = null;
    constructor(IssueNote: any = null) {
      super(IssueNote);
      this.Id = IssueNote == null ? null : IssueNote.Id;
      this.InventoryId = IssueNote == null ? null : IssueNote.InventoryId;
      this.SupplierId = IssueNote == null ? null : IssueNote.SupplierId;
      this.WareHouseId = IssueNote == null ? null : IssueNote.WareHouseId;
      this.Quantity = IssueNote == null ? null : IssueNote.Quantity;
      this.UnitPrice = IssueNote == null ? null : IssueNote.UnitPrice;
    }
}
