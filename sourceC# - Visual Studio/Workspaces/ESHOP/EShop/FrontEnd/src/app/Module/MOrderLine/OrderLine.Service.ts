import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { HttpService } from '../../Shared/HttpService';
import { OrderLineEntity } from './OrderLine.Entity';

@Injectable()
export class OrderLineService extends HttpService<OrderLineEntity>{
    constructor(private Http: HttpClient) {
        super(Http);
        this.url = '/api/OrderLines';
    }
}
