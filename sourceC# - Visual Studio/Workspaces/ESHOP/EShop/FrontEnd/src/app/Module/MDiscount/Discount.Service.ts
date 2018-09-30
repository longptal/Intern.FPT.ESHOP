import 'rxjs/Rx';
import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {DiscountEntity} from './Discount.Entity';
import {HttpService} from '../../Shared/HttpService';

@Injectable()
export class DiscountService extends HttpService<DiscountEntity> {
  constructor(Http: HttpClient) {
    super(Http);
    this.url = '/api/Discounts';
  }
}
