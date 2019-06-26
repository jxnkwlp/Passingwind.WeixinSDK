using Passingwind.Weixin.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Passingwind.Weixin.Mp.Services
{
    public interface IAccessTokenStoreService
    {
        void Write(string appId, Token token);
        Token Read(string appId);
    }
}
