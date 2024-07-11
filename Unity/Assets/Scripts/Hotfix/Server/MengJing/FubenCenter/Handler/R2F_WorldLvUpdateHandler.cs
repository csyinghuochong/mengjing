using System;
using System.Collections.Generic;
using System.Linq;

namespace ET.Server
{

    [MessageHandler(SceneType.FubenCenter)]
    public class R2F_WorldLvUpdateHandler : MessageHandler<Scene, R2F_WorldLvUpdateRequest, F2R_WorldLvUpdateResponse>
    {
        protected override async ETTask Run(Scene scene, R2F_WorldLvUpdateRequest request, F2R_WorldLvUpdateResponse response)
        {
            List<ActorId> mapIdList = new List<ActorId>();
            FubenCenterComponent fubenCenterComponent = scene.GetComponent<FubenCenterComponent>();
            mapIdList.Add(StartSceneConfigCategory.Instance.GetBySceneName(scene.Zone(), $"Map{CommonHelp.MainCityID()}").ActorId);
            mapIdList.AddRange(fubenCenterComponent.FubenActorIdList.Values.ToList() );

            F2M_ServerInfoUpdateRequest F2M_ServerInfoUpdateRequest = F2M_ServerInfoUpdateRequest.Create();
            F2M_ServerInfoUpdateRequest.ServerInfo = request.ServerInfo;
            for (int i = mapIdList.Count - 1; i >= 0; i--)
            {
                try
                {
                    M2F_ServerInfoUpdateResponse m2m_TrasferUnitResponse = (M2F_ServerInfoUpdateResponse)await scene.Root().GetComponent<MessageSender>().Call
                           (mapIdList[i], F2M_ServerInfoUpdateRequest);

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
