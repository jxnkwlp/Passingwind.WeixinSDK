using Passingwind.Weixin.Mp;
using Passingwind.Weixin.Mp.Models;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Passingwind.WeixinSDK.Apis
{
    public class WeixinMpApiTest
    {
        public WeixinMpApi MpApi { get; }

        public WeixinMpApiTest()
        {
            string appId = "wxa60caa8a4543d3fa";
            string appSecret = "4f141b47bca5755a169d46584982186a";

            MpApi = new WeixinMpApi(appId, appSecret);

            Console.WriteLine(MpApi.Token?.AccessToken);
        }

        [Fact]
        public async Task AccessTokenTestAsync()
        {
            Console.WriteLine(MpApi.Token?.AccessToken);

            Assert.NotEmpty(MpApi.Token?.AccessToken);

            await MpApi.TryUpdateTokenAsync(true);

            Assert.NotEmpty(MpApi.Token?.AccessToken);

            string oldToken = MpApi.Token?.AccessToken;

            await MpApi.TryUpdateTokenAsync();

            Assert.True(oldToken == MpApi.Token?.AccessToken);
        }

        [Fact]
        public async Task CommonAPi_TestAsync()
        {
            var result1 = await MpApi.CommonApi.GetCallbackIpAsync();

            Assert.True(result1.ErrorCode == 0);

            //var result2 = await MpApi.CommonApi.CheckAsync(new CheckRequest()
            //{
            //    Action = "all",
            //    Check_Operator = CheckRequest.KnowCheckOperator.DEFAULT,
            //});

            //Assert.True(result2.ErrorCode == 0);
        }

        [Fact]
        public async Task UserApi_TestAsync()
        {
            var list = await MpApi.UserApi.GetListAsync();

            Assert.True(list.ErrorCode == 0 && list.Count > 0);

            var openIds = list.Data.Openid;

            var result2 = await MpApi.UserApi.GetInfoAsync(new UserInfoRequestModel() { Openid = openIds[0] });

            Assert.True(result2.ErrorCode == 0);

            var result3 = await MpApi.UserApi.BatchGetInfoAsync(openIds.Select(t => new UserInfoRequestModel() { Openid = t }).ToArray());

            Assert.True(result3.ErrorCode == 0 && result3.JsonSource.Length > 0);

            var result4 = await MpApi.UserApi.UpdateRemarkAsync(openIds[0], "aaaa");

            Assert.True(result4.ErrorCode == 0);


            var result5 = await MpApi.UserApi.TagsCreate("a");
            Assert.True(result5.ErrorCode == 0 && result5.Tag?.Id > 0);

            var result6 = await MpApi.UserApi.TagsUpdate(new UserTagModel() { Id = result5.Tag.Id, Name = "b" });
            Assert.True(result6.ErrorCode == 0);

            var result7 = await MpApi.UserApi.TagsDelete(result5.Tag.Id);
            Assert.True(result7.ErrorCode == 0);

            var result8 = await MpApi.UserApi.GetTags();
            Assert.True(result8.ErrorCode == 0 && result8.Tags?.Length > 0);

            var result9 = await MpApi.UserApi.BatchTags(result8.Tags[0].Id, openIds[0]);
            Assert.True(result9.ErrorCode == 0);

            var result10 = await MpApi.UserApi.GetTag(result8.Tags[0].Id);
            Assert.True(result10.ErrorCode == 0);

            var result11 = await MpApi.UserApi.GetMemberTags(openIds[0]);
            Assert.True(result11.ErrorCode == 0);

            var result12 = await MpApi.UserApi.BatchUnTags(result8.Tags[0].Id, openIds[0]);
            Assert.True(result12.ErrorCode == 0);
        }

    }
}
