using Passingwind.Weixin.MP.MessageHandlers;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Passingwind.Weixin.MP.Models.Message
{
    public class NewsResponseMessageContentModel : IResponseMessageContent
    {
        public IList<NewsItem> List { get; set; }

        public class NewsItem
        {
            public string Title { get; set; }
            public string Description { get; set; }
            public string PicUrl { get; set; }
            public string Url { get; set; }

        }
    }
}