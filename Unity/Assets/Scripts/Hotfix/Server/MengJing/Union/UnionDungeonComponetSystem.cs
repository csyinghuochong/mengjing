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

            // 先清掉上一轮残留的 BOSS，否则每天开活动都会在场景里多堆一只（永久不会消失）。
            // 这里清场景内所有怪物：2000009 是公会 BOSS 专用地图，只有 BOSS 一种怪。
            self.RemoveUnionBoss();

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

        /// <summary>
        /// 移除场景里已有的公会 BOSS。
        /// monsterId 传 0 时移除场景内所有 Monster（活动关闭用）。
        /// </summary>
        public static void RemoveUnionBoss(this UnionDungeonComponet self, int monsterId = 0)
        {
            Scene scene = self.Scene();
            if (scene == null || scene.IsDisposed)
            {
                return;
            }

            UnitComponent unitComponent = scene.GetComponent<UnitComponent>();
            if (unitComponent == null)
            {
                return;
            }

            using (ListComponent<long> removeIds = ListComponent<long>.Create())
            {
                List<EntityRef<Unit>> units = unitComponent.GetAll();
                for (int i = 0; i < units.Count; i++)
                {
                    Unit unit = units[i];
                    if (unit == null || unit.IsDisposed)
                    {
                        continue;
                    }

                    if (unit.Type != UnitType.Monster)
                    {
                        continue;
                    }

                    if (monsterId != 0 && unit.ConfigId != monsterId)
                    {
                        continue;
                    }

                    removeIds.Add(unit.Id);
                }

                for (int i = 0; i < removeIds.Count; i++)
                {
                    unitComponent.Remove(removeIds[i]);
                }
            }
        }
    }

}