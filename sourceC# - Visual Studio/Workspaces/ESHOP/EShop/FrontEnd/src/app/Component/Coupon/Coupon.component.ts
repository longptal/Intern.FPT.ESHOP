import {ChangeDetectorRef, Component, OnInit, ViewContainerRef, ViewEncapsulation} from '@angular/core';
import {CouponEntity} from '../../Module/MCoupon/Coupon.Entity';
import {CouponSearchEntity} from '../../Module/MCoupon/Coupon.SearchEntity';
import {CouponService} from '../../Module/MCoupon/Coupon.Service';
import {BottomToastsManager} from '../../Shared/CustomToaster';
import {CommonComponent} from '../../app.component';

@Component({
  selector: 'app-coupon',
  templateUrl: './Coupon.component.html',
  styleUrls: ['./Coupon.component.css'],
  encapsulation: ViewEncapsulation.None,
})
export class CouponComponent extends CommonComponent<CouponEntity> implements OnInit {
  CouponSearchEntity: CouponSearchEntity = new CouponSearchEntity();

  constructor(public CouponService: CouponService, cd: ChangeDetectorRef, public toastr: BottomToastsManager, vcr: ViewContainerRef) {
    super(CouponService, cd, toastr, vcr);
    this.CouponSearchEntity = new CouponSearchEntity();
    this.Search(this.CouponSearchEntity);
  }

  ngOnInit() {

  }
}
