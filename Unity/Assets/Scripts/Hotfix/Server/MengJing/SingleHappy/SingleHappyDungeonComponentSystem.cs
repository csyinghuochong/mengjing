using System;
using System.Collections.Generic;
using System.Linq;
using Unity.Mathematics;

namespace ET.Server
{
    [EntitySystemOf(typeof (SingleHappyDungeonComponent))]
    [FriendOf(typeof (SingleHappyDungeonComponent))]
    public static partial class SingleHappyDungeonComponentSystem
    {
        
        
        [EntitySystem]
        private static void Awake(this SingleHappyDungeonComponent self)
        {
        }

        [EntitySystem]
        private static void Destroy(this SingleHappyDungeonComponent self)
        {
        }

        public static int GetDropId(this SingleHappyDungeonComponent self, int level)
        {
            // 提取键并排序
            List<int> sortedKeys = new List<int>(GlobalValueConfigCategory.Instance.SingleHappyDrops.Keys);
            sortedKeys = sortedKeys.OrderByDescending(num => num).ToList();
            
            // 按排序后的键访问值
            foreach (int key in sortedKeys)
            {
                if (level >= key)
                {
                    return GlobalValueConfigCategory.Instance.SingleHappyDrops[key];
                }
            }
            
            return 0;
        }

        public static int GetEmptyCellNumber(this SingleHappyDungeonComponent self)
        {
            List<int> dropcells = new List<int>();
            List<Unit> droplist = UnitHelper.GetUnitList(self.Scene(), UnitType.DropItem);
            for (int i = 0; i < droplist.Count; i++)
            {
                int dropindex = droplist[i].GetComponent<NumericComponentS>().GetAsInt(NumericType.CellIndex);
                if (!dropcells.Contains(dropindex))
                {
                    dropcells.Add(dropindex);
                }
            }

            return HappyData.PositionList.Count - dropcells.Count;
        }

        public static void OnTimer(this SingleHappyDungeonComponent self, Unit unit)
        {
            List<int> dropcells = new List<int>();
            List<Unit> droplist = UnitHelper.GetUnitList(self.Scene(), UnitType.DropItem);
            for (int i = 0; i < droplist.Count; i++)
            {
                int dropindex = droplist[i].GetComponent<NumericComponentS>().GetAsInt(NumericType.CellIndex);
                if (!dropcells.Contains(dropindex))
                {
                    dropcells.Add(dropindex);
                }
            }
            
            int level = unit.GetComponent<UserInfoComponentS>().UserInfo.Lv;
            int dropids  = self.GetDropId(level);

            for (int p = 0; p < HappyData.PositionList.Count; p++)
            {

                if (p == 40)
                {
                    continue;
                }

                //空格子的概率
                if (RandomHelper.RandFloat01() < 0.3f)
                {
                    continue;
                }

                //该格子有道具
                if (dropcells.Contains(p + 1))
                {
                    continue;
                }

                List<RewardItem> rewardist = new List<RewardItem>();
                DropHelper.DropIDToDropItem(dropids, rewardist);
                
                if (rewardist.Count == 0)
                {
                    rewardist.Add( new RewardItem(){ItemID = 1, ItemNum = 10} );
                }

                if (rewardist.Count > 100)
                {
                    rewardist = rewardist.GetRange(0, 1);
                }
                
                if (rewardist.Count > 100)
                {
                    Log.Error($"rewardist.Count > 100:   {droplist[0]}");
                    break;
                }

                UnitComponent unitComponent = self.Scene().GetComponent<UnitComponent>();
                for (int i = 0; i < rewardist.Count; i++)
                {
                    if (!ItemConfigCategory.Instance.Contain(rewardist[i].ItemID))
                    {
                        rewardist[i].ItemID = 1;
                        rewardist[i].ItemNum = 1;
                    }

                    Unit dropitem = unitComponent.AddChildWithId<Unit, int>(IdGenerater.Instance.GenerateId(), 1);
                    unitComponent.Add(dropitem);
                    dropitem.AddComponent<UnitInfoComponent>();
                    dropitem.Type = UnitType.DropItem;
                    dropitem.AddComponent<DropComponentS>();
                    NumericComponentS numericComponentS = dropitem.AddComponent<NumericComponentS>();
                    numericComponentS.ApplyValue(NumericType.DropItemId, rewardist[i].ItemID, false);
                    numericComponentS.ApplyValue(NumericType.DropItemNum, rewardist[i].ItemNum, false);
                    numericComponentS.ApplyValue(NumericType.CellIndex, p + 1, false);
                    numericComponentS.ApplyValue(NumericType.DropType, 0, false);

                    float3 vector3 = HappyData.PositionList[p];
                    dropitem.Position = vector3;
                    dropitem.AddComponent<AOIEntity, int, float3>(2 * 1000, dropitem.Position);
                }
            }
        }

        public static void OnRestore(this SingleHappyDungeonComponent self, Unit player)
        {
            UnitComponent unitComponent = self.Scene().GetComponent<UnitComponent>();
            List<KeyValuePairLong4> SingleHappyDropList = player.GetComponent<DataCollationComponent>().SingleHappyDropList;
            for (int i = 0; i < SingleHappyDropList.Count; i++)
            {
                KeyValuePairLong4 keyValuePairLong4 = SingleHappyDropList[i];
                
                Unit dropitem = unitComponent.AddChildWithId<Unit, int>(keyValuePairLong4.KeyId, 1);
                unitComponent.Add(dropitem);
                dropitem.AddComponent<UnitInfoComponent>();
                dropitem.Type = UnitType.DropItem;
                dropitem.AddComponent<DropComponentS>();
                NumericComponentS numericComponentS = dropitem.AddComponent<NumericComponentS>();
                numericComponentS.ApplyValue(NumericType.DropItemId, keyValuePairLong4.Value, false);
                numericComponentS.ApplyValue(NumericType.DropItemNum, keyValuePairLong4.Value2, false);
                numericComponentS.ApplyValue(NumericType.CellIndex,  keyValuePairLong4.Value3, false);
                numericComponentS.ApplyValue(NumericType.DropType, 0, false);

                float3 vector3 = HappyData.PositionList[(int)(keyValuePairLong4.Value3) - 1];
                dropitem.Position = vector3;
                dropitem.AddComponent<AOIEntity, int, float3>(2 * 1000, dropitem.Position);
            }
        }

        public static void OnSave(this SingleHappyDungeonComponent self)
        {
            List<Unit> playerlist = UnitHelper.GetUnitList(self.Scene(), UnitType.Player);
            if (playerlist.Count == 0)
            {
                return;
            }

            List<KeyValuePairLong4> SingleHappyDropList = new List<KeyValuePairLong4>();
            List<Unit> droplist = UnitHelper.GetUnitList(self.Scene(), UnitType.DropItem);
            for (int i = 0; i < droplist.Count; i++)
            {
                Unit dropitem = droplist[i];
                NumericComponentS numericComponentS = dropitem.GetComponent<NumericComponentS>();
                KeyValuePairLong4 keyValuePairLong4 = new KeyValuePairLong4();
                keyValuePairLong4.KeyId = dropitem.Id;
                keyValuePairLong4.Value = numericComponentS.GetAsInt(NumericType.DropItemId);
                keyValuePairLong4.Value2 = numericComponentS.GetAsInt(NumericType.DropItemNum);
                keyValuePairLong4.Value3 = numericComponentS.GetAsInt(NumericType.CellIndex);
                SingleHappyDropList.Add(keyValuePairLong4);
            }

            playerlist[0].GetComponent<DataCollationComponent>().SingleHappyDropList = SingleHappyDropList;
        }
        
    }
}