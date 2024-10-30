
using System.Collections.Generic;
using Unity.Mathematics;

namespace ET.Server
{
    [MessageHandler(SceneType.Map)]
    public class C2M_GM2InfoRequestHandler : MessageLocationHandler<Unit, C2M_GM2InfoRequest, M2C_GM2InfoResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_GM2InfoRequest request, M2C_GM2InfoResponse response)
        {
            string account = unit.GetComponent<UserInfoComponentS>().Account;
            if (!GMData.GmAccount.Contains(account))
            {
                response.Error = ErrorCode.ERR_GMError;
                return;
            }

            int totalNumber = 0;
            int robotNumber = 0;
            List<int> zones = BroadCastHelper.GetAllZone();
            for (int i = 0; i < zones.Count; i++)
            {
                List<StartSceneConfig> zoneGates = StartSceneConfigCategory.Instance.Gates[zones[i]];

                foreach (StartSceneConfig gateServerId in zoneGates)
                {
                    G2A_GetUnitNumber g2M_UpdateUnitResponse = (G2A_GetUnitNumber)await unit.Root().GetComponent<MessageSender>().Call
                            (gateServerId.ActorId, A2G_GetUnitNumber.Create());
                    totalNumber+= g2M_UpdateUnitResponse.OnLinePlayer;
                    robotNumber += g2M_UpdateUnitResponse.OnLineRobot;
                }
            }
            response.OnLineNumber = totalNumber;
            response.OnLineRobot = robotNumber;

            await ETTask.CompletedTask;
        }
    }
}