import { Component, OnInit, ViewEncapsulation, ViewContainerRef, ChangeDetectorRef } from '@angular/core';
import { CommonComponent } from '../../../app.component';
import { WareHouseService } from '../../../Module/MWareHouse/WareHouse.Service';
import { ReceiptNoteService } from '../../../Module/MReceiptNote/ReceiptNote.Service';
import { BottomToastsManager } from '../../../Shared/CustomToaster';
import { SupplierService } from '../../../Module/MSupplier/Supplier.Service';
import { ReceiptNoteEntity } from '../../../Module/MReceiptNote/ReceiptNote.Entity';
import { ActivatedRoute } from '@angular/router';
import { StockTransferEntity } from "../../../Module/MStockTransfer/StockTransfer.Entity";
import { StockTransferService } from "../../../Module/MStockTransfer/StockTransfer.Service";


@Component({
  selector: "app-StockTransferDetail",
  templateUrl: "./StockTransferDetail.component.html",
  styleUrls: ["./StockTransferDetail.component.css"],
  encapsulation: ViewEncapsulation.None,
})
export class StockTransferDetailComponent extends CommonComponent<StockTransferEntity> implements OnInit {
  public StockTransferId: number = 0;
  constructor(public StockTransferService: StockTransferService, cd: ChangeDetectorRef, toastr: BottomToastsManager, vcr: ViewContainerRef,
    public SupplierService: SupplierService, public WareHouseService: WareHouseService, public route: ActivatedRoute) {

    super(StockTransferService, cd, toastr, vcr);

    this.route.params.subscribe((params) => {

      if (params.StockTransferId !== undefined) {
        this.StockTransferId = params.StockTransferId;
        this.GetId(this.StockTransferId);
      }
    });
  }
  ngOnInit() {

  }
}
