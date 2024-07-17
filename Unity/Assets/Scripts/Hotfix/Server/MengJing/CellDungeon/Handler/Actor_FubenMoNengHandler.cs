using System;
using System.Collections.Generic;


namespace ET.Server
{
    [MessageHandler(SceneType.Map)]
    public class Actor_FubenMoNengHandler : MessageLocationHandler<Unit, Actor_FubenMoNengRequest, Actor_FubenMoNengResponse>
    {
        protected override async ETTask Run(Unit unit, Actor_FubenMoNengRequest request, Actor_FubenMoNengResponse response)
        {
            response.MysteryItemInfos .AddRange(unit.Scene().GetComponent<CellDungeonComponent>().MysteryItemInfos); 
            await ETTask.CompletedTask;
        }
    }
}
