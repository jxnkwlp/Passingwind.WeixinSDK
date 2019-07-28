using Passingwind.Weixin.Common;
using Passingwind.Weixin.Http;
using Passingwind.Weixin.Logger;
using Passingwind.Weixin.Models;
using Passingwind.Weixin.MP.Models;
using System.Threading.Tasks;

namespace Passingwind.Weixin.MP.Apis
{
    /// <summary>
    ///  通用API
    /// </summary>
    public class CommonApi
    {
        private readonly WeixinMpApi _api;

        protected ILogger Logger => _api.Logger;

        protected IHttpService HttpService => _api.HttpService;

        protected WeixinServerHostConfig ServerHostConfig => _api.ServerHostConfig;

        public CommonApi(WeixinMpApi api)
        {
            _api = api;
        }

        /// <summary>
        ///  获取微信服务器IP地址 
        /// </summary> 
        /// <remarks>
        ///  https://mp.weixin.qq.com/wiki?t=resource/res_main&id=mp1421140187
        /// </remarks>
        public async Task<CallbackIpJsonReturnModel> GetCallbackIpAsync()
        {
            return (await HttpService.GetAsync<CallbackIpJsonReturnModel>($"{ServerHostConfig.DefaultApiHost}/cgi-bin/cgi-bin/cgi-bin/getcallbackip?access_token={_api.Token?.AccessToken}")).Data;
        }


        /// <summary>
        ///  网络检测
        /// </summary>
        /// <remarks>
        ///  https://mp.weixin.qq.com/wiki?t=resource/res_main&id=21541575776DtsuT
        /// </remarks>
        public async Task<CheckResultModel> CheckAsync(CheckRequest request)
        {
            var url = $"{ServerHostConfig.DefaultApiHost}/cgi-bin/cgi-bin/cgi-bin/callback/check?access_token={_api.Token?.AccessToken}";
            return (await HttpService.PostAsync<CheckRequest, CheckResultModel>(url, request, PostDataType.Json)).Data;
        }
    }
}
