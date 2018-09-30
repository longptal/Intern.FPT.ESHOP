import {ChangeDetectorRef, Component, OnInit, ViewContainerRef, ViewEncapsulation} from '@angular/core';
import {ProductEntity} from '../../Module/MProduct/Product.Entity';
import {ModalComponent} from '../../Shared/MaterialComponent/modal/modal.component';
import {ProductService} from '../../Module/MProduct/Product.Service';
import {BottomToastsManager} from '../../Shared/CustomToaster';
import {PagingModel} from '../../Shared/MaterialComponent/paging/paging.model';
import {ProductSearchEntity} from '../../Module/MProduct/Product.SearchEntity';
import {Router} from '@angular/router';
import {CategoryService} from '../../Module/MCategory/Category.Service';
import {CategoryEntity} from '../../Module/MCategory/Category.Entity';

@Component({
  selector: 'app-Product',
  templateUrl: './Product.component.html',
  encapsulation: ViewEncapsulation.None,
})
export class ProductComponent implements OnInit {
  ProductEntities: ProductEntity[] = [];
  PagingModel: PagingModel = new PagingModel(7, 10, data => {
  });
  ProductEntity: ProductEntity = new ProductEntity();
  ProductSearchEntity: ProductSearchEntity = new ProductSearchEntity();
  ModalProductEntity: ProductEntity = new ProductEntity();
  CategoryEntities: CategoryEntity[] = [];
  EditModalComponent: ModalComponent = new ModalComponent();
  IsSearch: boolean = false;

  constructor(cd: ChangeDetectorRef, public ProductService: ProductService, private toastr: BottomToastsManager, vcr: ViewContainerRef, private Router: Router, private CategoryService: CategoryService) {
    this.toastr.setRootViewContainerRef(vcr);
    this.SearchProduct(this.ProductSearchEntity);
    this.CategoryService.Gets().subscribe(res => {
      this.CategoryEntities = res;
    });
  }

  ngOnInit() {

  }

  SearchProduct(SearchEntity: ProductSearchEntity, IsRefersh?) {
    if (IsRefersh) {
      SearchEntity = Object.assign(new ProductSearchEntity());
    } else {
      SearchEntity.Skip = this.PagingModel.Take * this.PagingModel.Active;
      SearchEntity.Take = this.PagingModel.Take;
    }
    this.ProductService.Gets(SearchEntity).subscribe(res => {
      if (res) {
        this.ProductEntities = res;
        this.ProductEntities = this.ProductEntities.map((value) => {
          value.IsEdit = false;
          return value;
        });
        this.Count(SearchEntity);
      }
    }, err => {
      this.toastr.error('Some thing wrong!', 'Error');
    });
  }

  Count(SearchEntity: ProductSearchEntity) {
    this.ProductService.Count(SearchEntity).subscribe(data => {
      this.PagingModel.TotalPage = Math.ceil(data / this.PagingModel.Take);
    });
  }

  ToProductDetail(ProductEntity: ProductEntity) {
    if (ProductEntity.Id !== null) {
      this.Router.navigate(['/Product/' + ProductEntity.Id + '/ProductDetail']);
    }
  }

  AddProduct() {
    let Product: ProductEntity = new ProductEntity();
    Product.IsEdit = true;
    this.ProductEntities.unshift(Product);
  }

  DeleteProduct(ProductEntity: ProductEntity) {
    this.ProductService.Delete(ProductEntity.Id).subscribe(res => {
      if (res) {
        let IndexNumber = this.ProductEntities.indexOf(ProductEntity);
        this.ProductEntities.splice(IndexNumber, 1);
        this.toastr.ShowSuccess();
      }
    }, err => {
      this.toastr.ShowError('Something wrong!');
    });
  }

  SaveProduct(ProductEntity: ProductEntity) {
    this.ProductService.Create(ProductEntity).subscribe(res => {
      let IndexNumber = this.ProductEntities.indexOf(ProductEntity);
      Object.assign(this.ProductEntities[IndexNumber], res);
      this.ProductEntities[IndexNumber].IsEdit = false;
      this.toastr.ShowSuccess();
    }, err => {
      this.toastr.ShowError('Something wrong!');
    });
  }

  CancelProduct(ProductEntity: ProductEntity) {
    let index = this.ProductEntities.indexOf(ProductEntity);
    this.ProductEntities.splice(index, 1);
  }
}
