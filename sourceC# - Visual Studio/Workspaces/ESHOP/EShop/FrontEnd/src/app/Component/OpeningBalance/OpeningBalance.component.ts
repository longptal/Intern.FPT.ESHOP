import {ChangeDetectorRef, Component, OnInit, ViewContainerRef, ViewEncapsulation} from '@angular/core';
import {Router} from '@angular/router';
import {BottomToastsManager} from '../../Shared/CustomToaster';
import {CommonComponent} from '../../app.component';
import {OpeningBalanceEntity} from '../../Module/MOpeningBalance/OpeningBalance.Entity';
import {OpeningBalanceSearchEntity} from '../../Module/MOpeningBalance/OpeningBalance.SearchEntity';
import {WareHouseService} from '../../Module/MWareHouse/WareHouse.Service';
import {OpeningBalanceService} from '../../Module/MOpeningBalance/OpeningBalance.Service';
import {WareHouseEntity} from '../../Module/MWareHouse/WareHouse.Entity';
import {WareHouseSearchEntity} from '../../Module/MWareHouse/WareHouse.SearchEntity';

@Component({
  selector: 'app-openingbalance',
  templateUrl: './OpeningBalance.component.html',
  styleUrls: ['./OpeningBalance.component.css'],
  encapsulation: ViewEncapsulation.None,
})
export class OpeningBalanceComponent extends CommonComponent<OpeningBalanceEntity> implements OnInit {
  OpeningBalanceSearchEntity: OpeningBalanceSearchEntity = new OpeningBalanceSearchEntity();
  WareHouseEntity: WareHouseEntity = new WareHouseEntity();
  WareHouseEntities: Array<WareHouseEntity> = [];
  WareHouseSearchEntity: WareHouseSearchEntity = new WareHouseSearchEntity();
  IsSearch: boolean = false;

  constructor(public OpeningBalanceService: OpeningBalanceService,
              public WareHouseService: WareHouseService,
              private Router: Router,
              cd: ChangeDetectorRef, public toastr: BottomToastsManager,
              public vcr: ViewContainerRef) {

    super(OpeningBalanceService, cd, toastr, vcr);

  }

  ngOnInit() {

  }


}
