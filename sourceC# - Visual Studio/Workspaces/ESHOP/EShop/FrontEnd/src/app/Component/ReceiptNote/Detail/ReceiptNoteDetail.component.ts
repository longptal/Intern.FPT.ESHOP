import { Component, OnInit, ViewEncapsulation, ViewContainerRef, ChangeDetectorRef } from '@angular/core';
import { CommonComponent } from '../../../app.component';
import { WareHouseService } from '../../../Module/MWareHouse/WareHouse.Service';
import { ReceiptNoteService } from '../../../Module/MReceiptNote/ReceiptNote.Service';
import { BottomToastsManager } from '../../../Shared/CustomToaster';
import { SupplierService } from '../../../Module/MSupplier/Supplier.Service';
import { ReceiptNoteEntity } from '../../../Module/MReceiptNote/ReceiptNote.Entity';
import { ActivatedRoute } from '@angular/router';


@Component({
  selector: "app-ReceiptNoteDetail",
  templateUrl: "./ReceiptNoteDetail.component.html",
  styleUrls: ["./ReceiptNoteDetail.component.css"],
  encapsulation: ViewEncapsulation.None,
})
export class ReceiptNoteDetailComponent extends CommonComponent<ReceiptNoteEntity> implements OnInit {
  public ReceiptNoteId: number = 0;
  constructor(public ReceiptNoteService: ReceiptNoteService, cd: ChangeDetectorRef, toastr: BottomToastsManager, vcr: ViewContainerRef,
    public SupplierService: SupplierService, public WareHouseService: WareHouseService, public route: ActivatedRoute) {

    super(ReceiptNoteService, cd, toastr, vcr);

    this.route.params.subscribe((params) => {

      if (params.ReceiptNoteId !== undefined) {
        this.ReceiptNoteId = params.ReceiptNoteId;
        this.GetId(this.ReceiptNoteId);
      }
    });
  }
  ngOnInit() {

  }
}
