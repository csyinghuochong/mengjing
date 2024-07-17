namespace ET.Server
{

    [MessageHandler(SceneType.Map)]
    public class C2M_TurtleRecordHandler : MessageLocationHandler<Unit, C2M_TurtleRecordRequest, M2C_TurtleRecordResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_TurtleRecordRequest request, M2C_TurtleRecordResponse response)
        {
            ActorId ctivtiyserverid = UnitCacheHelper.GetActivityServerId(unit.Zone());
            M2A_TurtleRecordRequest m2A_TurtleRecord = M2A_TurtleRecordRequest.Create();
            m2A_TurtleRecord.AccountId = unit.GetComponent<UserInfoComponentS>().UserInfo.AccInfoID;
  
            A2M_TurtleRecordResponse a2M_TurtleSupport = (A2M_TurtleRecordResponse)await unit.Root().GetComponent<MessageSender>().Call
                        (ctivtiyserverid, m2A_TurtleRecord);

            response.WinTimes = a2M_TurtleSupport.WinTimes;
            response.SupportId = a2M_TurtleSupport. SupportId;
            response.SupportTimes = a2M_TurtleSupport.SupportTimes; 

            await ETTask.CompletedTask;
        }
    }
}
