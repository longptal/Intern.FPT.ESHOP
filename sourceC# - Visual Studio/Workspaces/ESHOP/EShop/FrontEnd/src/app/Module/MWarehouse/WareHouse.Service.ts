import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { HttpService } from '../../Shared/HttpService';
import { WareHouseEntity } from "./WareHouse.Entity";

@Injectable()
export class WareHouseService extends HttpService<WareHouseEntity>{
  constructor(private Http: HttpClient) {
    super(Http);
    this.url = '/api/WareHouses';
  }
}
