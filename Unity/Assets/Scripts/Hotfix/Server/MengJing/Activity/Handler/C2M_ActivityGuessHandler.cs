namespace ET.Server
{

    [MessageHandler(SceneType.Map)]
    public class C2M_ActivityGuessHandler : MessageLocationHandler<Unit, C2M_ActivityGuessRequest, M2C_ActivityGuessResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_ActivityGuessRequest request, M2C_ActivityGuessResponse response)
        {
            ActorId activitySceneid = UnitCacheHelper.GetActivityServerId(unit.Zone());
            ActivityV1Info activityV1Info = unit.GetComponent<ActivityComponentS>().ActivityV1Info;
            if (activityV1Info.GuessIds.Contains(request.GuessId))
            {
                response.Error = ErrorCode.ERR_Already_Guess;
  
                return;
            }
            string costItem = ActivityConfigHelper.GetGuessCostItem(activityV1Info.GuessIds.Count);
            if (!unit.GetComponent<BagComponentS>().CheckCostItem(costItem))
            {
                response.Error = ErrorCode.ERR_ItemNotEnoughError;

                return;
            }

            M2A_ActivityGuessRequest M2A_ActivityGuessRequest = M2A_ActivityGuessRequest.Create();
            M2A_ActivityGuessRequest.UnitId = unit.Id;
            M2A_ActivityGuessRequest.GuessId = request.GuessId;
            A2M_ActivityGuessResponse r_GameStatusResponse = (A2M_ActivityGuessResponse)await unit.Root().GetComponent<MessageSender>().Call
                   (activitySceneid, M2A_ActivityGuessRequest);
            if (activityV1Info.GuessIds.Contains(request.GuessId))
            {
                response.Error = ErrorCode.ERR_Already_Guess;

                return;
            }
            activityV1Info.GuessIds.Add(request.GuessId);
            unit.GetComponent<BagComponentS>().OnCostItemData(costItem);
 
            await ETTask.CompletedTask;
        }
    }
}
