import {ChangeDetectorRef, Component, OnInit, ViewContainerRef, ViewEncapsulation} from '@angular/core';
import {CommonComponent} from '../../../app.component';
import {WareHouseService} from '../../../Module/MWareHouse/WareHouse.Service';
import {BottomToastsManager} from '../../../Shared/CustomToaster';
import {SupplierService} from '../../../Module/MSupplier/Supplier.Service';
import {ActivatedRoute} from '@angular/router';
import {ReceiptNoteLineEntity} from '../../../Module/MReceiptNoteLine/ReceiptNoteLine.Entity';
import {ReceiptNoteLineSearchEntity} from '../../../Module/MReceiptNoteLine/ReceiptNoteLine.SearchEntity';
import {ReceiptNoteLineService} from '../../../Module/MReceiptNoteLine/ReceiptNoteLine.Service';
import { StockTransferLineEntity } from "../../../Module/MStockTransferLine/StockTransferLine.Entity";
import { StockTransferLineSearchEntity } from "../../../Module/MStockTransferLine/StockTransferLine.SearchEntity";
import { StockTransferLineService } from "../../../Module/MStockTransferLine/StockTransferLine.Service";


@Component({
  selector: 'app-StockTransferLine',
  templateUrl: './StockTransferLine.component.html',
  styleUrls: ['./StockTransferLine.component.css'],
  encapsulation: ViewEncapsulation.None,
})
export class StockTransferLineComponent extends CommonComponent<StockTransferLineEntity> implements OnInit {
  public StockTransferId: number = 0;
  public FilterEntity: StockTransferLineSearchEntity = new StockTransferLineSearchEntity();

  constructor(public StockTransferLineService: StockTransferLineService, cd: ChangeDetectorRef,  toastr: BottomToastsManager, vcr: ViewContainerRef,
              public SupplierService: SupplierService, public WareHouseService: WareHouseService, public route: ActivatedRoute) {

    super(StockTransferLineService, cd, toastr, vcr);

    this.route.params.subscribe((params) => {

      if (params.StockTransferId !== undefined) {
        this.StockTransferId = params.StockTransferId;
        this.FilterEntity.StockTransferId = this.StockTransferId;
        this.Search(this.FilterEntity);
      }
    });
  }

  ngOnInit() {

  }
}
