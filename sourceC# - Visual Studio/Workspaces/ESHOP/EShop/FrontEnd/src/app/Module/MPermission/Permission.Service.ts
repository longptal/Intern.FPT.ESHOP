import 'rxjs/Rx';
import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { PermissionEntity } from "./Permission.Entity";
import { HttpService } from '../../Shared/HttpService';

@Injectable()
export class PermissionService extends HttpService<PermissionEntity> {
    constructor(Http: HttpClient) {
        super(Http);
        this.url = "/api/Permissions";
    }
}
