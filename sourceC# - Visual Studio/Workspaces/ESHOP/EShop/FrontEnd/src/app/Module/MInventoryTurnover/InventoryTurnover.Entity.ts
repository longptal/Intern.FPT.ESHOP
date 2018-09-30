import { IEntity } from "../IEntity.Entity";
import { IssueNoteEntity } from "../MIssueNote/IssueNote.Entity";
import { ReceiptNoteEntity } from "../MReceiptNote/ReceiptNote.Entity";

export class InventoryTurnoverEntity extends IEntity {
  Id: number = 0;
  IssueNoteId: number = 0;
  ReceiptNoteId: number = 0;
  CreatedDate: Date = null;
  UpdatedDate: Date = null;
  IsDeleted: boolean;
  IssueNoteEntity: IssueNoteEntity = null;
  ReceiptNoteEntity: ReceiptNoteEntity = null;
  public constructor() {
    super();
  }

}
