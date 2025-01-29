




using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Servicess;
using Entities;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.RenderTree;
using Microsoft.Extensions.Hosting;
using System.IO;
using System;

namespace MyShop
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class MiddlewareRating
    {
        private readonly RequestDelegate _next;
       
        public MiddlewareRating(RequestDelegate next)
        {
            _next = next;
        }

      

        public  Task Invoke(HttpContext httpContext, IRatingService ratingService)
        {

            Rating rating = new Rating()
            {
                Path = httpContext.Request.Path.Value,
                Host = httpContext.Request.Host.Value,
                Method = httpContext.Request.Method,
                Referer = httpContext.Request.Headers.Referer,
                UserAgent = httpContext.Request.Headers.UserAgent,
                RecordDate = DateTime.Now
            };
            //                •	HOST- כתובת האתר בה אנו גולשים כעת
            //•	METHOD- המתודה אליה נגשנו)
            //•	[PATH] URL ה- אליו בוצעה הפניה
            //•	REFERER- הדף ממנו התבצעה הפניה
            //•	USER_AGENT- מכיל את שם הדפדפן, גירסתו, מערכת ההפעלה ושפתה
            //•	RECORD_DATE- תאריך הרישום לרייטינג

            ratingService.Post(rating);
            return _next(httpContext);

        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class MiddlewareRatingExtensions
    {
        public static IApplicationBuilder UseMiddlewareRating(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<MiddlewareRating>();
        }
    }
}
