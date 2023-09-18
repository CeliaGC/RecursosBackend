namespace Security.IServices
{
    public interface IUserSecurityService
    {
        string GenerateAuthorizationToken(string userName, string userPassword);
        void ValidateUserTokenFromAttribute(string authorization, List<string> authorizedRols, bool authorizedAnonymous);
    }
}