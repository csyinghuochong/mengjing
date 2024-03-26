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
            
            //HintHelp.GetInstance().DataUpdate(DataType.SkillUpgrade, skillId.ToString() + "_" + m2C_SkillSet.NewSkillID.ToString());
        }
        
        public static async ETTask<bool> ChangeOccTwoRequest(Scene root, int occTwoID)
        {
            UserInfoComponentC userInfoComponent = root.GetComponent<UserInfoComponentC>();
            C2M_ChangeOccTwoRequest c2M_ChangeOccTwoRequest = new C2M_ChangeOccTwoRequest() { OccTwoID = occTwoID };
            M2C_ChangeOccTwoResponse m2C_SkillSet = (M2C_ChangeOccTwoResponse)await self.DomainScene().GetComponent<SessionComponent>().Session.Call(c2M_ChangeOccTwoRequest);

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

    }
    
}