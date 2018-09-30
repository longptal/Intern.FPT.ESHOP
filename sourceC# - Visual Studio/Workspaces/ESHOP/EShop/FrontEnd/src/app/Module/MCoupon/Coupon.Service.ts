import 'rxjs/Rx';
import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { CouponEntity } from "./Coupon.Entity";
import { HttpService } from '../../Shared/HttpService';

@Injectable()
export class CouponService extends HttpService<CouponEntity> {
    constructor(Http: HttpClient) {
        super(Http);
        this.url = '/api/Coupons';
    }
}
