import {ChangeDetectorRef, Component, OnInit, ViewContainerRef, ViewEncapsulation} from '@angular/core';
import {ReceiptNoteEntity} from '../../Module/MReceiptNote/ReceiptNote.Entity';
import {ReceiptNoteService} from '../../Module/MReceiptNote/ReceiptNote.Service';
import {BottomToastsManager} from '../../Shared/CustomToaster';
import {SupplierService} from '../../Module/MSupplier/Supplier.Service';
import {WareHouseService} from '../../Module/MWareHouse/WareHouse.Service';
import {InventoryService} from '../../Module/MInventory/Inventory.Service';
import {CommonComponent} from '../../app.component';


@Component({
  selector: 'app-ReceiptNote',
  templateUrl: './ReceiptNote.component.html',
  styleUrls: ['./ReceiptNote.component.css'],
  encapsulation: ViewEncapsulation.None,
})
export class ReceiptNoteComponent extends CommonComponent<ReceiptNoteEntity> implements OnInit {
  constructor(cd: ChangeDetectorRef, ReceiptNoteService: ReceiptNoteService, toastr: BottomToastsManager, vcr: ViewContainerRef,
              public SupplierService: SupplierService, public WareHouseService: WareHouseService, public InventoryService: InventoryService,) {

    super(ReceiptNoteService, cd, toastr, vcr);
  }

  ngOnInit() {

  }
}
