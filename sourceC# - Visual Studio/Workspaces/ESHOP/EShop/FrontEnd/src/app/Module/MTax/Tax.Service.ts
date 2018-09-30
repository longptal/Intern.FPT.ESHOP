import 'rxjs/Rx';
import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { TaxEntity } from "./Tax.Entity";
import { HttpService } from '../../Shared/HttpService';

@Injectable()
export class TaxService extends HttpService<TaxEntity> {
    constructor(Http: HttpClient) {
        super(Http);
        this.url = '/api/Taxes';
    }
}
