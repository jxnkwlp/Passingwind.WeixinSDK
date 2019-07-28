using Passingwind.Weixin.Common;
using Passingwind.Weixin.Http;
using Passingwind.Weixin.Logger;
using Passingwind.Weixin.MP.Models.DataCube;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Passingwind.Weixin.MP.Apis
{
    public class DataCubeApi
    {
        private readonly WeixinMpApi _api;

        protected string AccessToken => _api.Token?.AccessToken;

        protected ILogger Logger => _api.Logger;

        protected IHttpService HttpService => _api.HttpService;

        protected WeixinServerHostConfig ServerHostConfig => _api.ServerHostConfig;

        public DataCubeApi(WeixinMpApi api)
        {
            _api = api;
        }


        #region 用户分析数据接口

        /// <summary>
        /// 获取用户增减数据
        /// </summary> 
        /// <remarks>
        /// <![CDATA[https://mp.weixin.qq.com/wiki?t=resource/res_main&id=mp1421141082]]> 
        /// </remarks>
        public async Task<GetUserAnalysisResultModel> GetUserSummaryAsync(GetUserAnalysisRequestModel model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));

            string url = $"{ServerHostConfig.DefaultApiHost}/datacube/getusersummary?access_token={_api.Token?.AccessToken}";

            return (await HttpService.PostAsync<GetUserAnalysisResultModel>(url, model)).Data;
        }

        /// <summary>
        /// 获取累计用户数据
        /// </summary> 
        /// <remarks>
        /// <![CDATA[https://mp.weixin.qq.com/wiki?t=resource/res_main&id=mp1421141082]]> 
        /// </remarks>
        public async Task<GetUserAnalysisResultModel> GetUserCumulateAsync(GetUserAnalysisRequestModel model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));

            string url = $"{ServerHostConfig.DefaultApiHost}/datacube/getusercumulate?access_token={_api.Token?.AccessToken}";

            return (await HttpService.PostAsync<GetUserAnalysisResultModel>(url, model)).Data;
        }

        #endregion

        #region 图文分析数据接口

        /// <summary>
        /// 获取图文群发每日数据
        /// </summary> 
        /// <remarks>
        /// <![CDATA[https://mp.weixin.qq.com/wiki?t=resource/res_main&id=mp1421141084 ]]> 
        /// </remarks>
        public async Task<ArticleSummaryResultModel> GetArticleSummaryAsync(ArticleSummaryRequestModel model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));

            string url = $"{ServerHostConfig.DefaultApiHost}/datacube/getarticlesummary?access_token={_api.Token?.AccessToken}";

            return (await HttpService.PostAsync<ArticleSummaryResultModel>(url, model)).Data;
        }

        /// <summary>
        /// 获取图文群发总数据
        /// </summary> 
        /// <remarks>
        /// <![CDATA[https://mp.weixin.qq.com/wiki?t=resource/res_main&id=mp1421141084 ]]> 
        /// </remarks>
        public async Task<ArticleTotalResultModel> GetArticleTotalAsync(ArticleTotalRequestModel model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));

            string url = $"{ServerHostConfig.DefaultApiHost}/datacube/getarticletotal?access_token={_api.Token?.AccessToken}";

            return (await HttpService.PostAsync<ArticleTotalResultModel>(url, model)).Data;
        }

        /// <summary>
        /// 获取图文统计数据
        /// </summary> 
        /// <remarks>
        /// <![CDATA[https://mp.weixin.qq.com/wiki?t=resource/res_main&id=mp1421141084 ]]> 
        /// </remarks>
        public async Task<UserReadResultModel> GetUserReadAsync(UserReadRequestModel model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));

            string url = $"{ServerHostConfig.DefaultApiHost}/datacube/getuserread?access_token={_api.Token?.AccessToken}";

            return (await HttpService.PostAsync<UserReadResultModel>(url, model)).Data;
        }

        /// <summary>
        /// 获取图文统计分时数据
        /// </summary> 
        /// <remarks>
        /// <![CDATA[https://mp.weixin.qq.com/wiki?t=resource/res_main&id=mp1421141084 ]]> 
        /// </remarks>
        public async Task<UserReadHourResultModel> GetUserReadHourAsync(UserReadHourRequestModel model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));

            string url = $"{ServerHostConfig.DefaultApiHost}/datacube/getuserreadhour?access_token={_api.Token?.AccessToken}";

            return (await HttpService.PostAsync<UserReadHourResultModel>(url, model)).Data;
        }

        /// <summary>
        /// 获取图文分享转发数据
        /// </summary> 
        /// <remarks>
        /// <![CDATA[https://mp.weixin.qq.com/wiki?t=resource/res_main&id=mp1421141084 ]]> 
        /// </remarks>
        public async Task<UserShareResultModel> GetUserShareAsync(UserShareRequestModel model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));

            string url = $"{ServerHostConfig.DefaultApiHost}/datacube/getusershare?access_token={_api.Token?.AccessToken}";

            return (await HttpService.PostAsync<UserShareResultModel>(url, model)).Data;
        }

        /// <summary>
        /// 获取图文分享转发分时数据
        /// </summary> 
        /// <remarks>
        /// <![CDATA[https://mp.weixin.qq.com/wiki?t=resource/res_main&id=mp1421141084 ]]> 
        /// </remarks>
        public async Task<UserShareHourResultModel> GetUserShareHourAsync(UserShareHourRequestModel model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));

            string url = $"{ServerHostConfig.DefaultApiHost}/datacube/getusersharehour?access_token={_api.Token?.AccessToken}";

            return (await HttpService.PostAsync<UserShareHourResultModel>(url, model)).Data;
        }

        #endregion

        #region 消息分析数据接口

        /// <summary>
        /// 获取图文分享转发分时数据
        /// </summary> 
        /// <remarks>
        /// <![CDATA[https://mp.weixin.qq.com/wiki?t=resource/res_main&id=mp1421141085 ]]> 
        /// </remarks>
        public async Task<UpStreamMsgResultModel> GetUpStreamMsgAsync(UpStreamMsgRequestModel model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));

            string url = $"{ServerHostConfig.DefaultApiHost}/datacube/getupstreammsg?access_token={_api.Token?.AccessToken}";

            return (await HttpService.PostAsync<UpStreamMsgResultModel>(url, model)).Data;
        }

        /// <summary>
        /// 获取消息分送分时数据
        /// </summary> 
        /// <remarks>
        /// <![CDATA[https://mp.weixin.qq.com/wiki?t=resource/res_main&id=mp1421141085 ]]> 
        /// </remarks>
        public async Task<UpStreamMsgHourResultModel> GetUpStreamMsgHourAsync(UpStreamMsgHourRequestModel model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));

            string url = $"{ServerHostConfig.DefaultApiHost}/datacube/getupstreammsghour?access_token={_api.Token?.AccessToken}";

            return (await HttpService.PostAsync<UpStreamMsgHourResultModel>(url, model)).Data;
        }

        /// <summary>
        /// 获取消息发送周数据
        /// </summary> 
        /// <remarks>
        /// <![CDATA[https://mp.weixin.qq.com/wiki?t=resource/res_main&id=mp1421141085 ]]> 
        /// </remarks>
        public async Task<UpStreamMsgHourResultModel> GetUpStreamMsgWeekAsync(UpStreamMsgHourRequestModel model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));

            string url = $"{ServerHostConfig.DefaultApiHost}/datacube/getupstreammsgweek?access_token={_api.Token?.AccessToken}";

            return (await HttpService.PostAsync<UpStreamMsgHourResultModel>(url, model)).Data;
        }

        /// <summary>
        /// 获取消息发送月数据
        /// </summary> 
        /// <remarks>
        /// <![CDATA[https://mp.weixin.qq.com/wiki?t=resource/res_main&id=mp1421141085 ]]> 
        /// </remarks>
        public async Task<UpStreamMsgMonthResultModel> GetUpStreamMsgMonthAsync(UpStreamMsgMonthRequestModel model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));

            string url = $"{ServerHostConfig.DefaultApiHost}/datacube/getupstreammsgmonth?access_token={_api.Token?.AccessToken}";

            return (await HttpService.PostAsync<UpStreamMsgMonthResultModel>(url, model)).Data;
        }

        /// <summary>
        /// 获取消息发送分布数据
        /// </summary> 
        /// <remarks>
        /// <![CDATA[https://mp.weixin.qq.com/wiki?t=resource/res_main&id=mp1421141085 ]]> 
        /// </remarks>
        public async Task<UpStreamMsgDistResultModel> GetUpStreamMsgDistAsync(UpStreamMsgDistRequestModel model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));

            string url = $"{ServerHostConfig.DefaultApiHost}/datacube/getupstreammsgdist?access_token={_api.Token?.AccessToken}";

            return (await HttpService.PostAsync<UpStreamMsgDistResultModel>(url, model)).Data;
        }

        /// <summary>
        /// 获取消息发送分布周数据
        /// </summary> 
        /// <remarks>
        /// <![CDATA[https://mp.weixin.qq.com/wiki?t=resource/res_main&id=mp1421141085 ]]> 
        /// </remarks>
        public async Task<UpStreamMsgDistWeekResultModel> GetUpStreamMsgDistWeekAsync(UpStreamMsgDistWeekRequestModel model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));

            string url = $"{ServerHostConfig.DefaultApiHost}/datacube/getupstreammsgdistweek?access_token={_api.Token?.AccessToken}";

            return (await HttpService.PostAsync<UpStreamMsgDistWeekResultModel>(url, model)).Data;
        }

        /// <summary>
        /// 获取消息发送分布月数据
        /// </summary> 
        /// <remarks>
        /// <![CDATA[https://mp.weixin.qq.com/wiki?t=resource/res_main&id=mp1421141085 ]]> 
        /// </remarks>
        public async Task<UpStreamMsgDistMonthResultModel> GetUpStreamMsgDistMonthAsync(UpStreamMsgDistMonthRequestModel model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));

            string url = $"{ServerHostConfig.DefaultApiHost}/datacube/getupstreammsgdistmonth?access_token={_api.Token?.AccessToken}";

            return (await HttpService.PostAsync<UpStreamMsgDistMonthResultModel>(url, model)).Data;
        }

        #endregion

        #region 接口分析数据接口

        /// <summary>
        /// 获取接口分析数据
        /// </summary> 
        /// <remarks>
        /// <![CDATA[https://mp.weixin.qq.com/wiki?t=resource/res_main&id=mp1421141086 ]]> 
        /// </remarks>
        public async Task<InterfaceSummaryResultModel> GetInterfaceSummaryAsync(InterfaceSummaryRequestModel model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));

            string url = $"{ServerHostConfig.DefaultApiHost}/datacube/getinterfacesummary?access_token={_api.Token?.AccessToken}";

            return (await HttpService.PostAsync<InterfaceSummaryResultModel>(url, model)).Data;
        }

        /// <summary>
        /// 获取接口分析分时数据
        /// </summary> 
        /// <remarks>
        /// <![CDATA[https://mp.weixin.qq.com/wiki?t=resource/res_main&id=mp1421141086 ]]> 
        /// </remarks>
        public async Task<InterfaceSummaryHourResultModel> GetUpStreamMsgDistMonthAsync(InterfaceSummaryHourRequestModel model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));

            string url = $"{ServerHostConfig.DefaultApiHost}/datacube/getinterfacesummaryhour?access_token={_api.Token?.AccessToken}";

            return (await HttpService.PostAsync<InterfaceSummaryHourResultModel>(url, model)).Data;
        }

        #endregion
    }
}
