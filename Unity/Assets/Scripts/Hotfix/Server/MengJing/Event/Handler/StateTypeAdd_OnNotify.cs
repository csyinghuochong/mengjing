using System;
using System.Collections.Generic;

namespace ET.Server
{
    [Event(SceneType.Map)]
    public class StateTypeAdd_OnNotify : AEvent<Scene, StateTypeAdd>
    {
        protected override async ETTask Run(Scene scene, StateTypeAdd args)
        {
            await ETTask.CompletedTask;
        }
    }
}