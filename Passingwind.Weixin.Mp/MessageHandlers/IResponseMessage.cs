using System;
using System.Collections.Generic;
using System.Text;

namespace Passingwind.Weixin.MP.MessageHandlers
{
    public interface IResponseMessage
    {
        IResponseMessageContent Content { get; set; }
    }
}
