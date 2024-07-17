namespace ET.Server
{
    [MessageHandler(SceneType.Map)]
    public class C2M_JiaYuanCookBookOpenHandler : MessageLocationHandler<Unit, C2M_JiaYuanCookBookOpen, M2C_JiaYuanCookBookOpen>
    {
        protected override async ETTask Run(Unit unit, C2M_JiaYuanCookBookOpen request, M2C_JiaYuanCookBookOpen response)
        {
            UserInfoComponentS userInfoComponent = unit.GetComponent<UserInfoComponentS>();
            ItemConfig itemCof = ItemConfigCategory.Instance.Get(request.LearnMakeId);
            long needzijin = JiaYuanHelper.GetCookBookCost(itemCof.UseLv);

            if (userInfoComponent.UserInfo.JiaYuanFund < needzijin)
            {
                response.Error = ErrorCode.ERR_HouBiNotEnough;
                return;
            }

            JiaYuanComponentS jiaYuanComponent = unit.GetComponent<JiaYuanComponentS>();
            if (jiaYuanComponent.LearnMakeIds_7.Contains(request.LearnMakeId))
            {
                response.Error = ErrorCode.ERR_AlreadyLearn;
                return;
            }

            jiaYuanComponent.LearnMakeIds_7.Add(request.LearnMakeId);
            userInfoComponent.UpdateRoleData(UserDataType.JiaYuanFund, (needzijin * -1).ToString() );
            UnitCacheHelper.SaveComponentCache(unit.Root(),  jiaYuanComponent).Coroutine();
            response.LearnMakeIds = jiaYuanComponent.LearnMakeIds_7;
            await ETTask.CompletedTask;
        }
    }
}
