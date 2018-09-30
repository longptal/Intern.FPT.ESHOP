using System;
using System.Net;
using System.Net.Http;
using EShop.Entities;
using EShop.MAdmin;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;

namespace EShop
{
    public class ExceptionResponseAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            var response = context.HttpContext.Response;
            context.HttpContext.Response.Clear();
            context.HttpContext.Response.ContentType = "application/json";
            if (context.Exception is UnauthorizedException)
            {
                response.StatusCode = (int)HttpStatusCode.Unauthorized;
            }
            if (context.Exception is BadRequestException)
            {
                response.StatusCode = (int)HttpStatusCode.BadRequest;
            }
            if (context.Exception is ConflictException)
            {
                response.StatusCode = (int)HttpStatusCode.Conflict;
            }

            if (context.Exception is ForbiddenException)
            {
                response.StatusCode = (int)HttpStatusCode.Forbidden;
            }
            if (context.Exception is NotFoundException)
            {
                response.StatusCode = (int)HttpStatusCode.NotFound;
            }
            if (context.Exception is InternalServerErrorException)
            {
                response.StatusCode = (int)HttpStatusCode.InternalServerError;
            }
            var Message = JsonConvert.SerializeObject(new { context.Exception.Message });
            response.WriteAsync(Message);
        }
    }


    public class UnauthorizedException : Exception
    {
        public UnauthorizedException(string Message) : base(Message)
        {
        }
    }

    public class BadRequestException : Exception
    {
        private static string ModifyMessage(BaseEntity BaseEntity)
        {
            return JsonConvert.SerializeObject(BaseEntity);
        }
        public BadRequestException(BaseEntity BaseEntity) : base(ModifyMessage(BaseEntity)) { }

        public BadRequestException(string Message) : base(Message) { }
    }

    public class InternalServerErrorException: Exception
    {
        public InternalServerErrorException(string Message) : base(Message) { }
    }

    public class ForbiddenException : Exception
    {
        public ForbiddenException(string Message) : base(Message)
        {
        }
    }

    public class NotFoundException : Exception
    {
        public NotFoundException() : base("Item didn't exist")
        {
        }
    }

    public class ConflictException : Exception
    {
        public ConflictException(string Message) : base(Message)
        {
        }
    }
}