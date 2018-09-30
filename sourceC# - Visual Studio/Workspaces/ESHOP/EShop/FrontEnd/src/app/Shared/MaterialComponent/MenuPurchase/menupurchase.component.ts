import { Component, EventEmitter, Input, Output, OnInit} from '@angular/core';
import {fakeAsync} from "@angular/core/testing";
import { Router } from "@angular/router";

@Component({
    selector: 'menupurchase',
    templateUrl: './menupurchase.component.html',
    styleUrls: ['./menupurchase.component.css']
})

export class MenuPurchaseComponent implements OnInit {
    @Input() NumberSelected: number;
    MenuList: any[] = [{ Number: 1, Name: 'Đề nghị', SubName: 'Mua sắm', Active: false, Link: 'Fams/PurchaseRequest', Query: null },
        { Number: 2, Name: 'Phương án', SubName: 'Mua sắm', Active: false, Link: 'Fams/PurchasePlan', Query: {Type: 'PROCESS'} },
        { Number: 3, Name: 'Catalog', SubName: 'Đặt hàng', Active: false, Link: 'Fams/Catalogs', Query: null},
        { Number: 4, Name: 'Đặt hàng', SubName: 'Sản phẩm', Active: false, Link: 'Fams/PurchaseOrders', Query: null},
        { Number: 5, Name: 'Nhận hàng', SubName: 'Sản phẩm', Active: false, Link: 'Fams/PurchaseReceipt', Query: null },
        { Number: 6, Name: 'Thanh toán', SubName: 'Mua hàng', Active: false, Link: '#', Query: null}]

    constructor(private Router: Router) {
    }
    ngOnInit() {
        if (!this.NumberSelected) {
            throw new Error('Number value is required!')
        } else {
            for (let i of this.MenuList) {
                if (i.Number === this.NumberSelected) {
                    i.Active = true;
                } else {
                    i.Active = false;
                }
            }
        }
    }
    NavigateLink(Menu) {
        if (Menu.Query !== null) {
            this.Router.navigate([Menu.Link], { queryParams: Menu.Query });
        } else {
            this.Router.navigate([Menu.Link]);
        }
    }
}