import {ChangeDetectorRef, Component, OnInit, ViewContainerRef, ViewEncapsulation} from '@angular/core';
import {CommonComponent} from '../../../app.component';
import {WareHouseService} from '../../../Module/MWareHouse/WareHouse.Service';
import {BottomToastsManager} from '../../../Shared/CustomToaster';
import {SupplierService} from '../../../Module/MSupplier/Supplier.Service';
import {ActivatedRoute} from '@angular/router';
import {ReceiptNoteLineEntity} from '../../../Module/MReceiptNoteLine/ReceiptNoteLine.Entity';
import {ReceiptNoteLineSearchEntity} from '../../../Module/MReceiptNoteLine/ReceiptNoteLine.SearchEntity';
import {ReceiptNoteLineService} from '../../../Module/MReceiptNoteLine/ReceiptNoteLine.Service';
import { IssueNoteLineEntity } from "../../../Module/MIssueNoteLine/IssueNoteLine.Entity";
import { IssueNoteLineSearchEntity } from "../../../Module/MIssueNoteLine/IssueNoteLine.SearchEntity";
import { IssueNoteLineService } from "../../../Module/MIssueNoteLine/IssueNoteLine.Service";

@Component({
  selector: 'app-IssueNoteLine',
  templateUrl: './IssueNoteLine.component.html',
  styleUrls: ['./IssueNoteLine.component.css'],
  encapsulation: ViewEncapsulation.None,
})
export class IssueNoteLineComponent extends CommonComponent<IssueNoteLineEntity> implements OnInit {
  public IssueNoteId: number = 0;
  public FilterEntity: IssueNoteLineSearchEntity = new IssueNoteLineSearchEntity();

  constructor(public IssueNoteLineService: IssueNoteLineService, cd: ChangeDetectorRef,  toastr: BottomToastsManager, vcr: ViewContainerRef,
              public SupplierService: SupplierService, public WareHouseService: WareHouseService, public route: ActivatedRoute) {

    super(IssueNoteLineService, cd, toastr, vcr);

    this.route.params.subscribe((params) => {

      if (params.IssueNoteId !== undefined) {
        this.IssueNoteId = params.IssueNoteId;
        this.FilterEntity.IssueNoteId = this.IssueNoteId;
        this.Search(this.FilterEntity);
      }
    });
  }

  ngOnInit() {

  }
}
