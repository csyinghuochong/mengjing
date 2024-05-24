using System;

namespace ET.Server
{

    [MessageHandler(SceneType.FubenCenter)]
    public class M2F_FubenCenterOperateHandler : MessageHandler<Scene, M2F_FubenCenterOperateRequest, F2M_FubenCenterOpenResponse>
    {
        protected override async ETTask Run(Scene scene, M2F_FubenCenterOperateRequest request, F2M_FubenCenterOpenResponse response)
        {
            FubenCenterComponent fubenCenterComponent= scene.GetComponent<FubenCenterComponent>();
            if (request.OperateType == 1)
            {
                fubenCenterComponent.FubenInstanceList.Add(request.FubenInstanceId);
            }
            else
            { 
                fubenCenterComponent.FubenInstanceList.Remove(request.FubenInstanceId);
            }

            //Log.Debug($"FubenCenterOperate {scene.DomainZone()} {request.OperateType} {request.SceneType} {fubenCenterComponent.FubenInstanceList.Count}");
            response.ServerInfo = fubenCenterComponent.ServerInfo;

            await ETTask.CompletedTask;
        }
    }
}
