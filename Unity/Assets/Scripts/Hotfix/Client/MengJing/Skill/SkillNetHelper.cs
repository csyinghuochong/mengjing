using System.Collections.Generic;

namespace ET.Client
{
    public static class SkillNetHelper
    {
        public static async ETTask RequestSkillSet(Scene root)
        {
            C2M_SkillInitRequest request = C2M_SkillInitRequest.Create();

            M2C_SkillInitResponse response = (M2C_SkillInitResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);

            SkillSetComponentC skillSetComponent = root.GetComponent<SkillSetComponentC>();
            skillSetComponent.UpdateSkillSet(response.SkillSetInfo);

            EventSystem.Instance.Publish(root, new SkillSetting());
        }

        //激活天赋
        public static async ETTask ActiveTianFu(Scene root, int tianfuId)
        {
            C2M_TianFuActiveRequest request = C2M_TianFuActiveRequest.Create();
            request.TianFuId = tianfuId;

            M2C_TianFuActiveResponse response = (M2C_TianFuActiveResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);

            if (response.Error != 0)
            {
                return;
            }

            //如果有相同等级的天赋则替换
            EventSystem.Instance.Publish(root, new OnActiveTianFu());
            HintHelp.ShowHint(root, "激活成功！");
        }

        //激活技能
        public static async ETTask ActiveSkillID(Scene root, int skillId)
        {
            C2M_SkillUp request = C2M_SkillUp.Create();
            request.SkillID = skillId;

            M2C_SkillUp response = (M2C_SkillUp)await root.GetComponent<ClientSenderCompnent>().Call(request);

            if (response.Error != 0)
                return;

            SkillSetComponentC skillSetComponent = root.GetComponent<SkillSetComponentC>();
            skillSetComponent.OnActiveSkillID(skillId, response.NewSkillID);

            EventSystem.Instance.Publish(root,
                new SkillUpgrade { DataParamString = skillId + "_" + response.NewSkillID });
        }

        public static async ETTask<bool> ChangeOccTwoRequest(Scene root, int occTwoID)
        {
            UserInfoComponentC userInfoComponent = root.GetComponent<UserInfoComponentC>();
            C2M_ChangeOccTwoRequest request = C2M_ChangeOccTwoRequest.Create();
            request.OccTwoID = occTwoID;

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

            C2M_SkillSet request = C2M_SkillSet.Create();
            request.SkillID = skillId;
            request.SkillType = skillType;
            request.Position = pos;

            M2C_SkillSet response = (M2C_SkillSet)await root.GetComponent<ClientSenderCompnent>().Call(request);

            if (response.Error != 0)
                return;

            root.GetComponent<SkillSetComponentC>().OnSetSkillIdByPosition(skillId, skillType, pos);
            EventSystem.Instance.Publish(root, new SkillSetting());
        }

        public static async ETTask<int> SkillOperation(Scene root, int operationType)
        {
            C2M_SkillOperation request = C2M_SkillOperation.Create();
            request.OperationType = operationType;

            M2C_SkillOperation response = (M2C_SkillOperation)await root.GetComponent<ClientSenderCompnent>().Call(request);

            return response.Error;
        }

        public static async ETTask<int> TianFuPlan(Scene root, int tianFuPlan)
        {
            C2M_TianFuPlanRequest request = C2M_TianFuPlanRequest.Create();
            request.TianFuPlan = tianFuPlan;

            M2C_TianFuPlanResponse response = (M2C_TianFuPlanResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);

            return response.Error;
        }

        public static async ETTask<int> MakeSelect(Scene root, int makeType, int plan)
        {
            C2M_MakeSelectRequest request = C2M_MakeSelectRequest.Create();
            request.MakeType = makeType;
            request.Plan = plan;

            M2C_MakeSelectResponse response = (M2C_MakeSelectResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);

            root.GetComponent<UserInfoComponentC>().UserInfo.MakeList.Clear();
            root.GetComponent<UserInfoComponentC>().UserInfo.MakeList = response.MakeList;

            return response.Error;
        }
        
        public static async ETTask<int> MakeReset(Scene root, int plan)
        {
            C2M_MakeResetRequest request = C2M_MakeResetRequest.Create();
            request.Plan = plan;

            M2C_MakeResetResponse response = (M2C_MakeResetResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);

            root.GetComponent<UserInfoComponentC>().UserInfo.MakeList.Clear();
            root.GetComponent<UserInfoComponentC>().UserInfo.MakeList = response.MakeList;
            
            return response.Error;
        }

        public static async ETTask<int> MakeEquip(Scene root, long bagInfoID, int makeId, int plan)
        {
            C2M_MakeEquipRequest request = C2M_MakeEquipRequest.Create();
            request.BagInfoID = bagInfoID;
            request.MakeId = makeId;
            request.Plan = plan;

            M2C_MakeEquipResponse response = (M2C_MakeEquipResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);

            if (response.ItemId == 0)
            {
                HintHelp.ShowHint(root, "制作失败!");
            }

            if (response.NewMakeId != 0)
            {
                EquipMakeConfig equipMakeConfig = EquipMakeConfigCategory.Instance.Get(response.NewMakeId);
                ItemConfig itemConfig = ItemConfigCategory.Instance.Get(equipMakeConfig.MakeItemID);
                HintHelp.ShowHint(root, $"恭喜你领悟到新的制作技能 {itemConfig.ItemName}");
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
            C2M_ItemMeltingRequest request = C2M_ItemMeltingRequest.Create();
            request.OperateBagID = operateBagID;
            request.MakeType = makeType;

            M2C_ItemMeltingResponse response = (M2C_ItemMeltingResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);

            return response.Error;
        }

        public static async ETTask<M2C_LifeShieldCostResponse> LifeShieldCost(Scene root, int operateType, List<long> operateBagID)
        {
            C2M_LifeShieldCostRequest request = C2M_LifeShieldCostRequest.Create();
            request.OperateType = operateType;
            request.OperateBagID = operateBagID;

            M2C_LifeShieldCostResponse response = (M2C_LifeShieldCostResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);

            return response;
        }

        public static async ETTask<M2C_MakeLearnResponse> MakeLearn(Scene root, int makeId, int plan)
        {
            C2M_MakeLearnRequest request = C2M_MakeLearnRequest.Create();
            request.MakeId = makeId;
            request.Plan = plan;

            M2C_MakeLearnResponse response = (M2C_MakeLearnResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);
            if (response.Error == 0)
            {
                root.GetComponent<UserInfoComponentC>().UserInfo.MakeList.Add(makeId);
            }

            return response;
        }

        public static async ETTask<M2C_FindNearMonsterResponse> FindNearMonster(Scene root)
        {
            C2M_FindNearMonsterRequest request = C2M_FindNearMonsterRequest.Create();

            M2C_FindNearMonsterResponse response = (M2C_FindNearMonsterResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);

            return response;
        }

        public static async ETTask<int> SkillJueXingRequest(Scene root, int jueXingId)
        {
            C2M_SkillJueXingRequest request = C2M_SkillJueXingRequest.Create();
            request.JueXingId = jueXingId;
            M2C_SkillJueXingResponse response = (M2C_SkillJueXingResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);

            return response.Error;
        }

        public static async ETTask<int> TalentActiveRequest(Scene root, int position)
        {
            C2M_TalentActiveRequest request = C2M_TalentActiveRequest.Create();
            request.Position = position;
            M2C_TalentActiveResponse response = (M2C_TalentActiveResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);

            return response.Error;
        }

        public static async ETTask<int> TalentReSetRequest(Scene root)
        {
            C2M_TalentReSetRequest request = C2M_TalentReSetRequest.Create();

            M2C_TalentReSetResponse response = (M2C_TalentReSetResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);

            return response.Error;
        }
    }
}