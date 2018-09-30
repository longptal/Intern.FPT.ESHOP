import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { HttpService } from '../../Shared/HttpService';
import { IssueNoteEntity } from './IssueNote.Entity';

@Injectable()
export class IssueNoteService extends HttpService<IssueNoteEntity>{
    constructor(private Http: HttpClient) {
        super(Http);
        this.url = '/api/IssueNotes';
    }
}
