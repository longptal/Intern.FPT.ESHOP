import {Component, OnInit, ViewContainerRef, ViewEncapsulation} from '@angular/core';
import {RoleEntity} from '../../Module/MRole/Role.Entity';
import {RoleService} from '../../Module/MRole/Role.Service';
import {BottomToastsManager} from '../../Shared/CustomToaster';

@Component({
  selector: 'app-Role',
  templateUrl: './Role.component.html',
  styleUrls: ['./Role.component.css'],
  encapsulation: ViewEncapsulation.None,
})
export class RoleComponent implements OnInit {
  RoleEntities: RoleEntity[] = [];
  RoleEntity: RoleEntity = new RoleEntity();
  TempRole: {};

  constructor(public RoleService: RoleService, private toastr: BottomToastsManager, vcr: ViewContainerRef) {
    this.toastr.setRootViewContainerRef(vcr);
    this.SearchRole();
  }

  ngOnInit() {

  }

  SearchRole() {
    this.RoleService.Gets().subscribe(res => {
      if (res) {
        this.RoleEntities = res;
        this.toastr.ShowSuccess();
      }
    }, e => {
      this.toastr.error('Some thing wrong!', 'Error');
    });
  }

  AddRole() {
    let value = new RoleEntity();
    value.IsEdit = true;
    this.RoleEntities.unshift(value);
  }

  SaveRole(RoleEntity: RoleEntity) {
    if (RoleEntity.Id == null || RoleEntity.Id == undefined) {
      RoleEntity.Id = 0;
      this.RoleService.Create(RoleEntity).subscribe(res => {
        Object.assign(RoleEntity, res);
        RoleEntity.IsEdit = false;
        this.toastr.ShowSuccess();
      }, e => {
        this.toastr.error('Some thing wrong!', 'Error');
      });
    } else {
      this.RoleService.Update(RoleEntity).subscribe(res => {
        Object.assign(RoleEntity, res);
        RoleEntity.IsEdit = false;
        this.toastr.ShowSuccess();
      }, e => {
        this.toastr.error('Some thing wrong!', 'Error');
      });
    }
  }

  EditRole(RoleEntity: RoleEntity) {
    this.TempRole = JSON.parse(JSON.stringify(RoleEntity));
    RoleEntity.IsEdit = true;
  }

  DeleteRole(RoleEntity: RoleEntity) {
    this.RoleService.Delete(RoleEntity.Id).subscribe(res => {
      let index = this.RoleEntities.indexOf(RoleEntity);
      this.RoleEntities.splice(index, 1);
      this.toastr.ShowSuccess();
    }, e => {
      this.toastr.error('Some thing wrong!', 'Error');
    });
  }

  CancelRole(RoleEntity: RoleEntity) {
    if (RoleEntity.Id == null || RoleEntity.Id == undefined) {
      let index = this.RoleEntities.indexOf(RoleEntity);
      this.RoleEntities.splice(index, 1);
    } else {
      Object.assign(RoleEntity, this.TempRole);
    }
  }

}
