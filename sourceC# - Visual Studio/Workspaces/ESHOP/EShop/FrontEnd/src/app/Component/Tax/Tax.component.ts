import { Component, OnInit, ViewEncapsulation, ViewContainerRef, ChangeDetectorRef } from '@angular/core';
import { NgbDateISOParserFormatter } from "@ng-bootstrap/ng-bootstrap/datepicker/ngb-date-parser-formatter";
import { NgbDateStruct } from "@ng-bootstrap/ng-bootstrap";
import { TaxEntity } from '../../Module/MTax/Tax.Entity';
import { TaxSearchEntity } from '../../Module/MTax/Tax.SearchEntity';
import { PagingModel } from '../../Shared/MaterialComponent/paging/paging.model';
import { TaxService } from '../../Module/MTax/Tax.Service';
import { BottomToastsManager } from '../../Shared/CustomToaster';
import { CommonComponent } from '../../app.component';

@Component({
    selector: "app-Tax",
    templateUrl: "./Tax.component.html",
    styleUrls: ["./Tax.component.css"],
    encapsulation: ViewEncapsulation.None,
})
export class TaxComponent extends CommonComponent<TaxEntity> implements OnInit {
    TaxSearchEntity: TaxSearchEntity = new TaxSearchEntity();
    constructor(public TaxService: TaxService, cd: ChangeDetectorRef, public toastr: BottomToastsManager, vcr: ViewContainerRef) {
      super(TaxService, cd, toastr, vcr);
      this.TaxSearchEntity = new TaxSearchEntity();
      this.Search(this.TaxSearchEntity);
    }
    ngOnInit() {

    }
}
