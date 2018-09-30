import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { HttpService } from '../../Shared/HttpService';
import { ReceiptNoteEntity } from './ReceiptNote.Entity';

@Injectable()
export class ReceiptNoteService extends HttpService<ReceiptNoteEntity>{
    constructor(private Http: HttpClient) {
        super(Http);
        this.url = '/api/ReceiptNotes';
    }
}
