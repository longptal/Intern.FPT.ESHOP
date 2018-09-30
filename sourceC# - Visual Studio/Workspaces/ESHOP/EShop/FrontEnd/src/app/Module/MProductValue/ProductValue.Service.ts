import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { ProductValueEntity } from "./ProductValue.Entity";
import { HttpService } from '../../Shared/HttpService';

@Injectable()
export class ProductValueService extends HttpService<ProductValueEntity> {
    constructor(Http: HttpClient) {
        super(Http);
      this.url = '/api/ProductValues';
    }
}
