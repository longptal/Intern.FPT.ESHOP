import {ChangeDetectorRef, Component, ViewContainerRef} from '@angular/core';
import { EmployeeInfoService } from './Shared/EmployeeInfo.Service';
import { IEntity } from './Module/IEntity.Entity';
import { PagingModel } from './Shared/MaterialComponent/paging/paging.model';
import { BottomToastsManager } from './Shared/CustomToaster';
import { FilterEntity } from './Module/FilterEntity';
import { HttpService } from './Shared/HttpService';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'app';
  constructor(public EmployeeInfoService: EmployeeInfoService
  ) {
    this.EmployeeInfoService.GetCurrent();
  }
}
export class CommonComponent<T extends IEntity> {
  PagingModel: PagingModel = new PagingModel(7, 10);
  Entities: T[];
  Entity: T;
  temp: T;

  constructor(public HttpService: HttpService<T>, public cd: ChangeDetectorRef, public toastr: BottomToastsManager,
              public vcr: ViewContainerRef, isChild?: boolean) {
    if (isChild == true) return;
    this.toastr.setRootViewContainerRef(vcr);
  }

  Search(SearchEntity?: FilterEntity, IsPaging?: boolean) {
    SearchEntity.Skip = IsPaging ? this.PagingModel.Take * this.PagingModel.Active : 0;
    SearchEntity.Take = this.PagingModel.Take;
    this.HttpService.Gets(SearchEntity).subscribe(p => {
      this.Entities = p;
      this.toastr.ShowSuccess();
    }, e => {
      this.toastr.ShowError(e);
    });
    this.Count(SearchEntity);
  }
  GetId(Id: number) {
    this.HttpService.GetId(Id).subscribe(p => {
      this.Entity = p;
    });
  }
  Count(FilterEntity?: FilterEntity) {
    this.HttpService.Count(FilterEntity).subscribe(data => {
      this.PagingModel.TotalPage = Math.ceil(data / this.PagingModel.Take);
    });
  }

  Edit(T: T) {
    this.temp = JSON.parse(JSON.stringify(T));
    T.IsEdit = true;
  }

  Add(T: any) {
    this.Entities.unshift(T);
  }

  Delete(T: T) {
    this.HttpService.Delete(T.Id).subscribe(p => {
      let indexOf = this.Entities.indexOf(T);
      this.Entities.splice(indexOf, 1);
      this.toastr.ShowSuccess();
    }, e => {
      this.toastr.ShowError(e);
    });
  }

  Save(T: T) {
    if (T.Id === undefined || T.Id === null || T.Id == 0) {
      this.HttpService.Create(T).subscribe(p => {
        if (this.Entities != null) {
          this.Entities[0] = p;
          this.Entities[0].IsEdit = false;
        } else {
          T = p;
        }
        this.toastr.ShowSuccess();
      }, e => {
        this.toastr.ShowError(e);
      });
    } else {
      this.HttpService.Update(T).subscribe(p => {
        if (this.Entities != null) {
          for (let i = 0; i < this.Entities.length; i++) {
            if (this.Entities[i].Id == p.Id) {
              this.Entities[i] = p;
              this.Entities[i].IsEdit = false;
            }
          }
        } else {
          T = p;
        }
        this.toastr.ShowSuccess();
      }, e => {
        this.toastr.ShowError(e);
      });
    }
  }

  Cancel(T: T) {
    if (T.Id === undefined || T.Id === null) {
      this.Entities.splice(0, 1);
    } else {
      for (let i = 0; i < this.Entities.length; i++) {
        if (this.Entities[i].Id == this.temp.Id) {
          this.Entities[i] = this.temp;
          this.Entities[i].IsEdit = false;
        }
      }
    }
  }
}
