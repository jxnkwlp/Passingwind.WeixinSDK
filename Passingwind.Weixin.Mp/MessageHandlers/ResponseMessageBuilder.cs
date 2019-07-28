using Passingwind.Weixin.MP.Models.Message;
using System;
using System.Collections.Generic;
using System.Text;

namespace Passingwind.Weixin.MP.MessageHandlers
{
    public class ResponseMessageBuilder
    {
        private ResponseMessage _message;
        private IResponseMessageContent _messageContent;

        public ResponseMessageBuilder Create(ResponseMessage message)
        {
            _message = message;
            return this;
        }

        public ResponseMessageBuilder SetContent(IResponseMessageContent content)
        {
            _messageContent = content;
            return this;
        }

        public ResponseMessageModel Build()
        {
            var model = new ResponseMessageModel()
            {
                Content = _messageContent,
                CreateTime = _message.CreateTime,
                FromUserName = _message.FromUserName,
                ToUserName = _message.ToUserName,
                MsgType = "text",
            };

            switch (_message.MsgType)
            {
                case ResponseMessageType.Image:
                    model.MsgType = "image";
                    break;
                case ResponseMessageType.Music:
                    model.MsgType = "music";
                    break;
                case ResponseMessageType.News:
                    model.MsgType = "news";
                    break;
                case ResponseMessageType.Text:
                    model.MsgType = "text";
                    break;
                case ResponseMessageType.Video:
                    model.MsgType = "video";
                    break;
                case ResponseMessageType.Voice:
                    model.MsgType = "voice";
                    break;
                default:
                    throw new WeixinException("未知的Type");
            }

            return model;
        }
    }
}
