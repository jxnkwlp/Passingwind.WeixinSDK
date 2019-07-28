using System;
using System.IO;
using System.Xml.Serialization;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string body = @"<xml><ToUserName><![CDATA[gh_b064e59c7f03]]></ToUserName>
    <FromUserName><![CDATA[oryVMw_ltWbzv-vAubcarFQBe6nE]]></FromUserName>
    <CreateTime>1564281918</CreateTime>
    <MsgType><![CDATA[text]]></MsgType>
    <Content><![CDATA[11]]></Content>
    <MsgId>22395133140925056</MsgId>
</xml> ";

            XmlSerializer serializer = new XmlSerializer(typeof(RequestMessageModel));
            using (StringReader sr = new StringReader(body))
            {
                var result = serializer.Deserialize(sr);
            }

            Console.WriteLine("Hello World!");
        }
    }

    [Serializable]
    [XmlRoot(ElementName = "xml", IsNullable = true)]
    public class RequestMessageModel
    {
        public string ToUserName { get; set; }
        public string FromUserName { get; set; }
        public long CreateTime { get; set; }
        public string MsgType { get; set; }
        public string MsgId { get; set; }
    }
}
