using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [EntitySystemOf(typeof(Scroll_Item_MonsterItem))]
    public static partial class Scroll_Item_MonsterItemSystem
    {
        [EntitySystem]
        private static void Awake(this Scroll_Item_MonsterItem self)
        {
        }

        [EntitySystem]
        private static void Destroy(this Scroll_Item_MonsterItem self)
        {
            self.DestroyWidget();
        }

        public static void Refresh(this Scroll_Item_MonsterItem self, int monsterId)
        {
            MonsterConfig monsterConfig = MonsterConfigCategory.Instance.Get(monsterId);
            string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.MonsterIcon, monsterConfig.MonsterHeadIcon);
            Sprite sp = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path);
            self.E_IconImage.sprite = sp;
            self.E_NameText.text = monsterConfig.MonsterName;
            using (zstring.Block())
            {
                self.E_LvText.text = zstring.Format("等级:{0}", monsterConfig.Lv);
            }
        }
    }
}