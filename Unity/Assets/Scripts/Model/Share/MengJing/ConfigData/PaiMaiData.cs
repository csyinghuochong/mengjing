using System.Collections.Generic;

namespace ET
{
    //成就类型数据
    [EnableClass]
    public class PaiMaiTypeData
    {
        //每个章节对应的拍卖道具
        public Dictionary<int, List<int>> PaiMaiIDItemList = new Dictionary<int, List<int>>();
    }

    public enum PaiMaiTypeEnum : int
    {
        None = 0,
        CaiLiao = 1,
        CostItem = 2,
        PetItem = 3,
        Number = 4,
    }

    public static class PaiMaiData
    {

        [StaticField]
        public static List<string> PaiMaiTypeText = new List<string>() { "", "材料", "消耗品", "宠物" };

        [StaticField]
        public static Dictionary<int, string> PaiMaiIndexText = new Dictionary<int, string>()
    {
        { 1, "第一章" },
        { 2, "第二章" },
        { 3, "第三章" },
        { 4, "第四章" },
        { 5, "第五章" },
        { 21, "通用" },
        { 22, "宝石" },
        { 31, "技能" },
        { 32, "消耗" },
        /*
        {31,  "红色插槽" },
        {32,  "紫色插槽" },
        {33,  "蓝色插槽" },
        {34,  "绿色插槽" },
        {35,  "白色插槽" },
        {36,  "抗性宝石" },
        */
    };

        [StaticField]
        public static Dictionary<int, List<int>> PaiMaiIDItemList = new Dictionary<int, List<int>>();

        [StaticField]
        private static List<PaiMaiTypeData> paiMaiTypeData;


        [StaticField]
        public static List<PaiMaiTypeData> PaiMaiTypeData
        {
            get
            {
                if (paiMaiTypeData == null)
                {
                    paiMaiTypeData = new();
                    for (int i = 0; i < (int)PaiMaiTypeEnum.Number + 1; i++)
                    {
                        paiMaiTypeData.Add(new PaiMaiTypeData());
                    }

                    Dictionary<int, PaiMaiSellConfig> allPaiMaiData = PaiMaiSellConfigCategory.Instance.GetAll();
                    foreach (var item in allPaiMaiData)
                    {
                        PaiMaiSellConfig paiMaiSellConfig = item.Value;
                        int paiMaiType = paiMaiSellConfig.PaiMaiType;
                        int chapterId = paiMaiSellConfig.ChapterId;
                        PaiMaiTypeData paiMaiTypeDatas = paiMaiTypeData[paiMaiType];
                        if (!paiMaiTypeDatas.PaiMaiIDItemList.ContainsKey(chapterId))
                        {
                            paiMaiTypeDatas.PaiMaiIDItemList.Add(chapterId, new List<int>());
                        }

                        paiMaiTypeDatas.PaiMaiIDItemList[chapterId].Add(item.Key);
                    }
                }

                return paiMaiTypeData;
            }
            set
            {
                paiMaiTypeData = value;
            }
        }
    }
}