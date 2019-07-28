using System.Xml.Serialization;

namespace Passingwind.Weixin.MP.Models.Message
{
    [XmlType(AnonymousType = true)]
    [XmlRoot("xml", Namespace = "", IsNullable = false)]
    public class ViewEventRequestMessageModel : RequestMessageModel
    {
        /// <summary>
        ///   事件类型，VIEW
        /// </summary>
        public string Event { get; set; }

        /// <summary>
        ///  事件KEY值，设置的跳转URL
        /// </summary>
        public string EventKey { get; set; }
    }
}
