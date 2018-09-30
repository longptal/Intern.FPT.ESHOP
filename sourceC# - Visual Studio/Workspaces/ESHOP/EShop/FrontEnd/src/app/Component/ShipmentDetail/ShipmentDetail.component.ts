import {ChangeDetectorRef, Component, OnInit, ViewContainerRef, ViewEncapsulation} from '@angular/core';
import {ShipmentDetailEntity} from '../../Module/MShipmentDetail/ShipmentDetail.Entity';
import {ShipmentDetailSearchEntity} from '../../Module/MShipmentDetail/ShipmentDetail.SearchEntity';
import {ShipmentDetailService} from '../../Module/MShipmentDetail/ShipmentDetail.Service';
import {BottomToastsManager} from '../../Shared/CustomToaster';
import {CommonComponent} from '../../app.component';
import {CityService} from '../../Module/MCity/City.Service';
import {CountryService} from '../../Module/MCountry/Country.Service';
import { CustomerService } from '../../Module/MCustomer/Customer.Service';

@Component({
  selector: 'app-ShipmentDetail',
  templateUrl: './ShipmentDetail.component.html',
  styleUrls: ['./ShipmentDetail.component.css'],
  encapsulation: ViewEncapsulation.None,
})
export class ShipmentDetailComponent extends CommonComponent<ShipmentDetailEntity> implements OnInit {
  SearchEntity: ShipmentDetailSearchEntity = null;

  constructor(cd: ChangeDetectorRef, public ShipmentDetailService: ShipmentDetailService, public toastr: BottomToastsManager,
    vcr: ViewContainerRef, public CityService: CityService, public CountryService: CountryService, public CustomerService:CustomerService) {
    super(ShipmentDetailService, cd, toastr, vcr);
    this.SearchEntity = new ShipmentDetailSearchEntity();
    this.Search(this.SearchEntity);
  }

  ngOnInit() {

  }
}
