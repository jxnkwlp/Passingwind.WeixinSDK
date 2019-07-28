using System.Xml.Serialization;

namespace Passingwind.Weixin.MP.Models.Message
{
    [XmlType(AnonymousType = true)]
    [XmlRoot("xml", Namespace = "", IsNullable = false)]
    public class ClickEventRequestMessageModel : RequestMessageModel
    {
        /// <summary>
        ///  事件类型，CLICK
        /// </summary>
        public string Event { get; set; }

        /// <summary>
        ///  事件KEY值，与自定义菜单接口中KEY值对应
        /// </summary>
        public string EventKey { get; set; }
    }
}
