using System;
using System.Text;

namespace Passingwind.Weixin.Models
{
    public enum PostDataType
    {
        Json,
        FormData,
        Xml
    }

    public class HttpResponse
    {
        public byte[] Raw { get; set; }

        public int HttpStatusCode { get; set; }

        public string ContentType { get; set; }

        public string ContentDisposition { get; set; }

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
