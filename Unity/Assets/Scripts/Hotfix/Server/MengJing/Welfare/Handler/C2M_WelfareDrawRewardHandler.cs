namespace ET.Server
{
    [MessageHandler(SceneType.Map)]
    public class C2M_WelfareDrawRewardHandler : MessageLocationHandler<Unit, C2M_WelfareDrawRewardRequest, M2C_WelfareDrawRewardResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_WelfareDrawRewardRequest request, M2C_WelfareDrawRewardResponse response)
        {
            if (unit.GetComponent<NumericComponentS>().GetAsInt(NumericType.DrawReward) == 1)
            {
                Log.Error($"C2M_WelfareDrawRewardRequest 1");
                response.Error = ErrorCode.ERR_ModifyData;
                return;
            }
            
            int index = unit.GetComponent<NumericComponentS>().GetAsInt(NumericType.DrawIndex);
            if (index == 0 || index > ConfigData.WelfareDrawList.Count)
            {
                return;
            }


            string reward = ConfigData.WelfareDrawList[index - 1].Value;
            if (index == 7)
            { 
                UserInfoComponentS userInfoComponent = unit.GetComponent<UserInfoComponentS>();
                int weaponId = CommonHelp.GetWelfareWeapon( userInfoComponent.UserInfo.Occ, userInfoComponent.UserInfo.OccTwo );
                reward = $"{weaponId};1";
            }

            unit.GetComponent<BagComponentS>().OnAddItemData(  reward, $"{ItemGetWay.Welfare}_{TimeHelper.ServerNow()}");
            unit.GetComponent<NumericComponentS>().ApplyValue(NumericType.DrawReward, 1);
            await ETTask.CompletedTask;
        }
    }
}
