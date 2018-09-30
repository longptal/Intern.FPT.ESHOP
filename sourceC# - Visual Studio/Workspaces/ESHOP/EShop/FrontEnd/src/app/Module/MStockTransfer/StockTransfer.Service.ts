import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { StockTransferEntity } from './StockTransfer.Entity';
import { HttpService } from '../../Shared/HttpService';

@Injectable()
export class StockTransferService extends HttpService<StockTransferEntity>{
    constructor(private Http: HttpClient) {
        super(Http);
        this.url = '/api/Categories';
    }
}
