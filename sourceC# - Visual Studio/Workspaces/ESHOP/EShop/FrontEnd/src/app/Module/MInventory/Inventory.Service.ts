import 'rxjs/Rx';
import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { InventoryEntity } from "./Inventory.Entity";
import { HttpService } from '../../Shared/HttpService';

@Injectable()
export class InventoryService extends HttpService<InventoryEntity> {
    constructor(Http: HttpClient) {
        super(Http);
        this.url = '/api/Inventories';
    }
}
