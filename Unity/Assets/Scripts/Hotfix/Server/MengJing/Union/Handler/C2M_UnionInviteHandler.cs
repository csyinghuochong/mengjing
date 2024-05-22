using System;
using System.Collections.Generic;

namespace ET.Server
{

    [MessageLocationHandler(SceneType.Map)]
    public class C2M_UnionInviteHandler : MessageLocationHandler<Unit, C2M_UnionInviteRequest>
    {
        protected override async ETTask Run(Unit unit, C2M_UnionInviteRequest message)
        {
            Unit beinvite = unit.GetParent<UnitComponent>().Get(message.InviteId);

            UserInfo userInfo = unit.GetComponent<UserInfoComponentS>().UserInfo;
            if (string.IsNullOrEmpty(userInfo.UnionName))
            {
                return;
            }
            long unionid = unit.GetComponent<NumericComponentS>().GetAsLong( NumericType.UnionId_0 );
            if (unionid == 0)
            {
                return;
            }

            if (beinvite != null)
            {
                if (beinvite.GetComponent<NumericComponentS>().GetAsLong(NumericType.UnionId_0) != 0)
                {
                    return;
                }

                MapMessageHelper.SendToClient(beinvite, new M2C_UnionInviteMessage()
                { 
                    UnionId = unionid,
                    UnionName = userInfo.UnionName,
                    PlayerName = userInfo.Name,
                });
            }
            await ETTask.CompletedTask;
        }
    }
}
