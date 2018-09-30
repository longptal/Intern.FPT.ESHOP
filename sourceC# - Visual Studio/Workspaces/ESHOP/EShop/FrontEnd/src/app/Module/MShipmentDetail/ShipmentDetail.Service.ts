import 'rxjs/Rx';
import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { ShipmentDetailEntity } from "./ShipmentDetail.Entity";
import { HttpService } from '../../Shared/HttpService';

@Injectable()
export class ShipmentDetailService extends HttpService<ShipmentDetailEntity> {
    constructor(Http: HttpClient) {
        super(Http);
        this.url = '/api/ShipmentDetails';
    }
}
