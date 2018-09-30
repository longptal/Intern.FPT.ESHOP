import 'rxjs/Rx';
import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { EmployeeEntity } from '../Module/MEmployee/Employee.Entity';

@Injectable()
export class EmployeeInfoService {
  EmployeeEntity: EmployeeEntity;

  constructor() {

  }

  GetCurrent(): EmployeeEntity {
    if (this.EmployeeEntity == null) {
      let EJWT = this.GetCookie("EJWT");
      let User = EJWT.split(".")[1];
      if (User == null) {
        console.error("Cannot recognize JWT token!");
        return;
      }
      let user = JSON.parse(window.atob(User));
      this.EmployeeEntity = user.UserEntity;
    }
    return this.EmployeeEntity;
  }

  GetCookie(cname) {
    let name = cname + "=";
    let decodedCookie = decodeURIComponent(document.cookie);
    let ca = decodedCookie.split(';');
    for (let i = 0; i < ca.length; i++) {
      let c = ca[i];
      while (c.charAt(0) == ' ') {
        c = c.substring(1);
      }
      if (c.indexOf(name) == 0) {
        return c.substring(name.length, c.length);
      }
    }
    return "";
  }
}
