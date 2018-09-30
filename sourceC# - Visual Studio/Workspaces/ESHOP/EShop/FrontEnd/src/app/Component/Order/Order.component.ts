import {ChangeDetectorRef, Component, OnInit, ViewContainerRef, ViewEncapsulation} from '@angular/core';
import {OrderEntity} from '../../Module/MOrder/Order.Entity';
import {OrderService} from '../../Module/MOrder/Order.Service';
import {BottomToastsManager} from '../../Shared/CustomToaster';
import {CommonComponent} from '../../app.component';
import { CustomerService } from '../../Module/MCustomer/Customer.Service';
import { ShipmentDetailService } from '../../Module/MShipmentDetail/ShipmentDetail.Service';
import { OrderSearchEntity } from '../../Module/MOrder/Order.SearchEntity';


@Component({
  selector: 'app-Order',
  templateUrl: './Order.component.html',
  styleUrls: ['./Order.component.css'],
  encapsulation: ViewEncapsulation.None,
})
export class OrderComponent extends CommonComponent<OrderEntity> implements OnInit {
  public SearchEntity: OrderSearchEntity = new OrderSearchEntity();
  constructor(cd: ChangeDetectorRef, OrderService: OrderService, toastr: BottomToastsManager, vcr: ViewContainerRef,
    public CustomerService: CustomerService, public ShipmentDetailService: ShipmentDetailService) {

    super(OrderService, cd, toastr, vcr);
    this.Search(this.SearchEntity);
  }

  ngOnInit() {

  }
}
