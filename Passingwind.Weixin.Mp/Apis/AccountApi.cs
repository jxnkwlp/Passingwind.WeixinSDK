using Passingwind.Weixin.Common;
using Passingwind.Weixin.Http;
using Passingwind.Weixin.Logger;
using Passingwind.Weixin.Models;
using Passingwind.Weixin.MP.Models.Common;
using Passingwind.Weixin.MP.Models.QrCode;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Passingwind.Weixin.MP.Apis
{
    /// <summary>
    ///  帐号管理 相关接口
    /// </summary>
    public class AccountApi
    {
        private readonly WeixinMpApi _api;

        protected string AccessToken => _api.Token?.AccessToken;

        protected ILogger Logger => _api.Logger;

        protected IHttpService HttpService => _api.HttpService;

        protected WeixinServerHostConfig ServerHostConfig => _api.ServerHostConfig;

        public AccountApi(WeixinMpApi api)
        {
            _api = api;
        }

        #region 生成带参数的二维码

        /// <summary>
        ///  创建二维码ticket
        /// </summary> 
        /// <remarks>
        /// <![CDATA[https://mp.weixin.qq.com/wiki?t=resource/res_main&id=mp1443433542]]>
        /// </remarks>
        public async Task<QrCodeCreateResultModel> QrCodeCreateAsync(QrCodeCreateRequestModel model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));

            string url = $"{ServerHostConfig.DefaultApiHost}/qrcode/create?access_token={_api.Token?.AccessToken}";

            return (await HttpService.PostAsync<QrCodeCreateResultModel>(url, model)).Data;
        }

        /// <summary>
        ///   通过ticket换取二维码
        /// </summary> 
        /// <remarks>
        /// <![CDATA[https://mp.weixin.qq.com/wiki?t=resource/res_main&id=mp1443433542]]>
        /// </remarks>
        public async Task<QrCodeShowResultModel> QrCodeShowAsync(string ticket)
        {
            if (string.IsNullOrWhiteSpace(ticket))
            {
                throw new ArgumentException("message", nameof(ticket));
            }

            string url = $"{ServerHostConfig.DefaultApiHost}/cgi-bin/cgi-bin/cgi-bin/showqrcode?ticket={ticket}";

            var response = (await HttpService.GetAsync<QrCodeShowResultModel>(url));

            if (response.ContentType.StartsWith("image/"))
            {
                return new QrCodeShowResultModel()
                {
                    File = response.Raw,
                };
            }
            else
            {
                return response.Data;
            }
        }

        #endregion

        #region 长链接转短链接接口

        /// <summary>
        ///  长链接转短链接接口
        /// </summary> 
        /// <remarks>
        /// <![CDATA[https://mp.weixin.qq.com/wiki?t=resource/res_main&id=mp1443433600]]>
        /// </remarks>
        public async Task<GenerateShortUrlResultModel> GenerateShortUrl(GenerateShortUrlRequestModel model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));

            string url = $"{ServerHostConfig.DefaultApiHost}/cgi-bin/cgi-bin/shorturl?access_token={_api.Token?.AccessToken}";

            return (await HttpService.PostAsync<GenerateShortUrlResultModel>(url, model)).Data;
        }

        #endregion

    }
}
