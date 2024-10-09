using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_CellDungeonItem))]
    [EntitySystemOf(typeof(Scroll_Item_CellDungeonItem))]
    public static partial class Scroll_Item_CellDungeonItemSystem
    {
        [EntitySystem]
        private static void Awake(this Scroll_Item_CellDungeonItem self)
        {
        }

        [EntitySystem]
        private static void Destroy(this Scroll_Item_CellDungeonItem self)
        {
            self.DestroyWidget();
        }

        public static void Refresh(this Scroll_Item_CellDungeonItem self, int levelId)
        {
            self.E_ImageButtonButton.AddListener(self.OnClick);
            self.LevelId = levelId;

            CellGenerateConfig cellGenerateConfig = CellGenerateConfigCategory.Instance.Get(levelId);
            self.E_Lab_ChapSonNameOutText.text = cellGenerateConfig.ChapterName;
            using (zstring.Block())
            {
                self.E_Lab_EnterLevelText.text = zstring.Format("挑战等级：{0}", cellGenerateConfig.EnterLv);
            }

            // FubenPassInfo fubenPassInfo = self.Root().GetComponent<UserInfoComponentC>().GetPassInfoByID(levelId);
            // self.ImagePutong.SetActive(self.Root().GetComponent<UserInfoComponentC>().UserInfo.Lv >= cellGenerateConfig.EnterLv);
            // self.ImageTiaozhan.SetActive(fubenPassInfo != null && fubenPassInfo.Difficulty >= (int)FubenDifficulty.Normal);
            // self.ImageKunnan.SetActive(fubenPassInfo != null && fubenPassInfo.Difficulty >= (int)FubenDifficulty.TiaoZhan);

            // string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.MonsterIcon, cellGenerateConfig.BossIcon.ToString());
            string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.MonsterIcon, 70001004.ToString());
            Sprite sp = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path);
            self.E_ImageBossIconImage.sprite = sp;
        }

        public static void OnClick(this Scroll_Item_CellDungeonItem self)
        {
            self.GetParent<DlgCellChapterSelect>().OnSelect(self.LevelId);
        }
    }
}