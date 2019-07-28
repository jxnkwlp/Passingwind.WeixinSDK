# SDK

开发中...

# Usage
``` c#
// 必须
WeixinServiceRegister.Register();

// 引用API
var api = new WeixinMpApi([appId], [appSecret]);

// 比如
var userList = await api.UserApi.GetListAsync();

```

# 参数命令规则说明

因微信接口大部分参数采用命名规则是【下划线】法，而C#命名推荐使用的是帕斯卡/大驼峰等命名规则。
为了和微信保持一致，同时为了“好看”一点，命名规则为原字段名首字母改为大写，如果中间有下划线，则下划线后的单词首字母改为大写，比如 sub_button 会被命名为 Sub_Button 。

# 完成度

### 公众平台

[ ] 自定义菜单  
[x] 消息管理   
[x] 微信网页开发  
[ ] 素材管理  
[ ] 图文消息留言管理  
[ ] 用户管理  
[ ] 帐号管理  
[ ] 数据统计  
[x] 微信卡券  
[x] 微信门店  
[x] 微信小店  
[x] 智能接口   
[x] 新版客服功能  
[x] 微信摇一摇周边  
[x] 微信连Wi-Fi  
[x] 微信一物一码  
[x] 微信发票  
 
# TODO

获取用户地理位置 https://mp.weixin.qq.com/wiki?t=resource/res_main&id=mp1421140841

自定义菜单事件推送 https://mp.weixin.qq.com/wiki?t=resource/res_main&id=mp1421141016

微信认证事件推送
https://mp.weixin.qq.com/wiki?t=resource/res_main&id=mp1455785130