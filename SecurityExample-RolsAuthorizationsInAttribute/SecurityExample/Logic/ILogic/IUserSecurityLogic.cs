namespace Logic.ILogic
{
    public interface IUserSecurityLogic
    {
        string GenerateAuthorizationToken(string userName, string userPasswordEncrypted);
        string HashString(string key);
        bool ValidateUserToken(string userName, string token, List<string> authorizedRols);
    }
}
