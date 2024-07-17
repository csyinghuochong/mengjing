namespace ET.Server
{

    [MessageHandler(SceneType.Map)]
    public class C2M_GuideUpdateHandler : MessageLocationHandler<Unit, C2M_GuideUpdateRequest, M2C_GuideUpdateResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_GuideUpdateRequest request, M2C_GuideUpdateResponse response)
        { 
         
            unit.GetComponent<UserInfoComponentS>().UserInfo.CompleteGuideIds.Add(request.GuideId);
            await ETTask.CompletedTask;
        }
    }
}
