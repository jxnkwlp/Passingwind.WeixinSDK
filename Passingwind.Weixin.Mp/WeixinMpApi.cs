using Passingwind.Weixin.Common;
using Passingwind.Weixin.Common.Utils;
using Passingwind.Weixin.Models;
using Passingwind.Weixin.Mp.Apis;
using Passingwind.Weixin.Mp.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Passingwind.Weixin.Mp
{
    public class WeixinMpApi
    {
        private string _appSecret;

        public string AppId { get; }
        public Token Token { get; private set; }

        public IAccessTokenStoreService AccessTokenStoreService { get; private set; }

        public WeixinMpApi(string appId, string appSecret)
        {
            AppId = appId;
            _appSecret = appSecret;

            AccessTokenStoreService = new AccessTokenStoreService();

            _ = TryUpdateTokenAsync().Result;
        }

        public WeixinMpApi(string appId, string appSecret, IAccessTokenStoreService accessTokenStoreService) : this(appId, appSecret)
        {
            this.AccessTokenStoreService = accessTokenStoreService ?? throw new ArgumentNullException(nameof(accessTokenStoreService));

            _ = TryUpdateTokenAsync().Result;
        }

        /// <summary>
        ///  从微信服务器更新 access Token
        /// </summary> 
        public async Task<Token> TryUpdateTokenAsync(bool force = false)
        {
            if (this.Token == null || this.Token.IsExpired() || force)
            {
                string url = ServerUrl.MPAPI_URL + $"/token?grant_type=client_credential&appid={AppId}&secret={_appSecret}";

                var result = await HttpHelper.GetAsync<AccessTokenModel>(url);
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
                this.AccessTokenStoreService.Write(this.AppId, this.Token);

            return this.Token;
        }



        protected void CheckAccessToken()
        {

        }


        #region Apis

        public CommonApi CommonApi => new CommonApi(this);

        public UserApi UserApi => new UserApi(this);

        #endregion
    }
}
