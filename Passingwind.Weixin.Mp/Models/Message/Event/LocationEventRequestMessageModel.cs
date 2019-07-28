using System.Xml.Serialization;

namespace Passingwind.Weixin.MP.Models.Message
{
    [XmlType(AnonymousType = true)]
    [XmlRoot("xml", Namespace = "", IsNullable = false)]
    public class LocationEventRequestMessageModel : RequestMessageModel
    {
        /// <summary>
        ///  事件类型，LOCATION
        /// </summary>
        public string Event { get; set; }

        /// <summary>
        ///  地理位置纬度
        /// </summary>
        public float Latitude { get; set; }

        /// <summary>
        ///  地理位置经度
        /// </summary>
        public float Longitude { get; set; }

        /// <summary>
        ///  地理位置精度
        /// </summary>
        public float Precision { get; set; }
    }
}
