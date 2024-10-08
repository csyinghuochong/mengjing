namespace ET.Server
{
    [MessageHandler(SceneType.Map)]
    public class C2M_TalentActiveHandler : MessageLocationHandler<Unit, C2M_TalentActiveRequest, M2C_TalentActiveResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_TalentActiveRequest request, M2C_TalentActiveResponse response)
        {
            UserInfoComponentS userInfoComponentS = unit.GetComponent<UserInfoComponentS>();
            SkillSetComponentS skillSetComponentS = unit.GetComponent<SkillSetComponentS>();
            int tianfuplan = skillSetComponentS.TianFuPlan + 1;

            // 天赋点
            // int talentid = TalentHelpter.GetTalentIdByPosition(request.Position, skillSetComponentS.TianFuList());
            // int nextid = TalentHelpter.GetTalentNextId(userInfoComponentS.UserInfo.Occ, tianfuplan, request.Position, talentid);
            // if (nextid != 0)
            // {
            //     TalentConfig talentConfig = TalentConfigCategory.Instance.Get(nextid);
            //     if (userInfoComponentS.UserInfo.TalentPoints >= talentConfig.NeedUseNumber)
            //     {
            //         userInfoComponentS.UpdateRoleData(UserDataType.TalentPoints, (-talentConfig.NeedUseNumber).ToString());
            //     }
            //     else
            //     {
            //         response.Error = ErrorCode.ERR_TalentPointNot;
            //         return;
            //     }
            // }

            int erroCode = TalentHelpter.OnTalentActive(userInfoComponentS.UserInfo.Occ,
                tianfuplan,
                request.Position,
                skillSetComponentS.TianFuList());

            if (erroCode == ErrorCode.ERR_Success)
            {
                skillSetComponentS.UpdateSkillSet();
            }

            response.Error = erroCode;
            await ETTask.CompletedTask;
        }
    }
}