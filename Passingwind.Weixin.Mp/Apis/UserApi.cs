using Passingwind.Weixin.Common;
using Passingwind.Weixin.Common.Utils;
using Passingwind.Weixin.Models;
using Passingwind.Weixin.Mp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Passingwind.Weixin.Mp.Apis
{
    /// <summary>
    ///  UserApi
    /// </summary>
    public class UserApi
    {
        private readonly WeixinMpApi _api;

        protected string AccessToken => _api.Token?.AccessToken;

        public UserApi(WeixinMpApi api)
        {
            _api = api;
        }

        #region 设置用户备注名 

        /// <summary>
        ///  设置用户备注名
        /// </summary> 
        /// <param name="openId">普通用户的标识，对当前公众号唯一</param>
        /// <param name="remark">新的备注名，长度必须小于30字符</param>
        /// <remarks>
        /// <![CDATA[https://mp.weixin.qq.com/wiki?t=resource/res_main&id=mp1421140838]]>
        /// </remarks>
        public async Task<JsonResultModel> UpdateRemarkAsync(string openId, string remark)
        {
            string url = $"{ServerUrl.MPAPI_URL}/user/info/updateremark?access_token={_api.Token?.AccessToken}";

            return (await HttpHelper.PostAsync<UpdateRemarkRequestModel, JsonResultModel>(url, new UpdateRemarkRequestModel() { Remark = remark, Openid = openId }, PostDataFormat.Json)).Data;
        }

        #endregion

        #region 获取用户基本信息

        /// <summary>
        ///  获取用户基本信息（包括UnionID机制）
        /// </summary>
        /// <param name="openId">普通用户的标识，对当前公众号唯一</param>
        /// <param name="lang">返回国家地区语言版本，zh_CN 简体，zh_TW 繁体，en 英语</param>
        /// <remarks>
        ///  <![CDATA[https://mp.weixin.qq.com/wiki?t=resource/res_main&id=mp1421140839]]>
        /// </remarks>
        public async Task<UserInfoResultModel> GetInfoAsync(UserInfoRequestModel model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            string url = $"{ServerUrl.MPAPI_URL}/user/info?access_token={_api.Token?.AccessToken}&openid={model.Openid}&lang={model.Lang}";

            return (await HttpHelper.GetAsync<UserInfoResultModel>(url)).Data;
        }

        /// <summary>
        ///  批量获取用户基本信息
        /// </summary> 
        /// <remarks>
        ///  <![CDATA[https://mp.weixin.qq.com/wiki?t=resource/res_main&id=mp1421140839]]>
        /// </remarks>
        public async Task<BatchGetUserInfoResultModel> BatchGetInfoAsync(params UserInfoRequestModel[] models)
        {
            if (models == null)
            {
                throw new ArgumentNullException(nameof(models));
            }

            if (models.Length == 0)
                return null;

            string url = $"{ServerUrl.MPAPI_URL}/user/info/batchget?access_token={_api.Token?.AccessToken}";

            var request = new
            {
                user_list = models,
            };

            return (await HttpHelper.PostAsync<BatchGetUserInfoResultModel>(url, request, PostDataFormat.Json)).Data;
        }

        #endregion

        #region 获取用户列表

        /// <summary>
        ///  获取用户列表
        /// </summary>
        /// <param name="next_openid">第一个拉取的OPENID，不填默认从头开始拉取</param> 
        /// <remarks>
        ///   <![CDATA[https://mp.weixin.qq.com/wiki?t=resource/res_main&id=mp1421140840]]>
        /// </remarks>
        public async Task<UserListResultModel> GetListAsync(string next_openid = null)
        {
            string url = $"{ServerUrl.MPAPI_URL}/user/get?access_token={_api.Token?.AccessToken}&next_openid={next_openid}";

            return (await HttpHelper.GetAsync<UserListResultModel>(url)).Data;
        }

        #endregion

        #region 用户标签管理

        /// <summary>
        ///  创建标签
        /// </summary> 
        /// <example>
        ///  <![CDATA[https://mp.weixin.qq.com/wiki?t=resource/res_main&id=mp1421140837 ]]>
        /// </example>
        public async Task<TagCreaterResultModel> TagsCreate(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("message", nameof(name));
            }

            string url = $"{ServerUrl.MPAPI_URL}/tags/create?access_token={AccessToken}";

            var data = new { tag = new { name = name } };

            return (await HttpHelper.PostAsync<TagCreaterResultModel>(url, data)).Data;
        }

        /// <summary>
        ///  获取公众号已创建的标签
        /// </summary> 
        /// <example>
        ///  <![CDATA[https://mp.weixin.qq.com/wiki?t=resource/res_main&id=mp1421140837 ]]>
        /// </example>
        public async Task<TagListResultModel> GetTags()
        {
            string url = $"{ServerUrl.MPAPI_URL}/tags/get?access_token={AccessToken}";

            return (await HttpHelper.GetAsync<TagListResultModel>(url)).Data;
        }

        /// <summary>
        ///  编辑标签
        /// </summary> 
        /// <example>
        ///  <![CDATA[https://mp.weixin.qq.com/wiki?t=resource/res_main&id=mp1421140837  ]]>
        /// </example>
        public async Task<JsonResultModel> TagsUpdate(UserTagModel tag)
        {
            if (tag == null)
            {
                throw new ArgumentNullException(nameof(tag));
            }

            string url = $"{ServerUrl.MPAPI_URL}/tags/update?access_token={AccessToken}";

            var data = new { tag = tag };

            return (await HttpHelper.PostAsync<JsonResultModel>(url, data)).Data;
        }

        /// <summary>
        ///  删除标签
        /// </summary>  
        /// <example>
        ///  <![CDATA[https://mp.weixin.qq.com/wiki?t=resource/res_main&id=mp1421140837  ]]>
        /// </example>
        public async Task<JsonResultModel> TagsDelete(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException(nameof(id));
            }

            string url = $"{ServerUrl.MPAPI_URL}/tags/delete?access_token={AccessToken}";

            var data = new { tag = new { id = id } };

            return (await HttpHelper.PostAsync<JsonResultModel>(url, data)).Data;
        }

        /// <summary>
        ///  获取标签下粉丝列表
        /// </summary> 
        /// <example>
        ///  <![CDATA[https://mp.weixin.qq.com/wiki?t=resource/res_main&id=mp1421140837  ]]>
        /// </example>
        public async Task<TagsGetResultModel> GetTag(int id, string nextOpenid = null)
        {
            if (id <= 0)
            {
                throw new ArgumentException(nameof(id));
            }

            string url = $"{ServerUrl.MPAPI_URL}/user/tag/get?access_token={AccessToken}";

            var data = new { tagid = id, next_openid = nextOpenid };

            return (await HttpHelper.PostAsync<TagsGetResultModel>(url, data)).Data;
        }

        /// <summary>
        ///  批量为用户打标签
        /// </summary> 
        /// <example>
        ///  <![CDATA[https://mp.weixin.qq.com/wiki?t=resource/res_main&id=mp1421140837  ]]>
        /// </example>
        public async Task<JsonResultModel> BatchTags(int id, params string[] openIds)
        {
            if (id <= 0)
            {
                throw new ArgumentException(nameof(id));
            }

            if (openIds == null)
            {
                throw new ArgumentNullException(nameof(openIds));
            }

            string url = $"{ServerUrl.MPAPI_URL}/tags/members/batchtagging?access_token={AccessToken}";

            var data = new { openid_list = openIds, tagid = id };

            return (await HttpHelper.PostAsync<JsonResultModel>(url, data)).Data;
        }

        /// <summary>
        ///  批量为用户取消标签
        /// </summary> 
        /// <example>
        ///  <![CDATA[https://mp.weixin.qq.com/wiki?t=resource/res_main&id=mp1421140837 ]]>
        /// </example>
        public async Task<JsonResultModel> BatchUnTags(int id, params string[] openIds)
        {
            if (id <= 0)
            {
                throw new ArgumentException(nameof(id));
            }

            if (openIds == null)
            {
                throw new ArgumentNullException(nameof(openIds));
            }

            string url = $"{ServerUrl.MPAPI_URL}/tags/members/batchuntagging?access_token={AccessToken}";

            var data = new { openid_list = openIds, tagid = id };

            return (await HttpHelper.PostAsync<JsonResultModel>(url, data)).Data;
        }

        /// <summary>
        ///  获取用户身上的标签列表
        /// </summary> 
        /// <example>
        ///  <![CDATA[https://mp.weixin.qq.com/wiki?t=resource/res_main&id=mp1421140837 ]]>
        /// </example>
        public async Task<MemberTagsResultModel> GetMemberTags(string openId)
        {
            if (string.IsNullOrWhiteSpace(openId))
            {
                throw new ArgumentException("message", nameof(openId));
            }

            string url = $"{ServerUrl.MPAPI_URL}/tags/getidlist?access_token={AccessToken}";

            var data = new { openid = openId };

            return (await HttpHelper.PostAsync<MemberTagsResultModel>(url, data)).Data;
        }

        #endregion

        #region 黑名单管理

        /// <summary>
        ///  获取公众号的黑名单列表
        /// </summary> 
        /// <example>
        ///  <![CDATA[https://mp.weixin.qq.com/wiki?t=resource/res_main&id=mp1471422259_pJMWA]]>
        /// </example>
        public async Task<UserBlackListResultModel> GetBlackList(string beginOpenid = null)
        {
            string url = $"{ServerUrl.MPAPI_URL}/tags/members/getblacklist?access_token={AccessToken}";

            return (await HttpHelper.PostAsync<UserBlackListResultModel>(url, new { begin_openid = beginOpenid })).Data;
        }

        #endregion
    }
}
