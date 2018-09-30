import 'rxjs/Rx';
import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { OpeningBalanceEntity } from "./OpeningBalance.Entity";
import { HttpService } from '../../Shared/HttpService';

@Injectable()
export class OpeningBalanceService extends HttpService<OpeningBalanceEntity> {
    constructor(Http: HttpClient) {
        super(Http);
        this.url = "/api/PriceLists";
    }
}
