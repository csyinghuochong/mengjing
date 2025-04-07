
using System;
using System.Collections.Generic;

namespace ET
{
    
    [EnableClass]
    public class ItemStarInfo
    {
        public int StartType;
        public int ItemId;
        public int Star;
        public int Chapter;
    }
    
    public partial class ShouJiConfigCategory
    {
        
        private List<ItemStarInfo> ItemStarInfos = new List<ItemStarInfo>();
        private readonly object _lockObject = new object();
        
        
        public override void EndInit()
        {
            ItemStarInfos.Clear();
        }

        public List<ItemStarInfo> GetItemStarInfos()
        {
            if (ItemStarInfos.Count > 0)
            {
                return ItemStarInfos;
            }

            lock (_lockObject)
            {
                foreach (ShouJiConfig sceneConfig in this.GetAll().Values)
                {
                    int itemId = sceneConfig.ItemListID;
                    while (itemId != 0)
                    { 
                        ShouJiItemConfig shouJiItemConfig = ShouJiItemConfigCategory.Instance.Get(itemId);
                        itemId = shouJiItemConfig.NextID;
                        ItemStarInfo itemStarInfo = new ItemStarInfo();
                        itemStarInfo.StartType = shouJiItemConfig.StartType;
                        itemStarInfo.ItemId = shouJiItemConfig.ItemID;
                        itemStarInfo.Star = shouJiItemConfig.StartNum;
                        itemStarInfo.Chapter = sceneConfig.Id;
                        this.ItemStarInfos.Add(itemStarInfo);
                    }
                }
            }

            Console.WriteLine($" this.ItemStarInfos.count: { this.ItemStarInfos.Count}");
            return ItemStarInfos;
        }
    }
}