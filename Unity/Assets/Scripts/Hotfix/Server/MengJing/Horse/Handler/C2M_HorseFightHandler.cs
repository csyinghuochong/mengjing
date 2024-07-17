namespace ET.Server
{

    [MessageHandler(SceneType.Map)]
    public class C2M_HorseFightHandler : MessageLocationHandler<Unit, C2M_HorseFightRequest, M2C_HorseFightResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_HorseFightRequest request, M2C_HorseFightResponse response)
        {
            UserInfo userInfo = unit.GetComponent<UserInfoComponentS>().UserInfo;
            if (!userInfo.HorseIds.Contains(request.HorseId))
            {
                response.Error = ErrorCode.ERR_HoreseNotActive;
                return;
            }

            if (request.HorseId == 10001 && userInfo.Lv < 25)
            {
                response.Error = ErrorCode.ERR_EquipLvLimit;
                return;
            }

            unit.GetComponent<NumericComponentS>().ApplyValue(NumericType.HorseFightID, request.HorseId);
            await ETTask.CompletedTask;
        }
    }
}