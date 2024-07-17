using UnityEngine;

namespace ET.Client
{
    [EntitySystemOf(typeof (Scroll_Item_BossRefreshSettingItem))]
    public static partial class Scroll_Item_BossRefreshSettingItemSystem
    {
        [EntitySystem]
        private static void Awake(this Scroll_Item_BossRefreshSettingItem self)
        {
        }

        [EntitySystem]
        private static void Destroy(this Scroll_Item_BossRefreshSettingItem self)
        {
            self.DestroyWidget();
        }

        public static void Refresh(this Scroll_Item_BossRefreshSettingItem self, int bossConfigId)
        {
            MonsterConfig monsterConfig = MonsterConfigCategory.Instance.Get(bossConfigId);
            self.E_NameTextText.text = monsterConfig.MonsterName;

            // 按钮
            if (!PlayerPrefs.HasKey(bossConfigId.ToString()))
            {
                PlayerPrefs.SetString(bossConfigId.ToString(), "1");
            }

            self.E_ShowTextImage.gameObject.SetActive(PlayerPrefs.GetString(bossConfigId.ToString()) == "1");
        }
    }
}