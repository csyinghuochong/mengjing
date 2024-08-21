using System;

namespace ET.Server
{
    [Invoke((long)MailBoxType.GateSession)]
    public class MailBoxType_GateSessionHandler: AInvokeHandler<MailBoxInvoker>
    {
        public override void Handle(MailBoxInvoker args)
        {
            MailBoxComponent mailBoxComponent = args.MailBoxComponent;
            
            // 这里messageObject要发送出去，不能回收
            IMessage messageObject = args.MessageObject;
            
            if (mailBoxComponent.Parent is PlayerSessionComponent playerSessionComponent)
            {
                try
                {
                    playerSessionComponent.Session?.Send(messageObject);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error:  " +  messageObject.ToString());
                    Console.WriteLine(e);
                    throw;
                }
               
            }
        }
    }
}