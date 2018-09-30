import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { InventoryTurnoverEntity } from "./InventoryTurnover.Entity";
import { HttpService } from '../../Shared/HttpService';

@Injectable()
export class InventoryTurnoverService extends HttpService<InventoryTurnoverEntity> {
  constructor(Http: HttpClient) {
    super(Http);
    this.url = '/api/InventoryTurnovers';
  }
}
