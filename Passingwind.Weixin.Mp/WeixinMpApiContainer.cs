using System;
using System.Collections.Generic;

namespace Passingwind.Weixin.MP
{
    public class WeixinMpApiContainer : BaseApi
    {
        private static Dictionary<string, MPAccount> _accounts = new Dictionary<string, MPAccount>();
        private static Dictionary<string, WeixinMpApi> _apiInstances = new Dictionary<string, WeixinMpApi>();

        public static void Register(MPAccount account, string name = "default")
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("message", nameof(name));
            }

            if (_accounts.ContainsKey(name))
                throw new WeixinException($"名称'{name}'已注册");

            _accounts[name] = account;
        }

        public static WeixinMpApi GetInstance(string name = "default")
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("message", nameof(name));
            }

            if (_accounts.ContainsKey(name))
            {
                if (_apiInstances.ContainsKey(name))
                    return _apiInstances[name];
                else
                {
                    var instance = new WeixinMpApi(_accounts[name]);

                    _apiInstances[name] = instance;

                    return instance;
                }
            }
            else
                throw new Exception($"名称'{name}'未注册");
        }


    }
}
