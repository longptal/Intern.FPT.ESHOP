// Import Module:
import {Routing} from './Route';
import {BrowserModule} from '@angular/platform-browser';
import {NgModule, NO_ERRORS_SCHEMA} from '@angular/core';
import {HttpClientModule} from '@angular/common/http';
import {NgSelectModule} from '@ng-select/ng-select';
import {FormsModule} from '@angular/forms';
import {ConfirmationPopoverModule} from 'angular-confirmation-popover';
import {ToastModule} from 'ng2-toastr';
import {
  AccordionModule,
  ButtonModule,
  CalendarModule,
  ContextMenuModule,
  DataTableModule,
  DialogModule,
  InputTextModule,
  TreeModule
} from 'primeng/primeng';
import {CurrencyMaskModule} from 'ng2-currency-mask';
//Import Library Component:
import {BodyComponent} from './Shared/Body/Body.Component';
import {HeaderComponent} from './Shared/Header/Header.Component';
import {DropdownComponent} from './Shared/MaterialComponent/dropdown/dropdown.component';
import {ExcelComponent} from './Shared/MaterialComponent/Excel/Excel.component';
import {InputfileComponent} from './Shared/MaterialComponent/inputfile/inputfile.component';
import {MenuPurchaseComponent} from './Shared/MaterialComponent/MenuPurchase/menupurchase.component';
import {ModalComponent} from './Shared/MaterialComponent/modal/modal.component';
import {PagingComponent} from './Shared/MaterialComponent/paging/paging.component';
import {PortletComponent} from './Shared/MaterialComponent/Portlet/Portlet.Component';
import {TagsinputComponent} from './Shared/MaterialComponent/tagsinput/tagsinput.component';
import {AuthGuard} from './Auth.Guard.Service';
import {NgbModule} from '@ng-bootstrap/ng-bootstrap';
import {QuillEditorModule} from 'ngx-quill-editor';
//Import Module Component:
import {CategoryComponent} from './Component/Category/Category.component';
import {CouponComponent} from './Component/Coupon/Coupon.component';
import {PermissionComponent} from './Component/Permission/Permission.component';
import {ProductComponent} from './Component/Product/Product.component';
import {ProductAttributeComponent} from './Component/ProductAttribute/ProductAttribute.component';
import {RoleComponent} from './Component/Role/Role.component';
import {InventoryComponent} from './Component/Inventory/Inventory.component';
import {IntroductionComponent} from './Component/Introduction/Introduction.component';
import {LanguageComponent} from './Component/Language/Language.component';
import {OperationComponent} from './Component/Operation/Operation.component';
import {SupplierComponent} from './Component/Supplier/Supplier.component';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import {IssueNoteComponent} from './Component/IssueNote/IssueNote.component';
import {ReceiptNoteComponent} from './Component/ReceiptNote/ReceiptNote.component';
import {WareHouseComponent} from './Component/Warehouse/WareHouse.component';
import {OpeningBalanceComponent} from './Component/OpeningBalance/OpeningBalance.component';
import {StockTransferComponent} from './Component/StockTransfer/StockTransfer.component';
import { IssueNoteDetailComponent } from "./Component/IssueNote/Detail/IssueNoteDetail.component";
import { IssueNoteLineComponent } from "./Component/IssueNote/Detail/IssueNoteLine.component";
// Import Module Service:
import {EmployeeCodePipe} from './Shared/EmployeeCodePipe/EmployeeCode.pipe';
import {AvatarComponent} from './Shared/MaterialComponent/avatar/avatar.component';
import {AppComponent} from './app.component';
//Import Module Service:
import {CategoryService} from './Module/MCategory/Category.Service';
import {CouponService} from './Module/MCoupon/Coupon.Service';
import {IntroductionService} from './Module/MIntroduction/Introduction.Service';
import {InventoryService} from './Module/MInventory/Inventory.Service';
import {LanguageService} from './Module/MLanguage/Language.Service';
import {OperationService} from './Module/MOperation/Operation.Service';
import {PermissionService} from './Module/MPermission/Permission.Service';
import {ProductService} from './Module/MProduct/Product.Service';
import {RoleService} from './Module/MRole/Role.Service';
import {SupplierService} from './Module/MSupplier/Supplier.Service';
import {ProductAttributeService} from './Module/MProductAttribute/ProductAttribute.Service';
import {BottomToastsManager} from './Shared/CustomToaster';
import {EmployeeInfoService} from './Shared/EmployeeInfo.Service';
import {LoginComponent} from './Shared/Login/Login.Component';
import {HttpService} from './Shared/HttpService';
import {IssueNoteService} from './Module/MIssueNote/IssueNote.Service';
import {ReceiptNoteService} from './Module/MReceiptNote/ReceiptNote.Service';
import {WareHouseService} from './Module/MWareHouse/WareHouse.Service';
import {ProductDetailComponent} from './Component/Product/ProductDetail/ProductDetail.component';
import {ProductValueService} from './Module/MProductValue/ProductValue.Service';
import {TaxService} from './Module/MTax/Tax.Service';
import {DiscountService} from './Module/MDiscount/Discount.Service';
import {PackService} from './Module/MPack/Pack.Service';
import {EmployeeService} from './Module/MEmployee/Employee.Service';
import {ProductPictureService} from './Module/MProductPicture/ProductPicture.Service';
import {DatetimeComponent} from './Shared/MaterialComponent/datetime/datetime.component';
import {EmployeeComponent} from './Component/Employee/Employee.component';
import {ManufacturerComponent} from './Component/Manufacturer/Manufacturer.component';
import {ManufacturerService} from './Module/MManufacturer/Manufacturer.Service';
import {NgSelectCustomComponent} from './Shared/MaterialComponent/ng-select-custom/ng-select-custom.component';
import {CustomerComponent} from './Component/Customer/Customer.component';
import {CustomerGroupComponent} from './Component/CustomerGroup/CustomerGroup.component';
import {CustomerService} from './Module/MCustomer/Customer.Service';
import {CustomerGroupService} from './Module/MCustomerGroup/CustomerGroup.Service';
import {ShipmentDetailComponent} from './Component/ShipmentDetail/ShipmentDetail.component';
import {CityComponent} from './Component/City/City.component';
import {CountryComponent} from './Component/Country/Country.component';
import {CityService} from './Module/MCity/City.Service';
import {CountryService} from './Module/MCountry/Country.Service';
import {ShipmentDetailService} from './Module/MShipmentDetail/ShipmentDetail.Service';
import {OpeningBalanceService} from './Module/MOpeningBalance/OpeningBalance.Service';
import {StockTransferService} from './Module/MStockTransfer/StockTransfer.Service';
import {FileBrowserDirective} from './Shared/file-browser/file-browser.directive';
import {FileBrowserComponent} from './Shared/file-browser/file-browser.component';
import {ReceiptNoteDetailComponent} from './Component/ReceiptNote/Detail/ReceiptNoteDetail.component';
import {OrderLineComponent} from './Component/Order/Detail/OrderLine.component';
import {OrderDetailComponent} from './Component/Order/Detail/OrderDetail.component';
import {OrderComponent} from './Component/Order/Order.component';
import {FileService} from './Shared/file-browser/file/File.Service';
import {OrderLineService} from './Module/MOrderLine/OrderLine.Service';
import {OrderService} from './Module/MOrder/Order.Service';
import {ReceiptNoteLineService} from './Module/MReceiptNoteLine/ReceiptNoteLine.Service';
import {ReceiptNoteLineComponent} from './Component/ReceiptNote/Detail/ReceiptNoteLine.component';
import {DirectoryService} from './Shared/file-browser/directory/directory.service';
import {FileBrowserService} from './Shared/file-browser/file-browser.service';
import {NgSelectUserComponent} from './Shared/MaterialComponent/ng-select-user/ng-select-user.component';
import { IssueNoteLineService } from "./Module/MIssueNoteLine/IssueNoteLine.Service";
import { StockTransferLineService } from "./Module/MStockTransferLine/StockTransferLine.Service";
import { StockTransferLineComponent } from "./Component/StockTransfer/Detail/StockTransferLine.component";
import { StockTransferDetailComponent } from "./Component/StockTransfer/Detail/StockTransferDetail.component";




@NgModule({
  declarations: [
    AppComponent, BodyComponent, HeaderComponent, DropdownComponent, ExcelComponent, InputfileComponent, MenuPurchaseComponent, ModalComponent, EmployeeCodePipe,
    PagingComponent, AvatarComponent, PortletComponent, TagsinputComponent, LoginComponent, FileBrowserDirective, DatetimeComponent, NgSelectCustomComponent, NgSelectUserComponent,
    // Component Module;
    CategoryComponent, CouponComponent, IntroductionComponent, InventoryComponent, LanguageComponent, OperationComponent,
    PermissionComponent, ProductComponent, ProductAttributeComponent, RoleComponent, SupplierComponent, EmployeeComponent, PagingComponent,
    IssueNoteComponent, ReceiptNoteComponent, WareHouseComponent, FileBrowserComponent, ProductDetailComponent, ManufacturerComponent,
    CustomerComponent, CustomerGroupComponent, CityComponent, CountryComponent, ShipmentDetailComponent, OpeningBalanceComponent, StockTransferComponent,
    ReceiptNoteDetailComponent, ReceiptNoteLineComponent, OrderComponent, OrderDetailComponent, OrderLineComponent, IssueNoteDetailComponent, IssueNoteLineComponent, IssueNoteComponent,
    StockTransferComponent
  ],
  imports: [
    BrowserModule, Routing, NgbModule.forRoot(), NgSelectModule, FormsModule, HttpClientModule, BrowserAnimationsModule, QuillEditorModule, CurrencyMaskModule,
    // Toaster module:
    ToastModule.forRoot(),
    // Popover mopdule:
    ConfirmationPopoverModule.forRoot({
      confirmButtonType: 'danger' // set defaults here
    }),
    // Primeng module:
    InputTextModule, ButtonModule, DataTableModule, DialogModule, TreeModule, AccordionModule, ContextMenuModule, CalendarModule
  ],
  providers: [
    AuthGuard, BottomToastsManager, EmployeeInfoService, HttpService,
    // Service Module:
    CategoryService, CouponService, IntroductionService, InventoryService, LanguageService, OperationService,
    PermissionService, ProductService, RoleService, SupplierService, EmployeeService, ProductAttributeService,
    IssueNoteService, ReceiptNoteService, WareHouseService, FileBrowserService, ProductValueService, TaxService, PackService, DiscountService,
    EmployeeService, ProductPictureService, DirectoryService, ManufacturerService, CustomerService, CustomerGroupService, CityService, CountryService, ShipmentDetailService,
    OpeningBalanceService, StockTransferService, ReceiptNoteLineService, OrderService, OrderLineService, FileService, IssueNoteService, IssueNoteLineService, StockTransferService,
    StockTransferLineService
  ],
  bootstrap: [AppComponent],
  schemas: [NO_ERRORS_SCHEMA]
})
export class AppModule {
}


