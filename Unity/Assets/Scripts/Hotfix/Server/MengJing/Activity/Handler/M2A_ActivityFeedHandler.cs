using System;
using System.Collections.Generic;

namespace ET.Server
{
    [MessageHandler(SceneType.Activity)]
    [FriendOf(typeof(ActivityServerComponent))]
    public class M2A_ActivityFeedHandler : MessageHandler<Scene, M2A_ActivityFeedRequest, A2M_ActivityFeedResponse>
    {
        protected override async ETTask Run(Scene scene, M2A_ActivityFeedRequest request, A2M_ActivityFeedResponse response)
        {
            
            ActivityServerComponent activitySceneComponent = scene.GetComponent<ActivityServerComponent>();
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

                List<BagInfo> itemList = new List<BagInfo>();
                string[] rewardItem = ConfigData.Feed1RewardList[baoshidu].Split('@');
                for (int i = 0; i < rewardItem.Length; i++)
                {
                    string[] itemInfo = rewardItem[i].Split(';');
                    itemList.Add(new BagInfo() { ItemID = int.Parse(itemInfo[0]), ItemNum = int.Parse(itemInfo[1]) });
                }

                foreach (( long unitid, int feednumber ) in activitySceneComponent.DBDayActivityInfo.FeedPlayerList)
                {
                    MailInfo mailInfo = new MailInfo();
                    mailInfo.Status = 0;
                    mailInfo.Title = "喂食奖励";
                    mailInfo.MailId = IdGenerater.Instance.GenerateId();
                    mailInfo.ItemList.AddRange(itemList);

                    E2M_EMailSendResponse g_EMailSendResponse = (E2M_EMailSendResponse)await scene.Root().GetComponent<MessageSender>().Call
                                       (mailServerId, new M2E_EMailSendRequest()
                                       {
                                           Id = unitid,
                                           MailInfo = mailInfo,
                                           GetWay = ItemGetWay.Activity,
                                       });
                }
            }
            
            response.BaoShiDu = baoshidu;
            await ETTask.CompletedTask;
        }
    }
}
