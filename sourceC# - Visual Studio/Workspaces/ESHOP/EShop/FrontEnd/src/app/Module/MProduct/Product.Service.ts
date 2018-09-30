import 'rxjs/Rx';
import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { ProductEntity } from "./Product.Entity";
import { HttpService } from '../../Shared/HttpService';

@Injectable()
export class ProductService extends HttpService<ProductEntity> {
    constructor(Http: HttpClient) {
        super(Http);
        this.url = "/api/Products";
    }
}
