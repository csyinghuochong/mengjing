using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_BossRefreshTimeItem))]
    [EntitySystemOf(typeof(Scroll_Item_BossRefreshTimeItem))]
    public static partial class Scroll_Item_BossRefreshTimeItemSystem
    {
        [EntitySystem]
        private static void Awake(this Scroll_Item_BossRefreshTimeItem self)
        {
        }

        [EntitySystem]
        private static void Destroy(this Scroll_Item_BossRefreshTimeItem self)
        {
            self.DestroyWidget();
        }

        public static void Refresh(this Scroll_Item_BossRefreshTimeItem self, int monsterConfigId, long refreshTime)
        {
            self.RefreshTime = refreshTime;

            MonsterConfig monsterConfig = MonsterConfigCategory.Instance.Get(monsterConfigId);
            string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.MonsterIcon, monsterConfig.MonsterHeadIcon);
            Sprite sp = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path);

            self.E_PhotoImage.sprite = sp;
            self.E_NameText.text = monsterConfig.MonsterName;

            int dungeonid = SceneConfigHelper.GetFubenByMonster(monsterConfig.Id);
            if (dungeonid > 0)
            {
                using (zstring.Block())
                {
                    self.E_MapText.text = zstring.Format("({0})", DungeonConfigCategory.Instance.Get(dungeonid).ChapterName);
                }
            }

            self.RefreshTime();
        }

        public static void RefreshTime(this Scroll_Item_BossRefreshTimeItem self)
        {
            long time = self.RefreshTime;
            if (time > TimeHelper.ServerNow())
            {
                time -= TimeHelper.ClientNow();
                time /= 1000;
                int hour = (int)time / 3600;
                int min = (int)((time - (hour * 3600)) / 60);
                int sec = (int)(time - (hour * 3600) - (min * 60));
                using (zstring.Block())
                {
                    string showStr = zstring.Format("{0}时{1}分{2}秒", hour, min, sec);
                    self.E_TimeText.text = zstring.Format("刷新时间:{0}", showStr);
                }
            }
            else
            {
                self.E_TimeText.text = "已刷新";
            }
        }
    }
}