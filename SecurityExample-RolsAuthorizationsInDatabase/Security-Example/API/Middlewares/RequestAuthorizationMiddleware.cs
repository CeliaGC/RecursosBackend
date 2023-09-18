using API.IServices;

namespace API.Middlewares
{
    public class RequestAuthorizationMiddleware
    {
        private readonly IUserSecurityService _userSecurityService;
        public RequestAuthorizationMiddleware(IUserSecurityService userSecurityService)
        {
            _userSecurityService = userSecurityService;
        }

        public void ValidateRequestAutorizathion(HttpContext context)
        {
            var controller = context.GetRouteData().Values["controller"].ToString();
            var action = context.GetRouteData().Values["action"].ToString();
            if (!(controller == "User" && action == "Login"))
            {
                _userSecurityService.ValidateUserToken(context.Request.Headers.Authorization.ToString(),
                                                  controller,
                                                  action,
                                                  context.Request.Method.ToString());
            }
        }
    }
}
