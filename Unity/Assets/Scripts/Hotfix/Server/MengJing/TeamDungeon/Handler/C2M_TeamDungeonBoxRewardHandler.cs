using System.Collections.Generic;

namespace ET.Server
{

    [MessageHandler(SceneType.Map)]
    public class C2M_TeamDungeonBoxRewardHandler : MessageLocationHandler<Unit, C2M_TeamDungeonBoxRewardRequest, M2C_TeamDungeonBoxRewardResponse>
    {
        protected override async ETTask Run(Unit unit, C2M_TeamDungeonBoxRewardRequest request, M2C_TeamDungeonBoxRewardResponse response)
        {
            Scene scene = unit.Scene();
            if (scene.InstanceId == 0 || scene.IsDisposed)
            {
                ServerLogHelper.LogDebug($"TeamDungeonBoxReward scene.InstanceId == 0 {unit.Id}");
                return;
            }

            TeamDungeonComponent teamDungeonComponent = scene.GetComponent<TeamDungeonComponent>();
            if (teamDungeonComponent == null)
            {
                ServerLogHelper.LogDebug($"TeamDungeonBoxReward scene.InstanceId == 0 {unit.Id}");
                return;
            }

            if (teamDungeonComponent.BoxReward.Contains(request.BoxIndex))
            {
                ServerLogHelper.LogDebug($"TeamDungeonBoxReward[已翻牌]: {unit.Id} {request.BoxIndex}");
                response.Error = ErrorCode.ERR_AlreadyReceived;
                return;
            }

            ServerLogHelper.LogDebug($"TeamDungeonBoxReward[可翻牌]: {unit.Id} {request.BoxIndex} {request.RewardItem.ItemID} {request.RewardItem.ItemNum}");
            teamDungeonComponent.BoxReward.Add(request.BoxIndex);

            ////背包已经直接发邮件，response加一个状态。 客户端弹窗提示“由于您背包已满通关宝箱的奖励已经自动发放进您的邮箱中,请注意查收”
            if (unit.GetComponent<BagComponentS>().GetBagLeftCell(ItemLocType.ItemLocBag) < 1)
            {
                response.Mail = 1;
                List<ItemInfoProto> bagInfos = new List<ItemInfoProto>();
                ItemInfoProto BagInfo = ItemInfoProto.Create();
                BagInfo.ItemID = request.RewardItem.ItemID;
                BagInfo. ItemNum = request.RewardItem.ItemNum;
                bagInfos.Add(BagInfo);
                MailInfo mailInfo = MailInfo.Create();
                mailInfo.Status = 0;
                mailInfo.Context = "副本奖励";
                mailInfo.Title = "副本奖励";
                mailInfo.MailId = IdGenerater.Instance.GenerateId();
                mailInfo.ItemList.AddRange(bagInfos);

                MailHelp.SendUserMail( unit.Root(), unit.Id, mailInfo, ItemGetWay.FubenGetReward).Coroutine();
            }
            else
            {
                List<RewardItem> rewardItems = new List<RewardItem>() { request.RewardItem };
                unit.GetComponent<BagComponentS>().OnAddItemData(rewardItems, "", $"{ItemGetWay.FubenGetReward}_{TimeHelper.ServerNow()}");
            }

            UserInfo userInfo = unit.GetComponent<UserInfoComponentS>().UserInfo;

            M2C_TeamDungeonBoxRewardResult m2C_HorseNoticeInfo = M2C_TeamDungeonBoxRewardResult.Create();
            m2C_HorseNoticeInfo.UserId = userInfo.UserId;
            m2C_HorseNoticeInfo.BoxIndex = request.BoxIndex;
            m2C_HorseNoticeInfo.PlayerName = userInfo.Name;
            List<Unit> allPlayer = UnitHelper.GetUnitList(unit.Scene(), UnitType.Player);
            MapMessageHelper.SendToClient(allPlayer, m2C_HorseNoticeInfo);
            
            await ETTask.CompletedTask;
        }
    }
}
