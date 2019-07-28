using Passingwind.Weixin.Dependency;
using Passingwind.Weixin.Http;
using Passingwind.Weixin.Logger;
using System;

namespace Passingwind.Weixin
{
    public class WeixinServiceRegister
    {
        protected WeixinServiceRegister()
        {
        }

        /// <summary>
        ///  注册相关服务
        /// </summary>
        /// <returns></returns>
        public static WeixinServiceRegister Register()
        {
            DependencyManager.Register<ILogger, NullLogger>();
            DependencyManager.Register<IHttpService, DefaultHttpService>();
            DependencyManager.Register(new WeixinServerHostConfig());

            return new WeixinServiceRegister();
        }

        public WeixinServiceRegister AddLogger<TLogger>() where TLogger : class, ILogger
        {
            DependencyManager.Register<ILogger, TLogger>();

            return this;
        }

        public WeixinServiceRegister AddHttpService<THttpService>() where THttpService : class, IHttpService
        {
            DependencyManager.Register<IHttpService, THttpService>();

            return this;
        }

        public WeixinServiceRegister AddWeixinServerHost(Action<WeixinServerHostConfig> config)
        {
            var defaultConfig = new WeixinServerHostConfig();

            config(defaultConfig);

            DependencyManager.Register(defaultConfig);

            return this;
        }
    }


}
