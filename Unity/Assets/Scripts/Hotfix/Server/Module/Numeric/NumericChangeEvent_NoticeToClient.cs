using System;

namespace ET.Server
{
    [Event(SceneType.Map)]
    public class NumericChangeEvent_NoticeToClient : AEvent<Scene, NumbericChange>
    {
        protected override async ETTask Run(Scene scene, NumbericChange args)
        {
            
            if (NumericData.BroadcastType.Contains(args.NumericType))
            {
                NumbericChangeBroadcastHelper.Broadcast(args);
            }
            else
            {
                NumbericChangeBroadcastHelper.SendToClient(args);
            }
            await ETTask.CompletedTask;
        }
    }
}