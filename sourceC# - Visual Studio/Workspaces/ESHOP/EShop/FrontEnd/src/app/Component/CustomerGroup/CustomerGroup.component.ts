import {ChangeDetectorRef, Component, OnInit, ViewContainerRef, ViewEncapsulation} from '@angular/core';
import {CustomerGroupEntity} from '../../Module/MCustomerGroup/CustomerGroup.Entity';
import {CustomerGroupSearchEntity} from '../../Module/MCustomerGroup/CustomerGroup.SearchEntity';
import {CustomerGroupService} from '../../Module/MCustomerGroup/CustomerGroup.Service';
import {BottomToastsManager} from '../../Shared/CustomToaster';
import {CommonComponent} from '../../app.component';

@Component({
  selector: 'app-CustomerGroup',
  templateUrl: './CustomerGroup.component.html',
  styleUrls: ['./CustomerGroup.component.css'],
  encapsulation: ViewEncapsulation.None,
})
export class CustomerGroupComponent extends CommonComponent<CustomerGroupEntity> implements OnInit {

  CustomerGroupSearchEntity: CustomerGroupSearchEntity = new CustomerGroupSearchEntity();

  constructor(public CustomerGroupService: CustomerGroupService, cd: ChangeDetectorRef, public toastr: BottomToastsManager, vcr: ViewContainerRef) {
    super(CustomerGroupService, cd, toastr, vcr);
    this.CustomerGroupSearchEntity = new CustomerGroupSearchEntity();
    this.Search(this.CustomerGroupSearchEntity);
  }

  ngOnInit() {

  }
}
