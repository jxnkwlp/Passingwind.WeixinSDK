using Passingwind.Weixin.MP.Models.Message;
using System;
using System.Collections.Generic;
using System.Text;

namespace Passingwind.Weixin.MP.MessageHandlers
{
    public static class Extensions
    {
        #region MessageContext

        public static ClickEventRequestMessageModel GetClickEventRequestMessage(this MessageContext context)
        {
            return context.Request as ClickEventRequestMessageModel;
        }

        public static LocationEventRequestMessageModel GetLocationEventRequestMessage(this MessageContext context)
        {
            return context.Request as LocationEventRequestMessageModel;
        }

        public static ScanEventRequestMessageModel GetScanEventRequestMessage(this MessageContext context)
        {
            return context.Request as ScanEventRequestMessageModel;
        }

        public static SubscribeEventRequestMessageModel GetSubscribeEventRequestMessage(this MessageContext context)
        {
            return context.Request as SubscribeEventRequestMessageModel;
        }

        public static ViewEventRequestMessageModel GetViewEventRequestMessage(this MessageContext context)
        {
            return context.Request as ViewEventRequestMessageModel;
        }


        public static ImageRequestMessageModel GetImageRequestMessage(this MessageContext context)
        {
            return context.Request as ImageRequestMessageModel;
        }

        public static LinkRequestMessageModel GetLinkRequestMessage(this MessageContext context)
        {
            return context.Request as LinkRequestMessageModel;
        }

        public static LocationRequestMessageModel GetLocationRequestMessage(this MessageContext context)
        {
            return context.Request as LocationRequestMessageModel;
        }

        public static ShortVideoRequestMessageModel GetShortVideoRequestMessage(this MessageContext context)
        {
            return context.Request as ShortVideoRequestMessageModel;
        }

        public static TextRequestMessageModel GetTextRequestMessage(this MessageContext context)
        {
            return context.Request as TextRequestMessageModel;
        }

        public static VideoRequestMessageModel GetVideoRequestMessage(this MessageContext context)
        {
            return context.Request as VideoRequestMessageModel;
        }

        public static VoiceRequestMessageModel GetVoiceRequestMessage(this MessageContext context)
        {
            return context.Request as VoiceRequestMessageModel;
        }


        public static ResponseMessageModel CreateResponse(this MessageContext context, IResponseMessageContent content)
        {
            var res = new ResponseMessageBuilder()
                .Create(new ResponseMessage
                {
                    ToUserName = context.Request.FromUserName,
                    FromUserName = context.Request.ToUserName,
                })
                .SetContent(content)
                .Build();

            return res;
        }

        #endregion



        //protected virtual Task<string> HandleMessageAsync(LinkMessageModel model)
        //{
        //    if (HandleRequestMessage != null)
        //    {
        //        return HandleRequestMessage(model);
        //    }

        //    return Task.FromResult(defaultResponseSuccessMessage);
        //}

        //protected virtual Task<string> HandleMessageAsync(LocationMessageModel model)
        //{
        //    if (HandleRequestMessage != null)
        //    {
        //        return HandleRequestMessage(model);
        //    }

        //    return Task.FromResult(defaultResponseSuccessMessage);
        //}

        //protected virtual Task<string> HandleMessageAsync(ShortVideoMessageModel model)
        //{
        //    if (HandleRequestMessage != null)
        //    {
        //        return HandleRequestMessage(model);
        //    }

        //    return Task.FromResult(defaultResponseSuccessMessage);
        //}

        //protected virtual Task<string> HandleMessageAsync(TextMessageModel model)
        //{
        //    if (HandleRequestMessage != null)
        //    {
        //        return HandleRequestMessage(model);
        //    }

        //    return Task.FromResult(defaultResponseSuccessMessage);
        //}

        //protected virtual Task<string> HandleMessageAsync(VideoMessageModel model)
        //{
        //    if (HandleRequestMessage != null)
        //    {
        //        return HandleRequestMessage(model);
        //    }

        //    return Task.FromResult(defaultResponseSuccessMessage);
        //}

        //protected virtual Task<string> HandleResponseMessageAsync(VideoMessageModel model)
        //{
        //    if (HandleRequestMessage != null)
        //    {
        //        return HandleRequestMessage(model);
        //    }

        //    return Task.FromResult(defaultResponseSuccessMessage);
        //}
    }
}
