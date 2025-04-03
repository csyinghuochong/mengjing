using UnityEngine;

namespace ET.Client
{
    [EntitySystemOf(typeof(ES_TowerDungeon))]
    [FriendOfAttribute(typeof(ES_TowerDungeon))]
    public static partial class ES_TowerDungeonSystem
    {
        [EntitySystem]
        private static void Awake(this ES_TowerDungeon self, Transform transform)
        {
            self.uiTransform = transform;
            self.E_ButtonSelect_3Button.AddListener(() => { self.OnButtonSelect(FubenDifficulty.DiYu); });
            self.E_ButtonSelect_2Button.AddListener(() => { self.OnButtonSelect(FubenDifficulty.TiaoZhan); });
            self.E_ButtonSelect_1Button.AddListener(() => { self.OnButtonSelect(FubenDifficulty.Normal); });
            self.E_Btn_EnterButton.AddListenerAsync(self.OnBtn_EnterButton);
            GlobalValueConfig globalValueConfig = GlobalValueConfigCategory.Instance.Get(63);
            string[] jianyiLevel = globalValueConfig.Value.Split(';');
            using (zstring.Block())
            {
                self.E_TextLevelJianyi_1Text.text = zstring.Format("建议等级达到{0}级后进行挑战", jianyiLevel[0]);
                self.E_TextLevelJianyi_2Text.text = zstring.Format("建议等级达到{0}级后进行挑战", jianyiLevel[1]);
                self.E_TextLevelJianyi_3Text.text = zstring.Format("建议等级达到{0}级后进行挑战", jianyiLevel[2]);
            }

            globalValueConfig = GlobalValueConfigCategory.Instance.Get(61);
            self.ES_RewardList.Refresh(globalValueConfig.Value, 1f, false);
            self.OnButtonSelect(FubenDifficulty.Normal);
        }

        [EntitySystem]
        private static void Destroy(this ES_TowerDungeon self)
        {
            self.DestroyWidget();
        }

        public static void OnButtonSelect(this ES_TowerDungeon self, int difficulty)
        {
            Color color_1 = new(255, 255, 255, 150);
            Color color_2 = new(255, 255, 255, 0);
            self.E_ButtonSelect_3Image.color = difficulty == FubenDifficulty.DiYu ? color_1 : color_2;
            self.E_ButtonSelect_2Image.color = difficulty == FubenDifficulty.TiaoZhan ? color_1 : color_2;
            self.E_ButtonSelect_1Image.color = difficulty == FubenDifficulty.Normal ? color_1 : color_2;
            self.FubenDifficulty = difficulty;
        }

        public static async ETTask OnBtn_EnterButton(this ES_TowerDungeon self)
        {
            UserInfoComponentC userInfoComponent = self.Root().GetComponent<UserInfoComponentC>();
            GlobalValueConfig globalValueConfig = GlobalValueConfigCategory.Instance.Get(62);
            string[] jianyiLevel = globalValueConfig.Value.Split(';');
            if (userInfoComponent.UserInfo.Lv < int.Parse(jianyiLevel[self.FubenDifficulty - 1]))
            {
                using (zstring.Block())
                {
                    FlyTipComponent.Instance.ShowFlyTip(zstring.Format("{0}级进入！", jianyiLevel[self.FubenDifficulty - 1]));
                }

                return;
            }

            int sceneId = BattleHelper.GetSceneIdByType(MapTypeEnum.Tower);
            int errorCode = await EnterMapHelper.RequestTransfer(self.Root(), MapTypeEnum.Tower, sceneId, self.FubenDifficulty);
            if (errorCode == ErrorCode.ERR_Success)
            {
                self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_Tower, false);
            }
        }
    }
}
