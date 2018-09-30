import { FilterEntity } from "../FilterEntity";

export class ReceiptNoteSearchEntity extends FilterEntity {
  Id: string;
  SupplierId: string;
  WareHouseId: string;
  EmployeeId: string;
  InvoiceDate: Date;
  Lock: boolean;
  Title: string;
  CreatedDate: Date;
  UpdatedDate: Date;
  ReceiptNoteNo: number;
  ReceiptDate: Date;
  SystemDate: Date;
  Address: string;
  PhoneNumber: string;
  Comment: string;
    constructor(ReceiptNote: any = null) {
      super(ReceiptNote);
      this.Id = ReceiptNote == null ? null : ReceiptNote.Id;
      this.WareHouseId = ReceiptNote == null ? null : ReceiptNote.WareHouseId;
      this.SupplierId = ReceiptNote == null ? null : ReceiptNote.SupplierId;
      this.EmployeeId = ReceiptNote == null ? null : ReceiptNote.EmployeeId;
      this.Lock = ReceiptNote == null ? null : ReceiptNote.Lock;
      this.Title = ReceiptNote == null ? null : ReceiptNote.Title;
      this.ReceiptNoteNo = ReceiptNote == null ? null : ReceiptNote.ReceiptNoteNo;
      this.InvoiceDate = ReceiptNote == null ? null : ReceiptNote.InvoiceDate;
      this.CreatedDate = ReceiptNote == null ? null : ReceiptNote.CreatedDate;
      this.UpdatedDate = ReceiptNote == null ? null : ReceiptNote.UpdatedDate;
      this.ReceiptDate = ReceiptNote == null ? null : ReceiptNote.ReceiptDate;
      this.SystemDate = ReceiptNote == null ? null : ReceiptNote.SystemDate;
      this.Address = ReceiptNote == null ? null : ReceiptNote.Address;
      this.PhoneNumber = ReceiptNote == null ? null : ReceiptNote.PhoneNumber;
      this.Comment = ReceiptNote == null ? null : ReceiptNote.Comment;

    }
}
