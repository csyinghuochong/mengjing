using System.Collections.Generic;

namespace ET.Client
{
    [Event(SceneType.Demo)]
    public class BagItemItemAdd_RefreshShouji : AEvent<Scene, BagItemItemAdd>
    {
        protected override async ETTask Run(Scene scene, BagItemItemAdd args)
        {
            scene.GetComponent<ShoujiComponentC>()?.OnGetItem(args.ItemId);
            await ETTask.CompletedTask;
        }
    }
    
    [FriendOf(typeof(ShoujiComponentC))]
    [EntitySystemOf(typeof(ShoujiComponentC))]
    public static partial class ShoujiComponentCSystem
    {
        [EntitySystem]
        private static void Awake(this ShoujiComponentC self)
        {
        }

        public static ShouJiChapterInfo GetShouJiChapterInfo(this ShoujiComponentC self, int chapterId)
        {
            for (int i = 0; i < self.ShouJiChapterInfos.Count; i++)
            {
                if (self.ShouJiChapterInfos[i].ChapterId == chapterId)
                {
                    return self.ShouJiChapterInfos[i];
                }
            }

            return null;
        }

        public static int GetChapterStar(this ShoujiComponentC self, int chapterid)
        {
            ShouJiChapterInfo shouJiChapterInfo = self.GetShouJiChapterInfo(chapterid);
            return shouJiChapterInfo != null ? shouJiChapterInfo.StarNum : 0;
        }

        public static List<PropertyValue> GetChapterPro(this ShoujiComponentC self, int chapterid, int level)
        {
            List<PropertyValue> proList = new List<PropertyValue>();
            int star = self.GetChapterStar(chapterid);
            ShouJiConfig shouJiConfig = ShouJiConfigCategory.Instance.Get(chapterid);
            if (level == 1 && star >= shouJiConfig.ProList1_StartNum)
            {
                for (int i = 0; i < shouJiConfig.ProList1_Type.Length; i++)
                {
                    proList.Add(new PropertyValue() { HideID = shouJiConfig.ProList1_Type[i], HideValue = shouJiConfig.ProList1_Value[i] });
                }
            }

            if (level == 2 && star >= shouJiConfig.ProList2_StartNum)
            {
                for (int i = 0; i < shouJiConfig.ProList2_Type.Length; i++)
                {
                    proList.Add(new PropertyValue() { HideID = shouJiConfig.ProList2_Type[i], HideValue = shouJiConfig.ProList2_Value[i] });
                }
            }

            if (level == 3 && star >= shouJiConfig.ProList3_StartNum)
            {
                for (int i = 0; i < shouJiConfig.ProList3_Type.Length; i++)
                {
                    proList.Add(new PropertyValue() { HideID = shouJiConfig.ProList3_Type[i], HideValue = shouJiConfig.ProList3_Value[i] });
                }
            }

            return proList;
        }

        public static bool HaveShouJiItem(this ShoujiComponentC self, int chapterId, int itemId)
        {
            ShouJiChapterInfo shouJiChapterInfo = self.GetShouJiChapterInfo(chapterId);
            if (shouJiChapterInfo == null)
            {
                return false;
            }

            return shouJiChapterInfo.ShouJiItemList.Contains(itemId);
        }

        public static KeyValuePairInt GetTreasureInfo(this ShoujiComponentC self, int shoujiId)
        {
            KeyValuePairInt keyValuePairInt = null;
            for (int i = 0; i < self.TreasureInfo.Count; i++)
            {
                if (self.TreasureInfo[i].KeyId == shoujiId)
                {
                    keyValuePairInt = self.TreasureInfo[i];
                }
            }

            return keyValuePairInt;
        }

        public static void OnGetItem(this ShoujiComponentC self, int itemId)
        {
            ItemStarInfo itemStarInfo = null;
            List<ItemStarInfo> itemStars = ShouJiConfigCategory.Instance.GetItemStarInfos();
            for (int i = 0; i < itemStars.Count; i++)
            {
                if (itemStars[i].ItemId == itemId && itemStars[i].StartType == 1)
                {
                    itemStarInfo = itemStars[i];
                    break;
                }
            }
            if (itemStarInfo == null)
            {
                return;
            }
        
            ShouJiChapterInfo shouJiChapterInfo = self.GetShouJiChapterInfo(itemStarInfo.Chapter);
            if (shouJiChapterInfo == null)
            {
                shouJiChapterInfo = ShouJiChapterInfo.Create();
                shouJiChapterInfo.RewardInfo = 0;
                shouJiChapterInfo.ChapterId = itemStarInfo.Chapter;
                self.ShouJiChapterInfos.Add(shouJiChapterInfo);
            }
            if (!shouJiChapterInfo.ShouJiItemList.Contains(itemStarInfo.ItemId))
            {
                shouJiChapterInfo.ShouJiItemList.Add(itemStarInfo.ItemId);
                shouJiChapterInfo.StarNum += itemStarInfo.Star;
            }
        }
        
        public static void OnShouJiTreasure(this ShoujiComponentC self, int shoujiId, int itemNum)
        {
            KeyValuePairInt keyValuePairInt = null;
            for (int i = 0; i < self.TreasureInfo.Count; i++)
            {
                if (self.TreasureInfo[i].KeyId == shoujiId)
                {
                    keyValuePairInt = self.TreasureInfo[i];
                    keyValuePairInt.Value = itemNum;
                }
            }

            if (keyValuePairInt == null)
            {
                keyValuePairInt = new KeyValuePairInt() { KeyId = shoujiId, Value = itemNum };
                self.TreasureInfo.Add(keyValuePairInt);
            }

            self.OnActiveTreasureItem(shoujiId);
        }
        
        private static void OnActiveTreasureItem(this ShoujiComponentC self, int shoujiId)
        {
            if (!ShouJiItemConfigCategory.Instance.Contain(shoujiId))
            {
                return;
            }

            ShouJiItemConfig shouJiItemConfig = ShouJiItemConfigCategory.Instance.Get(shoujiId);

            bool active = false;
            foreach (KeyValuePairInt keyValuePairInt in self.TreasureInfo)
            {
                if (keyValuePairInt.KeyId == shoujiId)
                {
                    if (keyValuePairInt.Value >= shouJiItemConfig.AcitveNum)
                    {
                        active = true;
                        break;
                    }
                }
            }

            if (!active)
            {
                return;
            }
        
        
            ItemStarInfo itemStarInfo = null;
            List<ItemStarInfo> itemStars = ShouJiConfigCategory.Instance.GetItemStarInfos();
            for (int i = 0; i < itemStars.Count; i++)
            {
                if (itemStars[i].ItemId == shouJiItemConfig.ItemID && itemStars[i].StartType == 2)
                {
                    itemStarInfo = itemStars[i];
                }
            }
            if (itemStarInfo == null)
            {
                return;
            }
        
            ShouJiChapterInfo shouJiChapterInfo = self.GetShouJiChapterInfo(itemStarInfo.Chapter);
            if (shouJiChapterInfo == null)
            {
                shouJiChapterInfo = ShouJiChapterInfo.Create();
                shouJiChapterInfo.RewardInfo = 0;
                shouJiChapterInfo.ChapterId = itemStarInfo.Chapter;
                self.ShouJiChapterInfos.Add(shouJiChapterInfo);
            }
            if (!shouJiChapterInfo.ShouJiItemList.Contains(itemStarInfo.ItemId))
            {
                shouJiChapterInfo.ShouJiItemList.Add(itemStarInfo.ItemId);
                shouJiChapterInfo.StarNum += itemStarInfo.Star;
            }
        }
    }
}