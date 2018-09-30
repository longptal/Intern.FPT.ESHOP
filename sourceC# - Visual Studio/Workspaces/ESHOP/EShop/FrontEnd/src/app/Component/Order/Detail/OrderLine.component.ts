import {ChangeDetectorRef, Component, OnInit, ViewContainerRef, ViewEncapsulation, Input} from '@angular/core';
import {CommonComponent} from '../../../app.component';
import {WareHouseService} from '../../../Module/MWareHouse/WareHouse.Service';
import {BottomToastsManager} from '../../../Shared/CustomToaster';
import {SupplierService} from '../../../Module/MSupplier/Supplier.Service';
import {ActivatedRoute} from '@angular/router';
import {OrderLineEntity} from '../../../Module/MOrderLine/OrderLine.Entity';
import {OrderLineSearchEntity} from '../../../Module/MOrderLine/OrderLine.SearchEntity';
import {OrderLineService} from '../../../Module/MOrderLine/OrderLine.Service';
import { TaxService } from '../../../Module/MTax/Tax.Service';


@Component({
  selector: 'app-OrderLine',
  templateUrl: './OrderLine.component.html',
  styleUrls: ['./OrderLine.component.css'],
  encapsulation: ViewEncapsulation.None,
})
export class OrderLineComponent extends CommonComponent<OrderLineEntity> implements OnInit {
  public FilterEntity: OrderLineSearchEntity = new OrderLineSearchEntity();
  @Input() OrderId: number;
  constructor(cd: ChangeDetectorRef, public OrderLineService: OrderLineService, toastr: BottomToastsManager, vcr: ViewContainerRef, TaxService: TaxService,
              public SupplierService: SupplierService, public WareHouseService: WareHouseService, public route: ActivatedRoute) {

    super(OrderLineService, cd, toastr, vcr);

    this.route.params.subscribe((params) => {

      if (params.OrderId !== undefined) {
        this.OrderId = params.OrderId;
        this.FilterEntity.OrderId = this.OrderId;
        this.Search(this.FilterEntity);
      }
    });
  }

  ngOnInit() {

  }
}
