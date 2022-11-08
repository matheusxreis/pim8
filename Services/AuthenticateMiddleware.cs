using System.Globalization;
using pim8.Models.Database;


namespace pim8.Services
{
    public class AuthenticateMiddleware
    {
        private readonly RequestDelegate _next;
        private List<string> authUrls = new List<string> {"/", "/Auth/SignUp", "/Auth/SignIn", "/Auth/SignUpSuccess" };
        public AuthenticateMiddleware(RequestDelegate next)
        {
            _next = next;

        }
        public async Task InvokeAsync(
            HttpContext context,
            iUserRepository userRepository
            )
        {
            string? authCookie = context.Request.Cookies["SESSION_UNIP_PIM8"];

            string path = context.Request.Path;
            Boolean isAuthUrl = authUrls.Any(x => x == path);
            if (isAuthUrl)
            {
                await _next(context);
                return;
            }
            if (authCookie == null)
            {
                context.Response.Redirect("/Auth/SignIn"); return;
            } else {
                UserModel? user = userRepository.getUserById(authCookie);
                if(user?.name == null) { context.Response.Redirect("/Auth/SignIn"); return; }
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