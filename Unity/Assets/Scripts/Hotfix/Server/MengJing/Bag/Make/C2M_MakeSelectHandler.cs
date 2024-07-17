namespace ET.Server
{
    [MessageHandler(SceneType.Map)]
    public class C2M_MakeSelectHandler: MessageLocationHandler<Unit, C2M_MakeSelectRequest, M2C_MakeSelectResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_MakeSelectRequest request, M2C_MakeSelectResponse response)
        {
            int makeTypeNumeric = request.Plan == 1? NumericType.MakeType_1 : NumericType.MakeType_2;
            int shulianduNumeric = request.Plan == 1? NumericType.MakeShuLianDu_1 : NumericType.MakeShuLianDu_2;
            int oldMakeType = unit.GetComponent<NumericComponentS>().GetAsInt(makeTypeNumeric);
            unit.GetComponent<UserInfoComponentS>().ClearMakeListByType(oldMakeType);
            unit.GetComponent<UserInfoComponentS>().UserInfo.MakeList.AddRange(MakeHelper.GetInitMakeList(request.MakeType));
            unit.GetComponent<NumericComponentS>().ApplyValue(makeTypeNumeric, request.MakeType);
            unit.GetComponent<NumericComponentS>().ApplyValue(shulianduNumeric, 0);
            unit.GetComponent<ChengJiuComponentS>().OnSkillShuLianDu(0);
            response.MakeList = unit.GetComponent<UserInfoComponentS>().UserInfo.MakeList;
            await ETTask.CompletedTask;
        }
    }
}