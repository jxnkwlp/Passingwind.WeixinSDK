using Passingwind.Weixin.Dependency;
using Passingwind.Weixin.Http;
using Passingwind.Weixin.Logger;

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

            return new WeixinServiceRegister();
        }

        public WeixinServiceRegister RegisterLogger<TLogger>() where TLogger : class, ILogger
        {
            DependencyManager.Register<ILogger, TLogger>();

            return this;
        }

        public WeixinServiceRegister RegisterHttpService<THttpService>() where THttpService : class, IHttpService
        {
            DependencyManager.Register<IHttpService, THttpService>();

            return this;
        }
    }


}
