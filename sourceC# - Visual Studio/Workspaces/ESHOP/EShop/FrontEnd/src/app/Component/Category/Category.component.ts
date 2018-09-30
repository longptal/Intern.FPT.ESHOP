import {ChangeDetectorRef, Component, OnInit, ViewContainerRef, ViewEncapsulation} from '@angular/core';
import {Router} from '@angular/router';
import {CategoryEntity} from '../../Module/MCategory/Category.Entity';
import {CategorySearchEntity} from '../../Module/MCategory/Category.SearchEntity';
import {LanguageEntity} from '../../Module/MLanguage/Language.Entity';
import {CategoryService} from '../../Module/MCategory/Category.Service';
import {LanguageService} from '../../Module/MLanguage/Language.Service';
import {BottomToastsManager} from '../../Shared/CustomToaster';
import {CommonComponent} from '../../app.component';

@Component({
  selector: 'app-category',
  templateUrl: './Category.component.html',
  styleUrls: ['./Category.component.css'],
  encapsulation: ViewEncapsulation.None,
})
export class CategoryComponent extends CommonComponent<CategoryEntity> implements OnInit {
  CategorySearchEntity: CategorySearchEntity = new CategorySearchEntity();
  LanguageEntities: LanguageEntity[] = [];
  IsSearch: boolean = false;

  constructor(public CategoryService: CategoryService,
              public LanguageService: LanguageService,
              private Router: Router,
              cd: ChangeDetectorRef,
              public toastr: BottomToastsManager,
              public vcr: ViewContainerRef) {
    super(CategoryService,cd, toastr, vcr);
    this.CategorySearchEntity = new CategorySearchEntity();
    this.Search(this.CategorySearchEntity);
    this.LanguageService.Gets().subscribe(res => {
      if (res) {
        this.LanguageEntities = res;
      }
    });

  }

  ngOnInit() {

  }

  AddProductAttribute(CategoryEntity: CategoryEntity) {
    if (CategoryEntity.Id !== null) {
      this.Router.navigate(['/Category/' + CategoryEntity.Id + '/ProductAttribute']);
    }
  }

}
