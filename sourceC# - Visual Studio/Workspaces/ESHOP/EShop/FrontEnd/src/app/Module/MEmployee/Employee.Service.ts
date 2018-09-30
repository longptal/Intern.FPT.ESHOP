import 'rxjs/Rx';
import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {HttpService} from '../../Shared/HttpService';
import {EmployeeEntity} from './Employee.Entity';

@Injectable()
export class EmployeeService extends HttpService<EmployeeEntity> {
  constructor(Http: HttpClient) {
    super(Http);
    this.url = '/api/Employees';
  }
}
