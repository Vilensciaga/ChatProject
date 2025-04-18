using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.EncryptionMethods
{
    public static class Encryption
    {
        private static readonly string key = "ksjhdidjsndkuhdjkleioajciomwv89j094wmmviw9490jmfmw4o[05gjow4mf";

        public static string EncryptPassword(string password)
        {
            if (string.IsNullOrEmpty(password)) return "";
            password += key;

            var passwordBytes = Encoding.UTF8.GetBytes(password);
            return Convert.ToBase64String(passwordBytes);

        }


        public static string DecryptPassword(string hash)
        {
            if (string.IsNullOrEmpty(hash)) return "";
            var base64EncodeBytes = Convert.FromBase64String(hash);
            var result = Encoding.UTF8.GetString(base64EncodeBytes);
            result = result.Substring(0, result.Length - key.Length);
            return result;
        }

    }
}
