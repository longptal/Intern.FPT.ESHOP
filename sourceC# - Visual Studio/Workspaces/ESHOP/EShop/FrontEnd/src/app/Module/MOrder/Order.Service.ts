import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { HttpService } from '../../Shared/HttpService';
import { OrderEntity } from './Order.Entity';

@Injectable()
export class OrderService extends HttpService<OrderEntity>{
    constructor(private Http: HttpClient) {
        super(Http);
        this.url = '/api/Orders';
    }
}
