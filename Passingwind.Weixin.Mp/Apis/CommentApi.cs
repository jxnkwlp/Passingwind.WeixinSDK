using Passingwind.Weixin.Common;
using Passingwind.Weixin.Common.Utils;
using Passingwind.Weixin.Models;
using Passingwind.Weixin.Mp.Models.Comments;
using System;
using System.Threading.Tasks;

namespace Passingwind.Weixin.Mp.Apis
{
    public class CommentApi
    {
        private readonly WeixinMpApi _api;

        protected string AccessToken => _api.Token?.AccessToken;

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

            string url = $"{ServerUrl.MP_API_URL}/comment/open?access_token={_api.Token?.AccessToken}";

            return (await HttpHelper.PostAsync<JsonResultModel>(url, model)).Data;
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

            string url = $"{ServerUrl.MP_API_URL}/comment/close?access_token={_api.Token?.AccessToken}";

            return (await HttpHelper.PostAsync<JsonResultModel>(url, model)).Data;
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

            string url = $"{ServerUrl.MP_API_URL}/comment/list?access_token={_api.Token?.AccessToken}";

            return (await HttpHelper.PostAsync<CommentListResultModel>(url, model)).Data;
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

            string url = $"{ServerUrl.MP_API_URL}/comment/markelect?access_token={_api.Token?.AccessToken}";

            return (await HttpHelper.PostAsync<JsonResultModel>(url, model)).Data;
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

            string url = $"{ServerUrl.MP_API_URL}/comment/unmarkelect?access_token={_api.Token?.AccessToken}";

            return (await HttpHelper.PostAsync<JsonResultModel>(url, model)).Data;
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

            string url = $"{ServerUrl.MP_API_URL}/comment/delete?access_token={_api.Token?.AccessToken}";

            return (await HttpHelper.PostAsync<JsonResultModel>(url, model)).Data;
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

            string url = $"{ServerUrl.MP_API_URL}/comment/reply/add?access_token={_api.Token?.AccessToken}";

            return (await HttpHelper.PostAsync<JsonResultModel>(url, model)).Data;
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

            string url = $"{ServerUrl.MP_API_URL}/comment/reply/delete?access_token={_api.Token?.AccessToken}";

            return (await HttpHelper.PostAsync<JsonResultModel>(url, model)).Data;
        }
    }
}
