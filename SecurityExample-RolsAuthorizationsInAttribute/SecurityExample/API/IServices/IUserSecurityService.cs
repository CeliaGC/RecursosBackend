namespace API.IServices
{
    public interface IUserSecurityService
    {
        string GenerateAuthorizationToken(string userName, string userPassword);
        bool ValidateUserToken(string authorization, List<string> authorizedRols);
    }
}
