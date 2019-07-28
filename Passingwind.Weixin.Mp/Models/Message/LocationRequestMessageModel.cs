using System.Xml.Serialization;

namespace Passingwind.Weixin.MP.Models.Message
{
    [XmlType(AnonymousType = true)]
    [XmlRoot("xml", Namespace = "", IsNullable = false)]
    public class LocationRequestMessageModel : RequestMessageModel
    {
        public float Location_X { get; set; }
        public float Location_Y { get; set; }
        public float Scale { get; set; }
        public string Label { get; set; }
    }
}