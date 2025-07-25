using System;
using System.Collections.Generic;
using Unity.Mathematics;

namespace ET.Server
{


    [EntitySystemOf(typeof(UnionDungeonComponet))]
    [FriendOf(typeof(UnionDungeonComponet))]
    public static partial class UnionDungeonComponetSystem
    {

        /// <summary>
        /// 公会boss击杀
        /// </summary>
        /// <param name="self"></param>
        /// <param name="scene"></param>
        /// <param name="defend"></param>
        public static void OnKillEvent(this UnionDungeonComponet self, Unit defend)
        {
            SceneConfig sceneConfig = SceneConfigCategory.Instance.Get(2000009);
            if (defend.Type != UnitType.Monster || defend.ConfigId != sceneConfig.BossId)
            {
                return;
            }

            long serverTime = TimeHelper.ServerNow();
            List<Unit> players = UnitHelper.GetUnitList(self.Scene(), UnitType.Player);
            for (int i = 0; i < players.Count; i++)
            {
                MailInfo mailInfo = MailInfo.Create();
                mailInfo.Status = 0;
                mailInfo.Title = "公会入侵怪物奖励";
                mailInfo.MailId = IdGenerater.Instance.GenerateId();

                ItemInfoProto BagInfo = ItemInfoProto.Create();
                BagInfo.ItemID = 1;
                BagInfo.ItemNum = 100;
                BagInfo.GetWay = $"{ItemGetWay.UnionBoss}_{serverTime}";

                mailInfo.ItemList.Add(BagInfo);
                MailHelp.SendUserMail(self.Root(), players[i].Id, mailInfo,ItemGetWay.UnionBoss).Coroutine();
            }
        }

        public static void GenerateUnionBoss(this UnionDungeonComponet self)
        {
            DateTime dateTime = TimeHelper.DateTimeNow();
            long curTime = (dateTime.Hour * 60 + dateTime.Minute) * 60 + dateTime.Second;
            long openTime = FunctionHelp.BossOpenTime();
            long closeTime = FunctionHelp.BossCloseTime();
            if (curTime < openTime || curTime > closeTime)
            {
                return;
            }

            //获取开服天数
            int openDay = ServerHelper.GetServeOpenDay(self.Zone());

            //根据开服天数创建怪物
            int monsterID = FunctionHelp.GetUnionBossId(openDay);

            long serverTime = TimeHelper.ServerNow();
            float3 initPosi = new float3(0f, 0.5f, 0f);
            SceneConfig sceneConfig = SceneConfigCategory.Instance.Get(2000009);
            Unit unitMonster = UnitFactory.CreateMonster(self.Scene(), monsterID, initPosi,
                new CreateMonsterInfo() { Camp = CampEnum.CampMonster1, MasterID = 0, AttributeParams = string.Empty });


        }
        [EntitySystem]
        private static void Awake(this ET.Server.UnionDungeonComponet self)
        {

        }
    }

}