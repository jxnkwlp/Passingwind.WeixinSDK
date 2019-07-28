using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Passingwind.Weixin.Security
{
    public static class BizMessageSignature
    {
        public static string Create(string token, string timeStamp, string nonce, string encryptMessage)
        {
            var data = new SortedSet<string>();
            data.Add(token);
            data.Add(timeStamp);
            data.Add(nonce);
            data.Add(encryptMessage);

            string raw = string.Concat(data);

            try
            {
                SHA1 sha = new SHA1CryptoServiceProvider();
                byte[] dataHashed = sha.ComputeHash(Encoding.UTF8.GetBytes(raw));
                var hash = BitConverter.ToString(dataHashed).Replace("-", "");
                return hash;
            }
            catch (Exception)
            {
            }

            return null;
        }
    }
}
