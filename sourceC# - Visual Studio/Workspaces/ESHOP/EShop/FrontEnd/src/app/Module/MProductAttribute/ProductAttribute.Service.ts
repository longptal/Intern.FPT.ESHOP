import 'rxjs/Rx';
import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { ProductAttributeEntity } from "./ProductAttribute.Entity";
import { ProductAttributeSearchEntity } from "./ProductAttribute.SearchEntity";
import { HttpService } from '../../Shared/HttpService';

@Injectable()
export class ProductAttributeService extends HttpService<ProductAttributeEntity> {
    constructor(Http: HttpClient) {
        super(Http);
        this.url = "/api/ProductAttributes";
    }
}
