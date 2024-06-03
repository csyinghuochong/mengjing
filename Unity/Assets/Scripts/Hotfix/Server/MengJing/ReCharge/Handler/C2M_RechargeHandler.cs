﻿using System;

namespace ET.Server
{

    [MessageHandler(SceneType.Map)]
    public class C2M_RechargeHandler : MessageLocationHandler<Unit, C2M_RechargeRequest, M2C_RechargeResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_RechargeRequest request, M2C_RechargeResponse response)
        {
            using (await unit.Root().GetComponent<CoroutineLockComponent>().Wait(CoroutineLockType.Recharge, unit.Id))
            {
                ActorId dbCacheId = UnitCacheHelper.GetCenterServerId();
                C2C_CenterServerInfoRespone d2GGetUnit = (C2C_CenterServerInfoRespone)await unit.Root().GetComponent<MessageSender>().Call(dbCacheId, new C2C_CenterServerInfoReuest() { Zone = unit.Zone(), infoType = 1 });
                //Log.ILog.Info("d2GGetUnit.Value = " + d2GGetUnit.Value);
                if (int.Parse(d2GGetUnit.Value) != 1)
                {
                    return;
                }
                if (ComHelp.IsBanHaoZone(unit.Zone()))
                {
                    LogHelper.LogWarning($"充值[版号服]SendDiamondToUnit: {unit.Id}");
                    Console.WriteLine($"充值[版号服]SendDiamondToUnit: {unit.Id}");
                    RechargeHelp.SendDiamondToUnit(unit, request.RechargeNumber, "版号服");
                    return;
                }
                if (ComHelperS.IsInnerNet())
                {
                    RechargeHelp.SendDiamondToUnit(unit, request.RechargeNumber, "内测服");
                    return;
                }

                if (request.RechargeNumber <= 0 || ConfigHelper.GetDiamondNumber(request.RechargeNumber) <= 0)
                {
                    Log.Console($"充值作弊： 区：{unit.Zone()}  ID：{unit.Id}  rechargenumber: {request.RechargeNumber}");
                    Log.Warning($"充值作弊： 区：{unit.Zone()}  ID：{unit.Id}  rechargenumber: {request.RechargeNumber}");
                    return;
                }

                string serverName = ServerHelper.GetGetServerItem(false, unit.Zone()).ServerName;
                UserInfoComponentS userInfoComponent = unit.GetComponent<UserInfoComponentS>();
                string userName = userInfoComponent.UserInfo.Name;

                if (request.PayType == PayTypeEnum.IOSPay)
                {
                    ///IOS仅用来打印日志
                    Log.Warning($"拉起支付订单[IOS]: 服务器:{serverName} 玩家:{userName}  充值金额:{request.RechargeNumber}");
                    Log.Console($"拉起支付订单[IOS]: 服务器:{serverName} 玩家:{userName}  充值金额:{request.RechargeNumber}  时间:{TimeHelper.DateTimeNow().ToString()}");
                    return;
                }

                if (request.PayType == PayTypeEnum.WeiXinPay)
                {
                    Log.Warning($"拉起支付订单[微信支付]:服务器:{serverName} 玩家:{userName}   充值金额:{request.RechargeNumber}");
                    Log.Console($"拉起支付订单[微信支付]:服务器:{serverName} 玩家:{userName}   充值金额:{request.RechargeNumber}  时间:{TimeHelper.DateTimeNow().ToString()}");
                }

                if (request.PayType == PayTypeEnum.AliPay)
                {
                    Log.Warning($"拉起支付订单[支付宝]: 服务器:{serverName} 玩家:{userName}   充值金额:{request.RechargeNumber}");
                    Log.Console($"拉起支付订单[支付宝]: 服务器:{serverName} 玩家:{userName}   充值金额:{request.RechargeNumber}  时间:{TimeHelper.DateTimeNow().ToString()}");
                }

                if (request.PayType == PayTypeEnum.TikTok)
                {
                    Log.Warning($"拉起支付订单[TikTok]: 服务器:{serverName} 玩家:{userName}   充值金额:{request.RechargeNumber}");
                    Log.Console($"拉起支付订单[TikTok]: 服务器:{serverName} 玩家:{userName}   充值金额:{request.RechargeNumber}  时间:{TimeHelper.DateTimeNow().ToString()}");
                }

                ActorId rechareId = UnitCacheHelper.GetRechargeCenter();
              
                R2M_RechargeResponse r2M_RechargeResponse = (R2M_RechargeResponse)await unit.Root().GetComponent<MessageSender>().Call(rechareId, new M2R_RechargeRequest()
                {
                    Zone = unit.Zone(),
                    PayType = request.PayType,
                    UnitId = unit.Id,
                    UnitName = userName,
                    RechargeNumber = request.RechargeNumber,
                    Account = userInfoComponent.Account,
                    payMessage = request.RiskControlInfo,
                    ClientIp = userInfoComponent.RemoteAddress
                });

                response.Message = r2M_RechargeResponse.Message;
            }
            await ETTask.CompletedTask;
        }
    }
}
