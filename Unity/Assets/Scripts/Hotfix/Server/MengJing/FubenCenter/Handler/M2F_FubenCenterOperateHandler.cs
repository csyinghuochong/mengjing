namespace ET.Server
{

    [MessageHandler(SceneType.FubenCenter)]
    public class M2F_FubenCenterOperateHandler : MessageHandler<Scene, M2F_FubenCenterOperateRequest, F2M_FubenCenterOpenResponse>
    {
        protected override async ETTask Run(Scene scene, M2F_FubenCenterOperateRequest request, F2M_FubenCenterOpenResponse response)
        {
            FubenCenterComponent fubenCenterComponent= scene.GetComponent<FubenCenterComponent>();
            switch (request.OperateType)
            {
                case 1:   //废弃
                    fubenCenterComponent.FubenInstanceList.Add(request.FubenInstanceId);
                    break;
                case 2:   //废弃
                    fubenCenterComponent.FubenInstanceList.Remove(request.FubenInstanceId);
                    break;

                default:
                    break;  
            }
            
            await ETTask.CompletedTask;
        }
    }
}
