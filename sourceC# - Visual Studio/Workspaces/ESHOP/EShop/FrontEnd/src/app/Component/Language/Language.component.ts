import {ChangeDetectorRef, Component, OnInit, ViewContainerRef, ViewEncapsulation} from '@angular/core';
import {LanguageEntity} from '../../Module/MLanguage/Language.Entity';
import {LanguageSearchEntity} from '../../Module/MLanguage/Language.SearchEntity';
import {LanguageService} from '../../Module/MLanguage/Language.Service';
import {BottomToastsManager} from '../../Shared/CustomToaster';
import {CommonComponent} from '../../app.component';

@Component({
  selector: 'app-Language',
  templateUrl: './Language.component.html',
  styleUrls: ['./Language.component.css'],
  encapsulation: ViewEncapsulation.None,
})
export class LanguageComponent extends CommonComponent<LanguageEntity> implements OnInit {
  LanguageSearchEntity: LanguageSearchEntity = new LanguageSearchEntity();

  constructor(cd: ChangeDetectorRef, public LanguageService: LanguageService, public toastr: BottomToastsManager, vcr: ViewContainerRef) {
    super(LanguageService,  cd, toastr, vcr);
    this.LanguageSearchEntity = new LanguageSearchEntity();
    this.Search(this.LanguageSearchEntity);
  }

  ngOnInit() {

  }

}
