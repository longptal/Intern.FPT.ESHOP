import {Component, OnInit, ViewContainerRef, ViewEncapsulation} from '@angular/core';
import {ProductEntity} from '../../../Module/MProduct/Product.Entity';
import {ModalComponent} from '../../../Shared/MaterialComponent/modal/modal.component';
import {ProductService} from '../../../Module/MProduct/Product.Service';
import {BottomToastsManager} from '../../../Shared/CustomToaster';
import {ActivatedRoute} from '@angular/router';
import {CategoryService} from '../../../Module/MCategory/Category.Service';
import {CategoryEntity} from '../../../Module/MCategory/Category.Entity';
import {LanguageService} from '../../../Module/MLanguage/Language.Service';
import {LanguageEntity} from '../../../Module/MLanguage/Language.Entity';
import {ProductValueEntity} from '../../../Module/MProductValue/ProductValue.Entity';
import {ProductValueService} from '../../../Module/MProductValue/ProductValue.Service';
import {ProductValueSearchEntity} from '../../../Module/MProductValue/ProductValue.SearchEntity';
import {TaxService} from '../../../Module/MTax/Tax.Service';
import {PackService} from '../../../Module/MPack/Pack.Service';
import {DiscountService} from '../../../Module/MDiscount/Discount.Service';
import {TaxEntity} from '../../../Module/MTax/Tax.Entity';
import {TaxSearchEntity} from '../../../Module/MTax/Tax.SearchEntity';
import {DiscountEntity} from '../../../Module/MDiscount/Discount.Entity';
import {PackEntity} from '../../../Module/MPack/Pack.Entity';
import {PackSearchEntity} from '../../../Module/MPack/Pack.SearchEntity';
import {DiscountSearchEntity} from '../../../Module/MDiscount/Discount.SearchEntity';
import {ProductPictureService} from '../../../Module/MProductPicture/ProductPicture.Service';
import {ProductPictureEntity} from '../../../Module/MProductPicture/ProductPicture.Entity';
import {ProductPictureSearchEntity} from '../../../Module/MProductPicture/ProductPicture.SearchEntity';

@Component({
  selector: 'app-productdetail',
  templateUrl: './ProductDetail.component.html',
  encapsulation: ViewEncapsulation.None,
})
export class ProductDetailComponent implements OnInit {
  ProductId: number;
  htmlContent: string = 'abc';
  ProductDetailEntity: ProductEntity = new ProductEntity();
  ProductValueEntity: ProductValueEntity = new ProductValueEntity();
  TaxEntities: TaxEntity[] = [];
  TaxEntity: TaxEntity = new TaxEntity();
  TempTax: any = {};
  PackEntities: PackEntity[] = [];
  PackEntity: PackEntity = new PackEntity();
  TempPack: any = {};
  DiscountEntities: DiscountEntity[] = [];
  DiscountEntity: DiscountEntity = new DiscountEntity();
  TempDiscount: any = {};
  ProductValueEntities: ProductValueEntity[] = [];
  ModalProductDetailEntity: ProductEntity = new ProductEntity();
  EditModalComponent: ModalComponent = new ModalComponent();
  TempProductValueEntity: any = {};
  CategoryEntities: CategoryEntity[] = [];
  LanguageEntities: LanguageEntity[] = [];
  ProducPictureEntities: ProductPictureEntity[] = [];
  ToogleProduct: boolean;
  ToogleProductValue: boolean;
  LanguageId: number;
  IsSearch: boolean = false;
  editorOptions = {
    placeholder: 'Insert content...',
    modules: {
      toolbar: {
        container: [
          ['bold', 'italic', 'underline', 'strike'],        // toggled buttons
          ['blockquote', 'code-block'],
          [{'list': 'ordered'}, {'list': 'bullet'}],
          [{'indent': '-1'}, {'indent': '+1'}],          // outdent/indent
          [{'header': [1, 2, 3, 4, 5, 6, false]}],
        ],
        handlers: {}
      }
    },
    theme: 'snow'
  };

  constructor(public ProductDetailService: ProductService,
              private toastr: BottomToastsManager,
              private LanguageService: LanguageService,
              private CategoryService: CategoryService,
              private ProductValueService: ProductValueService,
              private TaxService: TaxService,
              private PackService: PackService,
              private DiscountService: DiscountService,
              private ProductPictureService: ProductPictureService,
              vcr: ViewContainerRef,
              private route: ActivatedRoute) {
    this.toastr.setRootViewContainerRef(vcr);
    this.CategoryService.Gets().subscribe(res => {
      this.CategoryEntities = res;
    }, err => {
      this.toastr.ShowError();
    });
    this.LanguageService.Gets().subscribe(res => {
      if (res) {
        this.LanguageEntities = res;
        this.LanguageEntities = this.LanguageEntities.map((item) => {
          item.IsEdit = false;
          return item;
        });
      }
    });
    this.route.params.subscribe((params) => {
      if (params.ProductId !== undefined) {
        this.ProductId = params.ProductId;
        if (params.ProductId !== '0') {
          this.ProductDetailService.GetId(this.ProductId).subscribe(res => {
            if (res) {
              this.ProductDetailEntity = JSON.parse(JSON.stringify(res));
            }
          }, err => {
            this.toastr.ShowError();
          });
          //Get list Tax:
          let TaxSearch = new TaxSearchEntity();
          //TaxSearch.ProductId = this.ProductId;
          this.TaxService.Gets(TaxSearch).subscribe(res => {
            this.TaxEntities = res;
          });
          //Get list Pack:
          let PackSearch = new PackSearchEntity();
          PackSearch.ProductId = this.ProductId;
          this.PackService.Gets(PackSearch).subscribe(res => {
            this.PackEntities = res;
          });
          //Get list Discount:
          let DiscountSearch = new DiscountSearchEntity();
          DiscountSearch.ProductId = this.ProductId;
          this.DiscountService.Gets(DiscountSearch).subscribe(res => {
            this.DiscountEntities = res;
          });
          //Get list image:
          let SearchProductPicture = new ProductPictureSearchEntity();
          SearchProductPicture.ProductId = this.ProductId;
          this.ProductPictureService.Gets(SearchProductPicture).subscribe(res => {
            this.ProducPictureEntities = res;
          });
        }
      }
    });
  }

  ngOnInit() {
    this.ToogleProduct = true;
    this.ToogleProductValue = true;
  }

  //Product Info Section
  SaveProductDetail(ProductDetailEntity: ProductEntity) {
    ProductDetailEntity.Id = this.ProductId;
    this.ProductDetailService.Update(ProductDetailEntity).subscribe(res => {
      this.toastr.ShowSuccess();
    }, err => {
      this.toastr.ShowError();
    });
  }

  //Tax Info Section:
  //AddTax() {
  //  let value = new TaxEntity();
  //  value.IsEdit = true;
  //  this.TaxEntities.unshift(value);
  //}
  //SaveTax(TaxEntity: TaxEntity) {
  //    TaxEntity.ProductId = this.ProductId;
  //    if (TaxEntity.Id == null || TaxEntity.Id == undefined || TaxEntity.Id == 0) {
  //      this.TaxService.Create(TaxEntity).subscribe(res => {
  //        Object.assign(TaxEntity, res);
  //        TaxEntity.IsEdit = false;
  //        this.toastr.ShowSuccess();
  //      }, e => {
  //        this.toastr.error("Some thing wrong!", 'Error');
  //      })
  //    } else {
  //      this.TaxService.Update(TaxEntity).subscribe(res => {
  //        Object.assign(TaxEntity, res)
  //        TaxEntity.IsEdit = false;
  //        this.toastr.ShowSuccess();
  //      }, e => {
  //        this.toastr.error("Some thing wrong!", 'Error');
  //      })
  //    }
  //}

  //EditTax(TaxEntity: TaxEntity) {
  //  this.TempTax = JSON.parse(JSON.stringify(TaxEntity));
  //  TaxEntity.IsEdit = true;
  //}

  //DeleteTax(TaxEntity: TaxEntity) {
  //  this.TaxService.Delete(TaxEntity.Id).subscribe(res => {
  //    let index = this.TaxEntities.indexOf(TaxEntity);
  //    this.TaxEntities.splice(index, 1);
  //    //this.Search();
  //    this.toastr.ShowSuccess();
  //  }, e => {
  //    this.toastr.error("Some thing wrong!", 'Error');
  //  })
  //}

  //CancelTax(TaxEntity: TaxEntity) {
  //  if (TaxEntity.Id == null || TaxEntity.Id == undefined || TaxEntity.Id == 0) {
  //    let index = this.TaxEntities.indexOf(TaxEntity);
  //    this.TaxEntities.splice(index, 1);
  //  } else {
  //    Object.assign(TaxEntity, this.TempTax);
  //    TaxEntity.IsEdit = false;
  //  }
  //}

  //Pack Info Section:
  AddPack() {
    let value = new PackEntity();
    value.IsEdit = true;
    this.PackEntities.unshift(value);
  }

  SavePack(PackEntity: PackEntity) {
    PackEntity.ProductId = this.ProductId;
    if (PackEntity.Id == null || PackEntity.Id == undefined || PackEntity.Id == 0) {
      this.PackService.Create(PackEntity).subscribe(res => {
        Object.assign(PackEntity, res);
        PackEntity.IsEdit = false;
        this.toastr.ShowSuccess();
      }, e => {
        this.toastr.error('Some thing wrong!', 'Error');
      });
    } else {
      this.PackService.Update(PackEntity).subscribe(res => {
        Object.assign(PackEntity, res);
        PackEntity.IsEdit = false;
        this.toastr.ShowSuccess();
      }, e => {
        this.toastr.error('Some thing wrong!', 'Error');
      });
    }
  }

  EditPack(PackEntity: PackEntity) {
    this.TempPack = JSON.parse(JSON.stringify(PackEntity));
    PackEntity.IsEdit = true;
  }

  DeletePack(PackEntity: PackEntity) {
    this.PackService.Delete(PackEntity.Id).subscribe(res => {
      let index = this.PackEntities.indexOf(PackEntity);
      this.PackEntities.splice(index, 1);
      this.toastr.ShowSuccess();
    }, e => {
      this.toastr.error('Some thing wrong!', 'Error');
    });
  }

  CancelPack(PackEntity: PackEntity) {
    if (PackEntity.Id == null || PackEntity.Id == undefined || PackEntity.Id == 0) {
      let index = this.PackEntities.indexOf(PackEntity);
      this.PackEntities.splice(index, 1);
    } else {
      Object.assign(PackEntity, this.TempPack);
      PackEntity.IsEdit = false;
    }
  }

  //Discount Info Section:
  AddDiscount() {
    let value = new DiscountEntity();
    value.IsEdit = true;
    this.DiscountEntities.unshift(value);
  }

  SaveDiscount(DiscountEntity: DiscountEntity) {
    DiscountEntity.ProductId = this.ProductId;
    if (DiscountEntity.Id == null || DiscountEntity.Id == undefined || DiscountEntity.Id == 0) {
      this.DiscountService.Create(DiscountEntity).subscribe(res => {
        Object.assign(DiscountEntity, res);
        DiscountEntity.IsEdit = false;
        this.toastr.ShowSuccess();
      }, e => {
        this.toastr.error('Some thing wrong!', 'Error');
      });
    } else {
      this.DiscountService.Update(DiscountEntity).subscribe(res => {
        Object.assign(DiscountEntity, res);
        DiscountEntity.IsEdit = false;
        this.toastr.ShowSuccess();
      }, e => {
        this.toastr.error('Some thing wrong!', 'Error');
      });
    }
  }

  EditDiscount(DiscountEntity: DiscountEntity) {
    this.TempDiscount = JSON.parse(JSON.stringify(DiscountEntity));
    DiscountEntity.IsEdit = true;
  }

  DeleteDiscount(DiscountEntity: DiscountEntity) {
    this.DiscountService.Delete(DiscountEntity.Id).subscribe(res => {
      let index = this.DiscountEntities.indexOf(DiscountEntity);
      this.DiscountEntities.splice(index, 1);
      //this.Search();
      this.toastr.ShowSuccess();
    }, e => {
      this.toastr.error('Some thing wrong!', 'Error');
    });
  }

  CancelDiscount(DiscountEntity: DiscountEntity) {
    if (DiscountEntity.Id == null || DiscountEntity.Id == undefined || DiscountEntity.Id == 0) {
      let index = this.DiscountEntities.indexOf(DiscountEntity);
      this.DiscountEntities.splice(index, 1);
    } else {
      Object.assign(DiscountEntity, this.TempDiscount);
      DiscountEntity.IsEdit = false;
    }
  }

  //Product Image:
  LoadImage(event) {
    if (event.length > 0) {
      let ProductPicture = new ProductPictureEntity();
      ProductPicture.ProductId = this.ProductId;
      let count = 0;
      for (let item of event) {
        ProductPicture.Path = item.Src;
        this.ProductPictureService.Create(ProductPicture).subscribe(res => {
          count++;
          if (count === event.length) {
            let SearchProductPicture = new ProductPictureSearchEntity();
            SearchProductPicture.ProductId = this.ProductId;
            this.ProductPictureService.Gets(SearchProductPicture).subscribe(res => {
              this.ProducPictureEntities = res;
            });
            this.toastr.ShowSuccess();
          }
        });
      }
    }
  }

  DeleteImage(FileEntity) {
    this.ProductPictureService.Delete(FileEntity.Id).subscribe(res => {
      if (res) {
        let index = this.ProducPictureEntities.indexOf(FileEntity);
        this.ProducPictureEntities.splice(index, 1);
        this.toastr.ShowSuccess();
      }
    });
  }

  //Product Value Section:
  ChangeLanguage(LanguageEntity: LanguageEntity) {
    if (!LanguageEntity.IsActive) {
      this.LanguageId = LanguageEntity.Id;
      this.LanguageEntities = this.LanguageEntities.map((item) => {
        item.IsActive = false;
        return item;
      });
      let Index = this.LanguageEntities.indexOf(LanguageEntity);
      this.LanguageEntities[Index].IsActive = true;
      let SearchProductValue = new ProductValueSearchEntity();
      SearchProductValue.LanguageId = this.LanguageId;
      SearchProductValue.ProductId = this.ProductDetailEntity.Id;
      this.ProductValueService.Gets(SearchProductValue).subscribe(res => {
        if (res) {
          this.ProductValueEntities = res;
          this.TempProductValueEntity = {};
          this.ProductValueEntities = this.ProductValueEntities.map((item) => {
            item.IsEdit = false;
            return item;
          });
        }
      });
    }
  }

  EditProductValue(ProductValueEntity: ProductValueEntity) {
    ProductValueEntity.IsEdit = true;
    this.TempProductValueEntity[ProductValueEntity.Id] = {};
    Object.assign(this.TempProductValueEntity[ProductValueEntity.Id], ProductValueEntity);
  }

  SaveProductValue(ProductValueEntity: ProductValueEntity) {
    this.ProductValueService.Create(ProductValueEntity).subscribe(res => {
      let Index = this.ProductValueEntities.indexOf(ProductValueEntity);
      Object.assign(this.ProductValueEntities[Index], res);
      this.ProductValueEntities[Index].IsEdit = false;
      this.toastr.ShowSuccess();
    });
  }

  CancelProductValue(ProductValueEntity: ProductValueEntity) {
    Object.assign(ProductValueEntity, this.TempProductValueEntity[ProductValueEntity.Id]);
    ProductValueEntity.IsEdit = false;
  }

}
