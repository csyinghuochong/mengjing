using System;

namespace ET.Server
{
    [MessageHandler(SceneType.Union)]
    public class U2M_UnionKeJiQuickHandler : MessageHandler<Unit, U2M_UnionKeJiQuickRequest, M2U_UnionKeJiQuickResponse>
    {
        protected override async ETTask Run(Unit unit, U2M_UnionKeJiQuickRequest request, M2U_UnionKeJiQuickResponse response)
        {
            if (unit.GetComponent<UserInfoComponentS>().UserInfo.Diamond <= request.Cost)
            {
                response.Error = ErrorCode.ERR_DiamondNotEnoughError;

                return;
            }

            unit.GetComponent<UserInfoComponentS>().UpdateRoleMoneySub(UserDataType.Diamond, $"-{request.Cost}", true, ItemGetWay.UnionXiuLian);


            await ETTask.CompletedTask;
        }
    }
}
