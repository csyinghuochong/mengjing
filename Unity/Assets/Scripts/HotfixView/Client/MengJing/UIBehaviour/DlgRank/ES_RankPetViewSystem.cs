using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof(ES_RankPetReward))]
    [EntitySystemOf(typeof(ES_RankPet))]
    [FriendOfAttribute(typeof(ES_RankPet))]
    public static partial class ES_RankPetSystem
    {
        [EntitySystem]
        private static void Awake(this ES_RankPet self, Transform transform)
        {
            self.uiTransform = transform;

            self.E_Button_AddButton.AddListener(self.OnButton_AddButton);
            self.E_Button_RefreshButton.AddListener(self.OnButton_RefreshButton);
            self.E_Button_RewardButton.AddListener(self.OnButton_RewardButton);
            self.E_Button_TeamButton.AddListenerAsync(self.OnButton_TeamButton);
            self.E_RankRewardButton.AddListener(() => {self.ES_RankPetReward.uiTransform.gameObject.SetActive(true);});

            self.PetUIList.Add(self.ES_RankPetItem_0);
            self.PetUIList.Add(self.ES_RankPetItem_1);
            self.PetUIList.Add(self.ES_RankPetItem_2);

            self.ES_RankPetReward.uiTransform.gameObject.SetActive(false);
            
            self.OnUpdateUI().Coroutine();
            self.OnUpdateTimes();
        }

        public static void OnShowWindow(this ES_RankPet self)
        {
            self.ES_RankPetReward.uiTransform.gameObject.SetActive(false);
        }
        
        [EntitySystem]
        private static void Destroy(this ES_RankPet self)
        {
            self.DestroyWidget();
        }

        public static async ETTask OnUpdateUI(this ES_RankPet self)
        {
            long instacnid = self.InstanceId;
            R2C_RankPetListResponse response =
                    await RankNetHelper.RankPetList(self.Root(), self.Root().GetComponent<UserInfoComponentC>().UserInfo.UserId);
            if (instacnid != self.InstanceId)
            {
                return;
            }

            for (int i = 0; i < response.RankPetList.Count; i++)
            {
                ES_RankPetItem esRankPetItem = self.PetUIList[i];
                esRankPetItem.OnInitUI(response.RankPetList[i]);
            }

            self.E_Text_RankText.text = response.RankNumber == 0 ? "无" : response.RankNumber.ToString();
        }

        public static void OnUpdateTimes(this ES_RankPet self)
        {
            int sceneId = BattleHelper.GetSceneIdByType(SceneTypeEnum.PetTianTi);
            int totalTimes = SceneConfigCategory.Instance.Get(sceneId).DayEnterNum;

            UserInfoComponentC userInfoComponent = self.Root().GetComponent<UserInfoComponentC>();
            int useTimes = (int)userInfoComponent.GetSceneFubenTimes(sceneId);
            using (zstring.Block())
            {
                self.E_Text_LeftTimeText.GetComponent<Text>().text = zstring.Format("{0}/{1}", totalTimes - useTimes, totalTimes);
            }
        }

        public static void OnButton_AddButton(this ES_RankPet self)
        {
            PopupTipHelp.OpenPopupTip(self.Root(), "重置次数",
                "是否花费200钻石重置次数",
                () => { self.RequestReset().Coroutine(); }, null).Coroutine();
        }

        public static async ETTask RequestReset(this ES_RankPet self)
        {
            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            NumericComponentC numericComponent = unit.GetComponent<NumericComponentC>();
            long resetValue = numericComponent.GetAsLong(NumericType.FubenTimesReset);
            if (resetValue >= 10)
            {
                FlyTipComponent.Instance.ShowFlyTip("每天只能重置十次");
                return;
            }

            M2C_FubenTimesResetResponse response = await RankNetHelper.FubenTimesReset(self.Root(), SceneTypeEnum.PetTianTi);
            if (response.Error != 0)
            {
                return;
            }

            int sceneId = BattleHelper.GetSceneIdByType(SceneTypeEnum.PetTianTi);
            UserInfoComponentC userInfoComponent = self.Root().GetComponent<UserInfoComponentC>();
            userInfoComponent.ClearFubenTimes(sceneId);
            self.OnUpdateTimes();
        }

        public static void OnButton_RefreshButton(this ES_RankPet self)
        {
            self.OnUpdateUI().Coroutine();
        }

        public static void OnButton_RewardButton(this ES_RankPet self)
        {
        }

        public static async ETTask OnButton_TeamButton(this ES_RankPet self)
        {
            await self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_PetFormation);
            DlgPetFormation dlgPetFormation = self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgPetFormation>();
            dlgPetFormation.OnInitUI(SceneTypeEnum.PetTianTi, null);
        }
    }
}
