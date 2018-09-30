import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { ProductPictureEntity } from "./ProductPicture.Entity";
import { HttpService } from '../../Shared/HttpService';

@Injectable()
export class ProductPictureService extends HttpService<ProductPictureEntity> {
    constructor(Http: HttpClient) {
        super(Http);
      this.url = '/api/ProductPictures';
    }
}
