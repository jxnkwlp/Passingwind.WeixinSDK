using Passingwind.Weixin.Mp;
using Passingwind.Weixin.Mp.Models;
using System;
using System.Linq;

namespace Passingwind.Weixin.Samples
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            string appId = "wxa60caa8a4543d3fa";
            string appSecret = "4f141b47bca5755a169d46584982186a";

            WeixinMpApiContainer mpApi = new WeixinMpApiContainer(appId, appSecret);

            Console.WriteLine(mpApi.Token?.AccessToken);

            //for (int i = 0; i < 2; i++)
            //{
            //    _ = mpApi.TryUpdateTokenAsync().Result;

            //    Console.WriteLine(mpApi.Token?.AccessToken);
            //}

            //var result1 = mpApi.CommonApi.GetCallbackIpAsync().Result;

            //var result2 = mpApi.CommonApi.CheckAsync(new CheckRequest()
            //{
            //    Action = "all",
            //    Check_Operator = CheckRequest.KnowCheckOperator.DEFAULT,
            //}).Result;


            var result = mpApi.UserApi.GetListAsync().Result;

            if (result.Data?.Openid?.Length > 0)
            {
                var openIds = result.Data.Openid;

                var result2 = mpApi.UserApi.GetInfoAsync(new UserInfoRequestModel() { Openid = openIds[0] }).Result;

                var result3 = mpApi.UserApi.BatchGetInfoAsync(openIds.Select(t => new UserInfoRequestModel() { Openid = t }).ToArray()).Result;

                var result4 = mpApi.UserApi.UpdateRemarkAsync(openIds[0], "aaaa").Result;
            }

        }
    }
}
