using Passingwind.Weixin.Common;
using Passingwind.Weixin.Http;
using Passingwind.Weixin.Logger;
using Passingwind.Weixin.Models;
using Passingwind.Weixin.MP.Models.Media;
using System;
using System.Threading.Tasks;

namespace Passingwind.Weixin.MP.Apis
{
    /// <summary>
    ///  素材管理
    /// </summary>
    public class MediaApi
    {
        private readonly WeixinMpApi _api;

        protected string AccessToken => _api.Token?.AccessToken;

        protected ILogger Logger => _api.Logger;

        protected IHttpService HttpService => _api.HttpService;

        protected WeixinServerHostConfig ServerHostConfig => _api.ServerHostConfig;

        public MediaApi(WeixinMpApi api)
        {
            _api = api;
        }

        #region 临时素材

        /// <summary>
        ///  新增临时素材
        /// </summary>
        /// <remarks>
        /// <![CDATA[https://mp.weixin.qq.com/wiki?t=resource/res_main&id=mp1444738726]]>
        /// </remarks>
        public async Task<MediaUploadResultModel> UploadAsync(MediaUploadRequestModel upload)
        {
            string url = $"{ServerHostConfig.DefaultApiHost}/cgi-bin/media/upload?access_token={_api.Token?.AccessToken}&type={upload.Type.ToString().ToLower()}";

            return (await HttpService.PostAsync<MediaUploadRequestModel, MediaUploadResultModel>(url, upload, PostDataType.FormData)).Data;
        }

        /// <summary>
        ///  获取临时素材
        /// </summary>
        /// <remarks>
        /// <![CDATA[https://mp.weixin.qq.com/wiki?t=resource/res_main&id=mp1444738726]]>
        /// </remarks>
        public async Task<GetMediaResultModel> GetAsync(string mediaId)
        {
            if (string.IsNullOrWhiteSpace(mediaId))
            {
                throw new ArgumentException("message", nameof(mediaId));
            }

            string url = $"{ServerHostConfig.DefaultApiHost}/cgi-bin/media/get?access_token={_api.Token?.AccessToken}&media_id={mediaId}";

            var response = await HttpService.GetAsync(url);
            if (response.Success)
            {
                if (response.ContentDisposition?.StartsWith("attachment") == true)
                {
                    return new GetMediaResultModel()
                    {
                        Data = response.Raw,
                    };
                }
                else
                {
                    return response.RawString.ToJsonResultModel<GetMediaResultModel>();
                }
            }
            return null;
        }

        /// <summary>
        ///  高清语音素材获取接口
        /// </summary>
        /// <remarks>
        ///  公众号可以使用本接口获取从JSSDK的uploadVoice接口上传的临时语音素材，格式为speex，16K采样率。该音频比上文的临时素材获取接口（格式为amr，8K采样率）更加清晰，适合用作语音识别等对音质要求较高的业务。 <![CDATA[https://mp.weixin.qq.com/wiki?t=resource/res_main&id=mp1444738726]]>
        /// </remarks>
        public async Task<GetJsSDKMediaResultModel> GetJsSDKAsync(string mediaId)
        {
            if (string.IsNullOrWhiteSpace(mediaId))
            {
                throw new ArgumentException("message", nameof(mediaId));
            }

            string url = $"{ServerHostConfig.DefaultApiHost}/cgi-bin/media/get/jssdk?access_token={_api.Token?.AccessToken}&media_id={mediaId}";

            var response = await HttpService.GetAsync(url);
            if (response.Success)
            {
                if (response.ContentDisposition?.StartsWith("attachment") == true)
                {
                    return new GetJsSDKMediaResultModel()
                    {
                        Data = response.Raw,
                    };
                }
                else
                {
                    return response.RawString.ToJsonResultModel<GetJsSDKMediaResultModel>();
                }
            }
            return null;
        }

        #endregion

        #region 永久素材

        /// <summary>
        ///  新增永久图文素材
        /// </summary>
        /// <remarks>
        /// <![CDATA[https://mp.weixin.qq.com/wiki?t=resource/res_main&id=mp1444738729]]>
        /// </remarks>
        public async Task<AddMaterialNewsResultModel> AddMaterialNews(params AddMaterialNewsArticleItemRequestModel[] model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));

            string url = $"{ServerHostConfig.DefaultApiHost}/cgi-bin/material/add_news?access_token={_api.Token?.AccessToken}";

            var data = new { articles = model };

            return (await HttpService.PostAsync<AddMaterialNewsResultModel>(url, data)).Data;
        }

        /// <summary>
        ///  新增其他类型永久素材
        /// </summary>
        /// <remarks>
        /// <![CDATA[https://mp.weixin.qq.com/wiki?t=resource/res_main&id=mp1444738729]]>
        /// </remarks>
        public async Task<AddMaterialResultModel> AddMaterial(AddMaterialRequestModel model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));

            string url = $"{ServerHostConfig.DefaultApiHost}/cgi-bin/material/add_material?access_token={_api.Token?.AccessToken}&type={model.Type.ToString().ToLower()}";

            return (await HttpService.PostAsync<AddMaterialRequestModel, AddMaterialResultModel>(url, model, PostDataType.FormData)).Data;
        }

        /// <summary>
        ///  上传图文消息内的图片获取URL
        /// </summary>
        /// <remarks>
        /// <![CDATA[https://mp.weixin.qq.com/wiki?t=resource/res_main&id=mp1444738729]]>
        /// </remarks>
        public async Task<UploadImageResultModel> UploadImage(UploadFileModel file)
        {
            if (file == null)
                throw new ArgumentNullException(nameof(file));

            string url = $"{ServerHostConfig.DefaultApiHost}/cgi-bin/media/uploadimg?access_token={_api.Token?.AccessToken} ";

            return (await HttpService.PostAsync<UploadImageResultModel>(url, new { media = file }, PostDataType.FormData)).Data;
        }


        /// <summary>
        ///  获取永久素材
        /// </summary>
        /// <remarks>
        /// <![CDATA[https://mp.weixin.qq.com/wiki?t=resource/res_main&id=mp1444738729]]>
        /// </remarks>
        public async Task<GetMaterialResultModel> GetMaterial(string mediaId)
        {
            if (string.IsNullOrWhiteSpace(mediaId))
            {
                throw new ArgumentException("message", nameof(mediaId));
            }

            string url = $"{ServerHostConfig.DefaultApiHost}/cgi-bin/material/get_material?access_token={_api.Token?.AccessToken} ";

            var data = new { media_id = mediaId };

            var response = await HttpService.PostAsync<GetMaterialResultModel>(url, data);
            if (response.Success)
            {
                if (response.ContentDisposition?.StartsWith("attachment") == true)
                {
                    return new GetMaterialResultModel()
                    {
                        FileData = response.Raw,
                    };
                }
                else
                {
                    return response.RawString.ToJsonResultModel<GetMaterialResultModel>();
                }
            }

            return null;
        }

        /// <summary>
        ///  删除永久素材
        /// </summary>
        /// <remarks>
        /// <![CDATA[https://mp.weixin.qq.com/wiki?t=resource/res_main&id=mp1444738731]]>
        /// </remarks>
        public async Task<JsonResultModel> DeleteMaterial(string mediaId)
        {
            string url = $"{ServerHostConfig.DefaultApiHost}/cgi-bin/material/del_material?access_token={_api.Token?.AccessToken} ";

            var data = new { media_id = mediaId };

            return (await HttpService.PostAsync<JsonResultModel>(url, data)).Data;
        }

        /// <summary>
        ///  修改永久图文素材
        /// </summary>
        /// <remarks>
        /// <![CDATA[https://mp.weixin.qq.com/wiki?t=resource/res_main&id=mp1444738732]]>
        /// </remarks>
        public async Task<JsonResultModel> UpdateNews(UpdateNewsRequestModel model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));

            string url = $"{ServerHostConfig.DefaultApiHost}/cgi-bin/material/update_news?access_token={_api.Token?.AccessToken} ";

            return (await HttpService.PostAsync<JsonResultModel>(url, model)).Data;
        }

        /// <summary>
        ///  获取素材总数
        /// </summary>
        /// <remarks>
        /// <![CDATA[https://mp.weixin.qq.com/wiki?t=resource/res_main&id=mp1444738733]]>
        /// </remarks>
        public async Task<GetMaterialCountResultModel> GetMaterialCount()
        {
            string url = $"{ServerHostConfig.DefaultApiHost}/cgi-bin/material/get_materialcount?access_token={_api.Token?.AccessToken} ";

            return (await HttpService.GetAsync<GetMaterialCountResultModel>(url)).Data;
        }


        /// <summary>
        ///  获取素材列表
        /// </summary>
        /// <remarks>
        /// <![CDATA[https://mp.weixin.qq.com/wiki?t=resource/res_main&id=mp1444738734]]>
        /// </remarks>
        public async Task<BatchGetMaterialResultModel> BatchGetMaterial(BatchGetMaterialRequestModel model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));

            string url = $"{ServerHostConfig.DefaultApiHost}/cgi-bin/material/batchget_material?access_token={_api.Token?.AccessToken} ";

            return (await HttpService.PostAsync<BatchGetMaterialResultModel>(url, model)).Data;
        }

        #endregion
    }
}
