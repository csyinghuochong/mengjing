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
            MailInfo MailInfo = MailInfo.Create();
            MailInfo.MailId = mailid;
            MailInfo.Context = "拍卖下架";
            MailInfo.Title = "拍卖下架";
            MailInfo.ItemList.Clear();
            MailInfo.ItemList.Add(request.PaiMaiItemInfo.BagInfo);
            dBMainInfo.MailInfoList.Add(MailInfo);

            await UnitCacheHelper.SaveComponent(scene.Root(),  request.PaiMaiItemInfo.UserId, dBMainInfo);
        }
    }
}
