using System.Collections.Generic;
using UnityEngine;

namespace ET.Client
{
    [EntitySystemOf(typeof(ES_PetEggChouKa))]
    [FriendOfAttribute(typeof(ES_PetEggChouKa))]
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
            self.E_Btn_RolePetBagButton.AddListener(self.OnBtn_RolePetBagButton);
            self.E_PetEggLucklyExplainBtnButton.AddListener(self.OnPetEggLucklyExplainBtnButton);
            self.E_Btn_ChouKaNumRewardButton.AddListener(self.OnBtn_ChouKaNumRewardButton);
            self.E_Btn_ChouKaTenButton.AddListener(() => { self.OnBtn_ChouKa(10).Coroutine(); });
            self.E_Btn_ChouKaButton.AddListener(() => { self.OnBtn_ChouKa(1).Coroutine(); });
            self.E_Btn_RolePetHeXinButton.AddListener(self.OnBtn_RolePetHeXinButton);

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
            int dropId = int.Parse(GlobalValueConfigCategory.Instance.Get(40).Value.Split('@')[1]);

            List<RewardItem> droplist = new List<RewardItem>();
            droplist = DropHelper.DropIDToShowItem(dropId, 1);
            string itemList = "";
            for (int i = 0; i < droplist.Count; i++)
            {
                itemList += droplist[i].ItemID + ";" + 1 + "@";
            }

            self.ES_RewardList.Refresh(droplist, 0.8f);
        }

        public static void OnBtn_RolePetBagButton(this ES_PetEggChouKa self)
        {
            self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_RolePetBag).Coroutine();
        }

        public static void OnPetEggLucklyExplainBtnButton(this ES_PetEggChouKa self)
        {
            self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_PetEggLucklyExplain).Coroutine();
        }

        public static void OnBtn_ChouKaNumRewardButton(this ES_PetEggChouKa self)
        {
            self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_PetEggChouKaReward).Coroutine();
        }

        public static void OnUpdateInfo(this ES_PetEggChouKa self)
        {
            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            NumericComponentC numericComponent = unit.GetComponent<NumericComponentC>();
            int totalTimes = numericComponent.GetAsInt(NumericType.PetExploreNumber);
            using (zstring.Block())
            {
                self.E_Text_TotalNumberText.text = zstring.Format("次数：{0}/{1}", totalTimes, GlobalValueConfigCategory.Instance.PetEggChouKaLimit);
            }

            self.E_Text_PetExploreLucklyText.text = numericComponent.GetAsInt(NumericType.PetExploreLuckly).ToString();
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

            using (zstring.Block())
            {
                self.E_Text_DiamondNumberText.text = zstring.Format("x {0}", ((int)(needDimanond * discount)).ToString());
            }

            string[] itemInfo = GlobalValueConfigCategory.Instance.Get(39).Value.Split('@')[0].Split(';');
            string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.ItemIcon, ItemConfigCategory.Instance.Get(int.Parse(itemInfo[0])).Icon);
            Sprite sp = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path);

            self.E_ItemImageIconImage.sprite = sp;
            long haveNumber = self.Root().GetComponent<BagComponentC>().GetItemNumber(int.Parse(itemInfo[0]));
            using (zstring.Block())
            {
                self.E_Text_CostNumberText.text = zstring.Format("{0}/{1}", haveNumber, itemInfo[1]);
            }

            self.E_Text_CostNumberText.color = haveNumber >= int.Parse(itemInfo[1]) ? Color.white : Color.red;
        }

        public static void OnBtn_RolePetHeXinButton(this ES_PetEggChouKa self)
        {
            self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_PetHeXinHeCheng).Coroutine();
        }

        public static async ETTask OnBtn_ChouKa(this ES_PetEggChouKa self, int choukaType)
        {
            BagComponentC bagComponent = self.Root().GetComponent<BagComponentC>();
            if (bagComponent.GetBagLeftCell(ItemLocType.ItemLocBag) < choukaType)
            {
                FlyTipComponent.Instance.ShowFlyTip("请预留足够的背包空间！");
                return;
            }

            if (bagComponent.GetBagLeftCell(ItemLocType.ItemLocBag) < choukaType)
            {
                FlyTipComponent.Instance.ShowFlyTip("请清理一下宠物之核背包！");
                return;
            }

            if (self.Root().GetComponent<PetComponentC>().RolePetBag.Count >= GlobalValueConfigCategory.Instance.RolePetBagNum)
            {
                FlyTipComponent.Instance.ShowFlyTip("请及时清理探索宠物仓库！");
                return;
            }

            string needItems = GlobalValueConfigCategory.Instance.Get(39).Value.Split('@')[0];
            if (choukaType == 1 && !self.Root().GetComponent<BagComponentC>().CheckNeedItem(needItems))
            {
                HintHelp.ShowErrorHint(self.Root(), ErrorCode.ERR_ItemNotEnoughError);
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
                HintHelp.ShowErrorHint(self.Root(), ErrorCode.ERR_DiamondNotEnoughError);
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
            dlgCommonReward.OnUpdateUI(response.RewardList);
        }
    }
}
