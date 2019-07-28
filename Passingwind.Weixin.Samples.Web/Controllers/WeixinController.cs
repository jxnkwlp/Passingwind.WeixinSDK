using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Passingwind.Weixin.MP;
using Passingwind.Weixin.MP.MessageHandlers;
using Passingwind.Weixin.MP.Models.Message;
using Passingwind.Weixin.Security;

namespace Passingwind.Weixin.Samples.Web.Controllers
{
    public class WeixinController : Controller
    {
        private readonly IBizMessageCryptService _bizMessageCryptService;
        private readonly WeixinMpApi _weixinMpApi;

        private readonly IConfiguration _configuration;
        private readonly ILogger<WeixinController> _logger;

        public WeixinController(IBizMessageCryptService bizMessageCryptService, IConfiguration configuration, ILogger<WeixinController> logger, WeixinMpApi weixinMpApi)
        {
            _bizMessageCryptService = bizMessageCryptService;
            _configuration = configuration;
            _logger = logger;
            _weixinMpApi = weixinMpApi;
        }

        public async Task<IActionResult> Index(long timestamp, string nonce, string signature, string echostr, string openid)
        {
            _logger.LogInformation($"请求: {Request.Method} {Request.Path} {Request.QueryString}");

            _logger.LogInformation($"请求参数: ");
            _logger.LogInformation($"timestamp:{timestamp}, nonce:{nonce}, signature:{signature}, echostr:{echostr}");

            string body = string.Empty;

            try
            {
                if (Request.Body != null)
                {
                    using (StreamReader stream = new StreamReader(Request.Body))
                    {
                        body = stream.ReadToEnd();
                    }
                }
            }
            catch (Exception)
            {
            }

            _logger.LogInformation($"请求 Body: ");
            _logger.LogInformation($"{body}");

            string token = _configuration.GetValue<string>("WeiXinMp:Token");

            var signatureString = _bizMessageCryptService.Encrypt(token, timestamp, nonce);

            _logger.LogInformation($"签名结果: {signatureString} {string.Equals(signatureString, signature, StringComparison.InvariantCultureIgnoreCase)}");

            if (!string.Equals(signatureString, signature, StringComparison.InvariantCultureIgnoreCase))
            {
                return Ok("fail[签名比对不正确]");
            }

            // 回复
            if (!string.IsNullOrEmpty(echostr))
            {
                return Ok(echostr);
            }

            if (!string.IsNullOrEmpty(body))
            {
                var handle = new MPMessageHandler();
                handle.Notifications.HandleMessage = (context) =>
                {
                    if (context.Request != null)
                    {
                        //var res = new ResponseMessageBuilder().Create(new ResponseMessage
                        //{
                        //    ToUserName = context.Request.FromUserName,
                        //    FromUserName = context.Request.ToUserName,
                        //})
                        //.SetContent(new TextResponseMessageContentModel()
                        //{
                        //    Content = "hello. \n你好. \n</aaa>"
                        //})
                        //.Build();

                        //context.SetResponse(res);

                        if (context.MessageType == MessageType.Event)
                        {
                            if (context.EventType == MessageEventType.Subscribe)
                            {
                                _logger.LogInformation("用户关注");

                                context.SetResponse(
                                    context.CreateResponse(new TextResponseMessageContentModel()
                                    {
                                        Content = $"欢迎关注。\n {Newtonsoft.Json.JsonConvert.SerializeObject(context.Request)}"
                                    })
                                );
                            }
                            else if (context.EventType == MessageEventType.Unsubscribe)
                            {
                                _logger.LogInformation("用户 取消关注");
                            }
                            else if (context.EventType == MessageEventType.Location)
                            {
                                _logger.LogInformation("上报位置信息");
                                _logger.LogInformation(Newtonsoft.Json.JsonConvert.SerializeObject(context.GetLocationEventRequestMessage()));

                                context.SetResponse(
                                   context.CreateResponse(new TextResponseMessageContentModel()
                                   {
                                       Content = $"上报位置信息。\n {Newtonsoft.Json.JsonConvert.SerializeObject(context.GetLocationEventRequestMessage())} ",
                                   })
                               );
                            }
                            else
                            {
                                context.SetResponse(
                                      context.CreateResponse(new TextResponseMessageContentModel()
                                      {
                                          Content = $"请求内容：\n" +
                                          $"{Newtonsoft.Json.JsonConvert.SerializeObject(context.Request)}"
                                      })
                                  );
                            }

                        }
                        else
                        {
                            //context.SetResponse(new ResponseMessageModel()
                            //{
                            //    ToUserName = context.Request.FromUserName,
                            //    FromUserName = context.Request.ToUserName,
                            //    MsgType = "text",
                            //    Content = new TextResponseMessageContentModel()
                            //    {
                            //        Content = "hello. \n你好. \n</aaa>"
                            //    },
                            //});

                            context.SetResponse(
                                       context.CreateResponse(new TextResponseMessageContentModel()
                                       {
                                           Content = $"hello. \n" +
                                           $"你好. \n" +
                                           $"<a href='http://baidu.com'>baidu</a>。\n" +
                                           $"请求内容：\n" +
                                           $"{Newtonsoft.Json.JsonConvert.SerializeObject(context.Request)}"
                                       })
                                   );
                        }
                    }

                    return Task.CompletedTask;
                };

                var result = await handle.HandleAsync(body);

                _logger.LogInformation($"处理消息结果: ");
                _logger.LogInformation(result);

                return Ok(result);
            }

            return Ok(1);
        }
    }

    //public class MyMPMessageHandler : MPMessageHandler
    //{
    //    protected override Task HandleMessageAsync(MessageContext context)
    //    {
    //        if (context.Request != null)
    //            context.SetResponse(new TextResponseMessageModel()
    //            {
    //                Content = "hello. \n你好. \n</aaa>",
    //                ToUserName = context.Request.FromUserName,
    //                FromUserName = context.Request.ToUserName,
    //                MsgType = "text",
    //            });

    //        return Task.CompletedTask;
    //    }

    //}
}