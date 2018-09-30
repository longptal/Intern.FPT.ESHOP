import {ChangeDetectorRef, Component, OnInit, ViewContainerRef, ViewEncapsulation} from '@angular/core';
import {BottomToastsManager} from '../../Shared/CustomToaster';
import {CommonComponent} from '../../app.component';
import {ManufacturerEntity} from '../../Module/MManufacturer/Manufacturer.Entity';
import {ManufacturerSearchEntity} from '../../Module/MManufacturer/Manufacturer.SearchEntity';
import {ManufacturerService} from '../../Module/MManufacturer/Manufacturer.Service';

@Component({
  selector: 'app-Manufacturer',
  templateUrl: './Manufacturer.component.html',
  styleUrls: ['./Manufacturer.component.css'],
  encapsulation: ViewEncapsulation.None,
})
export class ManufacturerComponent extends CommonComponent<ManufacturerEntity> implements OnInit {
  ManufacturerSearchEntity: ManufacturerSearchEntity = new ManufacturerSearchEntity();

  constructor(cd: ChangeDetectorRef, public ManufacturerService: ManufacturerService, toastr: BottomToastsManager, vcr: ViewContainerRef) {
    super(ManufacturerService, cd, toastr, vcr);
    this.Search(this.ManufacturerSearchEntity);
  }

  ngOnInit() {

  }
}
