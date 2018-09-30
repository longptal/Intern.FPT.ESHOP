import {ChangeDetectorRef, Component, OnInit, ViewContainerRef, ViewEncapsulation} from '@angular/core';
import {InventoryEntity} from '../../Module/MInventory/Inventory.Entity';
import {InventorySearchEntity} from '../../Module/MInventory/Inventory.SearchEntity';
import {InventoryService} from '../../Module/MInventory/Inventory.Service';
import {BottomToastsManager} from '../../Shared/CustomToaster';
import {WareHouseService} from '../../Module/MWareHouse/WareHouse.Service';
import {WareHouseEntity} from '../../Module/MWareHouse/WareHouse.Entity';
import {WareHouseSearchEntity} from '../../Module/MWareHouse/WareHouse.SearchEntity';
import {ProductEntity} from '../../Module/MProduct/Product.Entity';
import {ProductService} from '../../Module/MProduct/Product.Service';
import {CommonComponent} from '../../app.component';
import {ProductSearchEntity} from '../../Module/MProduct/Product.SearchEntity';

@Component({
  selector: 'app-Inventory',
  templateUrl: './Inventory.component.html',
  styleUrls: ['./Inventory.component.css'],
  encapsulation: ViewEncapsulation.None,
})
export class InventoryComponent extends CommonComponent<InventoryEntity> implements OnInit {
  InventorySearchEntity: InventorySearchEntity = new InventorySearchEntity();
  WareHouseEntity: WareHouseEntity = new WareHouseEntity();
  WareHouseEntities: Array<WareHouseEntity> = [];
  ProductEntity: ProductEntity = new ProductEntity();
  ProductEntities: Array<ProductEntity> = [];
  ProductSearchEntity: ProductSearchEntity;
  WareHouseSearchEntity: WareHouseSearchEntity = new WareHouseSearchEntity();

  constructor(public InventoryService: InventoryService,
              public toastr: BottomToastsManager, vcr: ViewContainerRef,
              cd: ChangeDetectorRef, public WareHouseService: WareHouseService,
              public ProductService: ProductService,) {
    super(InventoryService, cd, toastr, vcr);
    this.InventorySearchEntity = new InventorySearchEntity();
    this.ProductSearchEntity = new ProductSearchEntity();
    this.WareHouseSearchEntity = new WareHouseSearchEntity();
    this.GetWarehouseList();
    this.GetProductEntities();
  }

  ngOnInit() {

  }

  GetWarehouseList() {
    this.WareHouseService.Gets().subscribe(res => {
      if (res) {
        this.WareHouseEntities = res;
        this.WareHouseEntity = this.WareHouseEntities[0];
        this.InventorySearchEntity.WareHouseId = this.WareHouseEntities[0].Id;
        this.Search(this.InventorySearchEntity);
      }
    });
  }

  ChooseWarehouse(WareHouseEntity: WareHouseEntity, InventoryEntity?: InventoryEntity) {
    console.log(WareHouseEntity);
    this.InventorySearchEntity.WareHouseId = WareHouseEntity.Id;
    this.WareHouseEntity = WareHouseEntity;
    this.WareHouseEntity.Id = WareHouseEntity.Id;
    this.Search(this.InventorySearchEntity);
  }

  ChooseProduct(ProductEntity: ProductEntity, InventoryEntity?: InventoryEntity) {
    InventoryEntity.ProductEntity = ProductEntity;
    InventoryEntity.ProductId = ProductEntity.Id;
    console.log(InventoryEntity.ProductEntity);
    console.log(InventoryEntity.ProductId);
  }

  GetProductEntities() {
    this.ProductService.Gets().subscribe(res => {
      if (res) {
        this.ProductEntities = res;
        this.ProductEntity = this.ProductEntities[0];
      }
    });
  }
}
