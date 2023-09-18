using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace ConsoleApp
{
    public class Security
    {
        public string HashString(string key)
        {
            return BCrypt.Net.BCrypt.HashPassword(key);
        }
        public bool VerifyKey(string key, string hash)
        {
            return BCrypt.Net.BCrypt.Verify(key, hash);
        }
    }
}
