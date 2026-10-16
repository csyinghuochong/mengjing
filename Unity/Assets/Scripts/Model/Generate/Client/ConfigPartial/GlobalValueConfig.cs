using System.Collections.Generic;

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
        public int BagMaxCapacity = 0;
        public int PetHeXinMax = 200;

        public int HourseMaxCapacity = 0;

        public List<DayMonsters> DayMonsterList = new List<DayMonsters>();

        public List<DayJingLing> DayJingLingList = new List<DayJingLing>();

        public Dictionary<int, int> ZhuaPuItem = new Dictionary<int, int>();

        public List<int> ZhuaByGaiLvInit = new List<int>();

        public int SingleHappyBuyCost = 0;
        public int SingleHappyBuyAdd = 0;
        public int SingleHappyBuyMax = 0;

        public Dictionary<int, int> SingleHappyDrops = new Dictionary<int, int>();

        partial void PostInit()
        {
            DayMonsterList.Clear();
            BagMaxCapacity = BagInitCapacity + BuyBagCellMaxNum;
            HourseMaxCapacity = HourseInitCapacity + BuyHourseCellMaxNum;
            string[] zhubugialv = ZhuaByGaiLvInit_Str.Split(";");
            for (int i = 0; i < zhubugialv.Length; i++)
            {
                this.ZhuaByGaiLvInit.Add(int.Parse(zhubugialv[i]));
            }

            string[] singlehappybuy = SingleHappyBuy_Str.Split(";");
            SingleHappyBuyCost = int.Parse(singlehappybuy[0]);
            SingleHappyBuyAdd = int.Parse(singlehappybuy[1]);
            SingleHappyBuyMax = int.Parse(singlehappybuy[2]);

            //1;61201001,61200001@19;61202001,61200001@30;61203001,61200001@40;61204001,61200001@50;61205001,61200001
            string dropinfo = SingleHappyDrops_Str;
            string[] dropList = dropinfo.Split('@');

            for (int i = dropList.Length - 1; i >= 0; i--)
            {
                string[] dropitem = dropList[i].Split(';');
                int level = int.Parse(dropitem[0]);
                int dropid = int.Parse(dropitem[1]);

                SingleHappyDrops.Add(level, dropid);
            }

            string[] dayrefresh = DayMonsterList_Str.Split('@');
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

            string[] jinglingfresh = DayJingLingList_Str.Split('@');
            for (int i = 0; i < jinglingfresh.Length; i++)
            {
                //0.003;2;100,80006001&100,80006002&100,80006003&80,80006004&80,80006005&80,80006006&60,80006007&60,80006008&40,80006009&40,80006010

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

            string[] zhuabuItems = ZhuaPuItem_Str.Split('@');
            for (int i = 0; i < zhuabuItems.Length; i++)
            {
                string[] zhubuids = zhuabuItems[i].Split(';');
                ZhuaPuItem.Add(int.Parse(zhubuids[0]), int.Parse(zhubuids[1]));
            }
        }
    }
}