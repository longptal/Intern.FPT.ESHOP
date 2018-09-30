import {ChangeDetectorRef, Component, OnInit, ViewContainerRef, ViewEncapsulation} from '@angular/core';
import {CustomerEntity} from '../../Module/MCustomer/Customer.Entity';
import {CustomerSearchEntity} from '../../Module/MCustomer/Customer.SearchEntity';
import {CustomerService} from '../../Module/MCustomer/Customer.Service';
import {BottomToastsManager} from '../../Shared/CustomToaster';
import {CommonComponent} from '../../app.component';
import {CustomerGroupService} from '../../Module/MCustomerGroup/CustomerGroup.Service';

@Component({
  selector: 'app-Customer',
  templateUrl: './Customer.component.html',
  styleUrls: ['./Customer.component.css'],
  encapsulation: ViewEncapsulation.None,
})
export class CustomerComponent extends CommonComponent<CustomerEntity> implements OnInit {

  CustomerSearchEntity: CustomerSearchEntity = new CustomerSearchEntity();

  constructor(public CustomerService: CustomerService, cd: ChangeDetectorRef, public toastr: BottomToastsManager, vcr: ViewContainerRef, public CustomerGroupService: CustomerGroupService) {
    super(CustomerService, cd, toastr, vcr);
    this.CustomerSearchEntity = new CustomerSearchEntity();
    this.Search(this.CustomerSearchEntity);
  }

  ngOnInit() {

  }
}
