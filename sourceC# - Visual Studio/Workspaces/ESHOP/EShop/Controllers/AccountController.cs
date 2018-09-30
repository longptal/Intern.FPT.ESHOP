using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using EShop;
using EShop.AppStart;
using EShop.MAdmin.MCustomer;
using EShop.MAdmin.MEmployee;
using EShop.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using EShop.Entities;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication4.Auth
{
    [Route("api/Auth")]
    public class AccountController : Controller
    {
        private readonly IJWTHandler _JwtHandler;

        public AccountController(IJWTHandler jwtHandler)
        {
            _JwtHandler = jwtHandler;
        }

        [HttpGet("")]
        public IActionResult Get()
        {
            var file = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "index.html");
            return PhysicalFile(file, "text/html");
        }

        [HttpGet("me")]
        public IActionResult GetMe()
        {
            return Content($"Hello {User.Identity.Name}");
        }

        [HttpPost("customer-sign-up")]
        public IActionResult SignUp([FromBody]LoginModel Login)
        {
            IActionResult response = Unauthorized();
            EShopContext EShopContext = new EShopContext();
            if (EShopContext.Customers.Any(c => c.Username.ToLower() == Login.Username.ToLower()))
                throw new BadRequestException("Username existed!");
            var Customer = new Customer();
            Customer.Username = Login.Username;
            string ErrorMessValidationPass;
            if(!ValidatePassword(Customer.Username,out ErrorMessValidationPass)) throw new BadRequestException(ErrorMessValidationPass);
            Customer.Password = SecurePasswordHasher.Hash(Login.Password);
            EShopContext.Customers.Add(Customer);
            EShopContext.SaveChanges();
            var CustomerEntity = new CustomerEntity(Customer);
            var tokenString = _JwtHandler.CreateToken(CustomerEntity);
            response = Ok(new { token = tokenString });
            return response;
        }

        [HttpPost("customer-sign-in")]
        public IActionResult CustomerSignIn([FromBody]LoginModel Login)
        {
            IActionResult response = Unauthorized();
            var CustomerEntity = AuthenticateCustomer(Login);
            if (CustomerEntity != null)
            {
                var tokenString = _JwtHandler.CreateToken(CustomerEntity);
                response = Ok(new { token = tokenString });
            }
            return response;
        }

        [HttpPost("employee-sign-in")]
        public IActionResult EmployeeSignIn([FromBody]LoginModel Login)
        {
            IActionResult response = Unauthorized();
            var Employee = AuthenticateEmployee(Login);
            if (Employee != null)
            {
                var tokenString = _JwtHandler.CreateToken(Employee);
                response = Ok(new { token = tokenString });
            }
            return response;
        }

        [HttpPost("sso-sign-in")]
        [AllowAnonymous]
        public IActionResult RegisterExternalToken([FromBody] ExternalToken model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var SocialConfig = new SocialConfig();
            SocialConfig.Facebook = new SocialApp(){ AppId = "242553336313565", AppSecret = "87f4a02e389a94375d7b66a6d3d7c971" };
            SocialConfig.Google = new SocialApp() { AppId = "67665367723-2clkplsi4d95kfv4tior0997lsblvf4a.apps.googleusercontent.com", AppSecret = "87f4a02e389a94375d7b66a6d3d7c971" };
            var socialAuthServices = new SocialAuthServices(SocialConfig);
            var me = socialAuthServices.VerifyTokenAsync(model);
            CustomerEntity CustomerEntity = null;
            if (!me.IsVerified)
            {
                return Unauthorized();
            } else
            {
                var EShopContext = new EShopContext();
                if (model.Provider == "Facebook")
                {
                    Customer Customer = EShopContext.Customers.FirstOrDefault(c => c.FacebookId == me.Id);
                    if(Customer == null)
                    {
                        Customer = new Customer();
                        Customer.FacebookEmail = me.Email;
                        Customer.FacebookId = me.Id;
                        Customer.Display = me.Name;
                        Customer.Picture = me.UrlAvatar;
                        EShopContext.Customers.Add(Customer);
                        EShopContext.SaveChanges();
                    }
                    CustomerEntity = new CustomerEntity(Customer);
                }
                else if(model.Provider == "Google")
                {
                    Customer Customer = EShopContext.Customers.FirstOrDefault(c => c.GoogleId == me.Id);
                    if (Customer == null)
                    {
                        Customer = new Customer();
                        Customer.GoogleEmail = me.Email;
                        Customer.GoogleId = me.Id;
                        Customer.Display = me.Name;
                        Customer.Picture = me.UrlAvatar;
                        EShopContext.Customers.Add(Customer);
                        EShopContext.SaveChanges();
                    }
                    CustomerEntity = new CustomerEntity(Customer);
                }
            }
            if (CustomerEntity != null)
            {
                var tokenString = _JwtHandler.CreateToken(CustomerEntity);
                return Ok(new { token = tokenString });
            }
            return Ok();
        }



        private CustomerEntity AuthenticateCustomer(LoginModel Login)
        {
            EShopContext EShopContext = new EShopContext();
            var Customer = EShopContext.Customers.FirstOrDefault(c => c.Username.ToLower() == Login.Username.ToLower());
            if (Customer != null && SecurePasswordHasher.Verify(Login.Password, Customer.Password)) return new CustomerEntity(Customer);
            return null;
        }
        private EmployeeEntity AuthenticateEmployee(LoginModel Login)
        {
            EShopContext EShopContext = new EShopContext();
            var Employee = EShopContext.Employees.FirstOrDefault(c => c.Username.ToLower() == Login.Username.ToLower());
            if (Employee != null && SecurePasswordHasher.Verify(Login.Password, Employee.Password)) return new EmployeeEntity(Employee);
            return null;
        }
        public class LoginModel
        {
            public string Username { get; set; }
            public string Password { get; set; }
        }
        private bool ValidatePassword(string password, out string ErrorMessage)
        {
            var input = password;
            ErrorMessage = string.Empty;

            if (string.IsNullOrWhiteSpace(input))
            {
                throw new Exception("Password should not be empty");
            }

            var hasNumber = new Regex(@"[0-9]+");
            var hasUpperChar = new Regex(@"[A-Z]+");
            var hasLowerChar = new Regex(@"[a-z]+");
            var hasSymbols = new Regex(@"[!@#$%^&*()_+=\[{\]};:<>|./?,-]");

            if (!hasLowerChar.IsMatch(input))
            {
                ErrorMessage = "Password should contain At least one lower case letter";
                return false;
            }
            else if (!hasUpperChar.IsMatch(input))
            {
                ErrorMessage = "Password should contain At least one upper case letter";
                return false;
            }
            else if (input.Length > 16)
            {
                ErrorMessage = "Password too long, must less or equal than 16 character";
                return false;
            }
            else if (input.Length < 6)
            {
                ErrorMessage = "Password too short, must greater or equal than 6 character";
                return false;
            }
            else if (!hasNumber.IsMatch(input))
            {
                ErrorMessage = "Password should contain At least one numeric value";
                return false;
            }

            else if (!hasSymbols.IsMatch(input))
            {
                ErrorMessage = "Password should contain At least one special case characters";
                return false;
            }
            else
            {
                return true;
            }
        }
    }


}
