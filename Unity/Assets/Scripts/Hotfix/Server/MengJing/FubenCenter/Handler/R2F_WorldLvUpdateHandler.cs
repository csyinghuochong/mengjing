using System;
using System.Collections.Generic;

namespace ET.Server
{

    [MessageHandler(SceneType.FubenCenter)]
    public class R2F_WorldLvUpdateHandler : MessageHandler<Scene, R2F_WorldLvUpdateRequest, F2R_WorldLvUpdateResponse>
    {
        protected override async ETTask Run(Scene scene, R2F_WorldLvUpdateRequest request, F2R_WorldLvUpdateResponse response)
        {
            List<ActorId> mapIdList = new List<ActorId>();
            FubenCenterComponent fubenCenterComponent = scene.GetComponent<FubenCenterComponent>();
            mapIdList.Add(StartSceneConfigCategory.Instance.GetBySceneName(scene.Zone(), $"Map{ComHelp.MainCityID()}").ActorId);
            mapIdList.AddRange(fubenCenterComponent.FubenActorIdList );
            for (int i = mapIdList.Count - 1; i >= 0; i--)
            {
                try
                {
                    M2F_ServerInfoUpdateResponse m2m_TrasferUnitResponse = (M2F_ServerInfoUpdateResponse)await scene.Root().GetComponent<MessageSender>().Call
                           (mapIdList[i], new F2M_ServerInfoUpdateRequest() { ServerInfo = request.ServerInfo });

                    if (i != 0 && m2m_TrasferUnitResponse.Error != ErrorCode.ERR_Success)
                    {
                        Log.Debug($"WorldLvUpdateError: {mapIdList[i]}");
                        mapIdList.RemoveAt(i);
                    }
                }
                catch (Exception ex)
                {
                    Log.Debug(ex.ToString());
                }
            }
            fubenCenterComponent.ServerInfo = request.ServerInfo;

            await ETTask.CompletedTask;
        }
    }
}
