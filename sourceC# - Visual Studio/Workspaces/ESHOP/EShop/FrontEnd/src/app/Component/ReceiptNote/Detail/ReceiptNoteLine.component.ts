import {ChangeDetectorRef, Component, OnInit, ViewContainerRef, ViewEncapsulation} from '@angular/core';
import {CommonComponent} from '../../../app.component';
import {WareHouseService} from '../../../Module/MWareHouse/WareHouse.Service';
import {BottomToastsManager} from '../../../Shared/CustomToaster';
import {SupplierService} from '../../../Module/MSupplier/Supplier.Service';
import {ActivatedRoute} from '@angular/router';
import {ReceiptNoteLineEntity} from '../../../Module/MReceiptNoteLine/ReceiptNoteLine.Entity';
import {ReceiptNoteLineSearchEntity} from '../../../Module/MReceiptNoteLine/ReceiptNoteLine.SearchEntity';
import {ReceiptNoteLineService} from '../../../Module/MReceiptNoteLine/ReceiptNoteLine.Service';


@Component({
  selector: 'app-ReceiptNoteLine',
  templateUrl: './ReceiptNoteLine.component.html',
  styleUrls: ['./ReceiptNoteLine.component.css'],
  encapsulation: ViewEncapsulation.None,
})
export class ReceiptNoteLineComponent extends CommonComponent<ReceiptNoteLineEntity> implements OnInit {
  public ReceiptNoteId: number = 0;
  public FilterEntity: ReceiptNoteLineSearchEntity = new ReceiptNoteLineSearchEntity();

  constructor(public ReceiptNoteLineService: ReceiptNoteLineService, cd: ChangeDetectorRef,  toastr: BottomToastsManager, vcr: ViewContainerRef,
              public SupplierService: SupplierService, public WareHouseService: WareHouseService, public route: ActivatedRoute) {

    super(ReceiptNoteLineService, cd, toastr, vcr);

    this.route.params.subscribe((params) => {

      if (params.ReceiptNoteId !== undefined) {
        this.ReceiptNoteId = params.ReceiptNoteId;
        this.FilterEntity.ReceiptNoteId = this.ReceiptNoteId;
        this.Search(this.FilterEntity);
      }
    });
  }

  ngOnInit() {

  }

  AddNewRow() {
    let a = new ReceiptNoteLineEntity();
    a.IsEdit = true;
    console.log(a);
    this.Entities.push(a);
  }
}
