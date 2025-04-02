using System.Collections.Generic;
using Unity.Mathematics;

namespace ET.Server
{
    [Event(SceneType.Map)]
    public class ChangePosition_NotifyChuanSong: AEvent<Scene, ChangePosition>
    {
        protected override async ETTask Run(Scene scene, ChangePosition args)
        {
            
            await ETTask.CompletedTask;
        }
    }
}