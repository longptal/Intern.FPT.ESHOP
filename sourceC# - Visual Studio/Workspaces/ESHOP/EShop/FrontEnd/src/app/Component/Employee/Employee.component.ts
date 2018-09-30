import {ChangeDetectorRef, Component, ViewChild, ViewContainerRef} from '@angular/core';
import {EmployeeService} from '../../Module/MEmployee/Employee.Service';
import {BottomToastsManager} from '../../Shared/CustomToaster';
import {EmployeeEntity} from '../../Module/MEmployee/Employee.Entity';
import {ModalComponent} from '../../Shared/MaterialComponent/modal/modal.component';
import {CommonComponent} from '../../app.component';
import {SearchEmployeeEntity} from '../../Module/MEmployee/Employee.SearchEntity';


@Component({
  selector: 'App-Employee',
  templateUrl: './Employee.Component.html',
  styleUrls: ['./Employee.Component.css'],
  providers: [EmployeeService,
    BottomToastsManager]
})
export class EmployeeComponent extends CommonComponent<EmployeeEntity> {
  Title: string = 'Employee';
  SearchEmployeeEntity: SearchEmployeeEntity = new SearchEmployeeEntity();
  EditEmployee: EmployeeEntity = new EmployeeEntity();
  EditPosition: number = 0;
  @ViewChild('EditModal') EditModal: ModalComponent;

  constructor(public EmployeeService: EmployeeService,
              cd: ChangeDetectorRef,
              toastr: BottomToastsManager, vcr: ViewContainerRef) {
    super(EmployeeService, cd, toastr, vcr);
    this.PagingModel.Take = 10000;
    this.Search(this.SearchEmployeeEntity);
  }

  LoadDataToUpdateModal(Employee: EmployeeEntity, index: number) {
    this.EditEmployee = JSON.parse(JSON.stringify(Employee));
    this.EditPosition = index;
    this.EditModal.Open();
  }

  // LoadService(Store: StoreEntity | number) {
  //   if (Store == null) {
  //     this.ServiceStoreEntites = [];
  //     this.EditEmployee.ServiceEmployeeEntities = [];
  //     return;
  //   }
  //   let StoreId = (typeof Store) == 'number' ? Store : Store['Id'];
  //   if (StoreId != null) {
  //     let t = new SearchServiceStoreEntity();
  //     t.StoreId = StoreId;
  //     this.ServiceStoreService.Gets(t).subscribe(entities => {
  //       this.ServiceStoreEntites = entities;
  //       this.ServiceStoreEntites.forEach(se => {
  //         if (this.EditEmployee.ServiceEmployeeEntities != null) {
  //           se.IsChecked = this.EditEmployee.ServiceEmployeeEntities.some(x => x.ServiceId == se.ServiceId);
  //         }
  //       });
  //     });
  //   }
  // }

  AddNewEmployee() {
    this.EditEmployee = new EmployeeEntity();
    this.EditPosition = -1;
    // this.LoadService(null);
    this.EditModal.Open();
  }

  Save() {
    // if (this.ServiceStoreEntites != null) {
    //   this.EditEmployee.ServiceEmployeeEntities = this.ServiceStoreEntites.filter(ss => {
    //     return ss.IsChecked;
    //   }).map(ss => {
    //     let t = new ServiceEmployeeEntity();
    //     t.ServiceId = ss.ServiceId;
    //     return t;
    //   });
    // } else {
    //   this.EditEmployee.ServiceEmployeeEntities = [];
    // }
    if (this.EditEmployee.Id == 0) {
      this.EmployeeService.Create(this.EditEmployee).subscribe(employee => {
        this.Entities.unshift(employee);
        this.toastr.ShowSuccess();
        this.EditModal.Close();
      }, err => {
        this.toastr.ShowError(err);
      });
    } else {
      this.EmployeeService.Update(this.EditEmployee).subscribe(employee => {
        this.Entities[this.EditPosition] = employee;
        this.toastr.ShowSuccess();
        this.EditModal.Close();
      }, err => {
        this.toastr.ShowError(err);
      });
    }
  }
}
