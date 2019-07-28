using System;
using System.Collections.Generic;
using System.Text;
using Passingwind.Weixin.Common;

namespace Passingwind.Weixin.MP.Services
{
    public class DefaultAccessTokenStoreService : IAccessTokenStoreService
    {
        static Dictionary<string, Token> _tokens = new Dictionary<string, Token>();

        public Token Read(string appId)
        {
            if (_tokens.ContainsKey(appId))
                return _tokens[appId];
            return null;
        }

        public void Write(string appId, Token token)
        {
            _tokens[appId] = token;
        }
    }
}
