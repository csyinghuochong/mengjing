using System;
using System.Collections.Generic;

namespace ET.Server
{
    [MessageHandler(SceneType.EMail)]
    public class P2E_PaiMaiOverTimeHandler : MessageHandler<Scene, P2E_PaiMaiOverTimeRequest, E2P_PaiMaiOverTimeResponse>
    {
        protected override async ETTask Run(Scene scene, P2E_PaiMaiOverTimeRequest request, E2P_PaiMaiOverTimeResponse response)
        {
            DBMailInfo dBMainInfo = await UnitCacheHelper.GetComponent<DBMailInfo>(scene.Root(), request.PaiMaiItemInfo.UserId);
            if (dBMainInfo == null)
            {
                Log.Debug($"DBMailInfo==null {request.PaiMaiItemInfo.UserId}");
                return;
            }

            long mailid = IdGenerater.Instance.GenerateId();
            dBMainInfo.MailInfoList.Add(new MailInfo() { MailId = mailid, Context = "拍卖下架", Title = "拍卖下架", ItemList = new List<BagInfo>() { request.PaiMaiItemInfo.BagInfo } });

            await UnitCacheHelper.SaveComponent(scene.Root(),  request.PaiMaiItemInfo.UserId, dBMainInfo);
        }
    }
}
