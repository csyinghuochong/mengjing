using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof(DlgTeamDungeonCreate))]
    public static class DlgTeamDungeonCreateSystem
    {
        public static void RegisterUIEvent(this DlgTeamDungeonCreate self)
        {
            self.View.E_Button_XieZhuButton.AddListener(() => { self.OnButton_Create(TeamFubenType.XieZhu).Coroutine(); });
            self.View.E_Button_CreateButton.AddListener(() => { self.OnButton_Create(TeamFubenType.Normal).Coroutine(); });
            self.View.E_ShenYuanButtonButton.AddListener(() => { self.OnShenYuanMode(); });
            self.View.E_CloseButtonButton.AddListener(self.OnCloseButtonButton);
            
            self.View.EG_TeamdungeonItemRectTransform.gameObject.SetActive(false);
            List<SceneConfig> sceneConfig = SceneConfigCategory.Instance.GetAll().Values.ToList();
            PlayerInfoComponent playerInfoComponent = self.Root().GetComponent<PlayerInfoComponent>();
            bool isGmaccount = GMData.GmAccount.Contains(playerInfoComponent.Account);
            for (int i = 0; i < sceneConfig.Count; i++)
            {
                if (sceneConfig[i].MapType != (int)MapTypeEnum.TeamDungeon)
                {
                    continue;
                }

                if (!isGmaccount && sceneConfig[i].Id >= ConfigData.GmTeamdungeonId)
                {
                    continue;
                }

                self.FubenIdList.Add(sceneConfig[i].Id);
                GameObject item = UnityEngine.Object.Instantiate(self.View.EG_TeamdungeonItemRectTransform.gameObject);
                CommonViewHelper.SetParent(item, self.View.EG_TeamdungeonListRectTransform.gameObject);
                item.SetActive(true);
                self.ButtonList.Add(item.transform);

                //更新显示
                ReferenceCollector rcSon = item.GetComponent<ReferenceCollector>();
                using (zstring.Block())
                {
                    rcSon.Get<GameObject>("Lab_Lv").GetComponent<Text>().text = zstring.Format("进入等级:{0}级", sceneConfig[i].EnterLv);
                }

                rcSon.Get<GameObject>("Lab_Name").GetComponent<Text>().text = sceneConfig[i].Name;

                string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.TiTleIcon, sceneConfig[i].Icon);
                Sprite sp = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path);

                rcSon.Get<GameObject>("Img_Show").GetComponent<Image>().sprite = sp;

                item.GetComponent<Button>().onClick.AddListener(() => { self.OnClickButton(item.transform); });
            }

            self.OnClickButton(self.ButtonList[0]);

            self.View.E_Button_XieZhuButton.gameObject.SetActive(true);
            self.View.EG_ShenYuanRectTransform.gameObject.SetActive(true);
            self.View.E_CloseButtonButton.AddListener(() =>
            {
                self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_TeamDungeonCreate);
            });
        }

        public static void ShowWindow(this DlgTeamDungeonCreate self, Entity contextData = null)
        {
        }

        public static void OnClickButton(this DlgTeamDungeonCreate self, Transform transform)
        {
            int index = self.ButtonList.IndexOf(transform);
            for (int i = 0; i < self.ButtonList.Count; i++)
            {
                self.ButtonList[i].Find("E_ImageSelect").gameObject.SetActive(i == index);
            }

            self.OnUpdatUI(self.FubenIdList[index]);
        }

        public static void OnUpdatUI(this DlgTeamDungeonCreate self, int fubenId)
        {
            self.FubenId = fubenId;
            SceneConfig sceneConfig = SceneConfigCategory.Instance.Get(fubenId);

            int bossId = sceneConfig.BossId;
            MonsterConfig monsterConfig = MonsterConfigCategory.Instance.Get(bossId);
            List<RewardItem> allRewardItems = new List<RewardItem>();
            for (int i = 0; i < monsterConfig.DropID.Length; i++)
            {
                if (monsterConfig.DropID[i] != 0)
                {
                    allRewardItems.AddRange(DropHelper.DropIDToShowItem(monsterConfig.DropID[i], 4));
                }
            }

            allRewardItems.AddRange(ItemHelper.GetRewardItems(sceneConfig.RewardShow));

            List<RewardItem> rewardItems = new List<RewardItem>();
            for (int i = allRewardItems.Count - 1; i >= 0; i--)
            {
                bool have = false;
                RewardItem rewardItem = allRewardItems[i];
                for (int k = 0; k < rewardItems.Count; k++)
                {
                    if (rewardItems[k].ItemID == rewardItem.ItemID)
                    {
                        have = true;
                        break;
                    }
                }

                if (have)
                {
                    continue;
                }

                ItemConfig itemConfig = ItemConfigCategory.Instance.Get(allRewardItems[i].ItemID);
                if (itemConfig.ItemQuality < 4)
                {
                    continue;
                }

                rewardItems.Add(rewardItem);
            }

            self.View.ES_RewardList.Refresh(rewardItems);

            self.View.E_TextLevelLimitText.text = sceneConfig.EnterLv.ToString();
            using (zstring.Block())
            {
                self.View.E_TextPlayerLimitText.text = zstring.Format("{0}-3人", sceneConfig.PlayerLimit);
            }

            self.View.E_TextFubenDescText.text = sceneConfig.ChapterDes;
            self.View.E_TextFubenName2Text.text = sceneConfig.Name;

            // string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.TiTleIcon, sceneConfig.Icon2);
            // Sprite sp = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path);
            // self.View.E_DungeonImgImage.sprite = sp;
        }

        public static void OnButton_Close(this DlgTeamDungeonCreate self)
        {
            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_TeamDungeonCreate);
        }

        public static void OnShenYuanMode(this DlgTeamDungeonCreate self)
        {
            self.View.E_ShenYuanModeImage.gameObject.SetActive(!self.View.E_ShenYuanModeImage.gameObject.activeSelf);
        }

        public static async ETTask OnButton_Create(this DlgTeamDungeonCreate self, int dungeonType)
        {
            bool shenyuan = self.View.E_ShenYuanModeImage.gameObject.activeSelf;
            if (dungeonType == TeamFubenType.Normal && shenyuan)
            {
                BagComponentC bagComponent = self.Root().GetComponent<BagComponentC>();
                if (bagComponent.GetItemNumber(ConfigData.ShenYuanCostId) < 1)
                {
                    using (zstring.Block())
                    {
                        FlyTipComponent.Instance.ShowFlyTip(zstring.Format("需要道具{0}！",
                            ItemConfigCategory.Instance.Get(ConfigData.ShenYuanCostId).ItemName));
                    }

                    return;
                }

                dungeonType = TeamFubenType.ShenYuan;
            }

            SceneConfig sceneConfig = SceneConfigCategory.Instance.Get(self.FubenId);
            UserInfo userInfo = self.Root().GetComponent<UserInfoComponentC>().UserInfo;
            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            if (dungeonType == TeamFubenType.XieZhu && sceneConfig.EnterLv <= userInfo.Lv - 10)
            {
                int totalTimes = GlobalValueConfigCategory.Instance.MaxTeamDungeonsPerDay;
                int times = unit.GetTeamDungeonTimes();

                int totalTimes_2 = GlobalValueConfigCategory.Instance.MaxDailyXieZhuFubens;
                int times_2 = unit.GetTeamDungeonXieZhu();

                if (totalTimes - times > 0 && totalTimes_2 - times_2 <= 0)
                {
                    PopupTipHelp.OpenPopupTip(self.Root(), "系统提示", "帮助副本次数已尽，开启副本会消耗正常次数。",  () =>
                    {
                        self.RequestDragonDungeonCreate(dungeonType).Coroutine();
                    }, null).Coroutine();
                    return;
                }
            }

            self.RequestDragonDungeonCreate(dungeonType).Coroutine();
            await ETTask.CompletedTask;
        }
        
        private static async ETTask RequestDragonDungeonCreate(this DlgTeamDungeonCreate self, int dungeonType)
        {
            int errorCode = await TeamNetHelper.RequestTeamDungeonCreate(self.Root(), self.FubenId, dungeonType, MapTypeEnum.TeamDungeon);
            if (errorCode != ErrorCode.ERR_Success)
            {
                HintHelp.ShowErrorHint(self.Root(), errorCode);
                return;
            } 
            
            Scene root = self.Root();
            await root.GetComponent<TimerComponent>().WaitAsync(TimeHelper.Second);
            root.GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_TeamDungeonCreate);
            root.GetComponent<UIComponent>().GetDlgLogic<DlgDragonDungeon>().View.E_FunctionSetBtnToggleGroup.OnSelectIndex(1);
            //await root.GetComponent<TimerComponent>().WaitAsync(TimeHelper.Second);
            FlyTipComponent.Instance.ShowFlyTip($"创建{SceneConfigCategory.Instance.Get(self.FubenId).Name}副本成功！");
        }
        
        public static void OnCloseButtonButton(this DlgTeamDungeonCreate self)
        {
        }
    }
}
