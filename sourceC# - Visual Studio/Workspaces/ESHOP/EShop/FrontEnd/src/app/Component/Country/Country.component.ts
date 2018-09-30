import {ChangeDetectorRef, Component, OnInit, ViewContainerRef, ViewEncapsulation} from '@angular/core';
import {CountryEntity} from '../../Module/MCountry/Country.Entity';
import {CountrySearchEntity} from '../../Module/MCountry/Country.SearchEntity';
import {CountryService} from '../../Module/MCountry/Country.Service';
import {BottomToastsManager} from '../../Shared/CustomToaster';
import {CommonComponent} from '../../app.component';

@Component({
  selector: 'app-country',
  templateUrl: './Country.component.html',
  styleUrls: ['./Country.component.css'],
  encapsulation: ViewEncapsulation.None,
})
export class CountryComponent extends CommonComponent<CountryEntity> implements OnInit {
  SearchEntity: CountrySearchEntity = new CountrySearchEntity();

  constructor(public CountryService: CountryService, cd: ChangeDetectorRef,public toastr: BottomToastsManager, vcr: ViewContainerRef) {
    super(CountryService, cd, toastr, vcr);
    this.SearchEntity = new CountrySearchEntity();
    this.Search(this.SearchEntity);
  }

  ngOnInit() {

  }
}
