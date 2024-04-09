
using System.Collections.Generic;


namespace ET.Server
{
    [MessageLocationHandler(SceneType.Map)]
    [FriendOf(typeof(ChengJiuComponentS))]
    public class C2M_ChengJiuListHandler : MessageLocationHandler<Unit, C2M_ChengJiuListRequest, M2C_ChengJiuListResponse>
    {

        protected override async ETTask Run(Unit unit, C2M_ChengJiuListRequest request, M2C_ChengJiuListResponse response)
        {
            ChengJiuComponentS chengJiuComponent = unit.GetComponent<ChengJiuComponentS>();
            response.ChengJiuProgessList = chengJiuComponent.ChengJiuProgessList;
            response.ChengJiuCompleteList = chengJiuComponent.ChengJiuCompleteList;
            response.TotalChengJiuPoint = chengJiuComponent.TotalChengJiuPoint;
            response.AlreadReceivedId = chengJiuComponent.AlreadReceivedId;
            response.JingLingList = chengJiuComponent.JingLingList;
            response.JingLingId = chengJiuComponent.JingLingId;
            response.RandomDrop = chengJiuComponent.RandomDrop;

            await ETTask.CompletedTask;
        }
    }
}

