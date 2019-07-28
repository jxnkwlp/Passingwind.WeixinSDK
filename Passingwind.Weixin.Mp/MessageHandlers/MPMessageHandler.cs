using Passingwind.Weixin.Dependency;
using Passingwind.Weixin.Logger;
using Passingwind.Weixin.MessageHandlers;
using Passingwind.Weixin.Models;
using Passingwind.Weixin.MP.Models.Message;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;
using Passingwind.Weixin.Extensions;

namespace Passingwind.Weixin.MP.MessageHandlers
{
    /// <summary>
    ///  消息处理
    /// </summary>
    public class MPMessageHandler : IMessageHandler
    {
        public const string DEFAULT_RESPONSE_SUCCESS_MESSAGE = "success";

        private ILogger _logger = DependencyManager.Resolve<ILogger>();

        public MPMessageHandlerNotifications Notifications { get; set; }

        public string MessageBody { get; private set; }


        public MPMessageHandler()
        {
            this.Notifications = new MPMessageHandlerNotifications();
        }

        private XDocument ConventToXDocument(string body)
        {
            try
            {
                var docs = XDocument.Parse(body);
                return docs;
            }
            catch (Exception ex)
            {
                _logger.Error(nameof(MPMessageHandler), ex, "");

#if DEBUG
                throw ex;
#endif
            }

            return null;
        }

        private IList<XElement> GenerateFromProperties<T>(T instance) where T : class
        {
            var result = new List<XElement>();

            var props = instance.GetType().GetProperties(true).Where(t => t.CanWrite && t.CanRead);

            foreach (var property in props)
            {
                object value = property.GetValue(instance);

                if (property.PropertyType == typeof(string) && value != null)
                    result.Add(new XElement(property.Name, new XCData((string)value)));
                else
                    result.Add(new XElement(property.Name, property.GetValue(instance)));
            }

            return result;
        }

        /// <summary>
        ///  处理消息
        /// </summary>
        public async Task<string> HandleAsync(string body, CancellationToken cancellationToken = default)
        {
            this.MessageBody = body;

            XDocument document = ConventToXDocument(body);


            if (document == null)
            {
                OnMessageError(body);
                return null;
            }

            MessageContext messageContext = null;

            var msgType = document.Root.Element("MsgType")?.Value;
            var eventName = document.Root.Element("Event")?.Value;

            switch (msgType)
            {
                case "text":
                    messageContext = new MessageContext(MessageType.Text, DecodeRequestMessage<TextRequestMessageModel>(body), body);
                    break;
                case "image":
                    messageContext = new MessageContext(MessageType.Image, DecodeRequestMessage<ImageRequestMessageModel>(body), body);
                    break;
                case "voice":
                    messageContext = new MessageContext(MessageType.Voice, DecodeRequestMessage<VoiceRequestMessageModel>(body), body);
                    break;
                case "video":
                    messageContext = new MessageContext(MessageType.Video, DecodeRequestMessage<VideoRequestMessageModel>(body), body);
                    break;
                case "shortvideo":
                    messageContext = new MessageContext(MessageType.ShortVideo, DecodeRequestMessage<ShortVideoRequestMessageModel>(body), body);
                    break;
                case "location":
                    messageContext = new MessageContext(MessageType.Location, DecodeRequestMessage<LocationRequestMessageModel>(body), body);
                    break;
                case "link":
                    messageContext = new MessageContext(MessageType.Link, DecodeRequestMessage<LinkRequestMessageModel>(body), body);
                    break;
                case "event":
                    switch (eventName.ToLower())
                    {
                        case "subscribe":
                            messageContext = new MessageContext(MessageType.Event, DecodeRequestMessage<SubscribeEventRequestMessageModel>(body), body, MessageEventType.Subscribe);
                            break;

                        case "unsubscribe":
                            messageContext = new MessageContext(MessageType.Event, DecodeRequestMessage<SubscribeEventRequestMessageModel>(body), body, MessageEventType.Unsubscribe);
                            break;

                        case "scan":
                            messageContext = new MessageContext(MessageType.Event, DecodeRequestMessage<ScanEventRequestMessageModel>(body), body, MessageEventType.Scan);
                            break;

                        case "location":
                            messageContext = new MessageContext(MessageType.Event, DecodeRequestMessage<LocationEventRequestMessageModel>(body), body, MessageEventType.Location);
                            break;

                        case "click":
                            messageContext = new MessageContext(MessageType.Event, DecodeRequestMessage<ClickEventRequestMessageModel>(body), body, MessageEventType.Click);
                            break;

                        case "view":
                            messageContext = new MessageContext(MessageType.Event, DecodeRequestMessage<ViewEventRequestMessageModel>(body), body, MessageEventType.View);
                            break;

                        case "masssendjobfinish":
                            messageContext = new MessageContext(MessageType.Event, DecodeRequestMessage<MassSendJobFinishEventRequestMessageModel>(body), body, MessageEventType.View);
                            break;

                        default:
                            throw new WeixinException($"未处理的事件类型'{eventName}'");
                    }
                    break;
                default:
                    OnMessageError(body);
                    break;
            }

            if (messageContext != null)
            {
                try
                {
                    await HandleMessageAsync(messageContext);
                }
                catch (Exception ex)
                {
                    _logger.Error(nameof(MPMessageHandler), ex, $"处理消息失败。请求内容：{body}");

#if DEBUG
                    throw ex;
#endif
                }

                if (messageContext.Response == null)
                    return DEFAULT_RESPONSE_SUCCESS_MESSAGE;
                else
                {
                    return EncodeResponseMessage(messageContext.Response);
                }
            }

            return null;
        }
        protected virtual T DecodeRequestMessage<T>(string body) where T : RequestMessageModel, IRequestMessage
        {
            //if (!body.StartsWith("<?xml"))
            //{
            //    body.Insert(0, "<?xml version=\"1.0\" encoding=\"utf-8\" ?>");
            //}

            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                using (StringReader sr = new StringReader(body))
                {
                    var result = (T)serializer.Deserialize(sr);
                    return result;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(nameof(MPMessageHandler), ex, $"反序列化失败。请求内容：{body}");

#if DEBUG
                throw ex;
#endif
            }

            return default;
        }

        protected virtual string EncodeResponseMessage<T>(T instance) where T : class, IResponseMessage
        {
            // TODO 此处需要优化
            var props = instance.GetType().GetProperties(true).Where(t => t.CanWrite && t.CanRead);

            var doc = new XDocument();
            doc.Add(new XElement("xml"));

            var root = doc.Root;

            foreach (var property in props)
            {
                object value = property.GetValue(instance);

                if (property.PropertyType == typeof(IResponseMessageContent))
                {
                    if (value is ImageResponseMessageContentModel imageResponse)
                    {
                        root.Add(new XElement("Image", new XElement("MediaId", new XCData(imageResponse.MediaId))));
                    }
                    else if (value is MusicResponseMessageContentModel musicResponse)
                    {
                        root.Add(new XElement("Music", GenerateFromProperties(musicResponse)));
                    }
                    else if (value is NewsResponseMessageContentModel newsResponse)
                    {
                        var ele = new XElement("Articles");

                        if (newsResponse.List != null)
                        {
                            foreach (var item in newsResponse.List)
                            {
                                ele.Add("item", GenerateFromProperties(item));
                            }
                        }

                        root.Add(ele);
                    }
                    else if (value is TextResponseMessageContentModel textResponse)
                    {
                        root.Add(new XElement("Content", new XCData(textResponse.Content)));
                    }
                    else if (value is VideoResponseMessageContentModel videoResponse)
                    {
                        root.Add(new XElement("Video", GenerateFromProperties(videoResponse)));
                    }
                    else if (value is VoiceResponseMessageContentModel voiceResponse)
                    {
                        root.Add(new XElement("Voice", GenerateFromProperties(voiceResponse)));
                    }
                    else
                    {
                        throw new WeixinException($"未处理的类型 '{value.GetType().FullName}' ");
                    }
                }
                else
                {
                    if (property.PropertyType == typeof(string) && value != null)
                        root.Add(new XElement(property.Name, new XCData((string)value)));
                    else
                        root.Add(new XElement(property.Name, property.GetValue(instance)));
                }
            }

            return doc.ToString(SaveOptions.DisableFormatting);
        }

        protected virtual void OnMessageError(string body)
        {
        }

        /// <summary>
        ///  处理当前请求的事件消息
        /// </summary>
        protected virtual Task HandleMessageAsync(MessageContext context)
        {
            if (this.Notifications?.HandleMessage != null)
                return this.Notifications.HandleMessage(context);
            else
                return Task.CompletedTask;
        }

    }
}
