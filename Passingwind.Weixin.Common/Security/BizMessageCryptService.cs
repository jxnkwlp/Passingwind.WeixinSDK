using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Passingwind.Weixin.Security
{
    public class BizMessageCryptService : IBizMessageCryptService
    {
        public string Decrypt(string token, long timestamp, string nonce, string signature)
        {
            throw new NotImplementedException();
        }

        public string Encrypt(string token, long timestamp, string nonce)
        {
            var data = new SortedSet<string>();
            data.Add(token);
            data.Add(timestamp.ToString());
            data.Add(nonce);

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
