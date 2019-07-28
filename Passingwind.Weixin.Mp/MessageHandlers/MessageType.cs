using System;
using System.Collections.Generic;
using System.Text;

namespace Passingwind.Weixin.MP.MessageHandlers
{
    public enum MessageType
    {
        Unkonw = 0,
        Text,
        Image,
        Voice,
        Video,
        ShortVideo,
        Location,
        Link,

        Event,
    }

    public enum MessageEventType
    {
        Subscribe,
        Unsubscribe,
        Scan,
        Location,
        Click,
        View,
        MassSendJobFinish,
    }
}
