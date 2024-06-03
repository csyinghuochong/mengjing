﻿using System.Collections.Generic;


namespace ET
{

    public struct DayMonsters
    {
        public int MonsterId;
        public float GaiLv;
        public int TotalNumber;
    }

    public struct DayJingLing
    {
        public List<int> MonsterId;
        public List<int> Weights;
        public float GaiLv;
        public int TotalNumber;
    }

    public partial class GlobalValueConfigCategory
    {

        public int JianDingFuQulity = 0;

        public int FangunSkillId = 0;

        public int BagInitCapacity = 0;
        public int BagMaxCapacity = 0;

        public int HourseInitCapacity = 0;
        public int HourseMaxCapacity = 0;

        public int GemStoreInitCapacity = 0;
        public int GemStoreMaxCapacity = 0;

        public int OnLineLimit = 0;
        public int MaxLevel = 70;
        public int AccountBagMax = 0;

        public List<DayMonsters> DayMonsterList = new List<DayMonsters>();

        public List<DayJingLing> DayJingLingList = new List<DayJingLing>();

        public Dictionary<int, int> ZhuaPuItem = new Dictionary<int, int>();

        public override void EndInit()
        {
            DayMonsterList.Clear();
            JianDingFuQulity = this.Get(44).Value2;
            FangunSkillId = int.Parse(this.Get(2).Value);
            BagInitCapacity = this.Get(3).Value2;
            BagMaxCapacity = BagInitCapacity + this.Get(84).Value2;
            HourseInitCapacity = this.Get(4).Value2;
            HourseMaxCapacity = HourseInitCapacity + this.Get(85).Value2;
            OnLineLimit = int.Parse(this.Get(25).Value);
            AccountBagMax = this.Get(115).Value2;
            GemStoreInitCapacity = this.Get(118).Value2; 
            GemStoreMaxCapacity = this.Get(118).Value2; 

            string[] dayrefresh = this.Get(79).Value.Split('@');
            for (int i = 0; i < dayrefresh.Length; i++)
            {
                string[] itemInfo = dayrefresh[i].Split(';');
                int monsterId = int.Parse(itemInfo[0]);
                float gaiLv = float.Parse(itemInfo[1]);
                int total = int.Parse(itemInfo[2]);
                DayMonsterList.Add(new DayMonsters()
                {
                    MonsterId = monsterId,
                    GaiLv = gaiLv,
                    TotalNumber = total
                });
            }

            string[] jinglingfresh = this.Get(80).Value.Split('@');
            for (int i = 0; i < jinglingfresh.Length; i++)
            {
                string[] itemInfo = jinglingfresh[i].Split(';');
                float gaiLv = float.Parse(itemInfo[0]);
                int total = int.Parse(itemInfo[1]);

                DayJingLing dayJingLing = new DayJingLing();
                dayJingLing.MonsterId = new List<int>();
                dayJingLing.Weights = new List<int>();

                string[] monsterIist = itemInfo[2].Split('&');
                for (int m = 0; m < monsterIist.Length; m++)
                {
                    string[] monsterid = monsterIist[m].Split(',');
                    dayJingLing.Weights.Add(int.Parse(monsterid[0]));
                    dayJingLing.MonsterId.Add(int.Parse(monsterid[1]));
                }

                dayJingLing.GaiLv = gaiLv;
                dayJingLing.TotalNumber = total;    
                DayJingLingList.Add(dayJingLing);
            }

            string[] zhuabuItems = this.Get(82).Value.Split('@');
            for (int i = 0; i < zhuabuItems.Length; i++)
            {
                string[] zhubuids = zhuabuItems[i].Split(';');
                ZhuaPuItem.Add(int.Parse(zhubuids[0]), int.Parse(zhubuids[1]));
            }
        }


    }
}
