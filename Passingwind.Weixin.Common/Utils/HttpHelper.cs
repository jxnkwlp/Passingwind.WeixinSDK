//using Newtonsoft.Json;
//using Passingwind.Weixin.Logger;
//using Passingwind.Weixin.Models;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net.Http;
//using System.Text;
//using System.Threading.Tasks;

//namespace Passingwind.Weixin.Common.Utils
//{
//    /// <summary>
//    ///  HttpHelper
//    /// </summary>
//    [Obsolete]
//    public class HttpHelper
//    {
//        static HttpClient _httpClient = new HttpClient() { Timeout = TimeSpan.FromSeconds(30) };

//        /// <summary>
//        ///  Get
//        /// </summary> 
//        public static async Task<HttpResponse> GetAsync(string url)
//        {
//            HttpResponse result = new HttpResponse();

//            try
//            {
//                var response = await _httpClient.GetAsync(url);

//                response.EnsureSuccessStatusCode();

//                result.HttpStatusCode = (int)response.StatusCode;
//                result.ContentType = response.Content.Headers.ContentType?.ToString();
//                result.ContentDisposition = response.Content.Headers.ContentDisposition?.ToString();

//                result.Raw = await response.Content.ReadAsByteArrayAsync();

//                LoggerManager.GetLogger().Info("Http", $"request url {url} success. response");
//                LoggerManager.GetLogger().Info("Http", result.RawString);
//            }
//            catch (Exception ex)
//            {
//                LoggerManager.GetLogger().Error("Http", ex, $"request url {url} failed.");
//                result.Exception = ex;
//            }

//            return result;
//        }

//        /// <summary>
//        ///  Get
//        /// </summary> 
//        public static async Task<HttpResponse<T>> GetAsync<T>(string url) where T : JsonResultModel
//        {
//            HttpResponse result = await GetAsync(url);

//            if (result.Success && !string.IsNullOrEmpty(result.RawString))
//            {
//                return result.Load(result.RawString.ToJsonResultModel<T>());
//            }

//            return result.Load(default(T));
//        }

//        /// <summary>
//        ///  Post
//        /// </summary> 
//        public static async Task<HttpResponse> PostAsync(string url, string content = null)
//        {
//            var result = new HttpResponse();

//            try
//            {
//                var postContent = new StringContent(content ?? string.Empty, Encoding.UTF8);
//                var response = await _httpClient.PostAsync(url, postContent);

//                response.EnsureSuccessStatusCode();

//                result.HttpStatusCode = (int)response.StatusCode;
//                result.ContentType = response.Content.Headers.ContentType?.ToString();
//                result.ContentDisposition = response.Content.Headers.ContentDisposition?.ToString();

//                result.Raw = await response.Content.ReadAsByteArrayAsync();

//                LoggerManager.GetLogger().Info($"request url {url} success. response");
//                LoggerManager.GetLogger().Info(result.RawString);
//            }
//            catch (Exception ex)
//            {
//                result.Exception = ex;
//            }

//            return result;
//        }

//        /// <summary>
//        ///  Post
//        /// </summary> 
//        public static async Task<HttpResponse> PostAsync(string url, IList<KeyValuePair<string, object>> formData)
//        {
//            var result = new HttpResponse();

//            try
//            {
//                HttpResponseMessage httpResponse;

//                if (formData.Any(t => t.Value.GetType() == typeof(UploadFileModel)))
//                {
//                    string boundary = Guid.NewGuid().ToString();
//                    var content = new MultipartFormDataContent(boundary);
//                    content.Headers.Remove("Content-Type");
//                    content.Headers.TryAddWithoutValidation("Content-Type", $"multipart/form-data; boundary={boundary}");

//                    foreach (var item in formData)
//                    {
//                        if (item.Value == null)
//                            continue;

//                        if (item.Value.GetType() == typeof(UploadFileModel))
//                        {
//                            var file = (UploadFileModel)item.Value;
//                            var d = new ByteArrayContent(file.Data);

//                            d.Headers.Remove("Content-Disposition");
//                            d.Headers.TryAddWithoutValidation("Content-Disposition", $"form-data;name=\"media\"; filename=\"{file.FileName}\";filelength=\"{file.Data.Length}\""); // ºÍÎ¢ÐÅ¼æÈÝ

//                            content.Add(d, item.Key, file.FileName);
//                        }
//                        else if (item.Value.GetType().IsEnum)
//                        {
//                            content.Add(new StringContent(item.Value.ToString().ToLower(), Encoding.UTF8), item.Key);
//                        }
//                        else if (item.Value.GetType() == typeof(MediaDescription))
//                        {
//                            content.Add(new StringContent(JsonConvert.SerializeObject(item.Value, JsonSerializerConfig.SerializerSettings), Encoding.UTF8), item.Key);
//                        }
//                        else
//                        {
//                            content.Add(new StringContent(item.Value.ToString(), Encoding.UTF8), item.Key);
//                        }
//                    }

//                    httpResponse = await _httpClient.PostAsync(url, content);
//                }
//                else
//                {
//                    var content = new FormUrlEncodedContent(formData.Where(t => t.Value != null).Select(t => new KeyValuePair<string, string>(t.Key, t.Value.ToString())));

//                    httpResponse = await _httpClient.PostAsync(url, content);
//                }

//                httpResponse.EnsureSuccessStatusCode();

//                result.HttpStatusCode = (int)httpResponse.StatusCode;
//                result.ContentType = httpResponse.Content.Headers.ContentType?.ToString();
//                result.ContentDisposition = httpResponse.Content.Headers.ContentDisposition?.ToString();

//                result.Raw = await httpResponse.Content.ReadAsByteArrayAsync();

//                LoggerManager.GetLogger().Info($"request url {url} success. response");
//                LoggerManager.GetLogger().Info(result.RawString);
//            }
//            catch (Exception ex)
//            {
//                result.Exception = ex;
//            }

//            return result;
//        }

//        /// <summary>
//        ///  Post
//        /// </summary> 
//        public static async Task<HttpResponse<T>> PostAsync<T>(string url, string content = null) where T : JsonResultModel
//        {
//            HttpResponse result = await PostAsync(url, content);

//            if (result.Success && !string.IsNullOrEmpty(result.RawString))
//            {
//                return result.Load(result.RawString.ToJsonResultModel<T>());
//            }

//            return result.Load(default(T));
//        }

//        /// <summary>
//        ///  Post
//        /// </summary> 
//        public static async Task<HttpResponse> PostAsync<TRequestData>(
//            string url,
//            TRequestData requestData,
//            PostDataType dataType)
//            where TRequestData : class
//        {
//            if (dataType == PostDataType.Json)
//            {
//                string content = JsonConvert.SerializeObject(requestData, JsonSerializerConfig.SerializerSettings);

//                return await PostAsync(url, content);
//            }
//            else if (dataType == PostDataType.FormData)
//            {
//                var list = new List<KeyValuePair<string, object>>();
//                foreach (var item in requestData.GetType().GetProperties())
//                {
//                    list.Add(new KeyValuePair<string, object>(item.Name.ToLower(), item.GetValue(requestData, null)));
//                }

//                return await PostAsync(url, list);
//            }
//            else
//            {
//                throw new NotImplementedException();
//            }
//        }

//        /// <summary>
//        ///  Post
//        /// </summary> 
//        public static async Task<HttpResponse<TResultData>> PostAsync<TResultData>(
//            string url,
//            object requestData,
//            PostDataType dataType = PostDataType.Json)
//            where TResultData : JsonResultModel
//        {
//            HttpResponse result = await PostAsync(url, requestData, dataType);

//            if (result.Success && !string.IsNullOrEmpty(result.RawString))
//            {
//                return result.Load(result.RawString.ToJsonResultModel<TResultData>());
//            }

//            return result.Load(default(TResultData));
//        }

//        /// <summary>
//        ///  Post
//        /// </summary> 
//        public static async Task<HttpResponse<TResultData>> PostAsync<TRequestData, TResultData>(
//            string url,
//            TRequestData requestData,
//            PostDataType dataType = PostDataType.Json)
//            where TRequestData : class
//             where TResultData : JsonResultModel
//        {
//            HttpResponse result = await PostAsync(url, requestData, dataType);

//            if (result.Success && !string.IsNullOrEmpty(result.RawString))
//            {
//                return result.Load(result.RawString.ToJsonResultModel<TResultData>());
//            }

//            return result.Load(default(TResultData));
//        }

//    }

    
//}
