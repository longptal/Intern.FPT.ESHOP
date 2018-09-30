import {Component, OnInit, ViewContainerRef, ViewEncapsulation} from '@angular/core';
import {ProductAttributeEntity} from '../../Module/MProductAttribute/ProductAttribute.Entity';
import {ProductAttributeSearchEntity} from '../../Module/MProductAttribute/ProductAttribute.SearchEntity';
import {LanguageEntity} from '../../Module/MLanguage/Language.Entity';
import {PagingModel} from '../../Shared/MaterialComponent/paging/paging.model';
import {ProductAttributeService} from '../../Module/MProductAttribute/ProductAttribute.Service';
import {LanguageService} from '../../Module/MLanguage/Language.Service';
import {ActivatedRoute} from '@angular/router';
import {BottomToastsManager} from '../../Shared/CustomToaster';
import {CategoryService} from '../../Module/MCategory/Category.Service';
import {CategoryEntity} from '../../Module/MCategory/Category.Entity';

@Component({
  selector: 'app-ProductAttribute',
  templateUrl: './ProductAttribute.component.html',
  encapsulation: ViewEncapsulation.None,
})
export class ProductAttributeComponent implements OnInit {
  ProductAttributeEntities: ProductAttributeEntity[] = [];
  ProductAttributeEntity: ProductAttributeEntity = new ProductAttributeEntity();
  CategoryEntity: CategoryEntity = new CategoryEntity();
  TempProductAttribute: any = {};
  ProductAttributeSearchEntity: ProductAttributeSearchEntity = new ProductAttributeSearchEntity();
  LanguageEntities: LanguageEntity[] = [];
  CategoryId: number;
  IsSearch: boolean = false;
  Title: string = '';
  PagingModel: PagingModel = new PagingModel(7, 10, data => {
  });

  constructor(public ProductAttributeService: ProductAttributeService,
              public CategoryService: CategoryService,
              public LanguageService: LanguageService,
              private route: ActivatedRoute,
              private toastr: BottomToastsManager,
              vcr: ViewContainerRef) {
    this.toastr.setRootViewContainerRef(vcr);
    this.route.params.subscribe((params) => {
      this.LanguageService.Gets().subscribe(res => {
        if (res) {
          this.LanguageEntities = res;
        }
      });
      if (params.CategoryId !== undefined) {
        this.CategoryId = params.CategoryId;
        this.ProductAttributeSearchEntity.CategoryId = params.CategoryId;
        this.CategoryService.GetId(params.CategoryId).subscribe(res => {
          if (res) {
            this.CategoryEntity = Object.assign({}, res);
            this.Title = this.CategoryEntity.Code;
          }
        });
        this.SearchProductAttribute(this.ProductAttributeSearchEntity);
      }
    });

  }

  ngOnInit() {

  }

  Count() {
    this.ProductAttributeService.Count(this.ProductAttributeSearchEntity).subscribe(data => {
      this.PagingModel.TotalPage = Math.ceil(data / this.PagingModel.Take);
    });
  }

  SearchProductAttribute(SearchEntity: ProductAttributeSearchEntity, IsRefersh?) {
    if (IsRefersh) {
      SearchEntity = Object.assign(new ProductAttributeSearchEntity());
      SearchEntity.CategoryId = this.CategoryId;
    }
    this.ProductAttributeService.Gets(SearchEntity).subscribe(res => {
      if (res) {
        this.ProductAttributeEntities = res;
        this.Count();
        this.ProductAttributeEntities = this.ProductAttributeEntities.map((c) => {
          c.IsEdit = false;
          return c;
        });
      }
    }, err => {
      this.toastr.error('Some thing wrong!', 'Error');
    });
  }

  //AddProductAttribute() {
  //  let ProductAttribute: ProductAttributeEntity = new ProductAttributeEntity();
  //  ProductAttribute.IsEdit = true;
  //  for (let value of this.LanguageEntities) {
  //    ProductAttribute.Names[value.Id] = '';
  //  }
  //  this.ProductAttributeEntities.unshift(ProductAttribute);
  //}

  EditProductAttribute(ProductAttributeEntity: ProductAttributeEntity) {
    ProductAttributeEntity.IsEdit = true;
    this.TempProductAttribute[ProductAttributeEntity.Id] = Object.assign(ProductAttributeEntity);
  }

  DeleteProductAttribute(ProductAttributeEntity: ProductAttributeEntity) {
    ProductAttributeEntity.CategoryId = this.CategoryId;
    this.ProductAttributeService.Delete(ProductAttributeEntity.Id).subscribe(res => {
      if (res) {
        let IndexNumber = this.ProductAttributeEntities.indexOf(ProductAttributeEntity);
        this.ProductAttributeEntities.splice(IndexNumber, 1);
        this.toastr.ShowSuccess();
      }
    }, err => {
      this.toastr.ShowError();
    });
  }

  SaveProductAttribute(ProductAttributeEntity: ProductAttributeEntity, Type: string) {
    ProductAttributeEntity.CategoryId = this.CategoryId;
    if (ProductAttributeEntity.Id !== 0) {
      this.ProductAttributeService.Update(ProductAttributeEntity).subscribe(res => {
        let IndexNumber = this.ProductAttributeEntities.indexOf(ProductAttributeEntity);
        Object.assign(this.ProductAttributeEntities[IndexNumber], res);
        this.ProductAttributeEntities[IndexNumber].IsEdit = false;
        this.toastr.ShowSuccess();
      }, err => {
        this.toastr.ShowError();
      });
    } else {
      this.ProductAttributeService.Create(ProductAttributeEntity).subscribe(res => {
        Object.assign(this.ProductAttributeEntities[0], res);
        this.ProductAttributeEntities[0].IsEdit = false;
        this.toastr.ShowSuccess();
      }, err => {
        this.toastr.ShowError();
      });
    }
  }

  CancelProductAttribute(ProductAttributeEntity: ProductAttributeEntity) {
    if (ProductAttributeEntity.Id == null || ProductAttributeEntity.Id == undefined) {
      let index = this.ProductAttributeEntities.indexOf(ProductAttributeEntity);
      this.ProductAttributeEntities.splice(index, 1);
    } else {
      Object.assign(ProductAttributeEntity, this.TempProductAttribute);
      ProductAttributeEntity.IsEdit = false;
    }
  }

}
