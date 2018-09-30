import {RouterModule, Routes} from '@angular/router';
import {CouponComponent} from './Component/Coupon/Coupon.component';
import {CategoryComponent} from './Component/Category/Category.component';
import {ProductAttributeComponent} from './Component/ProductAttribute/ProductAttribute.component';
import {IntroductionComponent} from './Component/Introduction/Introduction.component';
import {InventoryComponent} from './Component/Inventory/Inventory.component';
import {LanguageComponent} from './Component/Language/Language.component';
import {OperationComponent} from './Component/Operation/Operation.component';
import {PermissionComponent} from './Component/Permission/Permission.component';
import {ProductComponent} from './Component/Product/Product.component';
import {RoleComponent} from './Component/Role/Role.component';
import {SupplierComponent} from './Component/Supplier/Supplier.component';
import {LoginComponent} from './Shared/Login/Login.Component';
import {AuthGuard} from './Auth.Guard.Service';
import {IssueNoteComponent} from './Component/IssueNote/IssueNote.component';
import {ReceiptNoteComponent} from './Component/ReceiptNote/ReceiptNote.component';
import {WareHouseComponent} from './Component/Warehouse/WareHouse.component';
import {ProductDetailComponent} from './Component/Product/ProductDetail/ProductDetail.component';
import {ManufacturerComponent} from './Component/Manufacturer/Manufacturer.component';
import {CustomerGroupComponent} from './Component/CustomerGroup/CustomerGroup.component';
import {CountryComponent} from './Component/Country/Country.component';
import {CityComponent} from './Component/City/City.component';
import {ShipmentDetailComponent} from './Component/ShipmentDetail/ShipmentDetail.component';
import {OpeningBalanceComponent} from './Component/OpeningBalance/OpeningBalance.component';
import {StockTransferComponent} from './Component/StockTransfer/StockTransfer.component';
import {ReceiptNoteDetailComponent} from './Component/ReceiptNote/Detail/ReceiptNoteDetail.component';
import {EmployeeComponent} from './Component/Employee/Employee.component';
import {OrderComponent} from './Component/Order/Order.component';
import {OrderDetailComponent} from './Component/Order/Detail/OrderDetail.component';
import { IssueNoteDetailComponent } from "./Component/IssueNote/Detail/IssueNoteDetail.component";


//[END]
const routes: Routes = [
  {
    'path': 'Manufacturers',
    'component': ManufacturerComponent,
  },
  {
    'path': 'Categories',
    'component': CategoryComponent,
    canActivate: [AuthGuard],
  },
  {
    'path': 'Categories/:CategoryId',
    children: [
      {
        'path': 'ProductAttributes',
        'component': ProductAttributeComponent,
      }
    ],
    canActivate: [AuthGuard],
  },
  {
    'path': 'Coupons',
    'component': CouponComponent,
    canActivate: [AuthGuard],
  },
  {
    'path': 'Introductions',
    'component': IntroductionComponent,
    canActivate: [AuthGuard],
  },
  {
    'path': 'Inventories',
    'component': InventoryComponent,
    canActivate: [AuthGuard],
  },
  {
    'path': 'Languages',
    'component': LanguageComponent,
    canActivate: [AuthGuard],
  },
  {
    'path': 'Operations',
    'component': OperationComponent,
    canActivate: [AuthGuard],
  },
  {
    'path': 'Permissions',
    'component': PermissionComponent,
    canActivate: [AuthGuard],
  },
  {
    'path': 'Products',
    'component': ProductComponent,
    canActivate: [AuthGuard],
  },
  {
    'path': 'Products/:ProductId',
    children: [
      {
        'path': 'ProductDetails',
        'component': ProductDetailComponent,
      }
    ],
    canActivate: [AuthGuard],
  },
  {
    'path': 'Roles',
    'component': RoleComponent,
    canActivate: [AuthGuard],
  },
  {
    'path': 'Suppliers',
    'component': SupplierComponent,
    canActivate: [AuthGuard],
  },
  {
    'path': 'SignIn',
    'component': LoginComponent,
  },
  {
    'path': 'IssueNotes',
    'component': IssueNoteComponent,
  },
  {
    'path': 'IssueNotes/:IssueNoteId',
    'component': IssueNoteDetailComponent,
  },
  {
    'path': 'ReceiptNotes',
    'component': ReceiptNoteComponent,
  },
  {
    'path': 'WareHouses',
    'component': WareHouseComponent,
  },
  {
    'path': 'ReceiptNotes/:ReceiptNoteId',
    'component': ReceiptNoteDetailComponent,
  },
  {
    'path': 'WareHouses',
    'component': WareHouseComponent,
  },
  {
    'path': 'CustomerGroups',
    'component': CustomerGroupComponent,
  },
  {
    'path': 'Countries',
    'component': CountryComponent,
  },
  {
    'path': 'Cities',
    'component': CityComponent,
  },
  {
    'path': 'ShipmentDetails',
    'component': ShipmentDetailComponent,
  },
  {
    'path': 'OpeningBalance',
    'component': OpeningBalanceComponent,
  },
  {
    'path': 'StockTransfer',
    'component': StockTransferComponent,
  },
  {
    'path': 'Employee',
    'component': EmployeeComponent,
  },
  {
    'path': 'Orders',
    'component': OrderComponent,
  },
  {
    'path': 'Orders/:OrderId',
    'component': OrderDetailComponent,
  },
];
export const Routing = RouterModule.forRoot(routes);
