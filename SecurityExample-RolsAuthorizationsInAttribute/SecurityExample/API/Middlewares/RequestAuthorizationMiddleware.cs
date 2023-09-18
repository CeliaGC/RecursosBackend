using API.Attributes;
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
            EndpointAuthorizeAttribute authorization = new EndpointAuthorizeAttribute(context);

            if (authorization.Values.AllowsAnonymous)
            {
                return;
            }

            _userSecurityService.ValidateUserToken(context.Request.Headers.Authorization.ToString(),
                                                 authorization.Values.AllowedUserRols);
        }
    }
}
