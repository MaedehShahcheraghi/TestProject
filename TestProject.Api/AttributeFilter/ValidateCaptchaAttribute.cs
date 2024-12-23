using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using System;
using System.Text;
using TP.Application;
using TP.Application.Contracts.Infrastructure.CaptchaService;
using TP.Application.Models.Captcha;
using TP.Infrastructure.Service;

public class ValidateCaptchaAttribute : IAsyncActionFilter
{
    private readonly IMemoryCache _memoryCache;

    public ValidateCaptchaAttribute(IMemoryCache memoryCache)
    {
        _memoryCache = memoryCache ?? throw new ArgumentNullException(nameof(memoryCache));
    }

    public string ErrorMessage { get; set; } = "Invalid captcha.";

    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        if (context == null)
        {
            throw new ArgumentNullException(nameof(context));
        }

        var httpContext = context.HttpContext;

        var captchaId = httpContext.Request.Headers["CaptchaId"].ToString();
        if (string.IsNullOrEmpty(captchaId))
        {
            context.Result = new BadRequestObjectResult(new { Message = "CaptchaId is required in the request headers." });
            return;
        }

        var captchaArgument = context.ActionArguments.Values
           .FirstOrDefault(arg => arg is BaseCaptcha) as BaseCaptcha;

        if (captchaArgument == null || string.IsNullOrEmpty(captchaArgument.CaptchaCode))
        {
            context.Result = new BadRequestObjectResult(new { Message = "CaptchaCode is required in the request body." });
            return;
        }

        var captchaCode = captchaArgument.CaptchaCode;
        if (string.IsNullOrEmpty(captchaCode))
        {
            context.Result = new BadRequestObjectResult(new { Message = "CaptchaCode is required in the request body." });
            return;
        }

        var captchaValidationRequest = new TP.Application.Models.Captcha.CaptchaValidationRequest
        {
            CaptchaId = captchaId,
            CaptchaCode = captchaCode,
        };

        var captchaService = (ICaptchaService)httpContext.RequestServices.GetService(typeof(ICaptchaService));
        if (captchaService == null)
        {
            context.Result = new ObjectResult(new { Message = "Captcha service is not configured properly." })
            {
                StatusCode = StatusCodes.Status500InternalServerError
            };
            return;
        }

        var result =await captchaService.ValidateCaptcha(captchaValidationRequest);

        switch (result)
        {
            case TP.Application.Models.Captcha.CaptchaStatus.UnprocessableEntity:
                context.Result = new ObjectResult(new { Message = $"Captcha is invalid or malformed." })
                {
                    StatusCode = StatusCodes.Status422UnprocessableEntity
                };
                return;

            case TP.Application.Models.Captcha.CaptchaStatus.Gone:
                context.Result = new ObjectResult(new { Message = "Captcha has expired. Please generate a new one." })
                {
                    StatusCode = StatusCodes.Status410Gone
                };
                return;

            case TP.Application.Models.Captcha.CaptchaStatus.Ok:
                break;

            case TP.Application.Models.Captcha.CaptchaStatus.NotFound:
                context.Result = new ObjectResult(new { Message = "Captcha not found or doesn't exist." })
                {
                    StatusCode = StatusCodes.Status404NotFound
                };
                return;

            case TP.Application.Models.Captcha.CaptchaStatus.BadRequest:
                context.Result = new ObjectResult(new { Message = "Captcha request is invalid. Please check your input." })
                {
                    StatusCode = StatusCodes.Status400BadRequest
                };
                return;

            default:
                context.Result = new ObjectResult(new { Message = "An unexpected error occurred while validating the captcha." })
                {
                    StatusCode = StatusCodes.Status500InternalServerError
                };
                return;
        }

        await next();
    }
}

        //public override void OnActionExecuting(ActionExecutingContext context)
        //{
        //    if (context == null)
        //    {
        //        throw new ArgumentNullException(nameof(context));
        //    }

        //    var httpContext = context.HttpContext;

        //    // دریافت CaptchaId از هدر
        //    var captchaId = httpContext.Request.Headers["CaptchaId"].ToString();
        //    if (string.IsNullOrEmpty(captchaId))
        //    {
        //        context.Result = new BadRequestObjectResult(new { Message = "CaptchaId is required in the request headers." });
        //        return;
        //    }

        //    // دریافت CaptchaCode از بدنه
        //    httpContext.Request.EnableBuffering(); // برای امکان خواندن چندباره بدنه
        //    string captchaCode;

        //    using (var reader = new StreamReader(httpContext.Request.Body, Encoding.UTF8, leaveOpen: true))
        //    {
        //        var body = reader.ReadToEndAsync().Result;
        //        httpContext.Request.Body.Position = 0; // بازنشانی جریان به ابتدا

        //        var captchaRequest = JsonConvert.DeserializeObject<CaptchaValidationRequest>(body);

        //        if (captchaRequest == null || string.IsNullOrEmpty(captchaRequest.CaptchaCode))
        //        {
        //            context.Result = new BadRequestObjectResult(new { Message = "CaptchaCode is required in the request body." });
        //            return;
        //        }

        //        captchaCode = captchaRequest.CaptchaCode;
        //    }

        //    // ساخت مدل ولیدیشن کپچا
        //    var captchavalidationrequest = new TP.Application.Models.Captcha.CaptchaValidationRequest()
        //    {
        //        CaptchaId = captchaId,
        //        CaptchaCode = captchaCode,
        //    };

        //    // دریافت سرویس کپچا از DI
        //    var captchaService = (ICaptchaService)httpContext.RequestServices.GetService(typeof(ICaptchaService));
        //    if (captchaService == null)
        //    {
        //        context.Result = new ObjectResult(new { Message = "Captcha service is not configured properly." })
        //        {
        //            StatusCode = StatusCodes.Status500InternalServerError
        //        };
        //        return;
        //    }

        //    // اعتبارسنجی کپچا
        //    var result = captchaService.ValidateCaptcha(captchavalidationrequest);

        //    switch (result)
        //    {
        //        case TP.Application.Models.Captcha.CaptchaStatus.UnprocessableEntity:
        //            context.Result = new ObjectResult(new { Message = "Captcha is invalid or malformed." })
        //            {
        //                StatusCode = StatusCodes.Status422UnprocessableEntity
        //            };
        //            return;

        //        case TP.Application.Models.Captcha.CaptchaStatus.Gone:
        //            context.Result = new ObjectResult(new { Message = "Captcha has expired. Please generate a new one." })
        //            {
        //                StatusCode = StatusCodes.Status410Gone
        //            };
        //            return;

        //        case TP.Application.Models.Captcha.CaptchaStatus.Ok:
        //            break;

        //        case TP.Application.Models.Captcha.CaptchaStatus.NotFound:
        //            context.Result = new ObjectResult(new { Message = "Captcha not found or doesn't exist." })
        //            {
        //                StatusCode = StatusCodes.Status404NotFound
        //            };
        //            return;

        //        case TP.Application.Models.Captcha.CaptchaStatus.BadRequest:
        //            context.Result = new ObjectResult(new { Message = "Captcha request is invalid. Please check your input." })
        //            {
        //                StatusCode = StatusCodes.Status400BadRequest
        //            };
        //            return;

        //        default:
        //            context.Result = new ObjectResult(new { Message = "An unexpected error occurred while validating the captcha." })
        //            {
        //                StatusCode = StatusCodes.Status500InternalServerError
        //            };
        //            return;
        //    }


        //}

//    }
//}
