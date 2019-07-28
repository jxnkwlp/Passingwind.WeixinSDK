using System.Xml.Serialization;

namespace Passingwind.Weixin.MP.Models.Message
{
    [XmlType(AnonymousType = true)]
    [XmlRoot("xml", Namespace = "", IsNullable = false)]
    public class ShortVideoRequestMessageModel : RequestMessageModel
    {
        public string MediaId { get; set; }
        public string ThumbMediaId { get; set; }
    }
}