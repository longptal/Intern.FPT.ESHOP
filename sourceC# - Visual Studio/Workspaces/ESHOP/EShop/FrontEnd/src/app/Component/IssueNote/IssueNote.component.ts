import {ChangeDetectorRef, Component, OnInit, ViewContainerRef, ViewEncapsulation} from '@angular/core';
import {Router} from '@angular/router';
import {IssueNoteEntity} from '../../Module/MIssueNote/IssueNote.Entity';
import {IssueNoteSearchEntity} from '../../Module/MIssueNote/IssueNote.SearchEntity';
import {ModalComponent} from '../../Shared/MaterialComponent/modal/modal.component';
import {IssueNoteService} from '../../Module/MIssueNote/IssueNote.Service';
import {BottomToastsManager} from '../../Shared/CustomToaster';
import {PagingModel} from '../../Shared/MaterialComponent/paging/paging.model';
import {SupplierEntity} from '../../Module/MSupplier/Supplier.Entity';
import {SupplierService} from '../../Module/MSupplier/Supplier.Service';
import {WareHouseEntity} from '../../Module/MWareHouse/WareHouse.Entity';
import {WareHouseService} from '../../Module/MWareHouse/WareHouse.Service';
import {InventoryEntity} from '../../Module/MInventory/Inventory.Entity';
import {InventoryService} from '../../Module/MInventory/Inventory.Service';
import {ProductEntity} from '../../Module/MProduct/Product.Entity';
import {InventorySearchEntity} from '../../Module/MInventory/Inventory.SearchEntity';

@Component({
  selector: 'app-issuenote',
  templateUrl: './IssueNote.component.html',
  styleUrls: ['./IssueNote.component.css'],
  encapsulation: ViewEncapsulation.None,
})
export class IssueNoteComponent implements OnInit {
  IssueNoteEntities: IssueNoteEntity[] = [];
  IssueNoteEntity: IssueNoteEntity = new IssueNoteEntity();
  IssueNoteSearchEntity: IssueNoteSearchEntity = new IssueNoteSearchEntity();
  PagingModel = new PagingModel(7, 10, data => {

  });
  TempIssueNote: {} = {};
  ModalIssueNoteEntity: IssueNoteEntity = new IssueNoteEntity();
  EditModalComponent: ModalComponent = new ModalComponent();
  IsSearch: boolean = false;
  SupplierEntity: SupplierEntity = new SupplierEntity();
  SupplierEntities: Array<SupplierEntity> = [];
  WareHouseEntities: Array<WareHouseEntity> = [];
  WareHouseEntity: WareHouseEntity = new WareHouseEntity();
  InventoryEntity: InventoryEntity = new InventoryEntity();
  InventoryEntities: Array<InventoryEntity> = [];
  ProductEntity: ProductEntity = new ProductEntity();
  ProductEntities: Array<ProductEntity> = [];
  IsAdding: boolean = false;

  constructor(public IssueNoteService: IssueNoteService,
              private Router: Router,
              private toastr: BottomToastsManager,
              cd: ChangeDetectorRef, vcr: ViewContainerRef,
              private SupplierService: SupplierService,
              private WareHouseService: WareHouseService,
              private InventoryService: InventoryService,) {

    this.toastr.setRootViewContainerRef(vcr);
    this.SearchIssueNote(this.IssueNoteSearchEntity);
    this.GetSupplierEntities();
    this.GetWarehouseList();
  }

  ngOnInit() {

  }

  SearchIssueNote(SearchEntity: IssueNoteSearchEntity, IsRefersh?) {
    if (IsRefersh) {
      SearchEntity = Object.assign(new IssueNoteSearchEntity());
    }
    this.IssueNoteService.Gets(SearchEntity).subscribe(res => {
      if (res) {
        this.IssueNoteEntities = res;
        this.Count(SearchEntity);
        this.IssueNoteEntities = this.IssueNoteEntities.map((c) => {
          c.IsEdit = false;
          return c;
        });
      }
    }, err => {
      this.toastr.error('Some thing wrong!', 'Error');
    });
  }

  Count(SearchEntity: IssueNoteSearchEntity) {
    this.IssueNoteService.Count(SearchEntity).subscribe(data => {
      this.PagingModel.TotalPage = Math.ceil(data / this.PagingModel.Take);
    });
  }

  AddProductAttribute(IssueNoteEntity: IssueNoteEntity) {
    if (IssueNoteEntity.Id) {
      this.Router.navigate(['/module/IssueNote/' + IssueNoteEntity.Id + '/ProductAttribute']);
    }
  }

  //AddIssueNote() {
  //  let IssueNote: IssueNoteEntity = new IssueNoteEntity();
  //  IssueNote.IsEdit = true;
  //  this.IssueNoteEntities.unshift(IssueNote);
  //}

  EditIssueNote(IssueNoteEntity: IssueNoteEntity) {
    IssueNoteEntity.IsEdit = true;
    this.TempIssueNote[IssueNoteEntity.Id] = Object.assign(IssueNoteEntity);
  }

  DeleteIssueNote(IssueNoteEntity: IssueNoteEntity) {
    this.IssueNoteService.Delete(IssueNoteEntity.Id).subscribe(res => {
      if (res) {
        let IndexNumber = this.IssueNoteEntities.indexOf(IssueNoteEntity);
        this.IssueNoteEntities.splice(IndexNumber, 1);
        this.toastr.ShowSuccess();
      }
    }, err => {
      this.toastr.ShowError();
    });
  }

  SaveIssueNote(IssueNoteEntity: IssueNoteEntity) {
    console.log(this.SupplierEntity.Id);
    console.log(IssueNoteEntity.WareHouseId);
    console.log(IssueNoteEntity.ProductId);
    if (IssueNoteEntity.Id == null || IssueNoteEntity.Id == undefined || IssueNoteEntity.Id == 0) {
      IssueNoteEntity.SupplierId = this.SupplierEntity.Id;
      //IssueNoteEntity.WareHouseId = IssueNoteEntity.WareHouseEntity.Id;
      this.IssueNoteService.Create(IssueNoteEntity).subscribe(res => {
        this.IssueNoteEntities.unshift(IssueNoteEntity);
        this.IssueNoteEntities[0].IsEdit = false;
        this.toastr.ShowSuccess();
      }, err => {
        this.toastr.ShowError();
      });
    } else {
      this.IssueNoteService.Update(IssueNoteEntity).subscribe(res => {
        let IndexNumber = this.IssueNoteEntities.indexOf(res);
        Object.assign(this.IssueNoteEntities[IndexNumber], res);
        this.IssueNoteEntities[IndexNumber].IsEdit = false;
        this.toastr.ShowSuccess();
      }, err => {
        this.toastr.ShowError();
      });
    }
  }

  CancelIssueNote(IssueNoteEntity: IssueNoteEntity) {
    if (IssueNoteEntity.Id == null || IssueNoteEntity.Id == undefined) {
      let index = this.IssueNoteEntities.indexOf(IssueNoteEntity);
      this.IssueNoteEntities.splice(index, 1);
    } else {
      Object.assign(IssueNoteEntity, this.TempIssueNote);
      IssueNoteEntity.IsEdit = false;
    }
  }

  GetSupplierEntities() {
    this.SupplierService.Gets().subscribe(res => {
      this.SupplierEntities = res;
      this.SupplierEntity = this.SupplierEntities[0];
    });
  }

  //ChooseSupplier(SupplierEntity: SupplierEntity, IssueNoteEntity?: IssueNoteEntity) {
  //  console.log(SupplierEntity);
  //  this.IssueNoteSearchEntity.SupplierId = SupplierEntity.Id;
  //  this.SupplierEntity = SupplierEntity;
  //  this.SupplierEntity.Id = SupplierEntity.Id;
  //  this.SearchIssueNote(this.IssueNoteSearchEntity);
  //}

  GetWarehouseList() {
    this.WareHouseService.Gets().subscribe(res => {
      this.WareHouseEntities = res;
      this.WareHouseEntity = this.WareHouseEntities[0];
    });
  }

  ChooseWarehouse(WareHouseEntity: WareHouseEntity, InventoryEntity?: InventoryEntity) {
    console.log(WareHouseEntity);
    this.IssueNoteSearchEntity.WareHouseId = WareHouseEntity.Id;
    this.WareHouseEntity = WareHouseEntity;
    this.WareHouseEntity.Id = WareHouseEntity.Id;
    this.GetProduct(WareHouseEntity.Id);
  }

  GetProduct(WareHouseId) {
    console.log(WareHouseId);
    let a = new InventorySearchEntity();
    a.WareHouseId = WareHouseId;
    a.IsDeleted = false;
    this.InventoryService.Gets(a).subscribe(res => {
      this.InventoryEntities = res;
    });
  }

  AddIssueNote() {
    this.IsAdding = true;
  }
}
