import 'rxjs/Rx';
import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { HttpService } from '../../Shared/HttpService';
import { ManufacturerEntity } from "./Manufacturer.Entity";

@Injectable()
export class ManufacturerService extends HttpService<ManufacturerEntity> {
    constructor(Http: HttpClient) {
        super(Http);
        this.url = "/api/Manufacturers";
    }
}
