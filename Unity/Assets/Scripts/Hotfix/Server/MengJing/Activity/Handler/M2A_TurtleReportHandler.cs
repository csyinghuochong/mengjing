using System.Collections.Generic;

namespace ET.Server
{
    [MessageHandler(SceneType.Activity)]
    [FriendOf(typeof(ActivitySceneComponent))]
    public class M2A_TurtleReportHandler : MessageHandler<Scene, M2A_TurtleReportRequest, A2M_TurtleReportResponse>
    {
        protected override async ETTask Run(Scene scene, M2A_TurtleReportRequest request, A2M_TurtleReportResponse response)
        {
            DBDayActivityInfo dBDayActivityInfo = scene.GetComponent<ActivitySceneComponent>().DBDayActivityInfo;
            if (dBDayActivityInfo.TurtleWinTimes.Count < 3)
            {
                dBDayActivityInfo.TurtleWinTimes = new List<int> { 0,0,0 };
            }
            
            int index = ConfigData.TurtleList.IndexOf( request.TurtleId );
            if (index != -1)
            {
                dBDayActivityInfo.TurtleWinTimes[index]++;
            }

            //发竞猜邮件
            List<KeyValuePair<long, long>>  playerids = null;
            scene.GetComponent<ActivitySceneComponent>().TurtleSupportList.TryGetValue(request.TurtleId, out playerids);
            if (playerids != null)
            {
                MailInfo mailInfo = MailInfo.Create();
                mailInfo.Status = 0;
                mailInfo.Context = "小龟竞猜奖励";
                mailInfo.Title = "小龟竞猜奖励";
                mailInfo.MailId = IdGenerater.Instance.GenerateId();

                string[] needList = GlobalValueConfigCategory.Instance.Get(97).Value.Split('@');
                for (int k = 0; k < needList.Length; k++)
                {
                    string[] itemInfo = needList[k].Split(';');
                    if (itemInfo.Length < 2)
                    {
                        continue;
                    }
                    int itemId = int.Parse(itemInfo[0]);
                    int itemNum = int.Parse(itemInfo[1]);
                    ItemInfoProto BagInfo = ItemInfoProto.Create();
                    BagInfo.ItemID = itemId;
                    BagInfo.ItemNum = itemNum;
                    BagInfo.GetWay = $"{ItemGetWay.Turtle}_{TimeHelper.ServerNow()}";
                    mailInfo.ItemList.Add(BagInfo);
                }

                for (int i = 0; i < playerids.Count; i++)
                {
                    MailHelp.SendUserMail(scene.Root(), playerids[i].Value, mailInfo,ItemGetWay.Turtle).Coroutine();
                }
            }
            
            await ETTask.CompletedTask;
        }
    }
}
