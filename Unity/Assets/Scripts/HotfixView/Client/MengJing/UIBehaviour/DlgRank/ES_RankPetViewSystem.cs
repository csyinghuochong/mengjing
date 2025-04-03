using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof(ES_RankPetItem))]
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

            self.PetUIList.Add(self.ES_RankPetItem);
            self.PetUIList.Add(self.AddChild<ES_RankPetItem, Transform>(UnityEngine.Object.Instantiate(self.ES_RankPetItem.uiTransform.gameObject, self.EG_PetListNodeRectTransform).transform));
            self.PetUIList.Add(self.AddChild<ES_RankPetItem, Transform>(UnityEngine.Object.Instantiate(self.ES_RankPetItem.uiTransform.gameObject, self.EG_PetListNodeRectTransform).transform));
            self.PetUIList.Add(self.AddChild<ES_RankPetItem, Transform>(UnityEngine.Object.Instantiate(self.ES_RankPetItem.uiTransform.gameObject, self.EG_PetListNodeRectTransform).transform));

            self.ImageIconList = new GameObject[5];
            self.ImageIconList[0] = self.E_ImageIcon1Image.gameObject;
            self.ImageIconList[1] = self.E_ImageIcon2Image.gameObject;
            self.ImageIconList[2] = self.E_ImageIcon3Image.gameObject;
            self.ImageIconList[3] = self.E_ImageIcon4Image.gameObject;
            self.ImageIconList[4] = self.E_ImageIcon5Image.gameObject;
            // self.ImageIconList[4].GetComponent<Button>().AddListener(() => { self.OnImageIconList(4).Coroutine(); });
            // self.ImageIconList[3].GetComponent<Button>().AddListener(() => { self.OnImageIconList(3).Coroutine(); });
            // self.ImageIconList[2].GetComponent<Button>().AddListener(() => { self.OnImageIconList(2).Coroutine(); });
            // self.ImageIconList[1].GetComponent<Button>().AddListener(() => { self.OnImageIconList(1).Coroutine(); });
            // self.ImageIconList[0].GetComponent<Button>().AddListener(() => { self.OnImageIconList(0).Coroutine(); });
            
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

        private static async ETTask OnUpdateUI(this ES_RankPet self)
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
            
            self.UpdateMyTeamInfo();
        }

        public static void UpdateMyTeamInfo(this ES_RankPet self)
        {
            PetComponentC petComponentC = self.Root().GetComponent<PetComponentC>();
            int number = 0;
            int combat = 0;
            List<long> petList = self.Root().GetComponent<PetComponentC>().GetPetFormatList(MapTypeEnum.PetTianTi);
            for (int i = 0; i < petList.Count; i++)
            {
                if (petList[i] == 0 || number >= 5)
                {
                    continue;
                }

                RolePetInfo rankPetInfo = petComponentC.GetPetInfoByID(petList[i]);
                PetConfig petConfig = PetConfigCategory.Instance.Get(rankPetInfo.ConfigId);
                string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.PetHeadIcon, petConfig.HeadIcon);
                Sprite sp = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path);

                self.ImageIconList[number].SetActive(true);
                self.ImageIconList[number].GetComponent<Image>().sprite = sp;

                combat += rankPetInfo.PetPingFen;
                number++;
            }
            
            for (int i = number; i < 5; i++)
            {
                self.ImageIconList[i].SetActive(false);
            }
            
            self.E_Text_CombatText.text = combat.ToString();
        }

        private static void OnUpdateTimes(this ES_RankPet self)
        {
            int sceneId = BattleHelper.GetSceneIdByType(MapTypeEnum.PetTianTi);
            int totalTimes = SceneConfigCategory.Instance.Get(sceneId).DayEnterNum;

            UserInfoComponentC userInfoComponent = self.Root().GetComponent<UserInfoComponentC>();
            int useTimes = (int)userInfoComponent.GetSceneFubenTimes(sceneId);
            using (zstring.Block())
            {
                self.E_Text_LeftTimeText.GetComponent<Text>().text = zstring.Format("{0}/{1}", totalTimes - useTimes, totalTimes);
            }
        }

        private static void OnButton_AddButton(this ES_RankPet self)
        {
            PopupTipHelp.OpenPopupTip(self.Root(), "重置次数",
                "是否花费200钻石重置次数",
                () => { self.RequestReset().Coroutine(); }, null).Coroutine();
        }

        private static async ETTask RequestReset(this ES_RankPet self)
        {
            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            NumericComponentC numericComponent = unit.GetComponent<NumericComponentC>();
            long resetValue = numericComponent.GetAsLong(NumericType.FubenTimesReset);
            if (resetValue >= 10)
            {
                FlyTipComponent.Instance.ShowFlyTip("每天只能重置十次");
                return;
            }

            M2C_FubenTimesResetResponse response = await RankNetHelper.FubenTimesReset(self.Root(), MapTypeEnum.PetTianTi);
            if (response.Error != 0)
            {
                return;
            }

            int sceneId = BattleHelper.GetSceneIdByType(MapTypeEnum.PetTianTi);
            UserInfoComponentC userInfoComponent = self.Root().GetComponent<UserInfoComponentC>();
            userInfoComponent.ClearFubenTimes(sceneId);
            self.OnUpdateTimes();
        }

        private static void OnButton_RefreshButton(this ES_RankPet self)
        {
            self.OnUpdateUI().Coroutine();
        }

        private static void OnButton_RewardButton(this ES_RankPet self)
        {
        }

        private static async ETTask OnButton_TeamButton(this ES_RankPet self)
        {
            await self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_PetFormation);
            DlgPetFormation dlgPetFormation = self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgPetFormation>();
            dlgPetFormation.OnInitUI(MapTypeEnum.PetTianTi, self.UpdateMyTeamInfo);
        }
    }
}
