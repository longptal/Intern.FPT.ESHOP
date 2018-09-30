import {Component} from "@angular/core";
import {MenuModel} from "../../menu-model";
import { HttpClient } from "@angular/common/http";
import { HttpService } from "../HttpService";
import { IEntity } from "../../Module/IEntity.Entity";
import { EmployeeInfoService } from "../EmployeeInfo.Service";
//import {Http} from "@angular/http";
// import {AuthService} from "../../Modules/Auth/Auth.Service";
// import {UserEntity} from "../../Modules/User/User.Entity";
// import {UserService} from "../../Modules/User/User.Service";
// import { PermissionService } from "app/Modules/Permission/Permission.Service";

// import {LayerAccessControlEntity} from "../../Modules/LayerAccessControl/LayerAccessControl.Entity";

@Component({
    selector: 'public-login',
    templateUrl: './Login.Component.html',
    styleUrls: ['./Login.Component.css']
})
export class LoginComponent {
  LoginModel: LoginModel = new LoginModel();

  constructor(private HttpService: HttpService<LoginModel>
    , public EmployeeInfoService: EmployeeInfoService
  ) {
    this.HttpService.url = "/api/Auth/employee-sign-in";
  }

  SignIn() {
    this.HttpService.Create(this.LoginModel).subscribe(res => {
      let data = (res as any);
      let UserInfo = this.DecodeUserInfo(data);
      this.setCookie("EJWT", data.token, UserInfo.exp);
      this.EmployeeInfoService.GetCurrent();
    })
  }

  DecodeUserInfo(data) {
  let User = data.token.split(".")[1];
  if (User == null) {
    console.error("Cannot recognize JWT token!");
    return;
  }
  let user = JSON.parse(this.b64DecodeUnicode(User));
  console.log(user);
  return user;
}

 setCookie(cname, cvalue, exp) {
  var d = new Date();
  d.setTime(d.getTime() + exp);
  var expires = "expires=" + exp;
  document.cookie = cname + "=" + cvalue + ";" + expires + ";path=/";
}

 b64DecodeUnicode(str) {
  str = str.replace('-', '+').replace('_', '/');
  switch (str.length % 4) {
    case 0:
      break;
    case 2:
      str += '==';
      break;
    case 3:
      str += '=';
      break;
    default:
      throw 'Illegal base64url string!';
  }
  return decodeURIComponent(Array.prototype.map.call(atob(str), function (c) {
    return '%' + ('00' + c.charCodeAt(0).toString(16)).slice(-2)
  }).join(''))
}
}

export class LoginModel extends IEntity {
  Username: string;
  Password: string;
}
