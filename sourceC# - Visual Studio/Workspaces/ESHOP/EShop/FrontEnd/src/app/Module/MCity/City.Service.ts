import 'rxjs/Rx';
import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { CityEntity } from "./City.Entity";
import { HttpService } from '../../Shared/HttpService';

@Injectable()
export class CityService extends HttpService<CityEntity> {
    constructor(Http: HttpClient) {
        super(Http);
      this.url = '/api/Cities';
    }
}
