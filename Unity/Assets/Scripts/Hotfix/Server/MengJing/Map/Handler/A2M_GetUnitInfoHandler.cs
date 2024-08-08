using System;

namespace ET.Server
{
    [MessageHandler(SceneType.Map)]
    public class A2M_GetUnitInfoHandler: MessageLocationHandler<Unit, A2M_GetUnitInfoRequest, M2A_GetUnitInfoResponse>
    {
        protected override async ETTask Run(Unit unit, A2M_GetUnitInfoRequest request, M2A_GetUnitInfoResponse response)
        {
            //Console.WriteLine($"A2M_GetUnitInfoRequest:  {unit.GetComponent<DBSaveComponent>().PlayerState}");
            response.PlayerState = (int)unit.GetComponent<DBSaveComponent>().PlayerState;
            await ETTask.CompletedTask;
        }
    }
}