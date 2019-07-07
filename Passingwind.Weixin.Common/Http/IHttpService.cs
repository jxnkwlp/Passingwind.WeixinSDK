using Passingwind.Weixin.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Passingwind.Weixin.Http
{
    public interface IHttpService
    {
        Task<HttpResponse> GetAsync(string url);

        Task<HttpResponse> PostAsync(string url, string content = null);

        Task<HttpResponse> PostAsync(string url, IList<KeyValuePair<string, object>> formData);

    }
}
