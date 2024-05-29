using System;
using System.Collections.Generic;

namespace ET.Server
{
    
    [MessageHandler(SceneType.Map)]
    public class C2M_IOSPayVerifyHandler : MessageLocationHandler<Unit, C2M_IOSPayVerifyRequest, M2C_IOSPayVerifyResponse>
    {
       
        protected override async ETTask Run(Unit unit, C2M_IOSPayVerifyRequest request, M2C_IOSPayVerifyResponse response)
        {
            //发送支付数据做验证
            Log.Warning($"IOS充值回调,收到支付请求消息:  {unit.Id}");

            //携程锁
            using (await unit.Root().GetComponent<CoroutineLockComponent>().Wait(CoroutineLockType.Recharge, unit.Id))
            {
                ActorId rechareId = UnitCacheHelper.GetRechargeCenter();

                UserInfoComponentS userInfoComponent = unit.GetComponent<UserInfoComponentS>();
                R2M_RechargeResponse r2M_RechargeResponse = (R2M_RechargeResponse)await unit.Root().GetComponent<MessageSender>().Call(rechareId, new M2R_RechargeRequest()
                {
                    Zone = unit.Zone(),
                    PayType = PayTypeEnum.IOSPay,
                    UnitId = unit.Id,
                    payMessage = request.payMessage,
                    UnitName = userInfoComponent.UserInfo.Name,
                    Account = userInfoComponent.Account,
                });
            }
            await ETTask.CompletedTask;
        }
    }
}
