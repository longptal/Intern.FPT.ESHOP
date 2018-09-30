import 'rxjs/Rx';
import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { PackEntity } from "./Pack.Entity";
import { HttpService } from '../../Shared/HttpService';

@Injectable()
export class PackService extends HttpService<PackEntity> {
    constructor(Http: HttpClient) {
        super(Http);
        this.url = '/api/Packs';
    }
}
