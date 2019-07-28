using Passingwind.Weixin.Http;
using Passingwind.Weixin.Logger;
using Passingwind.Weixin.Models;
using Passingwind.Weixin.MP.Models.Menus;
using System;
using System.Threading.Tasks;

namespace Passingwind.Weixin.MP.Apis
{
    /// <summary>
    ///  菜单相关
    /// </summary>
    public class MenuApi
    {
        private readonly WeixinMpApi _api;

        protected string AccessToken => _api.Token?.AccessToken;

        protected ILogger Logger => _api.Logger;

        protected IHttpService HttpService => _api.HttpService;

        protected WeixinServerHostConfig ServerHostConfig => _api.ServerHostConfig;

        public MenuApi(WeixinMpApi api)
        {
            _api = api;
        }

        #region 自定义菜单

        /// <summary>
        ///  自定义菜单查询接口
        /// </summary>
        /// <remarks>
        /// <![CDATA[https://mp.weixin.qq.com/wiki?t=resource/res_main&id=mp1421141014]]>
        /// </remarks>
        public async Task<MenuResultModel> GetAsync()
        {
            string url = $"{ServerHostConfig.DefaultApiHost}/cgi-bin/menu/get?access_token={_api.Token?.AccessToken}";

            return (await HttpService.GetAsync<MenuResultModel>(url)).Data;
        }
         
        /// <summary>
        ///  自定义菜单创建接口
        /// </summary>
        /// <remarks>
        /// <![CDATA[https://mp.weixin.qq.com/wiki?t=resource/res_main&id=mp1421141013]]>
        /// </remarks>
        public async Task<JsonResultModel> CreateAsync(CreateMenuRequesetModel model)
        {
            if (model == null || model.Button == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            string url = $"{ServerHostConfig.DefaultApiHost}/cgi-bin/menu/create?access_token={_api.Token?.AccessToken}";

            return (await HttpService.PostAsync<JsonResultModel>(url, model)).Data;
        }

        /// <summary>
        ///  自定义菜单删除接口
        /// </summary>
        /// <remarks>
        /// <![CDATA[https://mp.weixin.qq.com/wiki?t=resource/res_main&id=mp1421141015]]>
        /// </remarks>
        public async Task<JsonResultModel> DeleteAsync()
        {
            string url = $"{ServerHostConfig.DefaultApiHost}/cgi-bin/menu/delete?access_token={_api.Token?.AccessToken}";

            return (await HttpService.GetAsync<JsonResultModel>(url)).Data;
        }

        #endregion

        #region 个性化菜单

        /// <summary>
        ///  创建个性化菜单
        /// </summary>
        /// <remarks>
        /// <![CDATA[https://mp.weixin.qq.com/wiki?t=resource/res_main&id=mp1455782296]]>
        /// </remarks>
        public async Task<AddConditionalResultModel> AddConditional(AddConditionalRequestModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            string url = $"{ServerHostConfig.DefaultApiHost}/cgi-bin/menu/addconditional?access_token={_api.Token?.AccessToken}";

            return (await HttpService.PostAsync<AddConditionalResultModel>(url, model)).Data;
        }

        /// <summary>
        ///  删除个性化菜单
        /// </summary>
        /// <remarks>
        /// <![CDATA[https://mp.weixin.qq.com/wiki?t=resource/res_main&id=mp1455782296]]>
        /// </remarks>
        public async Task<JsonResultModel> DeleteConditional()
        {
            string url = $"{ServerHostConfig.DefaultApiHost}/cgi-bin/menu/delconditional?access_token={_api.Token?.AccessToken}";

            return (await HttpService.PostAsync<JsonResultModel>(url)).Data;
        }

        /// <summary>
        ///  测试个性化菜单匹配结果
        /// </summary>
        /// <remarks>
        /// <![CDATA[https://mp.weixin.qq.com/wiki?t=resource/res_main&id=mp1455782296]]>
        /// </remarks>
        public async Task<MenuResultModel> ConditionalTryMatch(string userId)
        {
            if (string.IsNullOrWhiteSpace(userId))
            {
                throw new ArgumentException("message", nameof(userId));
            }

            string url = $"{ServerHostConfig.DefaultApiHost}/cgi-bin/menu/trymatch?access_token={_api.Token?.AccessToken}";

            return (await HttpService.PostAsync<MenuResultModel>(url, new { user_id = userId })).Data;
        }

        #endregion

        #region 获取自定义菜单配置接口

        /// <summary>
        ///  获取自定义菜单配置接口
        /// </summary>
        /// <remarks>
        /// <![CDATA[https://mp.weixin.qq.com/wiki?t=resource/res_main&id=mp1434698695]]>
        /// </remarks>
        public async Task<MenuResultModel> GetCurrentSelfMenuInfo()
        {
            string url = $"{ServerHostConfig.DefaultApiHost}/cgi-bin/get_current_selfmenu_info?access_token={_api.Token?.AccessToken}";

            return (await HttpService.GetAsync<MenuResultModel>(url)).Data;
        }
         
        #endregion

    }
}
