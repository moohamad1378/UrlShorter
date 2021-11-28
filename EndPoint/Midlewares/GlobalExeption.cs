using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace EndPoint.Midlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class GlobalExeption
    {
        private readonly RequestDelegate _next;
        private readonly NLog.Logger nlog = NLog.LogManager.GetCurrentClassLogger();
        public GlobalExeption(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
              await   _next(httpContext);
            }
            catch (System.Exception ex)
            {
                nlog.Trace(ex);
                throw ex;
            }

            
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class GlobalExeptionExtensions
    {
        public static IApplicationBuilder UseGlobalExeption(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<GlobalExeption>();
        }
    }
}
