namespace ET.Server
{
    [MessageHandler(SceneType.Map)]
    public class C2M_SeasonDonateRewardHandler : MessageLocationHandler<Unit, C2M_SeasonDonateRewardRequest, M2C_SeasonDonateRewardResponse>
    {

        protected override async ETTask Run(Unit unit, C2M_SeasonDonateRewardRequest request, M2C_SeasonDonateRewardResponse response)
        {
            BagComponentS bagComponentS = unit.GetComponent<BagComponentS>();
            if (bagComponentS.GetBagLeftCell(ItemLocType.ItemLocBag) < 1)
            {
                response.Error = ErrorCode.ERR_BagIsFull;
                return;
            }

            if (bagComponentS.GetItemNumber(ConfigData.CommonSeasonDonateItemId) < 1)
            {
                response.Error = ErrorCode.ERR_ItemNotEnoughError;
                return;
            }
            bagComponentS.OnCostItemData($"{ConfigData.CommonSeasonDonateReward};1", ItemLocType.ItemLocBag);

            string[] itemlist = ConfigData.CommonSeasonDonateGetItem.Split('@');
            string getiteminfo = itemlist[ RandomHelper.RandomNumber(0, itemlist.Length) ];
            bagComponentS.OnAddItemData(getiteminfo, $"{ItemGetWay.Activity}_{TimeHelper.ServerNow()}");
            
            //玩家消耗1个捐献材料道具随机获得1个新道具，并增加领主值，当领主值慢时会在野外召唤领主BOSS,召唤完成后领主值清空为0,并且赛季领主升级到下一级,领主值清空，
            //总共配置10级领主，到了10级不会触发下一级会一直是10级，每级对应的领主值都不一样
            
            // NumericComponentS numericComponentS = unit.GetComponent<NumericComponentS>();
            // numericComponentS.ApplyChange( NumericType.CommonSeasonBossExp , 1 );
            //
            // long seasonbossexp = numericComponentS.GetAsLong( NumericType.SeasonBossExp );
            // int seasonbosslevel = numericComponentS.GetAsInt( NumericType.SeasonBossLevel );
            // long upneedLevel = ConfigData.CommonSeasonBossList[ seasonbosslevel ].Value;
            //
            // bool uplevel = false;    //是否升级
            // if (seasonbossexp >= upneedLevel && seasonbosslevel < ConfigData.SeasonBossList.Count)
            // {
            //     numericComponentS.ApplyChange( NumericType.SeasonBossLevel, 1 );
            //     numericComponentS.ApplyValue( NumericType.SeasonBossExp, 0 );
            //     numericComponentS.ApplyChange(NumericType.SeasonBossRefreshTime, TimeHelper.ServerNow());
            //     uplevel = true;
            // }
            //
            // MapComponent mapComponent = unit.Scene().GetComponent<MapComponent>();
            // if (uplevel && mapComponent.SceneType == SceneTypeEnum.LocalDungeon)
            // {
            //     
            //     
            // }

            await ETTask.CompletedTask;
        }
    }
}
