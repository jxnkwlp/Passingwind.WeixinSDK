using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Passingwind.Weixin.MP.Models.Message
{
    [XmlType(AnonymousType = true)]
    [XmlRoot("xml", Namespace = "", IsNullable = false)]
    public class MassSendJobFinishEventRequestMessageModel : RequestMessageModel
    {
        /// <summary>
        ///  事件类型，masssendjobfinish
        /// </summary>
        public string Event { get; set; }

        public string Status { get; set; }
        public long TotalCount { get; set; }
        public long FilterCount { get; set; }
        public long SentCount { get; set; }
        public long ErrorCount { get; set; }

        public CopyrightCheckResultModel CopyrightCheckResult { get; set; }

        public class CopyrightCheckResultModel
        {
            public int Count { get; set; }
            public int CheckState { get; set; }

            [XmlArray("ResultList")]
            [XmlArrayItem("item")]
            public List<CopyrightCheckResultItemModel> ResultList { get; set; }
        }

        public class CopyrightCheckResultItemModel
        {
            public int ArticleIdx { get; set; }
            public int UserDeclareState { get; set; }
            public int AuditState { get; set; }
            public string OriginalArticleUrl { get; set; }
            public int OriginalArticleType { get; set; }
            public int CanReprint { get; set; }
            public int NeedReplaceContent { get; set; }
            public int NeedShowReprintSource { get; set; }
        }
    }
}
