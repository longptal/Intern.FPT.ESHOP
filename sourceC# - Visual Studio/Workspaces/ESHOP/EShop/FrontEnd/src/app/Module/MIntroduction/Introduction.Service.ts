import 'rxjs/Rx';
import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { IntroductionEntity } from "./Introduction.Entity";
import { HttpService } from '../../Shared/HttpService';

@Injectable()
export class IntroductionService extends HttpService<IntroductionEntity> {
    constructor(Http: HttpClient) {
        super(Http);
        this.url = '/api/Introductions';
    }
}
