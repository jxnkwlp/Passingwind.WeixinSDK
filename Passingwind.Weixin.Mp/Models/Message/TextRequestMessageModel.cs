using System.Xml.Serialization;

namespace Passingwind.Weixin.MP.Models.Message
{
    [XmlType(AnonymousType = true)]
    [XmlRoot("xml", Namespace = "", IsNullable = false)]
    public class TextRequestMessageModel : RequestMessageModel
    {
        public string Content { get; set; }
    }
}