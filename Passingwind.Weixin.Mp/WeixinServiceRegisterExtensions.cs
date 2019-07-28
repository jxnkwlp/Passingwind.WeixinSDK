using Passingwind.Weixin.Dependency;
using Passingwind.Weixin.MP.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Passingwind.Weixin.MP
{
    public static class WeixinServiceRegisterExtensions
    {
        public static WeixinServiceRegister AddMpService(this WeixinServiceRegister serviceRegister)
        {
            DependencyManager.Register<IAccessTokenStoreService, DefaultAccessTokenStoreService>();

            return serviceRegister;
        }

        public static WeixinServiceRegister AddAccessTokenStore<T>(this WeixinServiceRegister serviceRegister) where T : class, IAccessTokenStoreService
        {
            DependencyManager.Register<IAccessTokenStoreService, T>();

            return serviceRegister;
        }
    }
}
