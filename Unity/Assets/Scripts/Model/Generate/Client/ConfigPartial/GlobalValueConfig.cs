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
        public int PetHeXinMax = 200;

        public int HourseInitCapacity = 0;
        public int HourseMaxCapacity = 0;

        public int GemStoreInitCapacity = 0;
        public int GemStoreMaxCapacity = 0;

        public int OnLineLimit = 0;

        public int AccountBagMax = 0;

        public List<DayMonsters> DayMonsterList = new List<DayMonsters>();

        public List<DayJingLing> DayJingLingList = new List<DayJingLing>();

        public Dictionary<int, int> ZhuaPuItem = new Dictionary<int, int>();
        
        //宝宝刷新概率
        public float BabyRefreshChance = 0.3f;

        public float BabyBianYiRefreshChance = 0.2f;
        //每日最多刷新宝宝数量
        public int BabyRefreshMaxNum = 100000000;
        
        public List<int> ZhuaByGaiLvInit = new List<int>();
        
        //赛季捐选道具ID.
        public  int CommonSeasonDonateItemId = 10024009;

        /// <summary>
        /// 捐选随机获得道具
        /// </summary>
        public  int CommonSeasonDonateGetItem = 601800041;
        
        public int SingleHappyInitTimes = 0;
        public long SingleHappyrecoverTime = 0;
        public int SingleHappyBuyCost = 0;
        public int SingleHappyBuyAdd = 0;
        public int SingleHappyBuyMax = 0;
        public Dictionary<int, int> SingleHappyDrops = new Dictionary<int,int>();

        public override void EndInit()
        {
            DayMonsterList.Clear();
            JianDingFuQulity = int.Parse(this.Get(44).Value);
            FangunSkillId = int.Parse(this.Get(2).Value);
            BagInitCapacity = int.Parse(this.Get(3).Value);
            BagMaxCapacity = BagInitCapacity + int.Parse(this.Get(84).Value);
            HourseInitCapacity = int.Parse(this.Get(4).Value);
            HourseMaxCapacity = HourseInitCapacity + int.Parse(this.Get(85).Value);
            OnLineLimit = int.Parse(this.Get(25).Value);
            AccountBagMax = int.Parse(this.Get(115).Value);
            GemStoreInitCapacity = int.Parse(this.Get(118).Value);
            GemStoreMaxCapacity = int.Parse(this.Get(118).Value);
            BabyRefreshChance = float.Parse(this.Get(124).Value);
            BabyBianYiRefreshChance = float.Parse(this.Get(125).Value);
            BabyRefreshMaxNum = int.Parse(this.Get(126).Value);
            string[] zhubugialv = this.Get(127).Value.Split(";");
            for (int i = 0; i < zhubugialv.Length; i++)
            {
                this.ZhuaByGaiLvInit.Add( int.Parse(zhubugialv[i]) );
            }
            
            CommonSeasonDonateItemId = int.Parse(this.Get(128).Value);
            CommonSeasonDonateGetItem = int.Parse(this.Get(129).Value);

            SingleHappyInitTimes = int.Parse(this.Get(130).Value);
            SingleHappyrecoverTime = long.Parse(this.Get(131).Value) * TimeHelper.Minute;
            string[] singlehappybuy = this.Get(133).Value.Split(";");
            SingleHappyBuyCost = int.Parse(singlehappybuy[0]);
            SingleHappyBuyAdd = int.Parse(singlehappybuy[1]);
            SingleHappyBuyMax = int.Parse(singlehappybuy[2]);
            
            //1;61201001,61200001@19;61202001,61200001@30;61203001,61200001@40;61204001,61200001@50;61205001,61200001
            string dropinfo = this.Get(134).Value;
            string[] dropList = dropinfo.Split('@');

            for (int i = dropList.Length - 1; i >= 0; i--)
            {
                string[] dropitem = dropList[i].Split(';');
                int level = int.Parse(dropitem[0]);
                int dropid = int.Parse(dropitem[1]);
    
                SingleHappyDrops.Add(level, dropid);
            }
            
            string[] dayrefresh = this.Get(79).Value.Split('@');
            for (int i = 0; i < dayrefresh.Length; i++)
            {
                string[] itemInfo = dayrefresh[i].Split(';');
                if (itemInfo.Length < 2)
                {
                    continue;
                }
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
