using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_PetMiningChallengeItem))]
    [FriendOf(typeof(DlgPetMiningChallenge))]
    public static class DlgPetMiningChallengeSystem
    {
        public static void RegisterUIEvent(this DlgPetMiningChallenge self)
        {
            self.View.E_ButtonCloseButton.AddListener(() =>
            {
                self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_PetMiningChallenge);
            });

            self.View.E_ButtonConfirmButton.AddListener(self.OnButtonConfirmButton);
            self.View.E_ButtonResetButton.AddListener(self.OnButtonResetButton);

            GameObject gameObject_0 = self.View.EG_DefendTeamRectTransform.Find("PetIcon_0").gameObject;
            gameObject_0.GetComponent<Button>().onClick.AddListener(() => { self.RequestPetInfo(0).Coroutine(); });
            self.PetIconList.Add(gameObject_0.GetComponent<Image>());

            GameObject gameObject_1 = self.View.EG_DefendTeamRectTransform.Find("PetIcon_1").gameObject;
            gameObject_1.GetComponent<Button>().onClick.AddListener(() => { self.RequestPetInfo(1).Coroutine(); });
            self.PetIconList.Add(gameObject_1.GetComponent<Image>());

            GameObject gameObject_2 = self.View.EG_DefendTeamRectTransform.Find("PetIcon_2").gameObject;
            gameObject_2.GetComponent<Button>().onClick.AddListener(() => { self.RequestPetInfo(2).Coroutine(); });
            self.PetIconList.Add(gameObject_2.GetComponent<Image>());

            GameObject gameObject_3 = self.View.EG_DefendTeamRectTransform.Find("PetIcon_3").gameObject;
            gameObject_3.GetComponent<Button>().onClick.AddListener(() => { self.RequestPetInfo(3).Coroutine(); });
            self.PetIconList.Add(gameObject_3.GetComponent<Image>());

            GameObject gameObject_4 = self.View.EG_DefendTeamRectTransform.Find("PetIcon_4").gameObject;
            gameObject_4.GetComponent<Button>().onClick.AddListener(() => { self.RequestPetInfo(4).Coroutine(); });
            self.PetIconList.Add(gameObject_4.GetComponent<Image>());
            
            self.TeamId = -1;
            ES_PetMining esPetMining = self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgPetSet>().View.ES_PetMining;
            List<int> defendteamids = esPetMining.GetSelfPetMingTeam();
            for (int i = 0; i < 3; i++)
            {
                GameObject gameObject = self.View.EG_TeamListNodeRectTransform.GetChild(i).gameObject;
                Scroll_Item_PetMiningChallengeItem uIPetMining = self.AddChild<Scroll_Item_PetMiningChallengeItem>();
                uIPetMining.uiTransform = gameObject.transform;
                uIPetMining.SelectHandler = self.OnSelectTeam;
                uIPetMining.TeamId = i;
                uIPetMining.OnUpdateUI(defendteamids.Contains(i));
                self.ChallengeTeamList.Add(uIPetMining);
            }
        }

        public static void ShowWindow(this DlgPetMiningChallenge self, Entity contextData = null)
        {
        }

        public static void OnButtonResetButton(this DlgPetMiningChallenge self)
        {
            PopupTipHelp.OpenPopupTip(self.Root(), "重置挑战", "是否花费350钻石重置5次挑战次数？/n提示:挑战次数上限为10", () => { self.RequestPetMingReset().Coroutine(); },
                null).Coroutine();
        }

        public static async ETTask RequestPetMingReset(this DlgPetMiningChallenge self)
        {
            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            if (unit.GetComponent<NumericComponentC>().GetAsInt(NumericType.PetMineReset) >= 3)
            {
                FlyTipComponent.Instance.ShowFlyTip("每天最多只能重置3次！");
                return;
            }

            UserInfoComponentC userInfoComponent = self.Root().GetComponent<UserInfoComponentC>();
            if (userInfoComponent.UserInfo.Diamond < 350)
            {
                FlyTipComponent.Instance.ShowFlyTip("钻石不足！");
                return;
            }

            long instanceid = self.InstanceId;
            int errorCode = await PetNetHelper.RequestPetMingReset(self.Root());
            if (instanceid != self.InstanceId || errorCode != ErrorCode.ERR_Success)
            {
                return;
            }

            self.UpdateChallengeTime();
        }

        public static void UpdateChallengeTime(this DlgPetMiningChallenge self)
        {
            int sceneid = BattleHelper.GetSceneIdByType(MapTypeEnum.PetMing);
            SceneConfig sceneConfig = SceneConfigCategory.Instance.Get(sceneid);

            int useTime = (int)self.Root().GetComponent<UserInfoComponentC>().GetSceneFubenTimes(sceneid);
            using (zstring.Block())
            {
                self.View.E_TextChallengeTimeText.text = zstring.Format("挑战剩余次数:{0}/10", sceneConfig.DayEnterNum - useTime);
            }
        }

        public static async ETTask RequestPetInfo(this DlgPetMiningChallenge self, int index)
        {
            if (self.PetMingPlayerInfo == null)
            {
                return;
            }

            long instanceid = self.InstanceId;
            long untiid = self.PetMingPlayerInfo.UnitId;
            long petid = self.PetMingPlayerInfo.PetIdList[index];

            F2C_WatchPetResponse response = await FriendNetHelper.RequestWatchPet(self.Root(), untiid, petid);
            if (instanceid != self.InstanceId)
            {
                return;
            }

            if (response.RolePetInfos == null)
            {
                FlyTipComponent.Instance.ShowFlyTip("查看宠物信息出错！");
                return;
            }

            await self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_PetInfo);
            if (instanceid != self.InstanceId)
            {
                return;
            }

            self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgPetInfo>()
                    .OnUpdateUI(response.RolePetInfos, response.PetHeXinList, response.Ks, response.Vs);
        }

        public static void OnSelectTeam(this DlgPetMiningChallenge self, int teamid)
        {
            self.TeamId = teamid;
            for (int i = 0; i < self.ChallengeTeamList.Count; i++)
            {
                Scroll_Item_PetMiningChallengeItem item = self.ChallengeTeamList[i];
                item.ImageSelect.SetActive(teamid == i);
                item.ButtonSelect.SetActive(teamid != i);
            }
        }

        public static void OnInitUI(this DlgPetMiningChallenge self, int mineType, int position, PetMingPlayerInfo petMingPlayerInfo)
        {
            DlgPetSet dlgPetSet = self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgPetSet>();
            ES_PetMining uIPetMining = dlgPetSet.View.ES_PetMining;

            self.MineTpe = mineType;
            self.Position = position;
            MineBattleConfig mineBattleConfig = MineBattleConfigCategory.Instance.Get(mineType);
            string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.OtherIcon, mineBattleConfig.Icon);
            Sprite sp = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path);

            self.View.E_RawImageImage.sprite = sp;
            self.View.E_Text_mingText.text = mineBattleConfig.Name;

            ServerItem serverItem = self.Root().GetComponent<PlayerInfoComponent>().ServerItem;
            
            int zone = serverItem.ServerId;
            int openDay = TimeHelper.GetServeOpenDay(serverItem.ServerOpenTime);
            float coffi = CommonHelp.GetMineCoefficient(openDay, mineType, position, uIPetMining.PetMineExtend);
            int chanchu = (int)(mineBattleConfig.GoldOutPut * coffi);

            using (zstring.Block())
            {
                self.View.E_Text_chanchuText.text = zstring.Format("产出:{0}小时", chanchu);
            }

            self.PetMingPlayerInfo = petMingPlayerInfo;
            string playerName = string.Empty;
            List<int> confids = new List<int>();
            if (petMingPlayerInfo != null)
            {
                using (zstring.Block())
                {
                    playerName = zstring.Format("占领者:{0}", petMingPlayerInfo.PlayerName);
                }

                confids = petMingPlayerInfo.PetConfig;
            }
            else
            {
                playerName = "占领者:无";
            }

            self.View.E_Text_playerText.text = playerName;

            for (int i = 0; i < self.PetIconList.Count; i++)
            {
                if (i >= confids.Count || confids[i] == 0)
                {
                    self.PetIconList[i].gameObject.SetActive(false);
                }
                else
                {
                    self.PetIconList[i].gameObject.SetActive(true);
                    PetConfig petConfig = PetConfigCategory.Instance.Get(confids[i]);
                    string _path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.PetHeadIcon, petConfig.HeadIcon);
                    Sprite _sp = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(_path);

                    self.PetIconList[i].sprite = _sp;
                }
            }

            self.ShowChallengeCD().Coroutine();

            self.UpdateChallengeTime();
        }

        public static async ETTask ShowChallengeCD(this DlgPetMiningChallenge self)
        {
            long instanceid = self.InstanceId;
            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            long cdTime = unit.GetComponent<NumericComponentC>().GetAsLong(NumericType.PetMineCDTime) - TimeHelper.ServerNow();

            if (cdTime <= 0)
            {
                self.View.E_TextChallengeCDText.text = string.Empty;
            }
            
            TimerComponent timerComponent = self.Root().GetComponent<TimerComponent>();
            while (cdTime > 0)
            {
                using (zstring.Block())
                {
                    self.View.E_TextChallengeCDText.text = zstring.Format("挑战冷却时间: {0}", TimeHelper.ShowLeftTime(cdTime));
                }

                await timerComponent.WaitAsync(1000);
                if (instanceid != self.InstanceId)
                {
                    break;
                }

                cdTime -= 1000;
            }
        }

        public static void OnButtonConfirmButton(this DlgPetMiningChallenge self)
        {
            if (self.TeamId == -1)
            {
                FlyTipComponent.Instance.ShowFlyTip("请选择一个队伍！");
                return;
            }

            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            long cdTime = unit.GetComponent<NumericComponentC>().GetAsLong(NumericType.PetMineCDTime);
            if (cdTime > TimeHelper.ServerNow())
            {
                FlyTipComponent.Instance.ShowFlyTip("挑战冷却中！");
                return;
            }

            int sceneid = BattleHelper.GetSceneIdByType(MapTypeEnum.PetMing);

            EnterMapHelper.RequestTransfer(self.Root(), MapTypeEnum.PetMing, sceneid, self.MineTpe, $"{self.Position}_{self.TeamId}").Coroutine();

            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_PetSet);
            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_PetMiningChallenge);
        }
    }
}
