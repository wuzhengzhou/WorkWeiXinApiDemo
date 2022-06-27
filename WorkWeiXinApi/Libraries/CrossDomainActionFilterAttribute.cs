using System;
using Microsoft.AspNetCore.Mvc.Filters;
namespace WorkWeiXinApi.Libraries
{
   /// <summary>
   /// 解决跨域问题
   /// </summary>
    public class CrossDomainActionFilterAttribute: Attribute, IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            //允许跨域请求
            context.HttpContext.Response.Headers.Add("Access-Control-Allow-Origin",
                context.HttpContext.Request.Headers["Origin"]);
            context.HttpContext.Response.Headers.Add("Access-Control-Allow-Method", "POST,OPTIONS");
            context.HttpContext.Response.Headers.Add("Access-Control-Allow-Headers",
                context.HttpContext.Request.Headers["Access-Control-Request-Headers"]);
            context.HttpContext.Response.Headers.Add("Access-Control-Max-Age", "86400");
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
        }
    }
}
