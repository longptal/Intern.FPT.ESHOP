import 'rxjs/Rx';
import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { CountryEntity } from "./Country.Entity";
import { HttpService } from '../../Shared/HttpService';

@Injectable()
export class CountryService extends HttpService<CountryEntity> {
    constructor(Http: HttpClient) {
        super(Http);
        this.url = '/api/Countries';
    }
}
