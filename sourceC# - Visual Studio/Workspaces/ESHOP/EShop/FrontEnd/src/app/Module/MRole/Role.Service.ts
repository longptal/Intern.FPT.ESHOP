import 'rxjs/Rx';
import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { RoleEntity } from "./Role.Entity";
import { HttpService } from '../../Shared/HttpService';

@Injectable()
export class RoleService extends HttpService<RoleEntity> {
    constructor(Http: HttpClient) {
        super(Http);
        this.url = "/api/Roles";
    }
}
