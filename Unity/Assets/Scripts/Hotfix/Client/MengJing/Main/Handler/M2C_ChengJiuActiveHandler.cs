using System;

namespace ET.Client
{
    [MessageHandler(SceneType.Demo)]
    public class M2C_ChengJiuActiveHandler: MessageHandler<Scene,  M2C_ChengJiuActiveMessage>
    {
        protected override async ETTask Run(Scene root, M2C_ChengJiuActiveMessage message)
        {
           
            await ETTask.CompletedTask;
        }
    }
}