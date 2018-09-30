import { Component, OnInit, ViewEncapsulation, ViewContainerRef, ChangeDetectorRef } from '@angular/core';
import { CommonComponent } from '../../../app.component';
import { WareHouseService } from '../../../Module/MWareHouse/WareHouse.Service';
import { ReceiptNoteService } from '../../../Module/MReceiptNote/ReceiptNote.Service';
import { BottomToastsManager } from '../../../Shared/CustomToaster';
import { SupplierService } from '../../../Module/MSupplier/Supplier.Service';
import { ActivatedRoute } from '@angular/router';
import { IssueNoteEntity } from "../../../Module/MIssueNote/IssueNote.Entity";
import { IssueNoteService } from "../../../Module/MIssueNote/IssueNote.Service";


@Component({
  selector: "app-IssueNoteDetail",
  templateUrl: "./IssueNoteDetail.component.html",
  styleUrls: ["./IssueNoteDetail.component.css"],
  encapsulation: ViewEncapsulation.None,
})
export class IssueNoteDetailComponent extends CommonComponent<IssueNoteEntity> implements OnInit {
  public IssueNoteId: number = 0;
  constructor(public IssueNoteService: IssueNoteService, cd: ChangeDetectorRef, toastr: BottomToastsManager, vcr: ViewContainerRef,
    public SupplierService: SupplierService, public WareHouseService: WareHouseService, public route: ActivatedRoute) {

    super(IssueNoteService, cd, toastr, vcr);

    this.route.params.subscribe((params) => {
      if (params.ReceiptNoteId !== undefined) {
        this.IssueNoteId = params.ReceiptNoteId;
        this.GetId(this.IssueNoteId);
      }
    });
  }
  ngOnInit() {

  }
}
