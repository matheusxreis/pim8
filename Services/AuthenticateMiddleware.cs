using System.Globalization;

namespace pim8.Services
{
    public class AuthenticateMiddleware
    {
        private readonly RequestDelegate _next;
        private List<string> authUrls = new List<string> { "/Auth/SignUp", "/Auth/SignIn", "/Auth/SignUpSuccess" };  
        public AuthenticateMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            string? authCookie = context.Request.Cookies["SESSION_UNIP_PIM8"];
            if (authCookie == null)
            {
                string path = context.Request.Path;
                if(authUrls.Any(x=>x == path) == false) { 
                context.Response.Redirect("/Auth/SignIn");
                return;
                }
            }
            await _next(context);
        }
    }

    public static class RequestAuthenticateMiddlewareExtensions
    {
        public static IApplicationBuilder UseAuth(
            this IApplicationBuilder builder
        )
        {
            return builder.UseMiddleware<AuthenticateMiddleware>();
        }
    }
}