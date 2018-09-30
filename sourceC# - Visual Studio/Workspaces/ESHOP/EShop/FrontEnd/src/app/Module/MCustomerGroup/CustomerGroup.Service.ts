import 'rxjs/Rx';
import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { HttpService } from '../../Shared/HttpService';
import { CustomerGroupEntity } from '../MCustomerGroup/CustomerGroup.Entity';

@Injectable()
export class CustomerGroupService extends HttpService<CustomerGroupEntity> {
  constructor(Http: HttpClient) {
    super(Http);
    this.url = '/api/CustomerGroups';
  }
}
