namespace Logic.ILogic
{
    public interface IUserSecurityLogic
    {
        string GenerateAuthorizationToken(string userName, string userPasswordEncrypted);
        bool ValidateUserToken(string userName, string token, string controller, string action, string method);
        string HashString(string key);
    }
}
