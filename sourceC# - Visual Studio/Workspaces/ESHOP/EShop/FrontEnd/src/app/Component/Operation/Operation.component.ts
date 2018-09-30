import {ChangeDetectorRef, Component, OnInit, ViewContainerRef, ViewEncapsulation} from '@angular/core';
import {OperationEntity} from '../../Module/MOperation/Operation.Entity';
import {OperationService} from '../../Module/MOperation/Operation.Service';
import {BottomToastsManager} from '../../Shared/CustomToaster';
import {OperationSearchEntity} from '../../Module/MOperation/Operation.SearchEntity';
import {CommonComponent} from '../../app.component';

@Component({
  selector: 'app-Operation',
  templateUrl: './Operation.component.html',
  styleUrls: ['./Operation.component.css'],
  encapsulation: ViewEncapsulation.None,
})
export class OperationComponent extends CommonComponent<OperationEntity> implements OnInit {
  OperationSearchEntity: OperationSearchEntity = new OperationSearchEntity();

  constructor(public OperationService: OperationService, cd: ChangeDetectorRef, public toastr: BottomToastsManager, vcr: ViewContainerRef) {
    super(OperationService, cd, toastr, vcr);
    this.OperationSearchEntity = new OperationSearchEntity();
    this.Search(this.OperationSearchEntity);
  }

  ngOnInit() {

  }

}
