using System;
using UnityEngine;

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

        public static void Refresh(this Scroll_Item_DungeonMapLevelItem self, int monsterConfigId, long refreshTime)
        {
            self.E_EnterMapButton.AddListener(self.OnEnterMap);

            self.MonsterConfigId = monsterConfigId;
            self.RefreshTime = refreshTime;

            MonsterConfig monsterConfig = MonsterConfigCategory.Instance.Get(monsterConfigId);
            string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.MonsterIcon, monsterConfig.MonsterHeadIcon);
            Sprite sp = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path);

            self.E_IconImage.sprite = sp;
            self.E_NameText.text = monsterConfig.MonsterName;

            self.LevelId = SceneConfigHelper.GetFubenByMonster(monsterConfig.Id);
            // self.E_MapText.text = DungeonConfigCategory.Instance.Get(self.LevelId).ChapterName;

            self.RefreshTime();
        }

        private static void OnEnterMap(this Scroll_Item_DungeonMapLevelItem self)
        {
            DlgDungeonMap dlgDungeonMap = self.GetParent<DlgDungeonMap>();
            dlgDungeonMap.LevelId = self.LevelId;
            dlgDungeonMap.OnEnterMapButtonClick().Coroutine();
        }

        public static void RefreshTime(this Scroll_Item_DungeonMapLevelItem self)
        {
            long time = self.RefreshTime;
            if (time > TimeHelper.ServerNow())
            {
                time -= TimeHelper.ServerNow();
                time /= 1000;
                int hour = (int)time / 3600;
                int min = (int)((time - (hour * 3600)) / 60);
                int sec = (int)(time - (hour * 3600) - (min * 60));
                using (zstring.Block())
                {
                    self.E_TimeText.text = zstring.Format("刷新时间:{0}时{1}分", hour, min);
                }
            }
            else
            {
                self.E_TimeText.text = "已刷新";
            }
        }
    }
}