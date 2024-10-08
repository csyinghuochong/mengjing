namespace ET.Server
{
    [MessageHandler(SceneType.Map)]
    public class C2M_TalentActiveHandler : MessageLocationHandler<Unit, C2M_TalentActiveRequest, M2C_TalentActiveResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_TalentActiveRequest request, M2C_TalentActiveResponse response)
        {
            //userInfoComponentS.UserInfo.TalentPoints--; 天赋点

            UserInfoComponentS userInfoComponentS = unit.GetComponent<UserInfoComponentS>();
            SkillSetComponentS skillSetComponentS = unit.GetComponent<SkillSetComponentS>();
            int tianfuplan = skillSetComponentS.TianFuPlan + 1;
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