import {Component} from '@angular/core';
import {MenuModel} from '../../menu-model';
import {EmployeeInfoService} from '../EmployeeInfo.Service';
import {EmployeeEntity} from '../../Module/MEmployee/Employee.Entity';
//import {Http} from "@angular/http";
// import {AuthService} from "../../Modules/Auth/Auth.Service";
// import {UserEntity} from "../../Modules/User/User.Entity";
// import {UserService} from "../../Modules/User/User.Service";
// import { PermissionService } from "app/Modules/Permission/Permission.Service";

// import {LayerAccessControlEntity} from "../../Modules/LayerAccessControl/LayerAccessControl.Entity";

@Component({
  selector: 'public-header',
  templateUrl: './Header.Component.html',
  styleUrls: ['./Header.Component.css']
})
export class HeaderComponent {
  MenuList: MenuModel[];
  //static User: UserEntity;
  // ParentLayerControl: LayerAccessControlEntity;
  EmployeeEntity: EmployeeEntity;

  constructor(
    public EmployeeInfoService: EmployeeInfoService
  ) {
    this.EmployeeInfoService.GetCurrent();
    this.MenuList = Array<MenuModel>();

    let Home = new MenuModel("Home", "Home"); this.MenuList.push(Home);

    let Sale = new MenuModel("Sale", "Sale"); this.MenuList.push(Sale);
    let Order = new MenuModel("Orders", "Orders"); Sale.addSub(Order);
    let Introduction = new MenuModel("Introductions", "Introductions"); Sale.addSub(Introduction);
    let Coupon = new MenuModel("Coupons", "Coupons"); Sale.addSub(Coupon);

   

    let StockManagement = new MenuModel("StockManagement", "StockManagement"); this.MenuList.push(StockManagement);
    let Inventory = new MenuModel("Inventories", "Inventories"); StockManagement.addSub(Inventory);
    let ReceiptNote = new MenuModel("ReceiptNotes", "ReceiptNotes"); StockManagement.addSub(ReceiptNote);
    let IssueNote = new MenuModel("IssueNotes", "IssueNotes"); StockManagement.addSub(IssueNote);
    let StockTransfer = new MenuModel("StockTransfer", "StockTransfer"); StockManagement.addSub(StockTransfer);
    let OpeningBalance = new MenuModel("OpeningBalance", "OpeningBalance"); StockManagement.addSub(OpeningBalance);

    let ProductManagement = new MenuModel("ProductManagement", "ProductManagement"); this.MenuList.push(ProductManagement);
    let Category = new MenuModel("Categories", "Categories"); ProductManagement.addSub(Category);
    let Warehouse = new MenuModel("Warehouses", "WareHouses"); ProductManagement.addSub(Warehouse);
    let Manufacturer = new MenuModel("Manufacturers", "Manufacturers"); ProductManagement.addSub(Manufacturer);
  
    let Management = new MenuModel("Management", "Management"); this.MenuList.push(Management);
    let Supplier = new MenuModel("Suppliers", "Suppliers"); Management.addSub(Supplier);
    let Customer = new MenuModel("Customers", "Customers"); Management.addSub(Customer);
    let Language = new MenuModel("Languages", "Languages"); Management.addSub(Language);
    let Employee = new MenuModel("Employees", "Employees"); Management.addSub(Employee);

    let System = new MenuModel("System", "System"); this.MenuList.push(System);
    let Permission = new MenuModel("Permissions", "Permissions"); System.addSub(Permission);
    let MailConfig = new MenuModel("MailConfigs", "MailConfigs"); System.addSub(MailConfig);
    
  }
}
