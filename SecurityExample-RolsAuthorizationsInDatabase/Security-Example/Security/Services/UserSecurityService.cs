using Logic.ILogic;
using Security.IServices;

namespace Security.Services
{
    public class UserSecurityService : IUserSecurityService
    {
        private readonly IUserSecurityLogic _userSecurityLogic;
        public UserSecurityService(IUserSecurityLogic userSecurityLogic) 
        {
            _userSecurityLogic = userSecurityLogic;
        }
        public string GenerateAuthorizationToken(string userName, string userPassword)
        {
            return _userSecurityLogic.GenerateAuthorizationToken(userName, userPassword);
        }
        public bool ValidateUserToken(string authorization, string controller, string action, string method)
        {
            var indexToSplit = authorization.IndexOf(':');
            var userName = authorization.Substring(7, indexToSplit - 7);
            var token = authorization.Substring(indexToSplit +1, authorization.Length - userName.Length -8);
            return _userSecurityLogic.ValidateUserToken(userName, token, controller, action, method);
        }
    }
}
