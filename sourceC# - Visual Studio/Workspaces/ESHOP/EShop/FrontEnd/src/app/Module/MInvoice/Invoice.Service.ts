import 'rxjs/Rx';
import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { InvoiceEntity } from "./Invoice.Entity";
import { HttpService } from '../../Shared/HttpService';

@Injectable()
export class InvoiceService extends HttpService<InvoiceEntity> {
  constructor(Http: HttpClient) {
    super(Http);
    this.url = '/api/Invoices';
  }
}
