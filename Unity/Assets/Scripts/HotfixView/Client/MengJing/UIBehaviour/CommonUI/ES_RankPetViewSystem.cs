using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [EntitySystemOf(typeof (ES_RankPet))]
    [FriendOfAttribute(typeof (ES_RankPet))]
    public static partial class ES_RankPetSystem
    {
        [EntitySystem]
        private static void Awake(this ES_RankPet self, Transform transform)
        {
            self.uiTransform = transform;

            self.E_Button_AddButton.AddListener(self.OnButton_Add);
            self.E_Button_RefreshButton.AddListener(self.OnButton_Refresh);
            self.E_Button_RewardButton.AddListener(self.OnButton_Reward);
            self.E_Button_TeamButton.AddListenerAsync(self.OnButton_Team);

            self.PetUIList.Add(self.ES_RankPetItem_0);
            self.PetUIList.Add(self.ES_RankPetItem_1);
            self.PetUIList.Add(self.ES_RankPetItem_2);

            self.OnUpdateUI().Coroutine();
            self.OnUpdateTimes();
        }

        [EntitySystem]
        private static void Destroy(this ES_RankPet self)
        {
            self.DestroyWidget();
        }

        public static async ETTask OnUpdateUI(this ES_RankPet self)
        {
            long instacnid = self.InstanceId;
            C2R_RankPetListRequest request = new() { UserId = self.Root().GetComponent<UserInfoComponentC>().UserInfo.UserId };
            R2C_RankPetListResponse response = (R2C_RankPetListResponse)await self.Root().GetComponent<ClientSenderCompnent>().Call(request);
            if (instacnid != self.InstanceId)
            {
                return;
            }

            for (int i = 0; i < response.RankPetList.Count; i++)
            {
                self.PetUIList[i].OnInitUI(response.RankPetList[i]);
            }

            self.E_Text_RankText.text = response.RankNumber == 0? "无" : response.RankNumber.ToString();
        }

        public static void OnUpdateTimes(this ES_RankPet self)
        {
            int sceneId = BattleHelper.GetSceneIdByType(SceneTypeEnum.PetTianTi);
            int totalTimes = SceneConfigCategory.Instance.Get(sceneId).DayEnterNum;

            UserInfoComponentC userInfoComponent = self.Root().GetComponent<UserInfoComponentC>();
            int useTimes = (int)userInfoComponent.GetSceneFubenTimes(sceneId);
            self.E_Text_LeftTimeText.GetComponent<Text>().text = $"{totalTimes - useTimes}/{totalTimes}";
        }

        public static void OnButton_Add(this ES_RankPet self)
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
            if (resetValue >= 3)
            {
                FlyTipComponent.Instance.SpawnFlyTipDi("每天只能重置三次");
                return;
            }

            C2M_FubenTimesResetRequest request = new() { SceneType = SceneTypeEnum.PetTianTi };
            M2C_FubenTimesResetResponse response =
                    (M2C_FubenTimesResetResponse)await self.Root().GetComponent<ClientSenderCompnent>().Call(request);
            if (response.Error != 0)
            {
                return;
            }

            int sceneId = BattleHelper.GetSceneIdByType(SceneTypeEnum.PetTianTi);
            UserInfoComponentC userInfoComponent = self.Root().GetComponent<UserInfoComponentC>();
            userInfoComponent.ClearFubenTimes(sceneId);
            self.OnUpdateTimes();
        }

        public static void OnButton_Refresh(this ES_RankPet self)
        {
            self.OnUpdateUI().Coroutine();
        }

        public static void OnButton_Reward(this ES_RankPet self)
        {
        }

        public static async ETTask OnButton_Team(this ES_RankPet self)
        {
            await self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_PetFormation);
            DlgPetFormation dlgPetFormation = self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgPetFormation>();
            dlgPetFormation.OnInitUI(SceneTypeEnum.PetTianTi, null);
        }
    }
}