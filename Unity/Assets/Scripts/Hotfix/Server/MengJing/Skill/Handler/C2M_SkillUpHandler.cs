using System.Collections.Generic;

namespace ET.Server
{

    [MessageLocationHandler(SceneType.Map)]
    public class C2M_SkillUpHandler : MessageLocationHandler<Unit, C2M_SkillUp, M2C_SkillUp>
    {
        protected override async ETTask Run(Unit unit, C2M_SkillUp request, M2C_SkillUp response)
        {
            SkillSetComponentS skillSetComponent = unit.GetComponent<SkillSetComponentS>();
			if (skillSetComponent.GetBySkillID(request.SkillID) == null)
			{
			    response.Error = ErrorCode.ERR_ModifyData;
			    return;
			}

			List<SkillPro> SkillList = skillSetComponent.GetSkillList();
			SkillConfig skillconf = SkillConfigCategory.Instance.Get(request.SkillID);
			int nextSkillID = skillconf.NextSkillID;
			if (nextSkillID == 0)
			{
				response.Error = ErrorCode.ERR_GoldNotEnoughError;     //错误码:技能达到最大等级
				return;
			}

			UserInfoComponentS unitInfoComponent = unit.GetComponent<UserInfoComponentS>();
			int costGoldValue = skillconf.CostGoldValue;
			int costSPValue = skillconf.CostSPValue;
			int RoseSP = unitInfoComponent.GetSp();
			if (/*unitInfoComponent.UserInfo.Gold < costGoldValue || */RoseSP < costSPValue)
			{
				response.Error = ErrorCode.ERR_GoldNotEnoughError;     //错误码:升级所需金币或者能量值不足
				return;
			}

			//替换原有技能
			for (int i = SkillList.Count - 1; i >= 0; i--)
			{
				if (SkillList[i].SkillID == request.SkillID)
				{
					SkillList[i].SkillID = nextSkillID;
					break;
				}
			}
				
			response.NewSkillID = nextSkillID;
			unit.GetComponent<UserInfoComponentS>().UpdateRoleMoneySub(UserDataType.Gold, (costGoldValue*-1).ToString(), true, ItemGetWay.CostItem);
			unit.GetComponent<UserInfoComponentS>().UpdateRoleData(UserDataType.Sp, (costSPValue * -1).ToString());

			Function_Fight.UnitUpdateProperty_Base( unit,true, true );

            await ETTask.CompletedTask;
        }
    }
}

