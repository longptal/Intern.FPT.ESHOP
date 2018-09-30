import {ChangeDetectorRef, Component, OnInit, ViewContainerRef, ViewEncapsulation} from '@angular/core';
import {PermissionEntity} from '../../Module/MPermission/Permission.Entity';
import {PermissionSearchEntity} from '../../Module/MPermission/Permission.SearchEntity';
import {PermissionService} from '../../Module/MPermission/Permission.Service';
import {BottomToastsManager} from '../../Shared/CustomToaster';
import {CommonComponent} from '../../app.component';

@Component({
  selector: 'app-Permission',
  templateUrl: './Permission.component.html',
  styleUrls: ['./Permission.component.css'],
  encapsulation: ViewEncapsulation.None,
})
export class PermissionComponent extends CommonComponent<PermissionEntity> implements OnInit {
  PermissionSearchEntity: PermissionSearchEntity = new PermissionSearchEntity();

  constructor(cd: ChangeDetectorRef, public PermissionService: PermissionService, toastr: BottomToastsManager, vcr: ViewContainerRef) {
    super(PermissionService, cd, toastr, vcr);
    this.Search(this.PermissionSearchEntity);
  }

  ngOnInit() {

  }
}
