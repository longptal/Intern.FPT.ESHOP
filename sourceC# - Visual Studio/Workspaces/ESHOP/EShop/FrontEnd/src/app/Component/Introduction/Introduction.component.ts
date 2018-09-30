import {ChangeDetectorRef, Component, OnInit, ViewContainerRef, ViewEncapsulation} from '@angular/core';
import {IntroductionEntity} from '../../Module/MIntroduction/Introduction.Entity';
import {IntroductionSearchEntity} from '../../Module/MIntroduction/Introduction.SearchEntity';
import {IntroductionService} from '../../Module/MIntroduction/Introduction.Service';
import {BottomToastsManager} from '../../Shared/CustomToaster';
import {CommonComponent} from '../../app.component';


@Component({
  selector: 'app-Introduction',
  templateUrl: './Introduction.component.html',
  styleUrls: ['./Introduction.component.css'],
  encapsulation: ViewEncapsulation.None,
})
export class IntroductionComponent extends CommonComponent<IntroductionEntity> implements OnInit {
  IntroductionSearchEntity: IntroductionSearchEntity = new IntroductionSearchEntity();

  constructor(public IntroductionService: IntroductionService,cd: ChangeDetectorRef, public toastr: BottomToastsManager, vcr: ViewContainerRef) {
    super(IntroductionService, cd, toastr, vcr);
    this.IntroductionSearchEntity = new IntroductionSearchEntity();
    this.Search(this.IntroductionSearchEntity);
  }

  ngOnInit() {

  }

}
