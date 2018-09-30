import {ChangeDetectorRef, Component, OnInit, ViewContainerRef, ViewEncapsulation} from '@angular/core';
import {SupplierEntity} from '../../Module/MSupplier/Supplier.Entity';
import {SupplierSearchEntity} from '../../Module/MSupplier/Supplier.SearchEntity';
import {SupplierService} from '../../Module/MSupplier/Supplier.Service';
import {BottomToastsManager} from '../../Shared/CustomToaster';
import {CommonComponent} from '../../app.component';

@Component({
  selector: 'app-Supplier',
  templateUrl: './Supplier.component.html',
  styleUrls: ['./Supplier.component.css'],
  encapsulation: ViewEncapsulation.None,
})
export class SupplierComponent extends CommonComponent<SupplierEntity> implements OnInit {
  SupplierSearchEntity: SupplierSearchEntity = new SupplierSearchEntity();

  constructor(public SupplierService: SupplierService, cd: ChangeDetectorRef, toastr: BottomToastsManager, vcr: ViewContainerRef) {
    super(SupplierService, cd, toastr, vcr);
    this.Search(this.SupplierSearchEntity);
  }

  ngOnInit() {

  }
}
