using System;
using System.Collections.Generic;

namespace ET.Server
{
    [FriendOf(typeof(DBCenterAccountInfo))]
    [FriendOf(typeof(FangChenMiComponent))]
    [MessageHandler(SceneType.AccountCenter)]
    public class A2Center_CheckAccountHandler : MessageHandler<Scene, A2Center_CheckAccount, Center2A_CheckAccount>
    {
        protected override async ETTask Run(Scene scene, A2Center_CheckAccount request, Center2A_CheckAccount response)
        {
            Console.WriteLine("A2Center_CheckAccount");

            DBComponent dBComponent = scene.Root().GetComponent<DBManagerComponent>().GetZoneDB(scene.Zone());
            List<DBCenterAccountInfo> centerAccountInfoList = await dBComponent.Query<DBCenterAccountInfo>(scene.Zone(), d => d.Account == request.AccountName && d.Password == request.Password);

            //手机号判断3/4
            if (centerAccountInfoList.Count == 0 && (request.ThirdLogin == "3" || request.ThirdLogin == "4"))
            {
                string Password = request.Password == "3" ? "4" : "3";
                centerAccountInfoList = await dBComponent.Query<DBCenterAccountInfo>(scene.Zone(), d => d.Account == request.AccountName && d.Password == Password);
            }
            //绑定手机号的账号
            if (centerAccountInfoList.Count == 0 && (request.ThirdLogin == "3" || request.ThirdLogin == "4"))
            {
                centerAccountInfoList = await dBComponent.Query<DBCenterAccountInfo>(scene.Zone(),
                   _account => _account.PlayerInfo != null && _account.PlayerInfo.PhoneNumber.Equals(request.AccountName));
            }

            DBCenterAccountInfo dBCenterAccountInfo = centerAccountInfoList != null && centerAccountInfoList.Count > 0 ? centerAccountInfoList[0] : null;
            response.PlayerInfo = dBCenterAccountInfo != null ? dBCenterAccountInfo.PlayerInfo : null;
            response.AccountId = dBCenterAccountInfo != null ? dBCenterAccountInfo.Id : 0;
            if (dBCenterAccountInfo != null && dBCenterAccountInfo.AccountType == (int)AccountType.Delete)
            {
                response.PlayerInfo = null;
            }
            if (response.PlayerInfo != null)
            {
                for (int i = 0; i < response.PlayerInfo.RechargeInfos.Count; i++)
                {
                    response.PlayerInfo.RechargeInfos[i].OrderInfo = string.Empty;
                }
            }
            response.IsHoliday = scene.GetComponent<FangChenMiComponent>().IsHoliday;
            response.StopServer = scene.GetComponent<FangChenMiComponent>().StopServer;

            await ETTask.CompletedTask;
        }
    }
}