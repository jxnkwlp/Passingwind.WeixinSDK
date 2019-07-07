using Newtonsoft.Json;
using Passingwind.Weixin.Logger;
using Passingwind.Weixin.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace Passingwind.Weixin.Http
{
    public class DefaultHttpService : IHttpService
    {
        static readonly HttpClient _httpClient = new HttpClient() { Timeout = TimeSpan.FromSeconds(30) };

        private readonly ILogger _logger;

        public DefaultHttpService(ILogger logger)
        {
            _logger = logger;
        }

        public async Task<HttpResponse> GetAsync(string url)
        {
            HttpResponse result = new HttpResponse();

            try
            {
                var response = await _httpClient.GetAsync(url);

                response.EnsureSuccessStatusCode();

                result.HttpStatusCode = (int)response.StatusCode;
                result.ContentType = response.Content.Headers.ContentType?.ToString();
                result.ContentDisposition = response.Content.Headers.ContentDisposition?.ToString();

                result.Raw = await response.Content.ReadAsByteArrayAsync();

                _logger.Info($"request url {url} success. response");
                _logger.Info(result.RawString);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"request url {url} failed.");
                result.Exception = ex;
            }

            return result;
        }

        public async Task<HttpResponse> PostAsync(string url, string content = null)
        {
            var result = new HttpResponse();

            try
            {
                var postContent = new StringContent(content ?? string.Empty, Encoding.UTF8);
                var response = await _httpClient.PostAsync(url, postContent);

                response.EnsureSuccessStatusCode();

                result.HttpStatusCode = (int)response.StatusCode;
                result.ContentType = response.Content.Headers.ContentType?.ToString();
                result.ContentDisposition = response.Content.Headers.ContentDisposition?.ToString();

                result.Raw = await response.Content.ReadAsByteArrayAsync();

                _logger.Info($"request url {url} success. response");
                _logger.Info(result.RawString);
            }
            catch (Exception ex)
            {
                result.Exception = ex;
            }

            return result;
        }

        public async Task<HttpResponse> PostAsync(string url, IList<KeyValuePair<string, object>> formData)
        {
            var result = new HttpResponse();

            try
            {
                HttpResponseMessage httpResponse;

                if (formData.Any(t => t.Value.GetType() == typeof(UploadFileModel)))
                {
                    string boundary = Guid.NewGuid().ToString();
                    var content = new MultipartFormDataContent(boundary);
                    content.Headers.Remove("Content-Type");
                    content.Headers.TryAddWithoutValidation("Content-Type", $"multipart/form-data; boundary={boundary}");

                    foreach (var item in formData)
                    {
                        if (item.Value == null)
                            continue;

                        if (item.Value.GetType() == typeof(UploadFileModel))
                        {
                            var file = (UploadFileModel)item.Value;
                            var d = new ByteArrayContent(file.Data);

                            d.Headers.Remove("Content-Disposition");
                            d.Headers.TryAddWithoutValidation("Content-Disposition", $"form-data;name=\"media\"; filename=\"{file.FileName}\";filelength=\"{file.Data.Length}\""); // 和微信兼容

                            content.Add(d, item.Key, file.FileName);
                        }
                        else if (item.Value.GetType().IsEnum)
                        {
                            content.Add(new StringContent(item.Value.ToString().ToLower(), Encoding.UTF8), item.Key);
                        }
                        else if (item.Value.GetType() == typeof(MediaDescription))
                        {
                            content.Add(new StringContent(JsonConvert.SerializeObject(item.Value, JsonSerializerConfig.SerializerSettings), Encoding.UTF8), item.Key);
                        }
                        else
                        {
                            content.Add(new StringContent(item.Value.ToString(), Encoding.UTF8), item.Key);
                        }
                    }

                    httpResponse = await _httpClient.PostAsync(url, content);
                }
                else
                {
                    var content = new FormUrlEncodedContent(formData.Where(t => t.Value != null).Select(t => new KeyValuePair<string, string>(t.Key, t.Value.ToString())));

                    httpResponse = await _httpClient.PostAsync(url, content);
                }

                httpResponse.EnsureSuccessStatusCode();

                result.HttpStatusCode = (int)httpResponse.StatusCode;
                result.ContentType = httpResponse.Content.Headers.ContentType?.ToString();
                result.ContentDisposition = httpResponse.Content.Headers.ContentDisposition?.ToString();

                result.Raw = await httpResponse.Content.ReadAsByteArrayAsync();

                _logger.Info($"request url {url} success. response");
                _logger.Info(result.RawString);
            }
            catch (Exception ex)
            {
                result.Exception = ex;
            }

            return result;
        }
    }
}
