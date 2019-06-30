using Passingwind.Weixin.Common;
using Passingwind.Weixin.Common.Utils;
using Passingwind.Weixin.Mp.Models;
using System.Threading.Tasks;

namespace Passingwind.Weixin.Mp.Apis
{
    /// <summary>
    ///  通用API
    /// </summary>
    public class CommonApi
    {
        private readonly WeixinMpApi _api;

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
            return (await HttpHelper.GetAsync<CallbackIpJsonReturnModel>($"{ServerUrl.MP_API_URL}/getcallbackip?access_token={_api.Token?.AccessToken}")).Data;
        }


        /// <summary>
        ///  网络检测
        /// </summary>
        /// <remarks>
        ///  https://mp.weixin.qq.com/wiki?t=resource/res_main&id=21541575776DtsuT
        /// </remarks>
        public async Task<CheckResultModel> CheckAsync(CheckRequest request)
        {
            var url = $"{ServerUrl.MP_API_URL}/callback/check?access_token={_api.Token?.AccessToken}";
            return (await HttpHelper.PostAsync<CheckRequest, CheckResultModel>(url, request, PostDataType.Json)).Data;
        }
    }
}
