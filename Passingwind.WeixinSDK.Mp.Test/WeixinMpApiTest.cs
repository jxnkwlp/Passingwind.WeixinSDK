using Passingwind.Weixin.Models;
using Passingwind.Weixin.Mp;
using Passingwind.Weixin.Mp.Models;
using Passingwind.Weixin.Mp.Models.Media;
using Passingwind.Weixin.Mp.Models.Menus;
using System;
using System.Collections.Generic;
using System.IO;
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


            var result13 = await MpApi.UserApi.BatchBlackList(openIds[1]);
            Assert.True(result13.ErrorCode == 0);

            var result14 = await MpApi.UserApi.GetBlackList();
            Assert.True(result14.ErrorCode == 0 && result14.Data.Openid.Length > 0);

            result14 = await MpApi.UserApi.GetBlackList();
            Assert.True(result14.ErrorCode == 0 && result14.Data?.Openid?.Length == 0);
        }

        [Fact]
        public async Task MenuAPi_TestAsync()
        {
            var menuCreate = new CreateMenuRequesetModel();

            menuCreate.Button = new List<MenuButtonModel>();
            menuCreate.Button.Add(new MenuButtonModel()
            {
                Name = "今日歌曲",
                Type = MenuButtonType.Click,
                Key = "001",
            });

            menuCreate.Button.Add(new MenuButtonModel()
            {
                Name = "菜单",
                Sub_Button = new List<MenuButtonModel>() {
                    new MenuButtonModel(){
                        Name = "搜索",
                        Type = MenuButtonType.View,
                        Url = "http://www.soso.com/"
                    },

                    new MenuButtonModel(){
                        Name = "赞一下我们",
                        Type = MenuButtonType.Click,
                        Key = "V1001_GOOD"
                    }
                },
            });

            var result1 = await MpApi.MenuApi.CreateAsync(menuCreate);
            Assert.True(result1.ErrorCode == 0);

            var result2 = await MpApi.MenuApi.GetAsync();
            Assert.True(result2.ErrorCode == 0 && result2.Menu?.Button?.Count > 0);

            var result3 = await MpApi.MenuApi.DeleteAsync();
            Assert.True(result3.ErrorCode == 0);
        }

        [Fact]
        public async Task ConditionalMenuAPi_TestAsync()
        {
            var list = await MpApi.UserApi.GetListAsync();

            var menuCreate = new AddConditionalRequestModel();

            menuCreate.Button = new List<MenuButtonModel>();
            menuCreate.Button.Add(new MenuButtonModel()
            {
                Name = "abc",
                Type = MenuButtonType.Click,
                Key = "001",
            });

            menuCreate.MatchRule = new MenuConditionalMatchRuleModel()
            {
                Sex = 1,
            };

            var result1 = await MpApi.MenuApi.AddConditional(menuCreate);
            Assert.True(result1.ErrorCode == 0);

            var result2 = await MpApi.MenuApi.ConditionalTryMatch(list.Data.Openid[0]);
            Assert.True(result2.ErrorCode == 0 && result2.Menu?.Button?.Count > 0);

            var result3 = await MpApi.MenuApi.DeleteConditional();
            Assert.True(result3.ErrorCode == 0);
        }


        [Fact]
        public async Task Media_TestAsync()
        {
            var result1 = await MpApi.MediaApi.UploadAsync(new MediaUploadRequestModel()
            {
                Type = MediaType.Image,
                Media = new UploadFileModel()
                {
                    Data = File.ReadAllBytes(AppDomain.CurrentDomain.BaseDirectory + "test-file.png"),
                    FileName = "myfile.png",
                    ContentType = "image/png"
                }
            });

            // {"type":"image","media_id":"xA_QBUJyD__azbK2gYvK-6Lh6NFtAohGUsBw1Re1_peUMYuDDaSbkggEMIz6epsF","created_at":1561866387}
            Assert.True(result1.ErrorCode == 0);


            var result2 = await MpApi.MediaApi.GetAsync(result1.Media_Id);

            Assert.True(result2.Data.Length > 0);
        }
    }
}
