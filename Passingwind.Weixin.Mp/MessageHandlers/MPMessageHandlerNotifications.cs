using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Passingwind.Weixin.MP.MessageHandlers
{
    public class MPMessageHandlerNotifications
    {
        public Func<MessageContext, Task> HandleMessage { get; set; }

        public MPMessageHandlerNotifications()
        {
        }
    }
}
