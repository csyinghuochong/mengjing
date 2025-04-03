namespace ET.Server
{
    [MessageHandler(SceneType.Map)]
    public class C2M_PetMeleeRewardHandler : MessageLocationHandler<Unit, C2M_PetMeleeRewardRequest, M2C_PetMeleeRewardResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_PetMeleeRewardRequest request, M2C_PetMeleeRewardResponse response)
        {
            if (!SceneConfigCategory.Instance.Contain(request.SceneId))
            {
                response.Error = ErrorCode.ERR_ModifyData;
                return;
            }

            SceneConfig sceneConfig = SceneConfigCategory.Instance.Get(request.SceneId);
            if (sceneConfig.MapType != MapTypeEnum.PetMelee)
            {
                response.Error = ErrorCode.ERR_ModifyData;
                return;
            }

            if (request.SceneId > unit.GetComponent<NumericComponentS>().GetAsInt(NumericType.PetMeleeDungeonId))
            {
                response.Error = ErrorCode.ERR_ModifyData;
                return;
            }

            PetComponentS petComponentS = unit.GetComponent<PetComponentS>();
            if (petComponentS.PetMeleeRewardIds.Contains(request.SceneId))
            {
                response.Error = ErrorCode.ERR_AlreadyReceived;
                return;
            }

            string userName = unit.GetComponent<UserInfoComponentS>().UserInfo.Name;
            Log.Warning(
                $"宠物乱斗领取奖励： 区:{unit.Zone()}   {unit.Id}   {request.SceneId}  {userName}  {unit.GetComponent<UserInfoComponentS>().UserInfo.Lv}");

            if (unit.GetComponent<BagComponentS>().OnAddItemData(sceneConfig.RewardShow, $"{ItemGetWay.PetMeleeReward}_{TimeHelper.ServerNow()}"))
            {
                petComponentS.PetMeleeRewardIds.Add(request.SceneId);
            }
            else
            {
                response.Error = ErrorCode.ERR_BagIsFull;
                return;
            }

            await ETTask.CompletedTask;
        }
    }
}