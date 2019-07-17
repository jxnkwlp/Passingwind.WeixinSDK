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

# TODO

获取用户地理位置 https://mp.weixin.qq.com/wiki?t=resource/res_main&id=mp1421140841

自定义菜单事件推送 https://mp.weixin.qq.com/wiki?t=resource/res_main&id=mp1421141016
