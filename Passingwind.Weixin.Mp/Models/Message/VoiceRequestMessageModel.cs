using System.Xml.Serialization;

namespace Passingwind.Weixin.MP.Models.Message
{
    [XmlType(AnonymousType = true)]
    [XmlRoot("xml", Namespace = "", IsNullable = false)]
    public class VoiceRequestMessageModel : RequestMessageModel
    {
        public string MediaId { get; set; }
        public string Format { get; set; }

        public string Recognition { get; set; }
    }
}