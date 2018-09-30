import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { HttpService } from '../../Shared/HttpService';
import { StockTransferLineEntity } from './StockTransferLine.Entity';

@Injectable()
export class StockTransferLineService extends HttpService<StockTransferLineEntity>{
    constructor(private Http: HttpClient) {
        super(Http);
        this.url = '/api/StockTransferLines';
    }
}
