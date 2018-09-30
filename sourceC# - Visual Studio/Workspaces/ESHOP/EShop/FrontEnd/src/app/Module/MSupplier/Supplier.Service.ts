import 'rxjs/Rx';
import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { SupplierEntity } from "./Supplier.Entity";
import { SupplierSearchEntity } from "./Supplier.SearchEntity";
import { HttpService } from '../../Shared/HttpService';

@Injectable()
export class SupplierService extends HttpService<SupplierEntity> {
    constructor(Http: HttpClient) {
        super(Http);
        this.url =  "/api/Suppliers";
    }
}
