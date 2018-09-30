import {ChangeDetectorRef, Component, OnInit, ViewContainerRef, ViewEncapsulation} from '@angular/core';
import {CommonComponent} from '../../../app.component';
import {WareHouseService} from '../../../Module/MWareHouse/WareHouse.Service';
import {OrderService} from '../../../Module/MOrder/Order.Service';
import {BottomToastsManager} from '../../../Shared/CustomToaster';
import {SupplierService} from '../../../Module/MSupplier/Supplier.Service';
import {OrderEntity} from '../../../Module/MOrder/Order.Entity';
import {ActivatedRoute} from '@angular/router';


@Component({
  selector: 'app-OrderDetail',
  templateUrl: './OrderDetail.component.html',
  styleUrls: ['./OrderDetail.component.css'],
  encapsulation: ViewEncapsulation.None,
})
export class OrderDetailComponent extends CommonComponent<OrderEntity> implements OnInit {
  public OrderId: number = 0;

  constructor(cd: ChangeDetectorRef, public OrderService: OrderService, toastr: BottomToastsManager, vcr: ViewContainerRef,
              public SupplierService: SupplierService, public WareHouseService: WareHouseService, public route: ActivatedRoute) {

    super(OrderService, cd, toastr, vcr);

    this.route.params.subscribe((params) => {

      if (params.OrderId !== undefined) {
        this.OrderId = params.OrderId;
        this.GetId(this.OrderId);
      }
    });
  }

  ngOnInit() {

  }
}
