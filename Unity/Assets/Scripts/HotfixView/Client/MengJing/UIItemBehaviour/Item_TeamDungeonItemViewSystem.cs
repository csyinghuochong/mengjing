using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_TeamDungeonItem))]
    [EntitySystemOf(typeof(Scroll_Item_TeamDungeonItem))]
    public static partial class Scroll_Item_TeamDungeonItemSystem
    {
        [EntitySystem]
        private static void Awake(this Scroll_Item_TeamDungeonItem self)
        {
        }

        [EntitySystem]
        private static void Destroy(this Scroll_Item_TeamDungeonItem self)
        {
            self.DestroyWidget();
        }

        public static void OnButton_Apply(this Scroll_Item_TeamDungeonItem self)
        {
            TeamNetHelper.TeamDungeonApplyRequest(self.Root(), self.TeamInfo.TeamId, self.TeamInfo.SceneId, self.TeamInfo.FubenType,
                self.TeamInfo.PlayerList[0].PlayerLv, true, self.TeamInfo.SceneType).Coroutine();
        }

        public static void OnUpdateUI(this Scroll_Item_TeamDungeonItem self, TeamInfo teamInfo, int sceneType)
        {
            self.E_Button_ApplyButton.AddListener(self.OnButton_Apply);

            self.ImagePlayerList = new GameObject[3];
            self.ImagePlayerList[0] = self.EG_ImagePlayer1RectTransform.gameObject;
            self.ImagePlayerList[1] = self.EG_ImagePlayer2RectTransform.gameObject;
            self.ImagePlayerList[2] = self.EG_ImagePlayer3RectTransform.gameObject;

            self.ImagePlayerNullList = new GameObject[3];
            self.ImagePlayerNullList[0] = self.EG_ImagePlayerNull_1RectTransform.gameObject;
            self.ImagePlayerNullList[1] = self.EG_ImagePlayerNull_2RectTransform.gameObject;
            self.ImagePlayerNullList[2] = self.EG_ImagePlayerNull_3RectTransform.gameObject;
            self.TeamInfo = teamInfo;
            for (int i = 0; i < self.ImagePlayerList.Length; i++)
            {
                if (i >= teamInfo.PlayerList.Count)
                {
                    self.ImagePlayerList[i].SetActive(false);
                    self.ImagePlayerNullList[i].SetActive(true);

                    continue;
                }

                TeamPlayerInfo teamPlayerInfo = teamInfo.PlayerList[i];
                self.ImagePlayerList[i].SetActive(true);
                self.ImagePlayerNullList[i].SetActive(false);
                using (zstring.Block())
                {
                    self.ImagePlayerList[i].transform.Find("Text_Level").GetComponent<Text>().text = zstring.Format("{0}级", teamPlayerInfo.PlayerLv);
                }

                self.ImagePlayerList[i].transform.Find("ImageMask/ImageHead").GetComponent<Image>().sprite = self.Root()
                        .GetComponent<ResourcesLoaderComponent>()
                        .LoadAssetSync<Sprite>(ABPathHelper.GetAtlasPath_2(ABAtlasTypes.PlayerIcon, teamPlayerInfo.Occ.ToString()));
            }

            switch (sceneType)
            {
                case MapTypeEnum.TeamDungeon:
                    SceneConfig teamDungeonConfig = SceneConfigCategory.Instance.Get(teamInfo.SceneId);
                    using (zstring.Block())
                    {
                        self.E_Text_ConditionText.text = zstring.Format("进入条件: {0}级", teamDungeonConfig.EnterLv);
                    }

                    string addStr = "";

                    if (teamInfo.FubenType == TeamFubenType.XieZhu)
                    {
                        int lvCha = self.Root().GetComponent<UserInfoComponentC>().UserInfo.Lv - teamDungeonConfig.EnterLv;
                        if (lvCha >= 10)
                        {
                            addStr = "(帮助模式)";
                        }
                    }

                    if (teamInfo.FubenType == TeamFubenType.ShenYuan)
                    {
                        addStr = "(深渊模式)";
                    }

                    using (zstring.Block())
                    {
                        self.E_Text_NameText.text = zstring.Format("{0}{1}", teamDungeonConfig.Name, addStr);
                        self.E_Text_TuijianText.text = zstring.Format("推荐等级： {0}-{1}级", teamDungeonConfig.TuiJianLv[0], teamDungeonConfig.TuiJianLv[1]);
                    }
                    break;
                case MapTypeEnum.DragonDungeon:
                    CellGenerateConfig cellGenerateConfig = CellGenerateConfigCategory.Instance.Get(teamInfo.SceneId);
                    using (zstring.Block())
                    {
                        self.E_Text_ConditionText.text = zstring.Format("进入条件: {0}级", cellGenerateConfig.EnterLv);
                    }

                    addStr = "";

                    if (teamInfo.FubenType == TeamFubenType.XieZhu)
                    {
                        int lvCha = self.Root().GetComponent<UserInfoComponentC>().UserInfo.Lv - cellGenerateConfig.EnterLv;
                        if (lvCha >= 10)
                        {
                            addStr = "(帮助模式)";
                        }
                    }

                    if (teamInfo.FubenType == TeamFubenType.ShenYuan)
                    {
                        addStr = "(深渊模式)";
                    }

                    string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.TiTleIcon, cellGenerateConfig.Icon);
                    Sprite sp = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path);
                    self.E_ImageIcon.sprite = sp;
                    
                    using (zstring.Block())
                    {
                        self.E_Text_NameText.text = zstring.Format("{0}{1}", cellGenerateConfig.ChapterName, addStr);
                        self.E_Text_TuijianText.text = zstring.Format("推荐等级： {0}-{1}级", cellGenerateConfig.EnterLv, cellGenerateConfig.EnterLv);
                    }
                    break;
                default:
                                       
                    break;
            }
           
        }
    }
}