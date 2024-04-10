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
            C2M_TianFuActiveRequest c2M_SkillSet = new C2M_TianFuActiveRequest() { TianFuId = tianfuId };
            M2C_TianFuActiveResponse m2C_SkillSet = (M2C_TianFuActiveResponse)await root.GetComponent<ClientSenderCompnent>().Call(c2M_SkillSet);

            if (m2C_SkillSet.Error != 0)
            {
                return;
            }

            EventSystem.Instance.Publish(root, new DataUpdate_OnActiveTianFu());
            //如果有相同等级的天赋则替换
            //HintHelp.GetInstance().DataUpdate(DataType.OnActiveTianFu);
            //HintHelp.GetInstance().ShowHint("激活成功！");
        }

        //激活技能
        public static async ETTask ActiveSkillID(Scene root, int skillId)
        {
            C2M_SkillUp c2M_SkillSet = new C2M_SkillUp() { SkillID = skillId };
            M2C_SkillUp m2C_SkillSet = (M2C_SkillUp)await root.GetComponent<ClientSenderCompnent>().Call(c2M_SkillSet);

            if (m2C_SkillSet.Error != 0)
                return;

            SkillSetComponentC skillSetComponent = root.GetComponent<SkillSetComponentC>();
            skillSetComponent.OnActiveSkillID(skillId, m2C_SkillSet.NewSkillID);

            EventSystem.Instance.Publish(root,
                new DataUpdate_SkillUpgrade { DataParamString = skillId + "_" + m2C_SkillSet.NewSkillID });
        }

        public static async ETTask<bool> ChangeOccTwoRequest(Scene root, int occTwoID)
        {
            UserInfoComponentC userInfoComponent = root.GetComponent<UserInfoComponentC>();
            C2M_ChangeOccTwoRequest c2M_ChangeOccTwoRequest = new C2M_ChangeOccTwoRequest() { OccTwoID = occTwoID };
            M2C_ChangeOccTwoResponse m2C_SkillSet =
                    (M2C_ChangeOccTwoResponse)await root.GetComponent<ClientSenderCompnent>().Call(c2M_ChangeOccTwoRequest);

            if (m2C_SkillSet.Error == 0)
            {
                UserInfo userInfo = userInfoComponent.UserInfo;
                userInfo.OccTwo = occTwoID;

                //飘字
                //HintHelp.GetInstance().ShowHint("恭喜你!转职成功");
                return true;
            }
            else
            {
                //HintHelp.GetInstance().ShowErrHint(m2C_SkillSet.Error);
                return false;
            }
        }

        public static async ETTask SetSkillIdByPosition(Scene root, int skillId, int skillType, int pos)
        {
            if (skillType == (int)SkillSetEnum.Skill && pos > 8)
                return;
            if (skillType == (int)SkillSetEnum.Item && pos <= 8)
                return;

            C2M_SkillSet c2M_SkillSet = new C2M_SkillSet() { SkillID = skillId, SkillType = skillType, Position = pos };
            M2C_SkillSet m2C_SkillSet = (M2C_SkillSet)await root.GetComponent<ClientSenderCompnent>().Call(c2M_SkillSet);

            if (m2C_SkillSet.Error != 0)
                return;

            root.GetComponent<SkillSetComponentC>().OnSetSkillIdByPosition(skillId, skillType, pos);
            EventSystem.Instance.Publish(root, new DataUpdate_SkillSetting());
        }

        public static async ETTask<int> SkillOperation(Scene root, int operationType)
        {
            C2M_SkillOperation request = new() { OperationType = operationType };
            M2C_SkillOperation response =
                    (M2C_SkillOperation)await root.GetComponent<ClientSenderCompnent>().Call(request);

            return response.Error;
        }

        public static async ETTask<int> TianFuPlan(Scene root, int tianFuPlan)
        {
            C2M_TianFuPlanRequest request = new() { TianFuPlan = tianFuPlan };
            M2C_TianFuPlanResponse response =
                    (M2C_TianFuPlanResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);

            return response.Error;
        }

        public static async ETTask<int> MakeSelect(Scene root, int makeType, int plan)
        {
            C2M_MakeSelectRequest request = new() { MakeType = makeType, Plan = plan };
            M2C_MakeSelectResponse response =
                    (M2C_MakeSelectResponse)await root.GetComponent<ClientSenderCompnent>().Call(request);

            root.GetComponent<UserInfoComponentC>().UserInfo.MakeList.Clear();
            root.GetComponent<UserInfoComponentC>().UserInfo.MakeList = response.MakeList;

            return response.Error;
        }
    }
}