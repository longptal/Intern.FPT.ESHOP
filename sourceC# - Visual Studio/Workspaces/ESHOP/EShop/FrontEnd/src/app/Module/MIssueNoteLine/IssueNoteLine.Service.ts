import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { HttpService } from '../../Shared/HttpService';
import { IssueNoteLineEntity } from './IssueNoteLine.Entity';

@Injectable()
export class IssueNoteLineService extends HttpService<IssueNoteLineEntity>{
    constructor(private Http: HttpClient) {
        super(Http);
        this.url = '/api/IssuseNoteLines';
    }
}
