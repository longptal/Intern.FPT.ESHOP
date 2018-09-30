import { Component, OnInit, ViewEncapsulation, ViewContainerRef, Input, ChangeDetectorRef } from '@angular/core';
import { NgbDateISOParserFormatter } from "@ng-bootstrap/ng-bootstrap/datepicker/ngb-date-parser-formatter";
import { NgbDateStruct } from "@ng-bootstrap/ng-bootstrap";
import { DiscountEntity } from '../../Module/MDiscount/Discount.Entity';
import { DiscountSearchEntity } from '../../Module/MDiscount/Discount.SearchEntity';
import { PagingModel } from '../../Shared/MaterialComponent/paging/paging.model';
import { DiscountService } from '../../Module/MDiscount/Discount.Service';
import { BottomToastsManager } from '../../Shared/CustomToaster';
import { CommonComponent } from '../../app.component';

@Component({
    selector: "app-discount",
    templateUrl: "./Discount.component.html",
    styleUrls: ["./Discount.component.css"],
    encapsulation: ViewEncapsulation.None,
})
export class DiscountComponent extends CommonComponent<DiscountEntity> implements OnInit {
    DiscountSearchEntity: DiscountSearchEntity;
    @Input() ProductId: number;
    constructor(public DiscountService: DiscountService, cd: ChangeDetectorRef, public toastr: BottomToastsManager, vcr: ViewContainerRef) {
      super(DiscountService, cd, toastr, vcr);
    }
    ngOnInit() {
      this.DiscountSearchEntity = new DiscountSearchEntity();
      this.DiscountSearchEntity.ProductId = this.ProductId;
      this.Search(this.DiscountSearchEntity);
    }
}
