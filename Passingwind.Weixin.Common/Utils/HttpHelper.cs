using Newtonsoft.Json;
using Passingwind.Weixin.Logger;
using Passingwind.Weixin.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Passingwind.Weixin.Common.Utils
{
    /// <summary>
    ///  HttpHelper
    /// </summary>
    public class HttpHelper
    {
        static HttpClient _httpClient = new HttpClient() { Timeout = TimeSpan.FromSeconds(30) };

        /// <summary>
        ///  Get
        /// </summary> 
        public static async Task<HttpResponse> GetAsync(string url)
        {
            HttpResponse result = new HttpResponse();

            try
            {
                var response = await _httpClient.GetAsync(url);

                response.EnsureSuccessStatusCode();

                result.HttpStatusCode = (int)response.StatusCode;
                result.ContentType = response.Content.Headers.ContentType?.ToString();
                result.Raw = await response.Content.ReadAsByteArrayAsync();

                LoggerManager.GetLogger().Info($"request url {url} success. response");
                LoggerManager.GetLogger().Info(result.RawString);
            }
            catch (Exception ex)
            {
                LoggerManager.GetLogger().Error(ex, $"request url {url} failed.");
                result.Exception = ex;
            }

            return result;
        }

        /// <summary>
        ///  Get
        /// </summary> 
        public static async Task<HttpResponse<T>> GetAsync<T>(string url) where T : JsonResultModel
        {
            HttpResponse result = await GetAsync(url);

            if (result.Success && !string.IsNullOrEmpty(result.RawString))
            {
                return result.Load(result.RawString.ToJsonResultModel<T>());
            }

            return result.Load(default(T));
        }

        /// <summary>
        ///  Post
        /// </summary> 
        public static async Task<HttpResponse> PostAsync(string url, string content = null)
        {
            var result = new HttpResponse();

            try
            {
                var postContent = new StringContent(content ?? string.Empty, Encoding.UTF8);
                var response = await _httpClient.PostAsync(url, postContent);

                response.EnsureSuccessStatusCode();

                result.HttpStatusCode = (int)response.StatusCode;
                result.ContentType = response.Content.Headers.ContentType?.ToString();
                result.Raw = await response.Content.ReadAsByteArrayAsync();

                LoggerManager.GetLogger().Info($"request url {url} success. response");
                LoggerManager.GetLogger().Info(result.RawString);
            }
            catch (Exception ex)
            {
                result.Exception = ex;
            }

            return result;
        }

        /// <summary>
        ///  Post
        /// </summary> 
        public static async Task<HttpResponse<T>> PostAsync<T>(string url, string content = null) where T : JsonResultModel
        {
            HttpResponse result = await PostAsync(url, content);

            if (result.Success && !string.IsNullOrEmpty(result.RawString))
            {
                return result.Load(result.RawString.ToJsonResultModel<T>());
            }

            return result.Load(default(T));
        }

        /// <summary>
        ///  Post
        /// </summary> 
        public static async Task<HttpResponse> PostAsync<TRequestData>(
            string url,
            TRequestData requestData,
            PostDataFormat format)
            where TRequestData : class
        {
            string content = string.Empty;

            if (format == PostDataFormat.Json)
            {
                content = Newtonsoft.Json.JsonConvert.SerializeObject(requestData, JsonSerializerConfig.SerializerSettings);
            }

            return await PostAsync(url, content);
        }

        /// <summary>
        ///  Post
        /// </summary> 
        public static async Task<HttpResponse<TResultData>> PostAsync<TResultData>(
            string url,
            object requestData,
            PostDataFormat format = PostDataFormat.Json)
            where TResultData : JsonResultModel
        {
            HttpResponse result = await PostAsync(url, requestData, format);

            if (result.Success && !string.IsNullOrEmpty(result.RawString))
            {
                return result.Load(result.RawString.ToJsonResultModel<TResultData>());
            }

            return result.Load(default(TResultData));
        }

        /// <summary>
        ///  Post
        /// </summary> 
        public static async Task<HttpResponse<TResultData>> PostAsync<TRequestData, TResultData>(
            string url,
            TRequestData requestData,
            PostDataFormat format = PostDataFormat.Json)
            where TRequestData : class
             where TResultData : JsonResultModel
        {
            HttpResponse result = await PostAsync(url, requestData, format);

            if (result.Success && !string.IsNullOrEmpty(result.RawString))
            {
                return result.Load(result.RawString.ToJsonResultModel<TResultData>());
            }

            return result.Load(default(TResultData));
        }

    }

    public enum PostDataFormat
    {
        Json,
        Xml
    }

    public class HttpResponse
    {
        public byte[] Raw { get; set; }

        public int HttpStatusCode { get; set; }

        public string ContentType { get; set; }

        public Exception Exception { get; set; }

        public string RawString
        {
            get
            {
                if (Raw == null)
                    return null;

                return Encoding.UTF8.GetString(Raw);
            }
        }

        public bool Success => HttpStatusCode == 200;

        public HttpResponse<T> Load<T>(T data)
        {
            return new HttpResponse<T>()
            {
                ContentType = ContentType,
                Exception = Exception,
                HttpStatusCode = HttpStatusCode,
                Raw = Raw,

                Data = data,
            };
        }
    }

    public class HttpResponse<T> : HttpResponse
    {
        public T Data { get; set; }
    }
}
