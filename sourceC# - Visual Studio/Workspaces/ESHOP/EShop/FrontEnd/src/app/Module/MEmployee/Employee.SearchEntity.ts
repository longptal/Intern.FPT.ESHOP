import {FilterEntity} from '../FilterEntity';

export class SearchEmployeeEntity extends FilterEntity {
  Id: number;
  UserName: string;
  HashPassword: string;
  Display: string;
  Avatar: string;
  FacebookId: string;
  FacebookEmail: string;
  GoogleId: string;
  GoogleEmail: string;
  PasswordAttemptTimes: number;
  OtpCode: string;
  PhoneNumber: string;
  IsDeleted: string;
  constructor(Employee: any = null) {
    super(Employee);
    this.Id = Employee == null ? null : Employee.Id;
    this.UserName = Employee == null ? null : Employee.UserName;
    this.HashPassword = Employee == null ? null : Employee.HashPassword;
    this.Display = Employee == null ? null : Employee.Display;
    this.Avatar = Employee == null ? null : Employee.Avatar;
    this.FacebookId = Employee == null ? null : Employee.FacebookId;
    this.FacebookEmail = Employee == null ? null : Employee.FacebookEmail;
    this.GoogleId = Employee == null ? null : Employee.GoogleId;
    this.GoogleEmail = Employee == null ? null : Employee.GoogleEmail;
    this.PasswordAttemptTimes = Employee == null ? null : Employee.PasswordAttemptTimes;
    this.OtpCode = Employee == null ? null : Employee.OtpCode;
    this.PhoneNumber = Employee == null ? null : Employee.PhoneNumber;
    this.IsDeleted = Employee == null ? null : Employee.IsDeleted;
  }
}
