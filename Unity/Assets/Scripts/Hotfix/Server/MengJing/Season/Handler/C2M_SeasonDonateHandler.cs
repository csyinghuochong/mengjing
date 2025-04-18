using System;
using System.Collections.Generic;

namespace ET.Server
{

    [MessageHandler(SceneType.Map)]
    public class C2M_SeasonDonateHandler : MessageLocationHandler<Unit, C2M_SeasonDonateRequest, M2C_SeasonDonateResponse>
    {

        protected override async ETTask Run(Unit unit, C2M_SeasonDonateRequest request, M2C_SeasonDonateResponse response)
        {
            using (await unit.Root().GetComponent<CoroutineLockComponent>().Wait(CoroutineLockType.Season, unit.Id))
            {
                
                BagComponentS bagComponentS = unit.GetComponent<BagComponentS>();
                if (bagComponentS.GetBagLeftCell(ItemLocType.ItemLocBag) < 1)
                {
                    response.Error = ErrorCode.ERR_BagIsFull;
                    return;
                }

                if (bagComponentS.GetItemNumber(GlobalValueConfigCategory.Instance.CommonSeasonDonateItemId) < 1)
                {
                    response.Error = ErrorCode.ERR_ItemNotEnoughError;
                    return;
                }
           
                //玩家消耗1个捐献材料道具随机获得1个新道具，并增加领主值，当领主值慢时会在野外召唤领主BOSS,召唤完成后领主值清空为0,并且赛季领主升级到下一级,领主值清空，
                //总共配置10级领主，到了10级不会触发下一级会一直是10级，每级对应的领主值都不一样

                ActorId activitySceneid = UnitCacheHelper.GetActivityServerId(unit.Zone());
                M2A_SeasonDonateRequest M2A_ActivityGuessRequest = M2A_SeasonDonateRequest.Create();
                M2A_ActivityGuessRequest.UnitID = unit.Id;
                A2M_SeasonDonateResponse r_GameStatusResponse = (A2M_SeasonDonateResponse)await unit.Root().GetComponent<MessageSender>().Call
                        (activitySceneid, M2A_ActivityGuessRequest);
                if (r_GameStatusResponse.Error != ErrorCode.ERR_Success)
                {
                    response.Error = r_GameStatusResponse.Error;
                    return;
                }
                
                bagComponentS.OnCostItemData($"{GlobalValueConfigCategory.Instance.CommonSeasonDonateItemId};1", ItemLocType.ItemLocBag);

               // string[] itemlist = 
               // string getiteminfo = itemlist[ RandomHelper.RandomNumber(0, itemlist.Length) ];
               
               int dropid = GlobalValueConfigCategory.Instance.CommonSeasonDonateGetItem;
               List<RewardItem> droplist = new List<RewardItem>();
               DropHelper.DropIDToDropItem_2(dropid, droplist);
               
                bagComponentS.OnAddItemData(droplist, String.Empty,   $"{ItemGetWay.Activity}_{TimeHelper.ServerNow()}");

                NumericComponentS numericComponentS = unit.GetComponent<NumericComponentS>();
                numericComponentS.ApplyChange(NumericType.CommonSeasonDonateTimes, 1);
                
                response.CommonSeasonBossExp = r_GameStatusResponse.CommonSeasonBossExp;
                response.CommonSeasonBossLevel = r_GameStatusResponse.CommonSeasonBossLevel;
                await ETTask.CompletedTask;
            }

        }
    }
}
