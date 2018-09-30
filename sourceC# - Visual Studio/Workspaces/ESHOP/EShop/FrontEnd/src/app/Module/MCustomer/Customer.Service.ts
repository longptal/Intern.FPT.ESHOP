import 'rxjs/Rx';
import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { CustomerEntity } from "./Customer.Entity";
import { HttpService } from '../../Shared/HttpService';

@Injectable()
export class CustomerService extends HttpService<CustomerEntity> {
  constructor(Http: HttpClient) {
    super(Http);
    this.url = '/api/Customers';
  }
}
