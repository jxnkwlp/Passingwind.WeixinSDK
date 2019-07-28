using System.Xml.Serialization;

namespace Passingwind.Weixin.MP.Models.Message
{
    [XmlType(AnonymousType = true)]
    [XmlRoot("xml", Namespace = "", IsNullable = false)]
    public class ScanEventRequestMessageModel : RequestMessageModel
    {
        /// <summary>
        ///  事件类型，subscribe/scan
        /// </summary>
        public string Event { get; set; }

        /// <summary>
        ///  事件KEY值，qrscene_为前缀，后面为二维码的参数值
        /// </summary>
        public string EventKey { get; set; }

        /// <summary>
        ///  二维码的ticket，可用来换取二维码图片
        /// </summary>
        public string Ticket { get; set; }
    }
}
