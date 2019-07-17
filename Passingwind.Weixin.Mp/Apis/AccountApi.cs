using Passingwind.Weixin.Common;
using Passingwind.Weixin.Http;
using Passingwind.Weixin.Logger;
using Passingwind.Weixin.Models;
using Passingwind.Weixin.Mp.Models.QrCode;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Passingwind.Weixin.Mp.Apis
{
    public class AccountApi
    {
        private readonly WeixinMpApi _api;

        protected string AccessToken => _api.Token?.AccessToken;

        protected ILogger Logger => _api.Logger;

        protected IHttpService HttpService => _api.HttpService;

        public AccountApi(WeixinMpApi api)
        {
            _api = api;
        }

        #region 生成带参数的二维码

        /// <summary>
        ///   创建二维码ticket
        /// </summary> 
        /// <remarks>
        /// <![CDATA[https://mp.weixin.qq.com/wiki?t=resource/res_main&id=mp1443433542]]>
        /// </remarks>
        public async Task<QrCodeCreateResultModel> QrCodeCreateAsync(QrCodeCreateRequestModel model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));

            string url = $"{ServerUrl.MP_API_URL}/qrcode/create?access_token={_api.Token?.AccessToken}";

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

            string url = $"{ServerUrl.MP_API_URL}/showqrcode?ticket={ticket}";

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


    }
}
