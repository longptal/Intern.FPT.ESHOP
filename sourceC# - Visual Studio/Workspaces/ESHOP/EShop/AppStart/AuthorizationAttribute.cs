using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using RestSharp;
using EShop.MAdmin;

namespace EShop
{
    public class MVCAuthorizationAttribute : IAuthorizationFilter
    {
        private readonly IConfiguration Configuration;
        public class FRoute
        {
            public string Name { get; set; }
            public List<string> Layers { get; set; }
        }
        public MVCAuthorizationAttribute(IConfiguration Configuration)
        {
            this.Configuration = Configuration;
        }

        public void OnAuthorization(AuthorizationFilterContext Context)
        {
            var Token = Context.HttpContext.Request.Cookies["token"];
            var RestClient = new RestClient(Configuration.GetSection("Portal").ToString());
            if (Token != null)
            {
                //List<FRoute> FRoutes;
                var Request = new RestRequest(@"User\FRoutes?DomainId=" + "", Method.GET);
                Request.AddCookie("Token", Token);
                var ResourceResponse = RestClient.Execute<List<FRoute>>(Request);
                if (ResourceResponse.Data != null)
                {
                    //FRoutes = ResourceResponse.Data;
                }
                else
                {
                    Context.Result = new Http403Result();
                    return;
                }

                //var currentPath = HttpUtility.UrlEncode(filterContext.HttpContext.Request.Url.AbsolutePath);

            }
            Context.Result = new Http401Result();
        }
    }

    public class WebAPIAuthorizationAttribute : IAuthorizationFilter
    {
        private readonly IConfiguration Configuration;
        private readonly IJWTHandler JWTHandler;
        public WebAPIAuthorizationAttribute(IConfiguration Configuration, IJWTHandler JWTHandler)
        {
            this.Configuration = Configuration;
            this.JWTHandler = JWTHandler;
        }
        public void OnAuthorization(AuthorizationFilterContext FilterContext)
        {
            
            throw new UnauthorizedException("Token hết hiệu lực.");
        }

        //protected override void HandleUnauthorizedRequest(ActionContext actionContext)
        //{
        //    actionContext.Response = new System.Net.Http.HttpResponseMessage(System.Net.HttpStatusCode.Forbidden);
        //    actionContext.Response.Content = new System.Net.Http.StringContent("Bạn không có quyền truy cập chức năng này");
        //}
    }

    internal class Http403Result : ActionResult
    {
        public override void ExecuteResult(ActionContext context)
        {
            // Set the response code to 403.
            context.HttpContext.Response.StatusCode = 403;
        }
    }

    internal class Http401Result : ActionResult
    {
        public override void ExecuteResult(ActionContext context)
        {
            context.HttpContext.Response.StatusCode = 401;
        }
    }


}
