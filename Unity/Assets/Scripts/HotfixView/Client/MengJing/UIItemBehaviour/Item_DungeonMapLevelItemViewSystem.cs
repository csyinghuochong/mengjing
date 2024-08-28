using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_DungeonMapLevelItem))]
    [EntitySystemOf(typeof(Scroll_Item_DungeonMapLevelItem))]
    public static partial class Scroll_Item_DungeonMapLevelItemSystem
    {
        [EntitySystem]
        private static void Awake(this Scroll_Item_DungeonMapLevelItem self)
        {
        }

        [EntitySystem]
        private static void Destroy(this Scroll_Item_DungeonMapLevelItem self)
        {
            self.DestroyWidget();
        }

        public static void Refresh(this Scroll_Item_DungeonMapLevelItem self, int levelIndex, int levelId, int diff)
        {
            self.LevelIndex = levelIndex;
            self.LevelId = levelId;

            DungeonConfig dungeonConfig = DungeonConfigCategory.Instance.Get(levelId);
            self.E_LevelNameText.text = dungeonConfig.ChapterName;

            using (zstring.Block())
            {
                // self.E_EnterLevelText.text = zstring.Format("第{0}关", levelIndex + 1);
                self.E_EnterLevelText.text = zstring.Format("挑战等级：{0}", dungeonConfig.EnterLv);
            }

            self.SetNanDu(diff);
        }

        public static void SetNanDu(this Scroll_Item_DungeonMapLevelItem self, int value)
        {
            CommonViewHelper.SetImageGray(self.Root(), self.E_NanDu_1Image.gameObject, value != 1);
            CommonViewHelper.SetImageGray(self.Root(), self.E_NanDu_2Image.gameObject, value != 2);
            CommonViewHelper.SetImageGray(self.Root(), self.E_NanDu_3Image.gameObject, value != 3);
        }
    }
}