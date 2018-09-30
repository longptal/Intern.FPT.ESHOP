import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { CategoryEntity } from './Category.Entity';
import { HttpService } from '../../Shared/HttpService';

@Injectable()
export class CategoryService extends HttpService<CategoryEntity>{
    constructor(private Http: HttpClient) {
        super(Http);
        this.url = '/api/Categories';
    }
}
