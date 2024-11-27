
namespace ET.Server
{
    [MessageLocationHandler(SceneType.Map)]
    [FriendOf(typeof(ChengJiuComponentS))]
    public class C2M_ChengJiuListHandler : MessageLocationHandler<Unit, C2M_ChengJiuListRequest, M2C_ChengJiuListResponse>
    {

        protected override async ETTask Run(Unit unit, C2M_ChengJiuListRequest request, M2C_ChengJiuListResponse response)
        {
            ChengJiuComponentS chengJiuComponent = unit.GetComponent<ChengJiuComponentS>();
            response.ChengJiuProgessList .AddRange(chengJiuComponent.ChengJiuProgessList); 
            response.ChengJiuCompleteList .AddRange(chengJiuComponent.ChengJiuCompleteList); 
            response.TotalChengJiuPoint = chengJiuComponent.TotalChengJiuPoint;
            response.AlreadReceivedId .AddRange(chengJiuComponent.AlreadReceivedId); 
            response.JingLingList .AddRange( chengJiuComponent.JingLingList);
            response.PetTuJianActives.AddRange( chengJiuComponent.PetTuJianActives );
            response.RandomDrop = chengJiuComponent.RandomDrop;

            await ETTask.CompletedTask;
        }
    }
}

