using System.Collections.Generic;

namespace ET.Client
{
    public static class SkillNetHelper
    {
        public static async ETTask RequestSkillSet(Scene root)
        {
            C2M_SkillInitRequest c2M_SkillSet = new C2M_SkillInitRequest() { };
            M2C_SkillInitResponse m2C_SkillSet = (M2C_SkillInitResponse)await root.GetComponent<ClientSenderCompnent>().Call(c2M_SkillSet);

            SkillSetComponentC skillSetComponent = root.GetComponent<SkillSetComponentC>();
            skillSetComponent.UpdateSkillSet(m2C_SkillSet.SkillSetInfo);

            EventSystem.Instance.Publish(root, new DataUpdate_SkillSetting());
        }

        //激活天赋
        public static async ETTask ActiveTianFu(Scene root, int tianfuId)
        {
            C2M_TianFuActiveRequest request = new() { TianFuId = tianfuId };
            M2C_TianFuActiveResponse response = (M2C_TianFuActiveResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);

            if (response.Error != 0)
            {
                return;
            }

            //如果有相同等级的天赋则替换
            EventSystem.Instance.Publish(root, new DataUpdate_OnActiveTianFu());
            HintHelp.ShowHint(root, "激活成功！");
        }

        //激活技能
        public static async ETTask ActiveSkillID(Scene root, int skillId)
        {
            C2M_SkillUp request = new() { SkillID = skillId };
            M2C_SkillUp response = (M2C_SkillUp)await root.GetComponent<ClientSenderCompnent>().Call(request);

            if (response.Error != 0)
                return;

            SkillSetComponentC skillSetComponent = root.GetComponent<SkillSetComponentC>();
            skillSetComponent.OnActiveSkillID(skillId, response.NewSkillID);

            EventSystem.Instance.Publish(root,
                new DataUpdate_SkillUpgrade { DataParamString = skillId + "_" + response.NewSkillID });
        }

        public static async ETTask<bool> ChangeOccTwoRequest(Scene root, int occTwoID)
        {
            UserInfoComponentC userInfoComponent = root.GetComponent<UserInfoComponentC>();
            C2M_ChangeOccTwoRequest request = new() { OccTwoID = occTwoID };
            M2C_ChangeOccTwoResponse response = (M2C_ChangeOccTwoResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);

            if (response.Error == 0)
            {
                UserInfo userInfo = userInfoComponent.UserInfo;
                userInfo.OccTwo = occTwoID;

                HintHelp.ShowHint(root, "恭喜你!转职成功");
                return true;
            }
            else
            {
                HintHelp.ShowErrorHint(root, response.Error);
                return false;
            }
        }

        public static async ETTask SetSkillIdByPosition(Scene root, int skillId, int skillType, int pos)
        {
            if (skillType == (int)SkillSetEnum.Skill && pos > 8)
                return;
            if (skillType == (int)SkillSetEnum.Item && pos <= 8)
                return;

            C2M_SkillSet request = new() { SkillID = skillId, SkillType = skillType, Position = pos };
            M2C_SkillSet response = (M2C_SkillSet)await root.GetComponent<ClientSenderCompnent>().Call(request);

            if (response.Error != 0)
                return;

            root.GetComponent<SkillSetComponentC>().OnSetSkillIdByPosition(skillId, skillType, pos);
            EventSystem.Instance.Publish(root, new DataUpdate_SkillSetting());
        }

        public static async ETTask<int> SkillOperation(Scene root, int operationType)
        {
            C2M_SkillOperation request = new() { OperationType = operationType };
            M2C_SkillOperation response = (M2C_SkillOperation)await root.GetComponent<ClientSenderCompnent>().Call(request);

            return response.Error;
        }

        public static async ETTask<int> TianFuPlan(Scene root, int tianFuPlan)
        {
            C2M_TianFuPlanRequest request = new() { TianFuPlan = tianFuPlan };
            M2C_TianFuPlanResponse response = (M2C_TianFuPlanResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);

            return response.Error;
        }

        public static async ETTask<int> MakeSelect(Scene root, int makeType, int plan)
        {
            C2M_MakeSelectRequest request = new() { MakeType = makeType, Plan = plan };
            M2C_MakeSelectResponse response = (M2C_MakeSelectResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);

            root.GetComponent<UserInfoComponentC>().UserInfo.MakeList.Clear();
            root.GetComponent<UserInfoComponentC>().UserInfo.MakeList = response.MakeList;

            return response.Error;
        }

        public static async ETTask<int> MakeEquip(Scene root, long bagInfoID, int makeId, int plan)
        {
            C2M_MakeEquipRequest request = new() { BagInfoID = bagInfoID, MakeId = makeId, Plan = plan };
            M2C_MakeEquipResponse response = (M2C_MakeEquipResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);

            if (response.ItemId == 0)
            {
                EventSystem.Instance.Publish(root, new ShowFlyTip() { Str = "制作失败!" });
            }

            if (response.NewMakeId != 0)
            {
                EquipMakeConfig equipMakeConfig = EquipMakeConfigCategory.Instance.Get(response.NewMakeId);
                ItemConfig itemConfig = ItemConfigCategory.Instance.Get(equipMakeConfig.MakeItemID);
                EventSystem.Instance.Publish(root, new ShowFlyTip() { Str = $"恭喜你领悟到新的制作技能 {itemConfig.ItemName}" });
                root.GetComponent<UserInfoComponentC>().UserInfo.MakeList.Add(response.NewMakeId);
            }

            if (bagInfoID == 0)
            {
                root.GetComponent<UserInfoComponentC>().OnMakeItem(makeId);
            }

            return response.Error;
        }

        public static async ETTask<int> ItemMelting(Scene root, List<long> operateBagID, int makeType)
        {
            C2M_ItemMeltingRequest request = new() { OperateBagID = operateBagID, MakeType = makeType };
            M2C_ItemMeltingResponse response = (M2C_ItemMeltingResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);

            return response.Error;
        }

        public static async ETTask<M2C_LifeShieldCostResponse> LifeShieldCost(Scene root, int operateType, List<long> operateBagID)
        {
            C2M_LifeShieldCostRequest request = new() { OperateType = operateType, OperateBagID = operateBagID };
            M2C_LifeShieldCostResponse response = (M2C_LifeShieldCostResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);

            return response;
        }

        public static async ETTask<M2C_MakeLearnResponse> MakeLearn(Scene root, int makeId, int plan)
        {
            C2M_MakeLearnRequest request = new() { MakeId = makeId, Plan = plan };
            M2C_MakeLearnResponse response =
                    (M2C_MakeLearnResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            if (response.Error == 0)
            {
                root.GetComponent<UserInfoComponentC>().UserInfo.MakeList.Add(makeId);
            }

            return response;
        }

        public static async ETTask<M2C_FindNearMonsterResponse> FindNearMonster(Scene root)
        {
            C2M_FindNearMonsterRequest request = new();
            M2C_FindNearMonsterResponse response = (M2C_FindNearMonsterResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);

            return response;
        }
    }
}