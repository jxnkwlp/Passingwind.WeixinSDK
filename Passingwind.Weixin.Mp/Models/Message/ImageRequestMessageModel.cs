using System.Xml.Serialization;

namespace Passingwind.Weixin.MP.Models.Message
{
    [XmlType(AnonymousType = true)]
    [XmlRoot("xml", Namespace = "", IsNullable = false)]
    public class ImageRequestMessageModel : RequestMessageModel
    {
        public string PicUrl { get; set; }
    }
}