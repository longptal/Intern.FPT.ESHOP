import { Component, OnInit, ViewEncapsulation, ViewContainerRef, Input, ChangeDetectorRef } from '@angular/core';
import { NgbDateISOParserFormatter } from "@ng-bootstrap/ng-bootstrap/datepicker/ngb-date-parser-formatter";
import { NgbDateStruct } from "@ng-bootstrap/ng-bootstrap";
import { PackEntity } from '../../Module/MPack/Pack.Entity';
import { PackSearchEntity } from '../../Module/MPack/Pack.SearchEntity';
import { PagingModel } from '../../Shared/MaterialComponent/paging/paging.model';
import { PackService } from '../../Module/MPack/Pack.Service';
import { BottomToastsManager } from '../../Shared/CustomToaster';
import { CommonComponent } from '../../app.component';

@Component({
    selector: "app-pack",
    templateUrl: "./Pack.component.html",
    styleUrls: ["./Pack.component.css"],
    encapsulation: ViewEncapsulation.None,
})
export class PackComponent extends CommonComponent<PackEntity> implements OnInit {
    PackSearchEntity: PackSearchEntity;
    @Input() ProductId: number;
    constructor(public PackService: PackService, cd: ChangeDetectorRef, public toastr: BottomToastsManager, vcr: ViewContainerRef) {
      super(PackService, cd, toastr, vcr);
    }
    ngOnInit() {
      this.PackSearchEntity = new PackSearchEntity();
      this.PackSearchEntity.ProductId = this.ProductId;
      this.Search(this.PackSearchEntity);
    }
}
