﻿using System.Collections.Generic;

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
            List<int> oldtalentlist = new List<int>();
            oldtalentlist.AddRange(skillSetComponentS.TianFuList());
            int erroCode = TalentHelpter.OnTalentActive(userInfoComponentS.UserInfo.Occ,
                tianfuplan,
                request.Position,
                oldtalentlist,
                userInfoComponentS.UserInfo.Lv,
                userInfoComponentS.UserInfo.TalentPoints);

            if (erroCode == ErrorCode.ERR_Success)
            {
                skillSetComponentS.OnActiveTianfu(oldtalentlist[^1]);
            }

            response.Error = erroCode;
            await ETTask.CompletedTask;
        }
    }
}