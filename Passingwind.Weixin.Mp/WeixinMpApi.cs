using Passingwind.Weixin.Common;
using Passingwind.Weixin.Dependency;
using Passingwind.Weixin.Http;
using Passingwind.Weixin.Models;
using Passingwind.Weixin.MP.Apis;
using Passingwind.Weixin.MP.Services;
using Passingwind.Weixin.Utils;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Passingwind.Weixin.MP
{
    public class WeixinMpApi : BaseApi
    {
        public MPAccount Account { get; private set; }

        public Token Token { get; private set; }

        public IAccessTokenStoreService AccessTokenStoreService { get; private set; }

        public WeixinMpApi(MPAccount account) : base()
        {
            Account = account;

            if (DependencyManager.TryResolve<IAccessTokenStoreService>(out var storeService))
            {
                AccessTokenStoreService = storeService;
            }
            else
            {
                AccessTokenStoreService = new DefaultAccessTokenStoreService();
            }

            AsyncHelper.RunSync(() => TryUpdateTokenAsync(true));
        }

        /// <summary>
        ///  从微信服务器更新 access Token
        /// </summary> 
        public async Task<Token> TryUpdateTokenAsync(bool force = false)
        {
            if (this.Token == null || this.Token.IsExpired() || force)
            {
                string url = this.ServerHostConfig.DefaultApiHost + $"/cgi-bin/token?grant_type=client_credential&appid={Account.AppId}&secret={Account.AppSecret}";

                var result = await HttpService.GetAsync<AccessTokenModel>(url);
                if (result.Success)
                {
                    var data = result.Data;
                    if (data?.ErrorCode == 0)
                    {
                        this.Token = new Token()
                        {
                            AccessToken = data.AccessToken,
                            ExpiresIn = data.ExpiresIn,
                            ExpiresTime = DateTimeOffset.Now.AddSeconds(data.ExpiresIn),
                        };
                    }
                    else
                    {
                        // TODO 
                    }
                }
                else
                {
                    // TODO 
                    // throw new Exception("获取access_token失败");
                }
            }
            else
            {
            }

            if (this.Token != null)
                this.AccessTokenStoreService.Write(this.Account.AppId, this.Token);

            return this.Token;
        }

        #region Apis

        public CommonApi CommonApi => new CommonApi(this);

        public UserApi UserApi => new UserApi(this);

        public MenuApi MenuApi => new MenuApi(this);

        public MediaApi MediaApi => new MediaApi(this);

        #endregion

    }
}
