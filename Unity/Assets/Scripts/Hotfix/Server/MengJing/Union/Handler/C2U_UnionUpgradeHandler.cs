
namespace ET.Server
{
    [MessageHandler(SceneType.Union)]
    public class C2U_UnionUpgradeHandler : MessageHandler<Scene, C2U_UnionUpgradeRequest, U2C_UnionUpgradeResponse>
    {
        protected override async ETTask Run(Scene scene, C2U_UnionUpgradeRequest request, U2C_UnionUpgradeResponse response)
        {
            UnionSceneComponent unionSceneComponent = scene.GetComponent<UnionSceneComponent>();

            using (await scene.Root().GetComponent<CoroutineLockComponent>().Wait(CoroutineLockType.UnionOperate, request.UnionId))
            {
                DBUnionInfo dBUnionInfo = await unionSceneComponent.GetDBUnionInfo(request.UnionId);
                if (dBUnionInfo == null)
                {
                    response.Error = ErrorCode.ERR_Union_Not_Exist;
                    return;
                }
                
                int level = dBUnionInfo.UnionInfo.Level;
                UnionConfig unionConfig = UnionConfigCategory.Instance.Get(level);
                if (dBUnionInfo.UnionInfo.Exp < unionConfig.Exp)
                {
                    response.Error = ErrorCode.ERR_ItemNotEnoughError;
                    return;
                }

                if (dBUnionInfo.UnionInfo.UnionGold < unionConfig.UnionGoldCost)
                {
                    response.Error = ErrorCode.ERR_ItemNotEnoughError;
                    return;
                }
                
                if ( !UnionConfigCategory.Instance.Contain(level + 1))
                {
                    response.Error = ErrorCode.ERR_UnionLevelMax;
                    return;
                }
                
                dBUnionInfo.UnionInfo.Level++;
                dBUnionInfo.UnionInfo.Exp -= unionConfig.Exp;
                dBUnionInfo.UnionInfo.UnionGold -= unionConfig.UnionGoldCost;
                
                MailInfo mailInfo = MailInfo.Create();
                mailInfo.Title = "公会升级";
                mailInfo.Context = "恭喜您!您所在得公会等级获得提升，这是公会升级的奖励!";
                
                long serverTime = TimeHelper.ServerNow();
                UnionConfig unionCof = UnionConfigCategory.Instance.Get(dBUnionInfo.UnionInfo.Level);
                string[] rewardStrList = unionCof.UpAllReward.Split(';');
                for (int i = 0; i < rewardStrList.Length; i++)
                {
                    string[] rewardList = rewardStrList[i].Split(',');
                
                    ItemInfoProto BagInfo = ItemInfoProto.Create();
                    BagInfo.ItemID = int.Parse(rewardList[0]);
                    BagInfo.ItemNum = int.Parse(rewardList[1]);
                    BagInfo. GetWay =$"{ItemGetWay.UnionUpLv}_{serverTime}";
                    mailInfo.ItemList.Add(BagInfo);
                }
                
                for (int i = 0; i < dBUnionInfo.UnionInfo.UnionPlayerList.Count; i++)
                {
                    MailHelp.SendUserMail(scene.Root(), dBUnionInfo.UnionInfo.UnionPlayerList[i].UserID, mailInfo,ItemGetWay.UnionUpLv).Coroutine();
                }
                
                string noticeContent = $"恭喜 <color=#{CommonHelp.QualityReturnColor(5)}>{dBUnionInfo.UnionInfo.UnionName}</color> 公会等级提升至{dBUnionInfo.UnionInfo.Level}级";
                BroadCastHelper.SendBroadMessage(scene.Root(), NoticeType.Notice, noticeContent);
 
                response.UnionMyInfo = dBUnionInfo.UnionInfo;
                await UnitCacheHelper.SaveComponent(scene.Root(),dBUnionInfo.Id,  dBUnionInfo);
            }

            await ETTask.CompletedTask;
        }
    }
}
