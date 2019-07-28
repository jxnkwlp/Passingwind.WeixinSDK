using System.Xml.Serialization;

namespace Passingwind.Weixin.MP.Models.Message
{
    [XmlType(AnonymousType = true)]
    [XmlRoot("xml", Namespace = "", IsNullable = false)]
    public class LinkRequestMessageModel : RequestMessageModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
    }
}