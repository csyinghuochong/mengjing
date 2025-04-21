using System;
using System.Collections.Generic;
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

        public static int GetDropId(this SingleHappyDungeonComponent self, int openDay)
        {
            string dropinfo = GlobalValueConfigCategory.Instance.Get(96).Value;
            string[] dropList = dropinfo.Split('@');

            for (int i = dropList.Length - 1; i >= 0; i--)
            {
                string[] dropitem = dropList[i].Split(';');
                int day = int.Parse(dropitem[0]);
                int dropid = int.Parse((dropitem[1]));

                if (openDay >= day)
                {
                    return dropid;
                }
            }

            return int.Parse(dropList[0].Split(';')[1]);
        }
        
        public static void OnTimer(this SingleHappyDungeonComponent self)
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

            int openDay = ServerHelper.GetServeOpenDay( self.Zone());
            int dropid = self.GetDropId(openDay);

            for (int p = 0; p < HappyData.PositionList.Count; p++)
            {
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
                DropHelper.DropIDToDropItem(dropid, rewardist);
                if (rewardist.Count > 100)
                {
                    Log.Error($"rewardist.Count > 100:   {dropid}");
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
    }
}