import 'rxjs/Rx';
import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { OperationEntity } from "./Operation.Entity";
import { HttpService } from '../../Shared/HttpService';

@Injectable()
export class OperationService extends HttpService<OperationEntity> {
    constructor(Http: HttpClient) {
        super(Http);
        this.url = '/api/Operations';
    }
}
