
using System.Collections.Generic;

namespace ET
{
    public class ItemStarInfo
    {
        public int ItemId;
        public int Star;
        public int Chapter;
    }
    
    public partial class ShouJiConfigCategory
    {
        
        public List<ItemStarInfo> ItemStarInfos = new List<ItemStarInfo>();
        
        public override void EndInit()
        {
            foreach (ShouJiConfig sceneConfig in this.GetAll().Values)
            {
                int itemId = sceneConfig.ItemListID;
                while (itemId != 0)
                { 
                    // ShouJiItemConfig shouJiItemConfig = ShouJiItemConfigCategory.Instance.Get(itemId);
                    // itemId = shouJiItemConfig.NextID;
                    // ItemStarInfo itemStarInfo = new ItemStarInfo();
                    // itemStarInfo.ItemId = shouJiItemConfig.ItemID;
                    // itemStarInfo.Star = shouJiItemConfig.StartNum;
                    // itemStarInfo.Chapter = sceneConfig.Id;
                    // this.ItemStarInfos.Add(itemStarInfo);
                }
            }
        }

        
    }
}