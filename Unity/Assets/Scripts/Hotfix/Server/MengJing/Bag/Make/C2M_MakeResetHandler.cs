namespace ET.Server
{
        [MessageHandler(SceneType.Map)]
    public class C2M_MakeResetHandler: MessageLocationHandler<Unit, C2M_MakeResetRequest, M2C_MakeResetResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_MakeResetRequest request, M2C_MakeResetResponse response)
        {
            int makeTypeNumeric = request.Plan == 1? NumericType.MakeType_1 : NumericType.MakeType_2;
            int shulianduNumeric = request.Plan == 1? NumericType.MakeShuLianDu_1 : NumericType.MakeShuLianDu_2;
            int oldMakeType = unit.GetComponent<NumericComponentS>().GetAsInt(makeTypeNumeric);
            unit.GetComponent<UserInfoComponentS>().ClearMakeListByType(oldMakeType);
            // unit.GetComponent<UserInfoComponentS>().UserInfo.MakeList.AddRange(MakeHelper.GetInitMakeList(request.MakeType));
            unit.GetComponent<NumericComponentS>().ApplyValue(makeTypeNumeric, 0);
            unit.GetComponent<NumericComponentS>().ApplyValue(shulianduNumeric, 0);
            unit.GetComponent<ChengJiuComponentS>().OnSkillShuLianDu(0);
            response.MakeList = unit.GetComponent<UserInfoComponentS>().UserInfo.MakeList;

            await ETTask.CompletedTask;
        }
    }
}