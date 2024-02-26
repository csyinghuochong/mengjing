using System;
using System.Collections.Generic;

namespace ET.Server
{
    [MessageLocationHandler(SceneType.Map)]
    public class C2M_GMCommandHandler: MessageLocationHandler<Unit, C2M_GMCommand>
    {
        protected override async ETTask Run(Unit unit, C2M_GMCommand message)
        {
            try
            {
                if (!GMHelp.IsGmAccount(message.Account)
                    && !ComHelp.IsBanHaoZone(unit.Zone()))
                {
                    return;
                }

                string[] commands = message.GMMsg.Split('#');
                if (commands.Length == 0)
                {
                    return;
                }

                switch (int.Parse(commands[0]))
                {
                    case 1: //新增道具1#12000003#200 【添加道具/道具id/道具数量】
                        int itemId = int.Parse(commands[1]);
                        int itemNumber = int.Parse(commands[2]);

                        // List<RewardItem> rewardItems = new List<RewardItem>();
                        // rewardItems.Add(new RewardItem() { ItemID = itemId, ItemNum = itemNumber });
                        // unit.GetComponent<BagComponentServer>()
                        //         .OnAddItemData(rewardItems, string.Empty, $"{ItemGetWay.GM}_{TimeHelper.ServerNow()}", true, true);
                        break;

                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                Log.Debug(ex.ToString());
            }

            await ETTask.CompletedTask;
        }
    }
}