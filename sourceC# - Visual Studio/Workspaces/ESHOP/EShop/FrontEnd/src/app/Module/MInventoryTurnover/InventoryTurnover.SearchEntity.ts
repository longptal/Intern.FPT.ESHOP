import { FilterEntity } from "../FilterEntity";

export class InventoryTurnoverSearchEntity extends FilterEntity {
  IssueNoteId: number = 0;
  ReceiptNoteId: number = 0;
  CreatedDate: Date = null;
  UpdatedDate: Date = null;
  IsDeleted: boolean;
  constructor(Entity: any = null) {
    super(Entity);
    this.IssueNoteId = Entity == null ? null : Entity.IssueNoteId;
    this.ReceiptNoteId = Entity == null ? null : Entity.ReceiptNoteId;
    this.IsDeleted = Entity == null ? null : Entity.IsDeleted;
  }
}
