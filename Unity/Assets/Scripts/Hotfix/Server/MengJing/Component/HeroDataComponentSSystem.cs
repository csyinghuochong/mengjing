using System;
using System.Collections.Generic;
using System.Linq;
using Unity.Mathematics;

namespace ET.Server
{

    [EntitySystemOf(typeof(HeroDataComponentS))]
    [FriendOf(typeof(HeroDataComponentS))]
    [FriendOf(typeof(NumericComponentS))]
    public static partial class HeroDataComponentSSystem
    {
        [EntitySystem]
        private static void Awake(this HeroDataComponentS self)
        {

        }
        
         public static void CheckNumeric(this HeroDataComponentS self)
         {
             Unit unit = self.GetParent<Unit>();
             NumericComponentS numericComponent = unit.GetComponent<NumericComponentS>();
             numericComponent.Reset();

             if (numericComponent.GetAsInt(NumericType.Ling_DiLv) == 0)
             {
                 numericComponent.ApplyValue(NumericType.Ling_DiLv, 1, false);
             }
             if (numericComponent.GetAsInt(NumericType.CangKuNumber) == 0)
             {
                 numericComponent.ApplyValue(NumericType.CangKuNumber, 1, false);
             }
             if (numericComponent.GetAsInt(NumericType.JianYuanCangKu) == 0)
             {
                 numericComponent.ApplyValue(NumericType.JianYuanCangKu, 1, false);
             }
             
             if (numericComponent.GetAsFloat(NumericType.ChouKaTenTime) == 0)
             {
                 numericComponent.ApplyValue(NumericType.ChouKaTenTime, TimeHelper.ServerNow(), false);
             }
             if (numericComponent.GetAsFloat(NumericType.ChouKaOneTime) == 0)
             {
                 numericComponent.ApplyValue(NumericType.ChouKaOneTime, TimeHelper.ServerNow(), false);
             }
             if (numericComponent.GetAsInt(NumericType.HorseRide) == 1)
             {
                 numericComponent.ApplyValue(NumericType.HorseRide, numericComponent.GetAsInt(NumericType.HorseFightID), false);
             }

             if (numericComponent.GetAsInt(NumericType.Now_Hp) <= 0 || numericComponent.GetAsInt(NumericType.Now_Dead) == 1)
             {
                 numericComponent.ApplyValue(NumericType.Now_Hp, numericComponent.GetAsInt(NumericType.Now_MaxHp), false);
                 numericComponent.ApplyValue(NumericType.Now_Dead, 0, false);
             }
             
             if (numericComponent.GetAsInt(NumericType.UnionXiuLian_0) == 0)
             {
                 Dictionary<int, List<UnionQiangHuaConfig>> keyValuePairs = UnionQiangHuaConfigCategory.Instance.UnionQiangHuaList;
                 numericComponent.ApplyValue(NumericType.UnionXiuLian_0, keyValuePairs[0][0].Id, false);
                 numericComponent.ApplyValue(NumericType.UnionXiuLian_1, keyValuePairs[1][0].Id, false);
                 numericComponent.ApplyValue(NumericType.UnionXiuLian_2, keyValuePairs[2][0].Id, false);
                 numericComponent.ApplyValue(NumericType.UnionXiuLian_3, keyValuePairs[3][0].Id, false);
             }
             if (numericComponent.GetAsInt(NumericType.UnionPetXiuLian_0) == 0)
             {
                 Dictionary<int, List<UnionQiangHuaConfig>> keyValuePairs = UnionQiangHuaConfigCategory.Instance.UnionQiangHuaList;
                 numericComponent.ApplyValue(NumericType.UnionPetXiuLian_0, keyValuePairs[4][0].Id, false);
                 numericComponent.ApplyValue(NumericType.UnionPetXiuLian_1, keyValuePairs[5][0].Id, false);
                 numericComponent.ApplyValue(NumericType.UnionPetXiuLian_2, keyValuePairs[6][0].Id, false);
                 numericComponent.ApplyValue(NumericType.UnionPetXiuLian_3, keyValuePairs[7][0].Id, false);
             }
             if (numericComponent.GetAsInt(NumericType.Bloodstone) == 0)
             {
                 numericComponent.ApplyValue(NumericType.Bloodstone, 10100, false);
             }

             UserInfoComponentS userInfoComponent = unit.GetComponent<UserInfoComponentS>();
             int PointLiLiang = numericComponent.GetAsInt(NumericType.PointLiLiang);
             int PointZhiLi = numericComponent.GetAsInt(NumericType.PointZhiLi);
             int PointTiZhi = numericComponent.GetAsInt(NumericType.PointTiZhi);
             int PointNaiLi = numericComponent.GetAsInt(NumericType.PointNaiLi);
             int PointMinJie = numericComponent.GetAsInt(NumericType.PointMinJie);
             int PointRemain = numericComponent.GetAsInt(NumericType.PointRemain);
             int totalPoint = (userInfoComponent.GetUserLv() - 1) * 10;
             
             //检测属性点
             if (unit.GetComponent<UserInfoComponentS>().IsRobot())
             {
                 //机器人属性点
             }
             else
             {
                 long addvalue = PointLiLiang + PointZhiLi + PointTiZhi + PointNaiLi + PointMinJie + PointRemain;
                 if (addvalue != totalPoint || addvalue > totalPoint || PointLiLiang > totalPoint || PointZhiLi > totalPoint
                     || PointTiZhi > totalPoint || PointNaiLi > totalPoint || PointMinJie > totalPoint
                     || PointLiLiang < 0 || PointZhiLi < 0 || PointTiZhi < 0 || PointNaiLi < 0 || PointMinJie < 0)
                 {

                     Log.Debug($"{PointLiLiang} {PointZhiLi} {PointTiZhi} {PointNaiLi} {PointMinJie}  {PointRemain}  totalPoint: {totalPoint}");
                     numericComponent.ApplyValue(NumericType.PointLiLiang, 0, false);
                     numericComponent.ApplyValue(NumericType.PointZhiLi, 0, false);
                     numericComponent.ApplyValue(NumericType.PointTiZhi, 0, false);
                     numericComponent.ApplyValue(NumericType.PointNaiLi, 0, false);
                     numericComponent.ApplyValue(NumericType.PointMinJie, 0, false);
                     numericComponent.ApplyValue(NumericType.PointRemain, totalPoint, false);
                 }
             }
         }

         public static void OnLoginCheck(this HeroDataComponentS self, long passTime)
         {
             Unit unit = self.GetParent<Unit>();
             NumericComponentS numericComponentS = unit.GetComponent<NumericComponentS>();

             int initTimes = GlobalValueConfigCategory.Instance.SingleHappyInitTimes;
             int remainTimes = numericComponentS.GetAsInt(NumericType.SingleHappyRemainTimes);
             if (initTimes <= remainTimes)
             {
                 return;
             }

             int addTimes = (int)(passTime * 1f/ GlobalValueConfigCategory.Instance.SingleHappyrecoverTime);
             addTimes = math.min(addTimes, initTimes - addTimes);
             numericComponentS.ApplyValue(NumericType.SingleHappyRemainTimes, remainTimes + addTimes, false);
         }
         
         public static void CheckSingeHappy(this HeroDataComponentS self)
         {
             Unit unit = self.GetParent<Unit>();
             NumericComponentS numericComponentS = unit.GetComponent<NumericComponentS>();

             int initTimes = GlobalValueConfigCategory.Instance.SingleHappyInitTimes;
             int remainTimes = numericComponentS.GetAsInt(NumericType.SingleHappyRemainTimes);
             if (initTimes <= remainTimes)
             {
                 return;
             }

             numericComponentS.ApplyValue(NumericType.SingleHappyRemainTimes, remainTimes + 1);
         }

         public static void OnLogin(this HeroDataComponentS self, int robotId)
         {
             Unit unit = self.GetParent<Unit>();
             NumericComponentS numericComponent = unit.GetComponent<NumericComponentS>();
             numericComponent.ApplyValue((int)NumericType.Now_Dead , 0, false);
             numericComponent.ApplyValue((int)NumericType.Now_Damage, 0, false);
             numericComponent.ApplyValue((int)NumericType.Now_Stall, 0, false);
             numericComponent.ApplyValue((int)NumericType.TeamId, 0, false);
             numericComponent.ApplyValue((int)NumericType.Now_Hp, numericComponent.GetAsLong((int)NumericType.Now_MaxHp), false);
             numericComponent.ApplyValue(NumericType.JueXingAnger, 0, false);
             numericComponent.ApplyValue(NumericType.RunRaceRankId, 0, false);
             numericComponent.ApplyValue(NumericType.MakeShuLianDu_1, 50, false);
             numericComponent.ApplyValue(NumericType.MakeShuLianDu_2, 50, false);

             if (robotId != 0)
             {
                 RobotConfig robotConfig = RobotConfigCategory.Instance.Get(robotId);
                 numericComponent.ApplyValue(NumericType.PointLiLiang, robotConfig.PointList[0], false);
                 numericComponent.ApplyValue(NumericType.PointZhiLi, robotConfig.PointList[1], false);
                 numericComponent.ApplyValue(NumericType.PointTiZhi, robotConfig.PointList[2], false);
                 numericComponent.ApplyValue(NumericType.PointNaiLi, robotConfig.PointList[3], false);
                 numericComponent.ApplyValue(NumericType.PointMinJie, robotConfig.PointList[4], false);
             }

              UserInfoComponentS userInfoComponent = unit.GetComponent<UserInfoComponentS>();
             if (numericComponent.GetAsInt(NumericType.CostTiLi) > 600)
             {
                
                 Log.Console($"体力消耗异常: {self.Zone()}  {userInfoComponent.GetName()} {numericComponent.GetAsInt(NumericType.CostTiLi)}");
             }

             if (numericComponent.GetAsInt(NumericType.SkillMakePlan2) == 0)
             {
                 numericComponent.ApplyValue(NumericType.MakeType_2, 0, false);
             }
             
             //月卡次数用完，则清空标志
             int yuekatimes = numericComponent.GetAsInt(NumericType.YueKaRemainTimes);
             if (yuekatimes > 0)
             {
                 numericComponent.ApplyValue(NumericType.YueKaEndTime, yuekatimes, false);
             }
             
             self.CheckSeasonOver(false);
             self.CheckSeasonOpen(false);
         }
         
         public static void CheckSeasonOver(this HeroDataComponentS self, bool notice)
         {
             ///赛季数据[赛季开始]
             Unit unit = self.GetParent<Unit>();
             NumericComponentS numericComponent = unit.GetComponent<NumericComponentS>();
             UserInfoComponentS userInfoComponent = unit.GetComponent<UserInfoComponentS>();
             long seasonopenTime = numericComponent.GetAsLong(NumericType.SeasonOpenTime);
             KeyValuePairLong keyValuePairLong = SeasonHelper.GetOpenSeason(userInfoComponent.UserInfo.Lv);

             if (seasonopenTime != 0 &&  (keyValuePairLong== null  || seasonopenTime != keyValuePairLong.Value) )
             {
                 //清空赛季相关数据. 赛季任务 晶核
                 Log.Warning($"清空赛季数据！:{unit.Id}");
                 Console.WriteLine($"清空赛季数据！: {unit.Zone()}  {unit.Id}  {seasonopenTime} ");
                 //self.SendSeasonReward(unit.GetComponent<UserInfoComponent>().UserInfo.SeasonLevel);

                 numericComponent.ApplyValue(NumericType.SeasonOpenTime, 0, notice);
                 numericComponent.ApplyValue(NumericType.SeasonReward, 0, notice);
                 numericComponent.ApplyValue(NumericType.SeasonBossFuben, 0, notice);
                 numericComponent.ApplyValue(NumericType.SeasonBossRefreshTime, 0, notice);
                 numericComponent.ApplyValue(NumericType.SeasonTowerId, 0, notice);
                 numericComponent.ApplyValue(NumericType.SeasonTask, 0, notice);
                 numericComponent.ApplyValue(NumericType.CommonSeasonDonateTimes, 0, notice);

                 unit.GetComponent<UserInfoComponentS>().OnResetSeason(notice);
                 unit.GetComponent<BagComponentS>().OnResetSeason(notice);
                 unit.GetComponent<TaskComponentS>().OnResetSeason(notice);
             }
         }
         
         public static void CheckSeasonOpen(this HeroDataComponentS self, bool notice)
         {
             Unit unit = self.GetParent<Unit>();
             UserInfoComponentS userInfoComponent = unit.GetComponent<UserInfoComponentS>();
             NumericComponentS numericComponent = unit.GetComponent<NumericComponentS>();

             if (numericComponent.GetAsInt(NumericType.SeasonBossFuben) >= 100000)
             {
                 numericComponent.ApplyValue(NumericType.SeasonBossFuben, SeasonHelper.GetFubenId(userInfoComponent.GetUserLv()), false);
             }

             if (numericComponent.GetAsInt(NumericType.SeasonBossFuben) >= ConfigData.GMDungeonId)
             {
                 numericComponent.ApplyValue(NumericType.SeasonBossFuben, SeasonHelper.GetFubenId(userInfoComponent.GetUserLv()), false);
             }

             KeyValuePairLong seasonOpenTime = SeasonHelper.GetOpenSeason(userInfoComponent.UserInfo.Lv);
             if (numericComponent.GetAsLong(NumericType.SeasonOpenTime) == 0 && seasonOpenTime != null)
             {
                 Log.Console($"CheckSeasonOpen: {unit.Id}");

                 //刷新boss
                 numericComponent.ApplyValue(NumericType.SeasonBossFuben, SeasonHelper.GetFubenId(userInfoComponent.GetUserLv()), false);
                 numericComponent.ApplyValue(NumericType.SeasonBossRefreshTime, TimeHelper.ServerNow() + TimeHelper.Minute, false);
                 numericComponent.ApplyValue(NumericType.SeasonOpenTime, seasonOpenTime.Value, false);

                 //刷新任务
                 TaskComponentS taskComponent = unit.GetComponent<TaskComponentS>();
                 taskComponent.InitSeasonMainTask(notice);

                 taskComponent.UpdateSeasonWeekTask(notice); 
             }
         }
        
         public static void SendSeasonReward(this HeroDataComponentS self, int seasonLevel)
         {
             string rewardItem = SeasonHelper.GetSeasonOverReward(seasonLevel);
             if (string.IsNullOrEmpty(rewardItem))
             {
                 return;
             }

             MailInfo mailInfo = MailInfo.Create();
             mailInfo.Status = 0;
             mailInfo.Context = "赛季结束奖励";
             mailInfo.Title = "赛季结束奖励";
             mailInfo.MailId = IdGenerater.Instance.GenerateId();
             mailInfo.ItemList.AddRange(ItemHelper.GetRewardItems_2(rewardItem));
             MailHelp.SendUserMail( self.Root(), self.Id, mailInfo, ItemGetWay.Season ).Coroutine();
         }

         private static void HeroDataApplyValue(this HeroDataComponentS self, int ntype, long value, List<int> keylist)
         {
             Unit unit = self.GetParent<Unit>();
             NumericComponentS numericComponent = unit.GetComponent<NumericComponentS>();
             numericComponent.ApplyValue(ntype, value, false);
             
             keylist.Add(ntype);
         }

         public static void OnInit(this HeroDataComponentS self)
         {
             Unit unit = self.GetParent<Unit>();
             int inittimes = GlobalValueConfigCategory.Instance.SingleHappyInitTimes;
             NumericComponentS numericComponent = unit.GetComponent<NumericComponentS>();
                          numericComponent.ApplyValue(NumericType.SingleHappyRemainTimes, inittimes, false);
         }

         /// <summary>
         /// 重置。隔天登录或者零点刷新
         /// </summary>
         /// <param name="self"></param>
         /// <param name="notice"></param>
         public static void OnZeroClockUpdate(this HeroDataComponentS self, bool notice = false)
         {
             Unit unit = self.GetParent<Unit>();
             NumericComponentS numericComponent = unit.GetComponent<NumericComponentS>();

             List<int> ks = new List<int>();
             self.HeroDataApplyValue(NumericType.HongBao, 0, ks);
             self.HeroDataApplyValue(NumericType.Now_XiLian, 0, ks);
             self.HeroDataApplyValue(NumericType.PetChouKa, 0, ks);
             self.HeroDataApplyValue(NumericType.YueKaAward, 0, ks);
             self.HeroDataApplyValue(NumericType.XiuLian_ExpNumber, 0, ks);
             self.HeroDataApplyValue(NumericType.XiuLian_CoinNumber, 0, ks);
             self.HeroDataApplyValue(NumericType.XiuLian_ExpTime, 0, ks);
             self.HeroDataApplyValue(NumericType.XiuLian_CoinTime, 0, ks);
             self.HeroDataApplyValue(NumericType.TiLiKillNumber, 0, ks);
             self.HeroDataApplyValue(NumericType.ChouKa, 0, ks);
             self.HeroDataApplyValue(NumericType.ExpToGoldTimes, 0, ks);
             self.HeroDataApplyValue(NumericType.RechargeSign, 0, ks);
             self.HeroDataApplyValue(NumericType.TeamDungeonTimes, 0, ks);
             self.HeroDataApplyValue(NumericType.TeamDungeonXieZhu, 0, ks);
             self.HeroDataApplyValue(NumericType.BattleTodayKill, 0, ks);
             self.HeroDataApplyValue(NumericType.FubenTimesReset, 0, ks);
             self.HeroDataApplyValue(NumericType.FenShangSet, 0, ks);
             self.HeroDataApplyValue(NumericType.ArenaNumber, 0, ks);
             self.HeroDataApplyValue(NumericType.JingLingRefreshTime, 0, ks);
             self.HeroDataApplyValue(NumericType.TreasureTask, 0, ks);
             self.HeroDataApplyValue(NumericType.JiaYuanExchangeZiJin, 0, ks);
             self.HeroDataApplyValue(NumericType.JiaYuanExchangeExp, 0, ks);
             self.HeroDataApplyValue(NumericType.JiaYuanVisitRefresh, 0, ks);
             self.HeroDataApplyValue(NumericType.JiaYuanGatherOther, 0, ks);
             self.HeroDataApplyValue(NumericType.JiaYuanPickOther, 0, ks);
             self.HeroDataApplyValue(NumericType.UnionDonationNumber, 0, ks);
             self.HeroDataApplyValue(NumericType.UnionDiamondDonationNumber, 0, ks);
             self.HeroDataApplyValue(NumericType.UnionWishGet, 0, ks);
             self.HeroDataApplyValue(NumericType.OrderTaskCompNumber, 0, ks);
             self.HeroDataApplyValue(NumericType.RaceDonationNumber, 0, ks);
         
             self.HeroDataApplyValue(NumericType.JiaYuanPurchaseRefresh, 0, ks);
             self.HeroDataApplyValue(NumericType.SealTowerArrived, 0, ks);
             self.HeroDataApplyValue(NumericType.SealTowerFinished, 0, ks);

             self.HeroDataApplyValue(NumericType.RunRaceRankId, 0, ks);
             self.HeroDataApplyValue(NumericType.HappyCellIndex, 0, ks);
             self.HeroDataApplyValue(NumericType.HappyMoveNumber, 0, ks);

             self.HeroDataApplyValue(NumericType.PetMineBattle, 0, ks);
             self.HeroDataApplyValue(NumericType.PetMineLogin, 0, ks);

             self.HeroDataApplyValue(NumericType.CostTiLi, 0, ks);
             self.HeroDataApplyValue(NumericType.DrawIndex, 0, ks);
             self.HeroDataApplyValue(NumericType.DrawReward, 0, ks);

             self.HeroDataApplyValue(NumericType.PetMineReset, 0, ks);

             self.HeroDataApplyValue(NumericType.V1DayCostDiamond, 0, ks);
             self.HeroDataApplyValue(NumericType.V1ChouKaNumber, 0, ks);
             self.HeroDataApplyValue(NumericType.V1RechageNumber, 0, ks);
             self.HeroDataApplyValue(NumericType.PetExploreNumber, 0, ks);
             self.HeroDataApplyValue(NumericType.PetHeXinExploreNumber, 0, ks);
             self.HeroDataApplyValue(NumericType.ItemXiLianNumber, 0, ks);
             
             self.HeroDataApplyValue(NumericType.SingleHappyCellIndex, 0, ks);
             int inittimes = GlobalValueConfigCategory.Instance.SingleHappyInitTimes;
             self.HeroDataApplyValue(NumericType.SingleHappyRemainTimes, inittimes, ks);
             self.HeroDataApplyValue(NumericType.SingleBuyTimes, 0, ks);
             
             int lirun =  (int)(numericComponent.GetAsInt(NumericType.InvestTotal) * 0.25f);
             self.HeroDataApplyValue(NumericType.InvestTotal, numericComponent.GetAsInt(NumericType.InvestTotal) + lirun, ks);
             
             if (notice)
             {
                 List<long> vs = new List<long>();
                 for (int i = 0; i < ks.Count; i++)
                 {
                     vs.Add( numericComponent.GetAsLong(ks[i]) );
                 }
                 
                 // 需要广播的notice= true
                 M2C_UnitNumericListUpdate m2C_UnitNumericListUpdate = M2C_UnitNumericListUpdate.Create();
                 //通知自己
                 m2C_UnitNumericListUpdate.UnitID = unit.Id;
                 m2C_UnitNumericListUpdate.Vs = vs;
                 m2C_UnitNumericListUpdate.Ks = ks;
                 MapMessageHelper.SendToClient(unit, m2C_UnitNumericListUpdate);
             }

             self.CheckSeasonOver(notice);
             self.CheckSeasonOpen(notice);
         }

         /// <summary>
         /// 返回主城
         /// </summary>
         /// <param name="self"></param>
         public static void OnReturn(this HeroDataComponentS self)
         {
             Unit unit = self.GetParent<Unit>();
             NumericComponentS numericComponent = unit.GetComponent<NumericComponentS>();
             numericComponent.ApplyValue(NumericType.Now_Dead, 0, false);
             numericComponent.ApplyValue(NumericType.Now_Damage, 0, false);
             numericComponent.ApplyValue(NumericType.BossBelongID, 0, false);
             numericComponent.ApplyValue(NumericType.Now_Shield_HP, 0, false);
             numericComponent.ApplyValue(NumericType.Now_Shield_MaxHP, 0, false);
             numericComponent.ApplyValue(NumericType.Now_Shield_DamgeCostPro, 0, false);

             long max_hp = numericComponent.GetAsLong(NumericType.Now_MaxHp);
             unit.GetComponent<NumericComponentS>().ApplyValue(NumericType.Now_Hp, max_hp, false);
         }

         public static void OnResetPoint(this HeroDataComponentS self)
         {
             Unit unit = self.GetParent<Unit>();
             NumericComponentS numericComponent = unit.GetComponent<NumericComponentS>();
             UserInfoComponentS userInfoComponent = unit.GetComponent<UserInfoComponentS>();
             numericComponent.ApplyValue(NumericType.PointLiLiang, 0, false);
             numericComponent.ApplyValue(NumericType.PointZhiLi, 0, false);
             numericComponent.ApplyValue(NumericType.PointTiZhi, 0, false);
             numericComponent.ApplyValue(NumericType.PointNaiLi, 0, false);
             numericComponent.ApplyValue(NumericType.PointMinJie,0, false);
             numericComponent.ApplyValue(NumericType.PointRemain, (userInfoComponent.GetUserLv()- 1) * 10, false);
             Function_Fight.UnitUpdateProperty_Base(unit, true, true); ;
         }

         /// <summary>
         /// 0 不复活 1等待复活
         /// </summary>
         /// <param name="self"></param>
         /// <returns></returns>
         public static int OnWaitRevive(this HeroDataComponentS self)
         {
             Unit unit = self.GetParent<Unit>();
             if (unit.Type != UnitType.Monster)
             {
                 return 0;
             }

             MonsterConfig monsterConfig = MonsterConfigCategory.Instance.Get(unit.ConfigId);
             int resurrection = (int)monsterConfig.ReviveTime;
             MapComponent mapComponent = unit.Scene().GetComponent<MapComponent>();
             if (CommonHelp.IsSeasonBoss(unit.ConfigId ) && mapComponent.MapType == (int)MapTypeEnum.LocalDungeon)
             {
                 LocalDungeonComponent localDungeon = unit.Root().GetComponent<LocalDungeonComponent>();
                 UserInfoComponentS userInfoComponent = localDungeon.MainUnit.GetComponent<UserInfoComponentS>();
                 localDungeon.MainUnit.GetComponent<NumericComponentS>().ApplyValue(NumericType.SeasonBossFuben, SeasonHelper.GetFubenId(userInfoComponent.GetUserLv()));
                 localDungeon.MainUnit.GetComponent<NumericComponentS>().ApplyValue(NumericType.SeasonBossRefreshTime, TimeHelper.ServerNow() + resurrection * 1000);
                 resurrection = 0;
             }
             if (resurrection == 0)
             {
                 return 0;
             }
          
             if (monsterConfig.MonsterType != (int)MonsterTypeEnum.Boss)
             {
                 if (mapComponent.MapType == (int)MapTypeEnum.LocalDungeon
                  || mapComponent.MapType == (int)MapTypeEnum.MiJing
                  || mapComponent.MapType == (int)MapTypeEnum.RunRace)
                 {
                     unit.Scene().GetComponent<YeWaiRefreshComponent>().OnAddRefreshList(unit, resurrection * 1000);
                 }
                 return 0;
             }
             else
             {
                 long resurrectionTime = 0;
                 if (mapComponent.MapType == (int)MapTypeEnum.LocalDungeon)
                 {
                     LocalDungeonComponent localDungeon = unit.Scene().GetComponent<LocalDungeonComponent>();
                     UserInfoComponentS userInfoComponent = localDungeon.MainUnit.GetComponent<UserInfoComponentS>();
                     int killNumber = userInfoComponent.GetMonsterKillNumber(unit.ConfigId)  +  1;
                     int chpaterid = DungeonConfigCategory.Instance.GetChapterByDungeon(mapComponent.SceneId);
                     BossDevelopment bossDevelopment = ConfigHelper.GetBossDevelopmentByKill(chpaterid , killNumber);
                     resurrection = (int)(resurrection * bossDevelopment.ReviveTimeAdd);

                     resurrectionTime = TimeHelper.ServerNow() + resurrection * 1000;
                     unit.GetComponent<NumericComponentS>().ApplyValue(NumericType.ReviveTime, resurrectionTime);
                     userInfoComponent.OnAddRevive(unit.ConfigId, resurrectionTime);
                     unit.RemoveComponent<ReviveTimeComponent>();
                     unit.AddComponent<ReviveTimeComponent, long>(resurrectionTime);

                     userInfoComponent.OnAddFirstWinSelf(unit, localDungeon.FubenDifficulty);
                     FirstWinHelper.SendFirstWinInfo(localDungeon.MainUnit, unit, localDungeon.FubenDifficulty);
                     return 1;
                 }
                 else
                 {
                     if (mapComponent.MapType == (int)MapTypeEnum.MiJing)
                     {
                         resurrectionTime = TimeHelper.ServerNow() + resurrection * 1000;
                         unit.GetComponent<NumericComponentS>().ApplyValue(NumericType.ReviveTime, resurrectionTime);

                         unit.RemoveComponent<ReviveTimeComponent>();
                         unit.AddComponent<ReviveTimeComponent, long>(resurrectionTime);
                         return 1;
                     }
                 }
                 return 0;
             }
         }

         public static void OnKillZhaoHuan(this HeroDataComponentS self, Unit attack)
         {
             Unit unit = self.GetParent<Unit>();
             UnitInfoComponent unitInfoComponent = unit.GetComponent<UnitInfoComponent>();
             if (unitInfoComponent == null)
             {
                 Log.Debug($"unitInfoComponent == null  {unit.Type } {unit.IsDisposed}");
                 return;
             }

             List<long> zhaohuanids = unitInfoComponent.GetZhaoHuanList();
             for (int i = zhaohuanids.Count - 1; i >= 0; i--)
             {
                 Unit zhaohuan = unit.GetParent<UnitComponent>().Get(zhaohuanids[i]);
                 if (zhaohuan == null)
                 {
                     continue;
                 }
                 
                 zhaohuan.GetComponent<HeroDataComponentS>().OnDead(attack!=null ? attack : zhaohuan);
             }
             zhaohuanids.Clear();
         }

         public static void PlayDeathSkill(this HeroDataComponentS self,Unit attack)
         {
             Unit unit = self.GetParent<Unit>();
             if (unit.Type == UnitType.Monster)
             {
                 if (unit.ConfigId == 90000202)   //90030005
                 {
                     Log.Console("PlayDeathSkill: 72009045");
                 }

                 MonsterConfig monsterConfig = MonsterConfigCategory.Instance.Get(unit.ConfigId);
                 if (monsterConfig.DeathSkillId != 0)
                 {
                     C2M_SkillCmd C2M_SkillCmd = C2M_SkillCmd.Create();
                     C2M_SkillCmd.SkillID = monsterConfig.DeathSkillId;
                     unit.GetComponent<SkillManagerComponentS>().OnUseSkill(C2M_SkillCmd, false);
                 }
             }
             if (unit.Type == UnitType.Pet )
             {
                 unit.GetComponent<SkillPassiveComponent>()?.OnTrigegerPassiveSkill(SkillPassiveTypeEnum.WillDead_6, attack.Id);
             }
         }

         public static void OnRevive(this HeroDataComponentS self, bool bornPostion = false)
         {
             Unit unit = self.GetParent<Unit>();
             NumericComponentS numericComponent  = unit.GetComponent<NumericComponentS>();
             long max_hp = numericComponent.GetAsLong(NumericType.Now_MaxHp);
             
             numericComponent.ApplyValue(NumericType.ReviveTime, 0);
             numericComponent.ApplyValue(NumericType.Now_Dead, 0);
             numericComponent.ApplyValue(NumericType.Now_Hp, max_hp);

             unit.Position = unit.GetBornPostion();
             unit.GetComponent<AIComponent>()?.Begin();
             unit.GetComponent<SkillPassiveComponent>()?.Begin();
         }

         public static void InitTempFollower(this HeroDataComponentS self, Unit matster, int monster)
         {
             Unit nowUnit = self.GetParent<Unit>();
             NumericComponentS numericComponent = nowUnit.GetComponent<NumericComponentS>();
             MonsterConfig monsterConfig = MonsterConfigCategory.Instance.Get(monster);

             //判定是否为成长怪物
             if (monsterConfig.MonsterSonType == MonsterSonTypeEnum.Type_1)
             {
                 int nowUserLv = nowUnit.GetComponent<UserInfoComponentS>().GetUserLv();
                 for (int i = 0; i < monsterConfig.Parameter.Length; i++)
                 {
                     MonsterConfig monsterCof = MonsterConfigCategory.Instance.Get(monsterConfig.Parameter[i]);
                     if (nowUserLv >= monsterCof.Lv)
                     {
                         //指定等级对应属性
                         monsterConfig = monsterCof;
                     }
                 }
             }

             NumericComponentS numericComponentMaster = matster.GetComponent<NumericComponentS>();
             
             numericComponent.ApplyValue((int)NumericType.Base_MaxHp_Base, (int)(numericComponentMaster.GetAsInt(NumericType.Base_MaxHp_Base) * 0.5f), false);
             numericComponent.ApplyValue((int)NumericType.Base_MinAct_Base, (int)(numericComponentMaster.GetAsInt(NumericType.Base_MinAct_Base) * 0.5f), false);
             numericComponent.ApplyValue((int)NumericType.Base_MaxAct_Base, (int)(numericComponentMaster.GetAsInt(NumericType.Base_MaxAct_Base) * 0.5f), false);
             numericComponent.ApplyValue((int)NumericType.Base_MinDef_Base, (int)(numericComponentMaster.GetAsInt(NumericType.Base_MinDef_Base) * 0.5f), false);
             numericComponent.ApplyValue((int)NumericType.Base_MaxDef_Base, (int)(numericComponentMaster.GetAsInt(NumericType.Base_MaxDef_Base) * 0.5f), false);
             numericComponent.ApplyValue((int)NumericType.Base_MinAdf_Base, (int)(numericComponentMaster.GetAsInt(NumericType.Base_MinAdf_Base) * 0.5f), false);
             numericComponent.ApplyValue((int)NumericType.Base_MaxAdf_Base, (int)(numericComponentMaster.GetAsInt(NumericType.Base_MaxAdf_Base) * 0.5f), false);

             numericComponent.ApplyValue((int)NumericType.Base_Speed_Base, monsterConfig.MoveSpeed, false);
             numericComponent.ApplyValue((int)NumericType.Base_Cri_Base, monsterConfig.Cri, false);
             numericComponent.ApplyValue((int)NumericType.Base_Res_Base, monsterConfig.Res, false);
             numericComponent.ApplyValue((int)NumericType.Base_Hit_Base, monsterConfig.Hit, false);
             numericComponent.ApplyValue((int)NumericType.Base_Dodge_Base, monsterConfig.Dodge, false);
             numericComponent.ApplyValue((int)NumericType.Base_ActDamgeSubPro_Base, monsterConfig.DefAdd, false);
             numericComponent.ApplyValue((int)NumericType.Base_MageDamgeSubPro_Base, monsterConfig.AdfAdd, false);
             numericComponent.ApplyValue((int)NumericType.Base_DamgeSubPro_Base, monsterConfig.DamgeAdd, false);

             //设置当前血量
             numericComponent.ApplyValue((int)NumericType.Now_Hp, numericComponent.GetAsLong(NumericType.Now_MaxHp), false);
         }

         public static void InitJiaYuanPet(this HeroDataComponentS self,  bool notice)
         {
             NumericComponentS numericComponent = self.GetParent<Unit>().GetComponent<NumericComponentS>();
             numericComponent.ApplyValue(NumericType.Now_MaxHp, 1, notice);
             numericComponent.ApplyValue(NumericType.Now_Hp, 1, notice);
         }

         public static void InitPet(this HeroDataComponentS self, RolePetInfo rolePetInfo, bool notice)
         {
             Unit unit = self.GetParent<Unit>();

             NumericComponentS numericComponent = unit.GetComponent<NumericComponentS>();
             for (int i = 0; i < rolePetInfo.Ks.Count; i++)
             {
                 numericComponent.ApplyValue(rolePetInfo.Ks[i], rolePetInfo.Vs[i], notice);
             }
         }
         
         public static void InitPetByMasther(this HeroDataComponentS self, Unit master)
         {
             Unit unit = self.GetParent<Unit>();

             NumericComponentS unitNumericComponent = unit.GetComponent<NumericComponentS>();
             NumericComponentS masterNumericComponent = master.GetComponent<NumericComponentS>();
             List<int> keylist = masterNumericComponent.NumericDic.Keys.ToList();
             
             List<int> ks = new List<int>();
             List<long> vs = new List<long>();
             for (int i = 0; i < keylist.Count; i++)
             {
                 if (keylist[i] > NumericType.Now_Hp)
                 {
                     continue;
                 }
                 ks.Add(keylist[i]);
                 vs.Add(masterNumericComponent.GetAsLong(keylist[i]));
                 unitNumericComponent.ApplyValue( keylist[i], masterNumericComponent.GetAsLong(keylist[i]) );
             }
             
             M2C_UnitNumericListUpdate m2C_UnitNumericListUpdate = M2C_UnitNumericListUpdate.Create();
             //通知自己
             m2C_UnitNumericListUpdate.UnitID = unit.Id;
             m2C_UnitNumericListUpdate.Vs = vs;
             m2C_UnitNumericListUpdate.Ks = ks;
             MapMessageHelper.SendToClient(master, m2C_UnitNumericListUpdate);
         }

         public static void InitPlan(this HeroDataComponentS self, JiaYuanPlant jiaYuanPlant, bool notice)
         {
             NumericComponentS numericComponent = self.GetParent<Unit>().GetComponent<NumericComponentS>();
             numericComponent.ApplyValue(NumericType.StartTime, jiaYuanPlant.StartTime, false);
             numericComponent.ApplyValue(NumericType.GatherNumber, jiaYuanPlant.GatherNumber, false);
             numericComponent.ApplyValue(NumericType.GatherLastTime, jiaYuanPlant.GatherLastTime, false);
             numericComponent.ApplyValue(NumericType.GatherCellIndex, jiaYuanPlant.CellIndex, false);
         }

         public static void InitPasture(this HeroDataComponentS self, JiaYuanPastures jiaYuanPlant, bool notice)
         {
             NumericComponentS numericComponent = self.GetParent<Unit>().GetComponent<NumericComponentS>();
             numericComponent.ApplyValue(NumericType.StartTime, jiaYuanPlant.StartTime, false);
             numericComponent.ApplyValue(NumericType.GatherNumber, jiaYuanPlant.GatherNumber, false);
             numericComponent.ApplyValue(NumericType.GatherLastTime, jiaYuanPlant.GatherLastTime, false);
         }

         public static void InitJingLing(this HeroDataComponentS self, Unit master, int jinglingid, bool notice)
         {
             NumericComponentS masterNumericComponent = master.GetComponent<NumericComponentS>();

             NumericComponentS numericComponent = self.GetParent<Unit>().GetComponent<NumericComponentS>();
             foreach ((int ntype, long value) in masterNumericComponent.NumericDic)
             {
                 numericComponent.ApplyValue(ntype, value, false);
             }
         }

         /// <summary>
         /// 角色属性模块初始化
         /// </summary>
         public static void InitMonsterInfo_Summon2(this HeroDataComponentS self, MonsterConfig monsterConfig, CreateMonsterInfo createMonsterInfo)
         {
             Unit nowUnit = self.GetParent<Unit>();
             NumericComponentS numericComponent = nowUnit.GetComponent<NumericComponentS>();

             int monsterlevel = 1;
             Unit masterUnit = nowUnit.GetParent<UnitComponent>().Get(createMonsterInfo.MasterID);
             if (masterUnit.Type == UnitType.Player)
             {
                 monsterlevel = masterUnit.GetComponent<UserInfoComponentS>().GetUserLv();
             }
             else
             {
                 monsterlevel = monsterConfig.Lv;
             }

             //0.8,0.8,0.5,0.5;5000,0,0,0,0
             //血量比例,攻击比例,魔法比例,物防比例，魔防比例；血量固定值,攻击固定值，魔法固定值，物防固定值，魔防固定值
             string[] summonInfo = createMonsterInfo.AttributeParams.Split(';');

             int useMasterModel = int.Parse(summonInfo[0]);
             numericComponent.ApplyValue((int)NumericType.UseMasterModel, useMasterModel, false);

             string[] attributeList_1 = summonInfo[1].Split(',');    //比列
             string[] attributeList_2 = summonInfo[2].Split(',');    //固定值

             NumericComponentS masterNumberComponent = masterUnit.GetComponent<NumericComponentS>();
             numericComponent.ApplyValue((int)NumericType.Now_Lv, monsterlevel, false);
             numericComponent.ApplyValue((int)NumericType.Base_MaxHp_Base, (int)((float)masterNumberComponent.GetAsInt(NumericType.Now_MaxHp) * float.Parse(attributeList_1[0]) * (1+ masterNumberComponent.GetAsFloat(NumericType.Now_SummonAddPro))) + int.Parse(attributeList_2[0]), false);
             numericComponent.ApplyValue((int)NumericType.Base_MinAct_Base, (int)((float)masterNumberComponent.GetAsInt(NumericType.Now_MaxAct) * float.Parse(attributeList_1[1]) * (1 + masterNumberComponent.GetAsFloat(NumericType.Now_SummonAddPro))) + int.Parse(attributeList_2[1]), false);  //召唤怪物继承当前角色最大攻击
             numericComponent.ApplyValue((int)NumericType.Base_MaxAct_Base, (int)((float)masterNumberComponent.GetAsInt(NumericType.Now_MaxAct) * float.Parse(attributeList_1[1]) * (1 + masterNumberComponent.GetAsFloat(NumericType.Now_SummonAddPro))) + int.Parse(attributeList_2[1]), false);
             numericComponent.ApplyValue((int)NumericType.Base_Mage_Base, (int)((float)masterNumberComponent.GetAsInt(NumericType.Now_Mage) * float.Parse(attributeList_1[2]) * (1 + masterNumberComponent.GetAsFloat(NumericType.Now_SummonAddPro))) + int.Parse(attributeList_2[2]), false);
             numericComponent.ApplyValue((int)NumericType.Base_MinDef_Base, (int)((float)masterNumberComponent.GetAsInt(NumericType.Now_MinDef) * float.Parse(attributeList_1[3]) * (1 + masterNumberComponent.GetAsFloat(NumericType.Now_SummonAddPro))) + int.Parse(attributeList_2[3]), false);
             numericComponent.ApplyValue((int)NumericType.Base_MaxDef_Base, (int)((float)masterNumberComponent.GetAsInt(NumericType.Now_MaxDef) * float.Parse(attributeList_1[3]) * (1 + masterNumberComponent.GetAsFloat(NumericType.Now_SummonAddPro))) + int.Parse(attributeList_2[3]), false);
             numericComponent.ApplyValue((int)NumericType.Base_MinAdf_Base, (int)((float)masterNumberComponent.GetAsInt(NumericType.Now_MinAdf) * float.Parse(attributeList_1[4]) * (1 + masterNumberComponent.GetAsFloat(NumericType.Now_SummonAddPro))) + int.Parse(attributeList_2[4]), false);
             numericComponent.ApplyValue((int)NumericType.Base_MaxAdf_Base, (int)((float)masterNumberComponent.GetAsInt(NumericType.Now_MaxAdf) * float.Parse(attributeList_1[4]) * (1 + masterNumberComponent.GetAsFloat(NumericType.Now_SummonAddPro))) + int.Parse(attributeList_2[4]), false);

             //属性
             numericComponent.ApplyValue((int)NumericType.Base_Speed_Base, monsterConfig.MoveSpeed, false);
             numericComponent.ApplyValue((int)NumericType.Base_Cri_Base, monsterConfig.Cri, false);
             numericComponent.ApplyValue((int)NumericType.Base_Res_Base, monsterConfig.Res, false);
             numericComponent.ApplyValue((int)NumericType.Base_Hit_Base, monsterConfig.Hit, false);
             numericComponent.ApplyValue((int)NumericType.Base_Dodge_Base, monsterConfig.Dodge, false);
             numericComponent.ApplyValue((int)NumericType.Base_ActDamgeSubPro_Base, monsterConfig.DefAdd, false);
             numericComponent.ApplyValue((int)NumericType.Base_MageDamgeSubPro_Base, monsterConfig.AdfAdd, false);
             numericComponent.ApplyValue((int)NumericType.Base_DamgeSubPro_Base, monsterConfig.DamgeAdd, false);
             //设置当前血量
             numericComponent.ApplyValue((int)NumericType.Now_Hp, numericComponent.GetAsInt(NumericType.Now_MaxHp), false);
             //Log.Debug("初始化当前怪物血量:" + numericComponent.GetAsLong(NumericType.Now_Hp));

             //新增的参数
             //血量比例,攻击比例,魔法比例,物防比例，魔防比例,新增比列1，新增比列2....；血量固定值,攻击固定值，魔法固定值，物防固定值，魔防固定值，新增固定值1,新增固定值2..
             if (attributeList_1.Length > 5)
             {
                 float a = masterNumberComponent.GetAsFloat(NumericType.Now_Cri);
                 //暴击,命中,闪避,韧性
                 numericComponent.ApplyValue((int)NumericType.Base_Cri_Base, (float.Parse(attributeList_1[5]) * masterNumberComponent.GetAsFloat(NumericType.Now_Cri)), false);
                 numericComponent.ApplyValue((int)NumericType.Base_Hit_Base, (float.Parse(attributeList_1[6]) * masterNumberComponent.GetAsFloat(NumericType.Now_Hit)), false);
                 numericComponent.ApplyValue((int)NumericType.Base_Dodge_Base, (float.Parse(attributeList_1[7]) * masterNumberComponent.GetAsFloat(NumericType.Now_Dodge)), false);
                 numericComponent.ApplyValue((int)NumericType.Base_Res_Base, (float.Parse(attributeList_1[8]) * masterNumberComponent.GetAsFloat(NumericType.Now_Res)), false);
             }

         }

         /// <summary>
         /// 角色属性模块初始化
         /// </summary>
         public static void InitMonsterInfo(this HeroDataComponentS self, MonsterConfig monsterConfig, CreateMonsterInfo createMonsterInfo)
         {
             Unit nowUnit = self.GetParent<Unit>();
             NumericComponentS numericComponent = nowUnit.GetComponent<NumericComponentS>();

             float hpCoefficient = 1f;
             float ackCoefficient = 1f;
             //根据副本难度刷新属性
             //进入 挑战关卡 怪物血量增加 1.5 伤害增加 1.2 低于关卡 血量增加2 伤害增加 1.5
             MapComponent mapComponent = nowUnit.Scene().GetComponent<MapComponent>();
             int sceneType = mapComponent.MapType;
             int fubenDifficulty = FubenDifficulty.None;

             float attributeAdd = 1f;

             if (sceneType == MapTypeEnum.CellDungeon || sceneType == MapTypeEnum.LocalDungeon)
             {
                 switch (sceneType)
                 {
                     case MapTypeEnum.CellDungeon:
                         fubenDifficulty = nowUnit.Scene().GetComponent<CellDungeonComponentS>().FubenDifficulty;
                         break;
                     case MapTypeEnum.LocalDungeon:
                         if (monsterConfig.MonsterType == MonsterTypeEnum.Boss)
                         {
                             LocalDungeonComponent localDungeonComponent = nowUnit.Scene().GetComponent<LocalDungeonComponent>();
                             Unit mainUnit = localDungeonComponent.MainUnit;
                             int killNumber = mainUnit.GetComponent<UserInfoComponentS>().GetMonsterKillNumber(monsterConfig.Id);
                             int chpaterid = DungeonConfigCategory.Instance.GetChapterByDungeon(mapComponent.SceneId);
                             BossDevelopment bossDevelopment = ConfigHelper.GetBossDevelopmentByKill(chpaterid, killNumber);
                             attributeAdd = bossDevelopment.AttributeAdd;
                             fubenDifficulty = localDungeonComponent.FubenDifficulty;
                         }
                         break;
                     default:
                         break;
                 }
                 if (monsterConfig.MonsterType == MonsterTypeEnum.Boss && !CommonHelp.IsSeasonBoss( monsterConfig.Id))
                 {
                     switch (fubenDifficulty)
                     {
                         case FubenDifficulty.TiaoZhan:
                             hpCoefficient = 1.75f;
                             ackCoefficient = 1.3f;
                             break;
                         case FubenDifficulty.DiYu:
                             hpCoefficient = 2.5f;
                             ackCoefficient = 1.65f;
                             break;
                     }
                 }
             }
             if (sceneType == MapTypeEnum.TeamDungeon)
             {
                 //副本的怪物难度提升（类似不难度的个人副本 给个配置即可）
                 int realplayerNumber = nowUnit.Scene().GetComponent<TeamDungeonComponent>().GetRealPlayerNumber();
                 fubenDifficulty = mapComponent.FubenDifficulty;
                 //深渊BOSSS属性加成
                 if (fubenDifficulty == TeamFubenType.ShenYuan && monsterConfig.MonsterType == MonsterTypeEnum.Boss)
                 {
                     hpCoefficient = 2.5f;
                     ackCoefficient = 1.3f;
                 }

                 //人数对应小怪
                 if (realplayerNumber == 2 && monsterConfig.MonsterType != MonsterTypeEnum.Boss)
                 {
                     hpCoefficient = 1.5f;
                 }
                 if (realplayerNumber >= 3 && monsterConfig.MonsterType != MonsterTypeEnum.Boss)
                 {
                     hpCoefficient = 2f;
                 }
             }

             //判定是否为成长怪物
             if (monsterConfig.MonsterSonType == MonsterSonTypeEnum.Type_1)
             {
                 int nowUserLv = nowUnit.GetComponent<UserInfoComponentS>().GetUserLv();
                 for (int i = 0; i < monsterConfig.Parameter.Length; i++)
                 {
                     MonsterConfig monsterCof = MonsterConfigCategory.Instance.Get(monsterConfig.Parameter[i]);
                     if (nowUserLv >= monsterCof.Lv)
                     {
                         //指定等级对应属性
                         monsterConfig = monsterCof;
                     }
                 }
             }

             //判定是否为成长怪物
             if (monsterConfig.MonsterSonType == MonsterSonTypeEnum.Type_2)
             {
                 MonsterConfig monsterCof = MonsterConfigCategory.Instance.Get(nowUnit.ConfigId);
                 int nowUserLv = monsterCof.Lv;
                 //nowUnit.GetComponent<UserInfoComponent>().UserInfo.Lv;
                 int playerLv = createMonsterInfo.PlayerLevel;
                 string attribute = createMonsterInfo.AttributeParams;   //2;2
                 float hpPro = float.Parse(attribute.Split(";")[0]);
                 float otherPro = float.Parse(attribute.Split(";")[1]);
                 ExpConfig expCof = ExpConfigCategory.Instance.Get(nowUserLv);
                 monsterConfig.Hp = (int)(expCof.BaseHp * hpPro);
                 monsterConfig.Act = (int)(expCof.BaseAct * otherPro);
                 monsterConfig.Def = (int)(expCof.BaseDef * otherPro);
                 monsterConfig.Adf = (int)(expCof.BaseAdf * otherPro);
                 monsterConfig.Lv = playerLv;
             }

             //attributeAdd   (boss成长boss加成)
             numericComponent.ApplyValue(NumericType.Base_MaxHp_Base, (int)(monsterConfig.Hp * hpCoefficient * attributeAdd), false);
             numericComponent.ApplyValue(NumericType.Base_MinAct_Base, (int)(monsterConfig.Act * ackCoefficient * attributeAdd), false);
             numericComponent.ApplyValue(NumericType.Base_MaxAct_Base, (int)(monsterConfig.Act * ackCoefficient * attributeAdd), false);
             numericComponent.ApplyValue(NumericType.Base_MinDef_Base, monsterConfig.Def, false);
             numericComponent.ApplyValue(NumericType.Base_MaxDef_Base, monsterConfig.Def, false);
             numericComponent.ApplyValue(NumericType.Base_MinAdf_Base, monsterConfig.Adf, false);
             numericComponent.ApplyValue(NumericType.Base_MaxAdf_Base, monsterConfig.Adf, false);
             numericComponent.ApplyValue(NumericType.Base_Speed_Base, monsterConfig.MoveSpeed, false);
             numericComponent.ApplyValue(NumericType.Base_Cri_Base, monsterConfig.Cri, false);
             numericComponent.ApplyValue(NumericType.Base_Res_Base, monsterConfig.Res, false);
             numericComponent.ApplyValue(NumericType.Base_Hit_Base, monsterConfig.Hit, false);
             numericComponent.ApplyValue(NumericType.Base_Dodge_Base, monsterConfig.Dodge, false);
             numericComponent.ApplyValue(NumericType.Base_ActDamgeSubPro_Base, monsterConfig.DefAdd, false);
             numericComponent.ApplyValue(NumericType.Base_MageDamgeSubPro_Base, monsterConfig.AdfAdd, false);
             numericComponent.ApplyValue(NumericType.Base_DamgeSubPro_Base, monsterConfig.DamgeAdd, false);

             //设置当前血量
             numericComponent.ApplyValue(NumericType.Now_Hp,  numericComponent.GetAsInt(NumericType.Now_MaxHp), false);
             //Log.Debug("初始化当前怪物血量:" + numericComponent.GetAsLong(NumericType.Now_Hp));
         }

         /// <summary>
         /// 更新当前角色身上的buff信息, 更新基础属性
         /// </summary>
         public static void BuffPropertyUpdate_Long(this HeroDataComponentS self, int numericType, long NumericTypeValue)
         {

             Unit nowUnit = self.GetParent<Unit>();
             NumericComponentS numericComponent = nowUnit.GetComponent<NumericComponentS>();
             long newvalue = numericComponent.GetAsLong(numericType) + NumericTypeValue;
             numericComponent.ApplyValue(numericType, newvalue);

             /*
             //获取是暴击等级等二次属性 需要二次计算
             if ((int)(numericType / 100) == NumericType.Now_CriLv)
             {

                 long criLv = numericComponent.GetAsLong(NumericType.Now_CriLv);
                 long hitLv = numericComponent.GetAsLong(NumericType.Now_HitLv);
                 long dodgeLv = numericComponent.GetAsLong(NumericType.Now_DodgeLv);
                 long resLv = numericComponent.GetAsLong(NumericType.Now_ResLv);

                 Function_Fight.GetInstance().UnitUpdateProperty_Base(nowUnit);

                 //float criProAdd = Function_Fight.LvProChange(criLv, nowUnit.GetComponent<UserInfoComponent>().UserInfo.Lv);
                 //numericComponent.Set(NumericType.Now_Cri, (long)(criLv * 10000) + numericComponent.GetAsLong(NumericType.Now_Cri), true);
             }
             */
         }

         public static void BuffPropertyUpdate_Float(this HeroDataComponentS self, int numericType, float NumericTypeValue)
         {
             Unit nowUnit = self.GetParent<Unit>();
             NumericComponentS numericComponent = nowUnit.GetComponent<NumericComponentS>();
             float newvalue = numericComponent.GetAsFloat(numericType) + NumericTypeValue;
             numericComponent.ApplyValue(numericType, newvalue);
         }


         public static void OnDead(this HeroDataComponentS self, Unit attack, bool nodrop = false)
         {
             Unit unit = self.GetParent<Unit>();
            
             unit.GetComponent<MoveComponent>()?.Stop(false);
             int waitRevive = self.OnWaitRevive();

             EventSystem.Instance.Publish( self.Scene(), new UnitKillEvent()
             {
                 WaitRevive = waitRevive,
                 UnitAttack = attack,
                 UnitDefend = unit,
                 NoDrop = nodrop,
             });
            }
    }
}
