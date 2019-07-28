using System.Xml.Serialization;

namespace Passingwind.Weixin.MP.Models.Message
{
    /// <summary> 
    /// </summary>
    /// <remarks>
    ///  <![CDATA[https://mp.weixin.qq.com/wiki?t=resource/res_main&id=mp1433751277 ]]>
    /// </remarks>
    [XmlType(AnonymousType = true)]
    [XmlRoot("xml", Namespace = "", IsNullable = false)]
    public class TemplateSendJobFinishEventRequestMessageModel : RequestMessageModel
    {
        /// <summary>
        ///  事件类型，TEMPLATESENDJOBFINISH
        /// </summary>
        public string Event { get; set; }

        /// <summary>
        ///  消息id
        /// </summary>
        public string MsgID { get; set; }

        /// <summary>
        ///  发送状态为成功
        /// </summary>
        public string Status { get; set; }

    }
}
