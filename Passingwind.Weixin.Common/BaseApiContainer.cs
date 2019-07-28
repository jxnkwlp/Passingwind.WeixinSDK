using Passingwind.Weixin.Dependency;
using Passingwind.Weixin.Http;
using Passingwind.Weixin.Logger;
using System;
using System.Collections.Generic;
using System.Text;

namespace Passingwind.Weixin
{
    public abstract class BaseApi
    {
        public ILogger Logger { get; private set; }

        public IHttpService HttpService { get; private set; }

        public WeixinServerHostConfig ServerHostConfig { get; private set; }

        public BaseApi()
        {
            this.Logger = DependencyManager.Resolve<ILogger>();
            this.HttpService = DependencyManager.Resolve<IHttpService>();
            this.ServerHostConfig = DependencyManager.Resolve<WeixinServerHostConfig>();
        }
    }
}
