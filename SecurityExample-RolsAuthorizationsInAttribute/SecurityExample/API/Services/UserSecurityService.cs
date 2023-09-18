using API.IServices;
using Logic.ILogic;

namespace API.Services
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
        public bool ValidateUserToken(string authorization, List<string> authorizedRols)
        {
            var userName = GetUserNameFromAuthorization(authorization);
            var token = GetTokenFromAuthorization(authorization);
            return _userSecurityLogic.ValidateUserToken(userName, token, authorizedRols);
        }
        private string GetUserNameFromAuthorization(string authorization)
        {
            var indexToSplit = authorization.IndexOf(':');
            return authorization.Substring(7, indexToSplit - 7);
        }
        private string GetTokenFromAuthorization(string authorization)
        {
            var indexToSplit = authorization.IndexOf(':');
            var userName = authorization.Substring(7, indexToSplit - 7);
            return authorization.Substring(indexToSplit + 1, authorization.Length - userName.Length - 8);
        }
    }
}