using System.Collections.Generic;

namespace ET.Server
{
    [MessageHandler(SceneType.Union)]
    public class M2U_UnionWishSendHandler : MessageHandler<Scene, M2U_UnionWishSendRequest, U2M_UnionWishSendResponse>
    {
        protected override async ETTask Run(Scene scene, M2U_UnionWishSendRequest request, U2M_UnionWishSendResponse response)
        {
            Log.Warning($"M2U_UnionCreateRequest:{request.UnionId}");
           
            DBUnionInfo dBUnionInfo = await scene.GetComponent<UnionSceneComponent>().GetDBUnionInfo(request.UnionId);
            if (dBUnionInfo == null)
            {
                response.Error = ErrorCode.ERR_Union_Not_Exist;
                return;
            }

            if ( CommonHelp.GetDayByTime(TimeHelper.ServerNow()) == CommonHelp.GetDayByTime(dBUnionInfo.UnionInfo.UnionWishTime))
            {
                response.Error = ErrorCode.ERR_TimesIsNot;
                return;
            }

            if (dBUnionInfo.UnionInfo.UnionGold < ConfigData.UnionWishSendDiamondCost)
            {
                response.Error = ErrorCode.ERR_UnionGoldNotEnough;
                return;
            }

            for (int i = dBUnionInfo.UnionInfo.UnionPlayerList.Count - 1; i >= 0; i--)
            {
                UnionPlayerInfo unionPlayerInfo = dBUnionInfo.UnionInfo.UnionPlayerList[i];

                MailInfo mailInfo = MailInfo.Create();
                mailInfo.Title = "公会祝福";
                mailInfo.Context = "恭喜您!您所在得公会等级获得提升，这是公会升级的奖励!";
                
                long serverTime = TimeHelper.ServerNow();
                UnionConfig unionCof = UnionConfigCategory.Instance.Get(dBUnionInfo.UnionInfo.Level);
                string[] rewardStrList = ConfigData.UnionWishRewardForPosition[unionPlayerInfo.Position].Split('@');
                for (int item = 0; item < rewardStrList.Length; item++)
                {
                    string[] rewardList = rewardStrList[item].Split(';');
                
                    ItemInfoProto BagInfo = ItemInfoProto.Create();
                    BagInfo.ItemID = int.Parse(rewardList[0]);
                    BagInfo.ItemNum = int.Parse(rewardList[1]);
                    BagInfo. GetWay =$"{ItemGetWay.UnionUpLv}_{serverTime}";
                    mailInfo.ItemList.Add(BagInfo);
                }
                
                MailHelp.SendUserMail(scene.Root(), unionPlayerInfo.UserID, mailInfo,ItemGetWay.UnionWish).Coroutine();
            }

            dBUnionInfo.UnionInfo.UnionGold -= ConfigData.UnionWishSendDiamondCost;
            dBUnionInfo.UnionInfo.UnionWishTime = TimeHelper.ServerNow(); 
            await UnitCacheHelper.SaveComponent(scene.Root(),dBUnionInfo.Id,  dBUnionInfo);
        }
    }
}
