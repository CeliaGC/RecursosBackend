using Data;
using Entities.Entities;
using Logic.ILogic;
using System.Data;
using System.Security.Authentication;
using System.Security.Cryptography;

namespace Logic.Logic
{
    public class UserSecurityLogic : IUserSecurityLogic
    {
        private readonly ServiceContext _serviceContext;
        public UserSecurityLogic(ServiceContext serviceContext)
        {
            _serviceContext = serviceContext;
        }

        public string GenerateAuthorizationToken(string userName, string userPassword)
        {
            var user = _serviceContext.Set<UserItem>()
                     .Where(u => u.UserName == userName).SingleOrDefault();

            if (user == null)
            {
                throw new InvalidCredentialException("El usuario no existe o bien está replicado.");
            }

            if (user.IsActive == false)
            {
                throw new InvalidOperationException("El usuario no está activo.");
            }

            if (!VerifyHashedKey(userPassword, user.EncryptedPassword))
            {
                throw new UnauthorizedAccessException("La contraseña es incorrecta.");
            }

            var secureRandomString = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64));
            user.EncryptedToken = HashString(secureRandomString);
            user.TokenExpireDate = DateTime.Now.AddMinutes(10);

            _serviceContext.SaveChanges();

            return secureRandomString;
        }

        public string HashString(string key)
        {
            return BCrypt.Net.BCrypt.HashPassword(key);
        }

        public bool ValidateUserToken(string userName, string token, List<string> authorizedRols)
        {
            var user = _serviceContext.Set<UserItem>()
                     .Where(u => u.UserName == userName).FirstOrDefault();

            if (user == null)
            {
                throw new InvalidCredentialException("El usuario no existe.");
            }

            if (user.IsActive == false)
            {
                throw new InvalidCredentialException("El usuario no está activo.");
            }

            var userRol = _serviceContext.Set<UserRolItem>().Where(r => r.Id == user.IdRol).First();

            bool authorizedRol = authorizedRols.Any(r => r.Equals(userRol.Name));

            if (!authorizedRol)
            {
                throw new UnauthorizedAccessException("El usuario no está autorizado para la acción.");
            }

            if (VerifyHashedKey(token, user.EncryptedToken) == false)
            {
                throw new UnauthorizedAccessException("El token es incorrecto.");
            }

            if (DateTime.Now > user.TokenExpireDate)
            {
                throw new UnauthorizedAccessException("El token ha expirado.");
            }

            user.TokenExpireDate = DateTime.Now.AddMinutes(10);
            _serviceContext.SaveChanges();

            return true;
        }

        private bool VerifyHashedKey(string key, string hash)
        {
            return BCrypt.Net.BCrypt.Verify(key, hash);
        }
    }
}