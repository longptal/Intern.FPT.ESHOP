import 'rxjs/Rx';
import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { PriceListEntity } from "./PriceList.Entity";
import { HttpService } from '../../Shared/HttpService';

@Injectable()
export class PriceListService extends HttpService<PriceListEntity> {
    constructor(Http: HttpClient) {
        super(Http);
        this.url = "/api/PriceLists";
    }
}
