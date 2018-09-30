import 'rxjs/Rx';
import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { LanguageEntity } from "./Language.Entity";
import { HttpService } from '../../Shared/HttpService';

@Injectable()
export class LanguageService extends HttpService<LanguageEntity> {
    constructor(Http: HttpClient) {
        super(Http);
        this.url = '/api/Languages'
    }
}
