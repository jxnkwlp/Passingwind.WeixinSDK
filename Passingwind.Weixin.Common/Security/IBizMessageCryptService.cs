using System;
using System.Collections.Generic;
using System.Text;

namespace Passingwind.Weixin.Security
{
    public interface IBizMessageCryptService
    {
        string Encrypt(string token, long timestamp, string nonce);
        string Decrypt(string token, long timestamp, string nonce, string signature);
    }
}
