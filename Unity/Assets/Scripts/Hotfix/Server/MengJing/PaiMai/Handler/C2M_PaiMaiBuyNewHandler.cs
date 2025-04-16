using System;
using System.Collections.Generic;
using Unity.Mathematics;

namespace ET.Server
{
    [MessageLocationHandler(SceneType.Map)]
    public class C2M_PaiMaiBuyNewHandler : MessageLocationHandler<Unit, C2M_PaiMaiBuyNewRequest, M2C_PaiMaiBuyNewResponse>
    {

		protected override async ETTask Run(Unit unit, C2M_PaiMaiBuyNewRequest request, M2C_PaiMaiBuyNewResponse response)
		{
              //背包是否有位置
            if (unit.GetComponent<BagComponentS>().GetBagLeftCell(ItemLocType.ItemLocBag) < 1)
            {
                response.Error = ErrorCode.ERR_BagIsFull;
                return;
            }

            if (request.PaiMaiItemInfoId == 0 ||request.ItemId == 0 )
            {
                response.Error = ErrorCode.ERR_ItemNotExist;
                return;
            }

            ItemConfig itemConfig = ItemConfigCategory.Instance.Get(request.ItemId );
            int cell = (int)math.ceil(request.ItemNum * 1f / itemConfig.ItemPileSum);
            if (unit.GetComponent<BagComponentS>().GetBagLeftCell(ItemLocType.ItemLocBag) < cell)
            {
                response.Error = ErrorCode.ERR_BagIsFull;
                return;
            }

            int buyNum = 0;
            if (request.BuyNum < 0 || request.BuyNum > request.ItemNum)
            {
                Log.Error($"C2M_PaiMaiBuyRequest 1");
                response.Error = ErrorCode.ERR_ModifyData;
                return;
            }
            else if (request.BuyNum == 0)
            {
                buyNum = request.ItemNum;
            }
            else
            {
                buyNum = request.BuyNum;
            }

            request.BuyNum = buyNum;
            
            long needGold = (long)request.Price * buyNum;
            if (request.ItemNum < 0 || needGold < 0)
            {
                response.Error = ErrorCode.ERR_GoldNotEnoughError;
                return;
            }

            //钱是否足够
            if (unit.GetComponent<UserInfoComponentS>().UserInfo.Gold < needGold)
            {
                response.Error = ErrorCode.ERR_GoldNotEnoughError;
                return;
            }

            bool firstDay = false;
            int openPaiMai = unit.GetComponent<NumericComponentS>().GetAsInt(NumericType.PaiMaiOpen);

            if (openPaiMai == 0)
            {
                UserInfoComponentS userInfoComponent = unit.GetComponent<UserInfoComponentS>();
                int createDay = userInfoComponent.GetCrateDay();

                //firstDay = createDay <= 1 && userInfoComponent.UserInfo.Lv <= 10;
                request.IsRecharge = unit.GetComponent<NumericComponentS>().GetAsInt(NumericType.RechargeNumber);

                if (request.IsRecharge > 0
                    || CommonHelp.IsCanPaiMai_KillBoss(userInfoComponent.UserInfo.MonsterRevives, userInfoComponent.UserInfo.Lv)
                    || CommonHelp.IsCanPaiMai_Level(createDay, userInfoComponent.UserInfo.Lv) == 0)
                {
                    openPaiMai = 1;
                    unit.GetComponent<NumericComponentS>().ApplyValue(NumericType.PaiMaiOpen, 1);
                }
            }

            if (!firstDay && openPaiMai == 0)
            {
                response.Error = ErrorCode.Pre_Condition_Error;
                return;
            }
            
             using (await unit.Root().GetComponent<CoroutineLockComponent>().Wait(CoroutineLockType.Buy, unit.Id))
            {
                ActorId paimaiServerId = UnitCacheHelper.GetPaiMaiServerId( unit.Zone() );
                M2P_PaiMaiBuyNewRequest M2P_PaiMaiBuyRequest = M2P_PaiMaiBuyNewRequest.Create();
             
                M2P_PaiMaiBuyRequest.Gold = unit.GetComponent<UserInfoComponentS>().UserInfo.Gold;
                M2P_PaiMaiBuyRequest.BuyNum = buyNum;
                M2P_PaiMaiBuyRequest.PaiMaiItemInfoId = request.PaiMaiItemInfoId;
                M2P_PaiMaiBuyRequest.ItemId = request.ItemId;
                M2P_PaiMaiBuyRequest.ItemNum = request.ItemNum;
                M2P_PaiMaiBuyRequest.Price = request.Price;
                M2P_PaiMaiBuyRequest.UnitId = unit.Id;

                P2M_PaiMaiBuyNewResponse r_GameStatusResponse = (P2M_PaiMaiBuyNewResponse)await unit.Root().GetComponent<MessageSender>().Call
                    (paimaiServerId, M2P_PaiMaiBuyRequest);
                if (r_GameStatusResponse.Error != ErrorCode.ERR_Success)
                {
                    response.Error = r_GameStatusResponse.Error;
                    return;
                }

                needGold = (long)request.Price * request.BuyNum;
               
                unit.GetComponent<UserInfoComponentS>().UpdateRoleMoneySub(UserDataType.Gold, (needGold * -1).ToString(), true, ItemGetWay.PaiMaiBuy);
                //背包添加道具
                unit.GetComponent<BagComponentS>().OnAddItemData(r_GameStatusResponse.ItemInfo, $"{ItemGetWay.PaiMaiBuy}_{TimeHelper.ServerNow()}");
                
                //给出售者邮件发送金币
                MailHelp.SendPaiMaiEmail(unit.Root(), r_GameStatusResponse.ItemInfo, request.Price, request.BuyNum, unit.Id);
                
                unit.GetComponent<DataCollationComponent>().PaiMaiCostGoldToday += needGold;
                if (unit.GetComponent<DataCollationComponent>().PaiMaiCostGoldToday >= 50000000)
                {
                    UserInfoComponentS userInfoComponent = unit.GetComponent<UserInfoComponentS>();
                    string levelInfo = $"区： {unit.Zone()}  {userInfoComponent.UserInfo.Name}   \t拍卖消耗金币:{unit.GetComponent<DataCollationComponent>().PaiMaiCostGoldToday}  " +
                        $" \t账号:{userInfoComponent.Account}   \t钻石:{userInfoComponent.UserInfo.Diamond}  \t金币:{userInfoComponent.UserInfo.Gold} \n";
                    ServerLogHelper.PaiMaiInfo(levelInfo);
                }
                else
                {
                    DataCollationComponent dataCollationComponent = unit.GetComponent<DataCollationComponent>();
                    NumericComponentS numericComponent = unit.GetComponent<NumericComponentS>();
                    dataCollationComponent.UpdateBuySelfPlayerList((long)(needGold * 0.95f), unit.Id, true);
                    long paimaigold = numericComponent.GetAsLong(NumericType.PaiMaiTodayGold)+(long)(needGold * 0.95f);
                    numericComponent.ApplyValue(NumericType.PaiMaiTodayGold, paimaigold, true);
                }
                
                //每天更新文本。
                //今天拍卖出售获取金币数量>=50000000  打印出来
                //充值《100 金币大于5亿
                if (needGold >= 500000)
                {
                    //服务器 道具名称 数量  价格  购买者名称 购买者等级  购买者充值 购买者当前金币 购买者账号 出售者名称   出售者账号  出售者等级 出售者当前金币
                    string serverName = ServerHelper.GetServerItemByZone(VersionMode.Beta, unit.Zone()).ServerName;
                    string itemName = itemConfig.ItemName;
                    int itemNumber = r_GameStatusResponse.ItemInfo.ItemNum;
                    long price = request.Price;

                    UserInfoComponentS userInfoComponent = unit.GetComponent<UserInfoComponentS>();
                    string buyPlayerName = userInfoComponent.UserInfo.Name;
                    int buyPlayerLv = userInfoComponent.UserInfo.Lv;
                    int buyPlayerRecharge = request.IsRecharge;
                    long buyNowGold = userInfoComponent.UserInfo.Gold;
                    string buyAccount = userInfoComponent.Account;
                    
                    string sellPlayerName = r_GameStatusResponse.PlayerName;
                    string sellAccoount = r_GameStatusResponse.Account;
                    UserInfoComponentS userInfoComponentSell = await UnitCacheHelper.GetComponentCache<UserInfoComponentS>(unit.Root(), r_GameStatusResponse.UserId);
                    UserInfo unionInfoCache = userInfoComponentSell.ChildrenDB[0] as UserInfo;
                    if (userInfoComponentSell != null)
                    {
                        int sellPlayerLv = unionInfoCache.Lv;
                        long sellNowGold = unionInfoCache.Gold;

                        string paimaiInfo = $"服务器:{serverName}   \t道具名称:{itemName}   \t数量:{itemNumber}   \t价格:{price}  \t购买者名称:{buyPlayerName}   \t购买者等级:{buyPlayerLv}    " +
                            $"\t购买者充值:{buyPlayerRecharge}   \t购买者当前金币:{buyNowGold}   \t购买者账号:{buyAccount}    \t出售者名称:{sellPlayerName}   \t出售者账号:{sellAccoount}   \t出售者等级:{sellPlayerLv}    \t出售者当前金币:{sellNowGold} ";
                        ServerLogHelper.PaiMaiInfo(paimaiInfo);
                    }
                }
            }
            
			await ETTask.CompletedTask;
		}
	}
}
