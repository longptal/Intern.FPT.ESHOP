import { IEntity } from "../IEntity.Entity";
import { ReceiptNoteEntity } from "../MReceiptNote/ReceiptNote.Entity";

export class SupplierEntity extends IEntity {
  Id: number = null;
  Address: string = null;
  Phone: string = null;
  Origin: string = null;
  IsActive: boolean = null;
  Cx: number = null;
  Code: string = null;
  Name: string = null;
  TaxCode: string = null;
  Description: string = null;
  ReceiptNoteEntities: Array<ReceiptNoteEntity> = [];
    public constructor() {
        super();
    }
}


