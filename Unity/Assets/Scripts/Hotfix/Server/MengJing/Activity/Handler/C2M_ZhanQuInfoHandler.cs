namespace ET.Server
{

    [MessageHandler(SceneType.Map)]
    public class C2M_ZhanQuInfoHandler : MessageLocationHandler<Unit, C2M_ZhanQuInfoRequest, M2C_ZhanQuInfoResponse>
    {

        protected override async ETTask Run(Unit unit, C2M_ZhanQuInfoRequest request, M2C_ZhanQuInfoResponse response)
        {

            ActorId paimaiServerId = StartSceneConfigCategory.Instance.GetBySceneName(unit.Zone(), "Activity").ActorId;

            M2A_ZhanQuInfoRequest M2A_ZhanQuInfoRequest = M2A_ZhanQuInfoRequest.Create();
            M2A_ZhanQuInfoRequest.UserId = unit.GetComponent<UserInfoComponentS>().UserInfo.UserId;
            A2M_ZhanQuInfoResponse r_GameStatusResponse = (A2M_ZhanQuInfoResponse)await unit.Root().GetComponent<MessageSender>().Call
                (paimaiServerId, M2A_ZhanQuInfoRequest);

            ActivityComponentS activityComponent = unit.GetComponent<ActivityComponentS>();
            response.ReceiveNum .AddRange( r_GameStatusResponse.ReceiveNum);
            response.ReceiveIds .AddRange(activityComponent.ZhanQuReceiveIds); 

            await ETTask.CompletedTask;
        }
    }
}
