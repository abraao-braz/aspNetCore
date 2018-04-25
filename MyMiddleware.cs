using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace hosting
{
    public class MyMiddleware
    {
        private RequestDelegate _next;
        public MyMiddleware(RequestDelegate next)
        {

            this._next = next;    
        }

        public async Task Invoke(HttpContext context)
        {
            //Request
            var start = DateTime.Now; 

            await _next(context);

            //Response
            var finish = DateTime.Now;

            var diff = finish.Subtract(start);

            await context.Response.WriteAsync($"The time was {diff.Milliseconds}");
            

        }
    }
}