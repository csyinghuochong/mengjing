using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [EntitySystemOf(typeof (ES_PetEggChouKa))]
    [FriendOfAttribute(typeof (ES_PetEggChouKa))]
    public static partial class ES_PetEggChouKaSystem
    {
        [EntitySystem]
        private static void Awake(this ES_PetEggChouKa self, Transform transform)
        {
            self.uiTransform = transform;

            self.E_Btn_PetEggLucklyExplainButton.AddListener(() =>
            {
                self.Root().GetComponent<UIComponent>().ShowWindow(WindowID.WindowID_PetEggChouKaProbExplain);
            });
            self.E_Btn_RolePetBagButton.AddListener(self.OnBtn_RolePetBag);
            self.E_PetEggLucklyExplainBtnButton.AddListener(self.OnPetEggLucklyExplainBtn);
            self.E_Btn_ChouKaNumRewardButton.AddListener(self.OnBtn_ChouKaNumReward);
            self.E_Btn_ChouKaTenButton.AddListener(() => { self.OnBtn_ChouKa(10).Coroutine(); });
            self.E_Btn_ChouKaButton.AddListener(() => { self.OnBtn_ChouKa(1).Coroutine(); });
            self.E_Btn_RolePetHeXinButton.AddListener(self.OnBtn_RolePetHeXin);

            self.EG_PetLuckyRectTransform.gameObject.SetActive(true);

            self.UpdateMoney();
            self.OnUpdateInfo();
            self.UpdateReward();
        }

        [EntitySystem]
        private static void Destroy(this ES_PetEggChouKa self)
        {
            self.DestroyWidget();
        }

        public static void UpdateReward(this ES_PetEggChouKa self)
        {
            self.ES_RewardList.Refresh(ConfigData.PetChouKaRewardItemShow, 0.8f);
        }

        public static void OnBtn_RolePetBag(this ES_PetEggChouKa self)
        {
            self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_RolePetBag).Coroutine();
        }

        public static void OnPetEggLucklyExplainBtn(this ES_PetEggChouKa self)
        {
            self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_PetEggLucklyExplain).Coroutine();
        }

        public static void OnBtn_ChouKaNumReward(this ES_PetEggChouKa self)
        {
            self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_PetEggChouKaReward).Coroutine();
        }

        public static void OnUpdateInfo(this ES_PetEggChouKa self)
        {
            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            NumericComponentC numericComponent = unit.GetComponent<NumericComponentC>();
            int totalTimes = numericComponent.GetAsInt(NumericType.PetExploreNumber);
            self.E_Text_TotalNumberText.text = $"今日累计次数：{totalTimes}";
            self.E_Text_PetExploreLucklyText.text = $"{numericComponent.GetAsInt(NumericType.PetExploreLuckly)}";
        }

        public static void UpdateMoney(this ES_PetEggChouKa self)
        {
            int needDimanond = int.Parse(GlobalValueConfigCategory.Instance.Get(40).Value.Split('@')[0]);
            int exlporeNumber = UnitHelper.GetMyUnitFromClientScene(self.Root()).GetComponent<NumericComponentC>()
                    .GetAsInt(NumericType.PetExploreNumber);
            string[] set = GlobalValueConfigCategory.Instance.Get(107).Value.Split(';');
            float discount;
            if (exlporeNumber < int.Parse(set[0]))
            {
                discount = 1;
            }
            else
            {
                discount = float.Parse(set[1]);
            }

            self.E_Text_DiamondNumberText.text = ((int)(needDimanond * discount)).ToString();

            string[] itemInfo = GlobalValueConfigCategory.Instance.Get(39).Value.Split('@')[0].Split(';');
            string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.ItemIcon, ItemConfigCategory.Instance.Get(int.Parse(itemInfo[0])).Icon);
            Sprite sp = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path);

            self.E_ItemImageIconImage.sprite = sp;
            long haveNumber = self.Root().GetComponent<BagComponentC>().GetItemNumber(int.Parse(itemInfo[0]));
            self.E_Text_CostNumberText.text = haveNumber + "/" + itemInfo[1];
            self.E_Text_CostNumberText.color = haveNumber >= int.Parse(itemInfo[1])? Color.white : Color.red;
        }

        public static void OnBtn_RolePetHeXin(this ES_PetEggChouKa self)
        {
            self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_PetHeXinHeCheng).Coroutine();
        }

        public static async ETTask OnBtn_ChouKa(this ES_PetEggChouKa self, int choukaType)
        {
            BagComponentC bagComponent = self.Root().GetComponent<BagComponentC>();
            if (bagComponent.GetBagLeftCell() < choukaType)
            {
                FlyTipComponent.Instance.SpawnFlyTipDi("请预留足够的背包空间！");
                return;
            }

            if (bagComponent.GetPetHeXinLeftSpace() < choukaType)
            {
                FlyTipComponent.Instance.SpawnFlyTipDi("请清理一下宠物之核背包！");
                return;
            }

            if (self.Root().GetComponent<PetComponentC>().RolePetBag.Count >= GlobalValueConfigCategory.Instance.Get(119).Value2)
            {
                FlyTipComponent.Instance.SpawnFlyTipDi("请及时清理探索宠物仓库！");
                return;
            }

            string needItems = GlobalValueConfigCategory.Instance.Get(39).Value.Split('@')[0];
            if (choukaType == 1 && !self.Root().GetComponent<BagComponentC>().CheckNeedItem(needItems))
            {
                ErrorViewHelp.ShowErrorHint(ErrorCode.ERR_ItemNotEnoughError);
                return;
            }

            int needDimanond = int.Parse(GlobalValueConfigCategory.Instance.Get(40).Value.Split('@')[0]);
            UserInfo userInfo = self.Root().GetComponent<UserInfoComponentC>().UserInfo;
            int exlporeNumber = UnitHelper.GetMyUnitFromClientScene(self.Root()).GetComponent<NumericComponentC>()
                    .GetAsInt(NumericType.PetExploreNumber);
            string[] set = GlobalValueConfigCategory.Instance.Get(107).Value.Split(';');
            float discount;
            if (exlporeNumber < int.Parse(set[0])) // 超过300次打8折
            {
                discount = 1;
            }
            else
            {
                discount = float.Parse(set[1]);
            }

            if (choukaType == 10 && userInfo.Diamond < (int)(needDimanond * discount))
            {
                ErrorViewHelp.ShowErrorHint(ErrorCode.ERR_DiamondNotEnoughError);
                return;
            }

            long instanceid = self.InstanceId;

            M2C_PetEggChouKaResponse response = await PetNetHelper.RequestPetEggChouKa(self.Root(), choukaType);
            if (response.Error != 0 || instanceid != self.InstanceId)
            {
                return;
            }

            self.UpdateMoney();
            self.OnUpdateInfo();

            await self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_CommonReward);
            DlgCommonReward dlgCommonReward = self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgCommonReward>();
            dlgCommonReward.OnUpdateUI(response.ReardList);
        }
    }
}