import {Injectable} from '@angular/core';
import {ActivatedRouteSnapshot, CanActivate, RouterStateSnapshot, Router} from '@angular/router';
import { EmployeeInfoService } from './Shared/EmployeeInfo.Service';
import { Route } from '@angular/router/src/config';
// import {AuthService} from './Modules/Auth/Auth.Service';

@Injectable()
export class AuthGuard implements CanActivate {
  constructor(
    private EmployeeInfoService: EmployeeInfoService, private router: Router
    ) {
    }

    canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean {
      let url: string = state.url;
      //if (this.EmployeeInfoService.GetCurrent() == null) {
      //  this.router.navigate(['/Login']);
      //}
        return true;
//        return this.authService.GetTypeOfLayout('',url).Ty == 'Show';
    }
}
