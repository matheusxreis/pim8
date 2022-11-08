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

        private Boolean isEmailConfirmation(string path){
            string[] dividedPath = path.Split("/");
            if(dividedPath.Length >= 3){
               if(dividedPath[2] == "ConfirmEmail"){ return true; };
               }
            return false;
        }
        public async Task InvokeAsync(
            HttpContext context,
            iUserRepository userRepository
            )
        {
            string? authCookie = context.Request.Cookies["SESSION_UNIP_PIM8"];

            string path = context.Request.Path;
            Boolean isAuthUrl = authUrls.Any(x => x == path);

            if(isEmailConfirmation(path)) { await _next(context); return; }
            if (isAuthUrl)
            {
                if(authCookie != null) { context.Response.Redirect("/Home/Index"); return; }
                await _next(context);
                return;
            }
            if (authCookie == null)
            {
                context.Response.Redirect("/Auth/SignIn"); return;
            } else {
                UserModel? user = userRepository.getUserById(authCookie);
                if(user?.name == null) { context.Response.Redirect("/Auth/SignIn"); }
              
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