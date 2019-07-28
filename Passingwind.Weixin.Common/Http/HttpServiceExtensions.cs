using Newtonsoft.Json;
using Passingwind.Weixin.Common;
using Passingwind.Weixin.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Passingwind.Weixin.Http
{
    public static class HttpServiceExtensions
    {
        /// <summary>
        ///  send get requeste
        /// </summary> 
        public static async Task<HttpResponse<T>> GetAsync<T>(this IHttpService http, string url) where T : JsonResultModel
        {
            HttpResponse result = await http.GetAsync(url);

            if (result.Success && !string.IsNullOrEmpty(result.RawString))
            {
                return result.Load(result.RawString.ToJsonResultModel<T>());
            }

            return result.Load(default(T));
        }

        /// <summary>
        ///  send post request 
        /// </summary> 
        public static async Task<HttpResponse<T>> PostAsync<T>(this IHttpService http, string url, string content = null) where T : JsonResultModel
        {
            HttpResponse result = await http.PostAsync(url, content);

            if (result.Success && !string.IsNullOrEmpty(result.RawString))
            {
                return result.Load(result.RawString.ToJsonResultModel<T>());
            }

            return result.Load(default(T));
        }

        /// <summary>
        ///  send post request 
        /// </summary>
        public static async Task<HttpResponse> PostAsync<TRequestData>(this IHttpService http,
            string url,
            TRequestData requestData,
            PostDataType dataType)
            where TRequestData : class
        {
            if (dataType == PostDataType.Json)
            {
                string content = JsonConvert.SerializeObject(requestData, JsonSerializerConfig.SerializerSettings);

                return await http.PostAsync(url, content);
            }
            else if (dataType == PostDataType.FormData)
            {
                var list = new List<KeyValuePair<string, object>>();
                foreach (var item in requestData.GetType().GetProperties())
                {
                    list.Add(new KeyValuePair<string, object>(item.Name.ToLower(), item.GetValue(requestData, null)));
                }

                return await http.PostAsync(url, list);
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        /// <summary>
        ///  send post request 
        /// </summary>
        public static async Task<HttpResponse<TResultData>> PostAsync<TResultData>(
            this IHttpService http,
            string url,
            object requestData,
            PostDataType dataType = PostDataType.Json)
            where TResultData : JsonResultModel
        {
            HttpResponse result = await http.PostAsync(url, requestData, dataType);

            if (result.Success && !string.IsNullOrEmpty(result.RawString))
            {
                return result.Load(result.RawString.ToJsonResultModel<TResultData>());
            }

            return result.Load(default(TResultData));
        }

        /// <summary>
        ///  send post request 
        /// </summary>
        public static async Task<HttpResponse<TResultData>> PostAsync<TRequestData, TResultData>(
            this IHttpService http,
            string url,
            TRequestData requestData,
            PostDataType dataType = PostDataType.Json)
            where TRequestData : class
             where TResultData : JsonResultModel
        {
            HttpResponse result = await http.PostAsync(url, requestData, dataType);

            if (result.Success && !string.IsNullOrEmpty(result.RawString))
            {
                return result.Load(result.RawString.ToJsonResultModel<TResultData>());
            }

            return result.Load(default(TResultData));
        }
    }
}
