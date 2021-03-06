import {Component, EventEmitter, Input, OnInit, Output} from '@angular/core';
import {DataEntity} from "./Data.Entity";

@Component({
    selector: 'inputfile',
    templateUrl: './inputfile.component.html'
})
export class InputfileComponent implements OnInit {
    Id: string = this.MakeRandomId();

    @Input() DataEntity: DataEntity = new DataEntity();
    @Output() onFileChanged: EventEmitter<DataEntity> = new EventEmitter();
    FileReader: any = new FileReader();
    constructor() {
    }

    @Input('FileId')
    set Innit(value: string) {
        if (value !== undefined)
            this.Id = value;
        else console.warn("FileId Field isn't setted !")
    }

    ngOnInit() {
    }

    OpenFile() {
        document.getElementById(this.Id).click();
    }


    LoadFile(files) {
        let f = files[0];
        this.DataEntity.Name = f.name;
        this.DataEntity.Length = f.size;
        let Arr = this.DataEntity.Name.split('.');
        this.DataEntity.Extension = Arr.length > 1 ? Arr[Arr.length - 1] : Arr[0];
        this.FileReader.readAsDataURL(f);
        this.FileReader.onloadend = e => { //callback after files finish loading
            this.DataEntity.Data = this.FileReader.result;
            this.DataEntity.Data = this.DataEntity.Data.substr(this.DataEntity.Data.indexOf(',') + 1);
            this.onFileChanged.emit(this.DataEntity);
        };
        
    }

    MakeRandomId(): string {
        let text = "";
        let possible = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        for (let i = 0; i < 5; i++)
            text += possible.charAt(Math.floor(Math.random() * possible.length));
        return text;
    }
}

