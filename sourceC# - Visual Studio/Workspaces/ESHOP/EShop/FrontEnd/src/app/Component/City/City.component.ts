import {ChangeDetectorRef, Component, OnInit, ViewContainerRef, ViewEncapsulation} from '@angular/core';
import {CityEntity} from '../../Module/MCity/City.Entity';
import {CitySearchEntity} from '../../Module/MCity/City.SearchEntity';
import {CityService} from '../../Module/MCity/City.Service';
import {BottomToastsManager} from '../../Shared/CustomToaster';
import {CommonComponent} from '../../app.component';
import {CountryService} from '../../Module/MCountry/Country.Service';

@Component({
  selector: 'app-city',
  templateUrl: './City.component.html',
  styleUrls: ['./City.component.css'],
  encapsulation: ViewEncapsulation.None,
})
export class CityComponent extends CommonComponent<CityEntity> implements OnInit {
  SearchEntity: CitySearchEntity = new CitySearchEntity();

  constructor(public CityService: CityService, cd: ChangeDetectorRef,
              public toastr: BottomToastsManager, vcr: ViewContainerRef, public CountryService: CountryService) {
    super(CityService, cd, toastr, vcr);
    this.SearchEntity = new CitySearchEntity();
    this.Search(this.SearchEntity);
  }

  ngOnInit() {

  }
}
