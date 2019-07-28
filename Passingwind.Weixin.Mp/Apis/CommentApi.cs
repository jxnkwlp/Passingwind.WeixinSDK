using Passingwind.Weixin.Http;
using Passingwind.Weixin.Logger;
using Passingwind.Weixin.Models;
using Passingwind.Weixin.MP.Models.Comments;
using System;
using System.Threading.Tasks;

namespace Passingwind.Weixin.MP.Apis
{
    public class CommentApi
    {
        private readonly WeixinMpApi _api;

        protected string AccessToken => _api.Token?.AccessToken;

        protected ILogger Logger => _api.Logger;

        protected IHttpService HttpService => _api.HttpService;

        protected WeixinServerHostConfig ServerHostConfig => _api.ServerHostConfig;

        public CommentApi(WeixinMpApi api)
        {
            _api = api;
        }

        /// <summary>
        ///  打开已群发文章评论
        /// </summary>
        /// <remarks>
        ///  <![CDATA[https://mp.weixin.qq.com/wiki?t=resource/res_main&id=mp1494572718_WzHIY]]>
        /// </remarks>
        public async Task<JsonResultModel> OpenAsync(CommentOpenCloseRequestModel model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));

            string url = $"{ServerHostConfig.DefaultApiHost}/cgi-bin/cgi-bin/comment/open?access_token={_api.Token?.AccessToken}";

            return (await HttpService.PostAsync<JsonResultModel>(url, model)).Data;
        }

        /// <summary>
        ///  关闭已群发文章评论
        /// </summary>
        /// <remarks>
        ///  <![CDATA[https://mp.weixin.qq.com/wiki?t=resource/res_main&id=mp1494572718_WzHIY]]>
        /// </remarks>
        public async Task<JsonResultModel> CloseAsync(CommentOpenCloseRequestModel model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));

            string url = $"{ServerHostConfig.DefaultApiHost}/cgi-bin/cgi-bin/comment/close?access_token={_api.Token?.AccessToken}";

            return (await HttpService.PostAsync<JsonResultModel>(url, model)).Data;
        }

        /// <summary>
        ///  查看指定文章的评论数据
        /// </summary>
        /// <remarks>
        ///  <![CDATA[https://mp.weixin.qq.com/wiki?t=resource/res_main&id=mp1494572718_WzHIY]]>
        /// </remarks>
        public async Task<CommentListResultModel> ListAsync(CommentListRequestModel model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));

            string url = $"{ServerHostConfig.DefaultApiHost}/cgi-bin/cgi-bin/comment/list?access_token={_api.Token?.AccessToken}";

            return (await HttpService.PostAsync<CommentListResultModel>(url, model)).Data;
        }

        /// <summary>
        ///  将评论标记精选
        /// </summary>
        /// <remarks>
        ///  <![CDATA[https://mp.weixin.qq.com/wiki?t=resource/res_main&id=mp1494572718_WzHIY]]>
        /// </remarks>
        public async Task<JsonResultModel> MarkElectAsync(CommentUpdateElectRequestModel model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));

            string url = $"{ServerHostConfig.DefaultApiHost}/cgi-bin/cgi-bin/comment/markelect?access_token={_api.Token?.AccessToken}";

            return (await HttpService.PostAsync<JsonResultModel>(url, model)).Data;
        }

        /// <summary>
        ///  将评论取消精选
        /// </summary>
        /// <remarks>
        ///  <![CDATA[https://mp.weixin.qq.com/wiki?t=resource/res_main&id=mp1494572718_WzHIY]]>
        /// </remarks>
        public async Task<JsonResultModel> UnMarkElectAsync(CommentUpdateElectRequestModel model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));

            string url = $"{ServerHostConfig.DefaultApiHost}/cgi-bin/cgi-bin/comment/unmarkelect?access_token={_api.Token?.AccessToken}";

            return (await HttpService.PostAsync<JsonResultModel>(url, model)).Data;
        }

        /// <summary>
        ///  删除评论
        /// </summary>
        /// <remarks>
        ///  <![CDATA[https://mp.weixin.qq.com/wiki?t=resource/res_main&id=mp1494572718_WzHIY]]>
        /// </remarks>
        public async Task<JsonResultModel> DeleteAsync(CommentDeleteRequestModel model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));

            string url = $"{ServerHostConfig.DefaultApiHost}/cgi-bin/cgi-bin/comment/delete?access_token={_api.Token?.AccessToken}";

            return (await HttpService.PostAsync<JsonResultModel>(url, model)).Data;
        }

        /// <summary>
        ///  回复评论
        /// </summary>
        /// <remarks>
        ///  <![CDATA[https://mp.weixin.qq.com/wiki?t=resource/res_main&id=mp1494572718_WzHIY]]>
        /// </remarks>
        public async Task<JsonResultModel> ReplyAsync(CommentReplyRequestModel model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));

            string url = $"{ServerHostConfig.DefaultApiHost}/cgi-bin/cgi-bin/comment/reply/add?access_token={_api.Token?.AccessToken}";

            return (await HttpService.PostAsync<JsonResultModel>(url, model)).Data;
        }

        /// <summary>
        ///  删除回复
        /// </summary>
        /// <remarks>
        ///  <![CDATA[https://mp.weixin.qq.com/wiki?t=resource/res_main&id=mp1494572718_WzHIY]]>
        /// </remarks>
        public async Task<JsonResultModel> ReplyDeleteAsync(CommentReplyDeleteRequestModel model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));

            string url = $"{ServerHostConfig.DefaultApiHost}/cgi-bin/cgi-bin/comment/reply/delete?access_token={_api.Token?.AccessToken}";

            return (await HttpService.PostAsync<JsonResultModel>(url, model)).Data;
        }
    }
}
