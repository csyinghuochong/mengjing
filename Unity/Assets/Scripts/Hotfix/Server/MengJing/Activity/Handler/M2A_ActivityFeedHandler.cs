using System.Collections.Generic;

namespace ET.Server
{
    [MessageHandler(SceneType.Activity)]
    [FriendOf(typeof(ActivitySceneComponent))]
    public class M2A_ActivityFeedHandler : MessageHandler<Scene, M2A_ActivityFeedRequest, A2M_ActivityFeedResponse>
    {
        protected override async ETTask Run(Scene scene, M2A_ActivityFeedRequest request, A2M_ActivityFeedResponse response)
        {
            
            ActivitySceneComponent activitySceneComponent = scene.GetComponent<ActivitySceneComponent>();
            if (!activitySceneComponent.DBDayActivityInfo.FeedPlayerList.ContainsKey(request.UnitID))
            {
                activitySceneComponent.DBDayActivityInfo.FeedPlayerList.Add( request.UnitID, 0 );
            }
            activitySceneComponent.DBDayActivityInfo.FeedPlayerList[request.UnitID]++;
            int baoshidu = ++activitySceneComponent.DBDayActivityInfo.BaoShiDu;

            if (ConfigData.Feed1RewardList.ContainsKey(baoshidu) 
                && baoshidu > activitySceneComponent.DBDayActivityInfo.FeedRewardKey )
            {
                ///发送饱食度奖励
                activitySceneComponent.DBDayActivityInfo.FeedRewardKey = baoshidu;

                ActorId mailServerId = UnitCacheHelper.GetMailServerId(scene.Zone());

                List<ItemInfoProto> itemList = new List<ItemInfoProto>();
                string[] rewardItem = ConfigData.Feed1RewardList[baoshidu].Split('@');
                for (int i = 0; i < rewardItem.Length; i++)
                {
                    string[] itemInfo = rewardItem[i].Split(';');
                    ItemInfoProto BagInfo = ItemInfoProto.Create();
                    BagInfo.ItemID = int.Parse(itemInfo[0]);
                    BagInfo.ItemNum = int.Parse(itemInfo[1]);
                    itemList.Add( BagInfo );
                }

                foreach (( long unitid, int feednumber ) in activitySceneComponent.DBDayActivityInfo.FeedPlayerList)
                {
                    MailInfo mailInfo = MailInfo.Create();
                    mailInfo.Status = 0;
                    mailInfo.Title = "喂食奖励";
                    mailInfo.MailId = IdGenerater.Instance.GenerateId();
                    mailInfo.ItemList.AddRange(itemList);

                    MailHelp.SendUserMail( scene.Root(), unitid,  mailInfo, ItemGetWay.Activity).Coroutine();
                }
            }
            
            response.BaoShiDu = baoshidu;
            await ETTask.CompletedTask;
        }
    }
}
