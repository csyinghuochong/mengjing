namespace ET.Server
{

    [MessageHandler(SceneType.Map)]
    public class C2M_HorseRideHandler : MessageLocationHandler<Unit, C2M_HorseRideRequest, M2C_HorseRideResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_HorseRideRequest request, M2C_HorseRideResponse response)
        {
            NumericComponentS numericComponent = unit.GetComponent<NumericComponentS>();
            UserInfoComponentS userInfoComponent = unit.GetComponent<UserInfoComponentS>();   
            if(userInfoComponent.UserInfo.HorseIds.Count == 0)
            {
                response.Error = ErrorCode.ERR_HoreseNotActive;
                return;
            }

            int now_horse = numericComponent.GetAsInt(NumericType.HorseRide);
            if (now_horse > 0)
            {
                numericComponent.ApplyValue(NumericType.HorseRide, 0);
                return;
            }

            int horseFightID = 0;
            string svalue = userInfoComponent.GetGameSettingValue( GameSettingEnum.RandomHorese);
            if (svalue == "0")
            {
                horseFightID = numericComponent.GetAsInt(NumericType.HorseFightID);
                if (horseFightID == 0)
                {
                    response.Error = ErrorCode.ERR_HoreseNotActive;
                    return;
                }
            }
            else
            {
                int randomIndex = RandomHelper.RandomNumber(0, userInfoComponent.UserInfo.HorseIds.Count);
                horseFightID = userInfoComponent.UserInfo.HorseIds[randomIndex];
            }
            numericComponent.ApplyValue(NumericType.HorseRide, horseFightID);

            await ETTask.CompletedTask;
        }
    }
}
