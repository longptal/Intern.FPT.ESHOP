import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { HttpService } from '../../Shared/HttpService';
import { ReceiptNoteLineEntity } from './ReceiptNoteLine.Entity';

@Injectable()
export class ReceiptNoteLineService extends HttpService<ReceiptNoteLineEntity>{
    constructor(private Http: HttpClient) {
        super(Http);
        this.url = '/api/ReceiptNoteLines';
    }
}
