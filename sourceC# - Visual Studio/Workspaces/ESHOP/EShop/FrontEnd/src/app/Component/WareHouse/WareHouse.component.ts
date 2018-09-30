import {ChangeDetectorRef, Component, OnInit, ViewContainerRef, ViewEncapsulation} from '@angular/core';
import {WareHouseEntity} from '../../Module/MWareHouse/WareHouse.Entity';
import {WareHouseSearchEntity} from '../../Module/MWareHouse/WareHouse.SearchEntity';
import {PagingModel} from '../../Shared/MaterialComponent/paging/paging.model';
import {WareHouseService} from '../../Module/MWareHouse/WareHouse.Service';
import {BottomToastsManager} from '../../Shared/CustomToaster';
import {EmployeeEntity} from '../../Module/MEmployee/Employee.Entity';
import {EmployeeService} from '../../Module/MEmployee/Employee.Service';
import {CommonComponent} from '../../app.component';
import {SearchEmployeeEntity} from '../../Module/MEmployee/Employee.SearchEntity';

;

@Component({
  selector: 'app-WareHouse',
  templateUrl: './WareHouse.component.html',
  styleUrls: ['./WareHouse.component.css'],
  encapsulation: ViewEncapsulation.None,
})
export class WareHouseComponent extends CommonComponent<WareHouseEntity> implements OnInit {
  WareHouseSearchEntity: WareHouseSearchEntity = new WareHouseSearchEntity();

  StockKeeperEntities: EmployeeEntity[] = [];
  StockKeeperEntity: EmployeeEntity = new EmployeeEntity();
  StockkeeperSearchEntity: SearchEmployeeEntity = new SearchEmployeeEntity();
  PagingModel: PagingModel = new PagingModel(7, 10, data => {
  });

  constructor(cd: ChangeDetectorRef, public WareHouseService: WareHouseService, toastr: BottomToastsManager, vcr: ViewContainerRef, public EmployeeService: EmployeeService,) {
    super(WareHouseService, cd, toastr, vcr);
    this.toastr.setRootViewContainerRef(vcr);
    this.Search(this.WareHouseSearchEntity);
    this.GetStockkeeperList();
  }

  ngOnInit() {

  }

  GetStockkeeperList() {
    let SearchEntity: SearchEmployeeEntity = new SearchEmployeeEntity();
    SearchEntity.Skip = 0;
    SearchEntity.Take = 10;
    this.EmployeeService.Gets(SearchEntity).subscribe(res => {
      this.StockKeeperEntities = res;
      this.StockKeeperEntity = this.StockKeeperEntities[0];
      // this.WareHouseEntity.StockkeeperId = this.StockkeeperEntities[0].Id;
      // this.WareHouseEntity.StockkeeperEntity = this.StockkeeperEntities[0];
    });
  }

  ChooseWarehouse(StockeeperEntity: EmployeeEntity, WareHouseEntity?: WareHouseEntity) {
    WareHouseEntity.StockkeeperEntity = StockeeperEntity;
    WareHouseEntity.StockkeeperId = StockeeperEntity.Id;
    console.log(WareHouseEntity.StockkeeperEntity);
    console.log(WareHouseEntity.StockkeeperId);
  }
}
