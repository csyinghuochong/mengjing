namespace ET.Client
{
    [FriendOf(typeof (DlgPetFubenResult))]
    public static class DlgPetFubenResultSystem
    {
        public static void RegisterUIEvent(this DlgPetFubenResult self)
        {
            self.View.E_Button_exitButton.AddListener(() => { self.OnButton_exit(); });
            self.View.E_Button_nextButton.AddListener(() => { self.OnButton_next(); });
            self.View.E_Button_nextButton.gameObject.SetActive(false);
            self.View.E_Button_continueButton.AddListener(() => { self.OnButton_continue(); });
            self.View.E_Button_continueButton.gameObject.SetActive(false);
        }

        public static void ShowWindow(this DlgPetFubenResult self, Entity contextData = null)
        {
        }

        public static void OnUpdateUI(this DlgPetFubenResult self, M2C_FubenSettlement message)
        {
            //  1胜利 2失败
            self.View.E_TextResultText.text = message.BattleResult == CombatResultEnum.Fail? "挑战失败" : "挑战胜利";

            self.View.E_Img_Star_1Image.gameObject.SetActive(message.StarInfos[0] == 1);
            self.View.E_Img_Star_2Image.gameObject.SetActive(message.StarInfos[1] == 1);
            self.View.E_Img_Star_3Image.gameObject.SetActive(message.StarInfos[2] == 1);

            int sceneType = self.Root().GetComponent<MapComponent>().MapType;
            if ((sceneType == MapTypeEnum.PetDungeon || sceneType == MapTypeEnum.SeasonTower)
                && message.BattleResult == CombatResultEnum.Win)
            {
                self.View.E_Button_nextButton.gameObject.SetActive(true);
            }
            else
            {
                self.View.E_Button_nextButton.gameObject.SetActive(false);
            }

            if (sceneType == MapTypeEnum.PetDungeon)
            {
                self.View.E_Button_continueButton.gameObject.SetActive(true);
            }
            else
            {
                self.View.E_Button_continueButton.gameObject.SetActive(false);
            }

            self.View.ES_RewardList.Refresh(message.RewardList);
        }

        public static void OnButton_exit(this DlgPetFubenResult self)
        {
            EnterMapHelper.RequestQuitFuben(self.Root());
            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_PetFubenResult);
        }

        public static void OnButton_continue(this DlgPetFubenResult self)
        {
            int sceneType = self.Root().GetComponent<MapComponent>().MapType;
            if (sceneType == MapTypeEnum.PetDungeon)
            {
                int sonsceneid = self.Root().GetComponent<MapComponent>().SonSceneId;
                if (!PetFubenConfigCategory.Instance.Contain(sonsceneid))
                {
                    FlyTipComponent.Instance.ShowFlyTip("已通关！");
                    return;
                }

                EnterMapHelper.RequestTransfer(self.Root(), (int)MapTypeEnum.PetDungeon,
                    BattleHelper.GetSceneIdByType(MapTypeEnum.PetDungeon), 0, sonsceneid.ToString()).Coroutine();

                self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_PetFubenResult);
            }
        }

        public static void OnButton_next(this DlgPetFubenResult self)
        {
            int sceneType = self.Root().GetComponent<MapComponent>().MapType;
            if (sceneType == MapTypeEnum.PetDungeon)
            {
                int sonsceneid = self.Root().GetComponent<MapComponent>().SonSceneId + 1;
                if (!PetFubenConfigCategory.Instance.Contain(sonsceneid))
                {
                    FlyTipComponent.Instance.ShowFlyTip("已通关！");
                    return;
                }

                EnterMapHelper.RequestTransfer(self.Root(), (int)MapTypeEnum.PetDungeon,
                    BattleHelper.GetSceneIdByType(MapTypeEnum.PetDungeon), 0, sonsceneid.ToString()).Coroutine();
            }

            if (sceneType == MapTypeEnum.SeasonTower)
            {
                int sonsceneid = self.Root().GetComponent<MapComponent>().SonSceneId + 1;
                if (!TowerConfigCategory.Instance.Contain(sonsceneid))
                {
                    FlyTipComponent.Instance.ShowFlyTip("已通关！");
                    return;
                }

                EnterMapHelper.RequestTransfer(self.Root(), (int)MapTypeEnum.SeasonTower,
                    BattleHelper.GetSceneIdByType(MapTypeEnum.SeasonTower), 0, sonsceneid.ToString()).Coroutine();
            }

            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_PetFubenResult);
        }
    }
}
