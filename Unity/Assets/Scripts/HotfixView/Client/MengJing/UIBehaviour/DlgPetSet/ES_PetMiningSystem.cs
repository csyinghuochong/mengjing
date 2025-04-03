using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [EntitySystemOf(typeof(ES_PetMining))]
    [FriendOfAttribute(typeof(ES_PetMining))]
    [FriendOf(typeof(ES_PetMiningItem))]
    public static partial class ES_PetMiningSystem
    {
        [EntitySystem]
        private static void Awake(this ES_PetMining self, Transform args2)
        {
            self.uiTransform = args2;

            self.E_PetMiningTeamButton.AddListener(() => { self.OnPetMiningTeamButton().Coroutine(); });
            self.E_ButtonRecord.AddListener(() => { self.OnButtonRecord().Coroutine(); });
            self.E_ButtonReward_2.AddListener(() => { self.OnButtonReward_2(); });
            self.E_ButtonReward.AddListener(() => { self.OnButtonReward().Coroutine(); });
            self.E_ButtonTeamToggle.AddListener(() => { self.OnButtonTeamToggle(); });
            self.E_ButtonEditorTeam.AddListener(() => { self.OnPetMiningTeamButton().Coroutine(); });

            self.TeamTipList.Clear();
            self.TeamIconList.Clear();
            ReferenceCollector rc = self.uiTransform.GetComponent<ReferenceCollector>();
            for (int i = 0; i < 3; i++)
            {
                using (zstring.Block())
                {
                    GameObject gamego = rc.Get<GameObject>($"Team_tip_{i}");
                    self.TeamTipList.Add(gamego.GetComponent<Text>());

                    GameObject gameicon = rc.Get<GameObject>($"PetTeam_{i}");

                    self.TeamIconList.Add(gameicon.transform.GetChild(0).Find("Icon").GetComponent<Image>());
                    self.TeamIconList.Add(gameicon.transform.GetChild(1).Find("Icon").GetComponent<Image>());
                    self.TeamIconList.Add(gameicon.transform.GetChild(2).Find("Icon").GetComponent<Image>());
                    self.TeamIconList.Add(gameicon.transform.GetChild(3).Find("Icon").GetComponent<Image>());
                    self.TeamIconList.Add(gameicon.transform.GetChild(4).Find("Icon").GetComponent<Image>());
                }
            }

            self.E_FunctionSetBtnToggleGroup.AddListener(self.OnClickPageButton);

            self.E_PetMiningItem.gameObject.SetActive(false);
            self.E_UIPetOccupyItem.gameObject.SetActive(false);
            
            ReddotViewComponent redPointComponent = self.Root().GetComponent<ReddotViewComponent>();
            redPointComponent.RegisterReddot(ReddotType.PetMine, self.Reddot_PetMine);
        }

        [EntitySystem]
        private static void Destroy(this ES_PetMining self)
        {
            ReddotViewComponent redPointComponent = self.Root().GetComponent<ReddotViewComponent>();
            redPointComponent.UnRegisterReddot(ReddotType.PetMine, self.Reddot_PetMine);
            
            self.DestroyWidget();
        }

        public static async ETTask OnButtonRecord(this ES_PetMining self)
        {
            long instanceid = self.InstanceId;
            await UserInfoNetHelper.ReddotReadRequest(self.Root(), ReddotType.PetMine);
            if (instanceid != self.InstanceId)
            {
                return;
            }

            await self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_PetMiningRecord, null);
        }

        public static void Reddot_PetMine(this ES_PetMining self, int num)
        {
            self.E_ButtonRecord.transform.Find("Reddot").gameObject.SetActive(num > 0);
        }

        public static void OnButtonTeamToggle(this ES_PetMining self)
        {
            self.E_PetMiningTeam.gameObject.SetActive(!self.E_PetMiningTeam.gameObject.activeSelf);

            // self.E_ButtonTeamToggle.GetComponent<RectTransform>().anchoredPosition =
            //         self.E_PetMiningTeam.gameObject.activeSelf ? new Vector2(-471.8f, -252.2f) : new Vector2(-198f, -252.2f);
            self.E_ButtonTeamToggle.transform.localScale = self.E_PetMiningTeam.gameObject.activeSelf ? Vector3.one : new Vector3(-1f, 1f, 1f);
        }

        public static async ETTask OnPetMiningTeamButton(this ES_PetMining self)
        {
            await self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_PetMiningTeam);
            self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgPetMiningTeam>().UpdateTeam = self.OnUpdateTeam;
        }

        public static void OnUpdateTeam(this ES_PetMining self)
        {
            PetComponentC petComponent = self.Root().GetComponent<PetComponentC>();
            UserInfo userInfo = self.Root().GetComponent<UserInfoComponentC>().UserInfo;
            List<long> teamlist = petComponent.PetMingList;

            for (int i = 0; i < self.TeamTipList.Count; i++)
            {
                int openLv = ConfigData.PetMiningTeamOpenLevel[i];
                using (zstring.Block())
                {
                    self.TeamTipList[i].text = zstring.Format("{0}级开启", openLv);
                }

                self.TeamTipList[i].gameObject.SetActive(openLv > userInfo.Lv);
            }

            for (int i = 0; i < self.TeamIconList.Count; i++)
            {
                if (teamlist[i] != 0)
                {
                    RolePetInfo rolePetInfo = petComponent.GetPetInfoByID(teamlist[i]);
                    self.TeamIconList[i].gameObject.SetActive(true);
                    PetConfig petConfig = PetConfigCategory.Instance.Get(rolePetInfo.ConfigId);
                    string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.PetHeadIcon, petConfig.HeadIcon);
                    Sprite sp = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path);
                    self.TeamIconList[i].sprite = sp;
                }
                else
                {
                    self.TeamIconList[i].gameObject.SetActive(false);
                }
            }
        }

        public static async ETTask OnButtonReward(this ES_PetMining self)
        {
            long instanceid = self.InstanceId;
            await PetNetHelper.RequestPetMingChanChu(self.Root());
            if (instanceid != self.InstanceId)
            {
                return;
            }

            self.E_Text_Chanchu_2.text = string.Empty;
        }

        public static void OnButtonReward_2(this ES_PetMining self)
        {
            self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_PetMiningReward).Coroutine();
        }

        public static void OnUpdateUI(this ES_PetMining self)
        {
            self.RequestMingList().Coroutine();
        }

        public static async ETTask RequestMingList(this ES_PetMining self)
        {
            long intanceid = self.InstanceId;
            A2C_PetMingListResponse response = await PetNetHelper.RequestPetMingList(self.Root());
            if (intanceid != self.InstanceId || response.Error != ErrorCode.ERR_Success)
            {
                return;
            }

            self.PetMingPlayers = response.PetMingPlayerInfos;
            self.PetMineExtend = response.PetMineExtend;
            if (self.E_FunctionSetBtnToggleGroup.GetSelectedToggle().Item1 == 0)
            {
                self.E_FunctionSetBtnToggleGroup.enabled = true;
                self.E_FunctionSetBtnToggleGroup.OnSelectIndex(0);
            }
            else
            {
                self.E_FunctionSetBtnToggleGroup.OnSelectIndex(self.E_FunctionSetBtnToggleGroup.GetSelectedToggle().Item1);
            }

            self.E_Text_Chanchu_2.text = response.ChanChu.ToString();
            self.OnUpdateTeam();
            self.UpdateMyMine();
        }

        public static List<int> GetSelfPetMingTeam(this ES_PetMining self)
        {
            List<int> teamids = new List<int>();
            List<PetMingPlayerInfo> petMingPlayers = self.GetSelfPetMing();
            for (int i = 0; i < petMingPlayers.Count; i++)
            {
                teamids.Add(petMingPlayers[i].TeamId);
            }

            return teamids;
        }

        public static void UpdateMyMine(this ES_PetMining self)
        {
            int chatchun = 0;
            int openDay = TimeHelper.GetServeOpenDay(self.Root().GetComponent<PlayerInfoComponent>().ServerItem.ServerOpenTime);

            List<PetMingPlayerInfo> petMingPlayers = self.GetSelfPetMing();
            for (int i = 0; i < petMingPlayers.Count; i++)
            {
                GameObject gameObject = null;
                if (i < self.PetOccupyItemList.Count)
                {
                    gameObject = self.PetOccupyItemList[i];
                }
                else
                {
                    gameObject = GameObject.Instantiate(self.E_UIPetOccupyItem.gameObject);
                    gameObject.SetActive(true);
                    self.PetOccupyItemList.Add(gameObject);
                }

                CommonViewHelper.SetParent(gameObject, self.E_BuildingList.gameObject);
                Image Image_ItemIcon = gameObject.transform.Find("Image_ItemIcon").GetComponent<Image>();

                MineBattleConfig mineBattleConfig = MineBattleConfigCategory.Instance.Get(petMingPlayers[i].MineType);
                string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.OtherIcon, mineBattleConfig.Icon);
                Sprite sp = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path);

                Image_ItemIcon.sprite = sp;

                float coffi = CommonHelp.GetMineCoefficient(openDay, petMingPlayers[i].MineType, petMingPlayers[i].Postion, self.PetMineExtend);

                int chanchu = (int)(mineBattleConfig.GoldOutPut * coffi);
                chatchun += chanchu;
            }

            self.E_BuildingList.gameObject.SetActive(false);
            self.E_BuildingList.gameObject.SetActive(true);
            using (zstring.Block())
            {
                self.E_Text_Chanchu_1.text = zstring.Format("{0}/小时", chatchun);
            }
        }

        public static List<PetMingPlayerInfo> GetSelfPetMing(this ES_PetMining self)
        {
            long unitid = self.Root().GetComponent<PlayerInfoComponent>().CurrentRoleId;
            List<PetMingPlayerInfo> petMingPlayers = new List<PetMingPlayerInfo>();

            List<PetMingPlayerInfo> allMingList = self.PetMingPlayers;
            for (int i = 0; i < allMingList.Count; i++)
            {
                if (allMingList[i].UnitId == unitid)
                {
                    petMingPlayers.Add(allMingList[i]);
                }
            }

            return petMingPlayers;
        }

        public static PetMingPlayerInfo GetPetMingPlayerInfos(this ES_PetMining self, int mineType, int position)
        {
            for (int i = 0; i < self.PetMingPlayers.Count; i++)
            {
                if (self.PetMingPlayers[i].MineType == mineType && self.PetMingPlayers[i].Postion == position)
                {
                    return self.PetMingPlayers[i];
                }
            }

            return null;
        }

        public static void OnClickPageButton(this ES_PetMining self, int page)
        {
            float maxWidth = 0;
            int occNumber = 0;
            int mineType = page + 10001;
            List<PetMiningItem> miningItems = ConfigData.PetMiningList[mineType];
            List<float> scaleValue = new List<float>() { 1f, 0.85f, 0.7f };

            for (int i = 0; i < miningItems.Count; i++)
            {
                ES_PetMiningItem uIPetMiningItem = null;
                if (i < self.PetMiningItemList.Count)
                {
                    uIPetMiningItem = self.PetMiningItemList[i];
                    uIPetMiningItem.uiTransform.gameObject.SetActive(true);
                }
                else
                {
                    GameObject gameObject = GameObject.Instantiate(self.E_PetMiningItem.gameObject);
                    gameObject.SetActive(true);
                    uIPetMiningItem = self.AddChild<ES_PetMiningItem, Transform>(gameObject.transform);
                    CommonViewHelper.SetParent(gameObject, self.E_PetMiningNode.gameObject);
                    self.PetMiningItemList.Add(uIPetMiningItem);
                }

                bool hexin = CommonHelp.IsHexinMine(mineType, i, self.PetMineExtend);

                PetMingPlayerInfo petMingPlayerInfo = self.GetPetMingPlayerInfos(mineType, i);
                uIPetMiningItem.uiTransform.GetComponent<RectTransform>().anchoredPosition = new Vector3(miningItems[i].X, miningItems[i].Y, 0f);
                maxWidth = miningItems[i].X + 300;
                uIPetMiningItem.OnInitUI(mineType, i, hexin, self.PetMineExtend);
                uIPetMiningItem.OnUpdateUI(petMingPlayerInfo);
                occNumber += (petMingPlayerInfo != null ? 1 : 0);
                uIPetMiningItem.uiTransform.localScale = Vector3.one * scaleValue[page];
            }

            for (int i = miningItems.Count; i < self.PetMiningItemList.Count; i++)
            {
                ES_PetMiningItem esPetMiningItem = self.PetMiningItemList[i];
                esPetMiningItem.uiTransform.gameObject.SetActive(false);
            }

            List<string> baginfs = new List<string>() { "Back_22", "Back_22", "Back_22" };
            var path = ABPathHelper.GetJpgPath(baginfs[page]);
            Sprite atlas = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path);
            self.E_ImageMineDi.sprite = atlas;
            using (zstring.Block())
            {
                self.E_Text_OccNumber.text = zstring.Format("当前占领{0}/{1}", occNumber, ConfigData.PetMiningList[mineType].Count);
            }

            //self.PetMiningNode.GetComponent<RectTransform>().sizeDelta = new Vector2(maxWidth, self.PetMiningNode.GetComponent<RectTransform>().sizeDelta.y);
        }
    }
}