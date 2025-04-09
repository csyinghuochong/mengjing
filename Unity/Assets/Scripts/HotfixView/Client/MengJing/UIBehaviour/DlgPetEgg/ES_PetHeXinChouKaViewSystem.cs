using UnityEngine;

namespace ET.Client
{
    [EntitySystemOf(typeof(ES_PetHeXinChouKa))]
    [FriendOfAttribute(typeof(ES_PetHeXinChouKa))]
    public static partial class ES_PetHeXinChouKaSystem
    {
        [EntitySystem]
        private static void Awake(this ES_PetHeXinChouKa self, Transform transform)
        {
            self.uiTransform = transform;

            self.E_Btn_ChouKaTenButton.AddListener(() => { self.OnBtn_ChouKa(10).Coroutine(); });
            self.E_Btn_ChouKaButton.AddListener(() => { self.OnBtn_ChouKa(1).Coroutine(); });
            self.E_Btn_RolePetHeXinButton.AddListener(self.OnBtn_RolePetHeXinButton);

            self.UpdateMoney();
        }

        [EntitySystem]
        private static void Destroy(this ES_PetHeXinChouKa self)
        {
            self.DestroyWidget();
        }

        public static void UpdateMoney(this ES_PetHeXinChouKa self)
        {
            ResourcesLoaderComponent resourcesLoaderComponent = self.Root().GetComponent<ResourcesLoaderComponent>();
            string[] itemInfo10 = GlobalValueConfigCategory.Instance.Get(111).Value.Split('@')[0].Split(';');
            string path1 = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.ItemIcon, ItemConfigCategory.Instance.Get(int.Parse(itemInfo10[0])).Icon);
            Sprite sp1 = resourcesLoaderComponent.LoadAssetSync<Sprite>(path1);

            self.E_ItemImageIcon10Image.sprite = sp1;
            int exlporeNumber = UnitHelper.GetMyUnitFromClientScene(self.Root()).GetComponent<NumericComponentC>()
                    .GetAsInt(NumericType.PetHeXinExploreNumber);
            string[] set = GlobalValueConfigCategory.Instance.Get(112).Value.Split(';');
            float discount;
            if (exlporeNumber < int.Parse(set[0]))
            {
                discount = 1;
            }
            else
            {
                discount = float.Parse(set[1]);
            }

            long haveNumber10 = self.Root().GetComponent<BagComponentC>().GetItemNumber(int.Parse(itemInfo10[0]));
            using (zstring.Block())
            {
                self.E_Text_DiamondNumberText.text = zstring.Format("{0}/{1}", haveNumber10, (int)(int.Parse(itemInfo10[1]) * discount));
            }

            self.E_Text_DiamondNumberText.color = haveNumber10 >= (int)(int.Parse(itemInfo10[1]) * discount) ? Color.white : Color.red;

            string[] itemInfo1 = GlobalValueConfigCategory.Instance.Get(110).Value.Split('@')[0].Split(';');
            string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.ItemIcon, ItemConfigCategory.Instance.Get(int.Parse(itemInfo1[0])).Icon);
            Sprite sp = resourcesLoaderComponent.LoadAssetSync<Sprite>(path);

            self.E_ItemImageIconImage.sprite = sp;
            long haveNumber1 = self.Root().GetComponent<BagComponentC>().GetItemNumber(int.Parse(itemInfo1[0]));
            using (zstring.Block())
            {
                self.E_Text_CostNumberText.text = zstring.Format("{0}/{1}", haveNumber1, itemInfo1[1]);
            }

            self.E_Text_CostNumberText.color = (haveNumber1 >= int.Parse(itemInfo1[1])) ? Color.white : Color.red;
        }

        public static void OnBtn_RolePetHeXinButton(this ES_PetHeXinChouKa self)
        {
            self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_PetHeXinHeCheng).Coroutine();
        }

        public static async ETTask OnBtn_ChouKa(this ES_PetHeXinChouKa self, int choukaType)
        {
            BagComponentC bagComponent = self.Root().GetComponent<BagComponentC>();
            if (bagComponent.GetBagLeftCell(ItemLocType.ItemLocBag) < choukaType)
            {
                FlyTipComponent.Instance.ShowFlyTip("请预留足够的背包空间！");
                return;
            }

            if (bagComponent.GetBagShowCell(ItemLocType.ItemPetHeXinBag) < choukaType)
            {
                FlyTipComponent.Instance.ShowFlyTip("请清理一下宠物之核背包！");
                return;
            }

            string needItems = GlobalValueConfigCategory.Instance.Get(110).Value.Split('@')[0];
            if (choukaType == 1 && !self.Root().GetComponent<BagComponentC>().CheckNeedItem(needItems))
            {
                HintHelp.ShowErrorHint(self.Root(), ErrorCode.ERR_ItemNotEnoughError);
                return;
            }

            string[] itemInfo10 = GlobalValueConfigCategory.Instance.Get(111).Value.Split('@')[0].Split(';');
            int exlporeNumber = UnitHelper.GetMyUnitFromClientScene(self.Root()).GetComponent<NumericComponentC>()
                    .GetAsInt(NumericType.PetExploreNumber);
            string[] set = GlobalValueConfigCategory.Instance.Get(112).Value.Split(';');
            float discount;
            if (exlporeNumber < int.Parse(set[0]))
            {
                discount = 1;
            }
            else
            {
                discount = float.Parse(set[1]);
            }

            long haveNumber10 = self.Root().GetComponent<BagComponentC>().GetItemNumber(int.Parse(itemInfo10[0]));
            if (choukaType == 10 && haveNumber10 < (int)(int.Parse(itemInfo10[1]) * discount))
            {
                HintHelp.ShowErrorHint(self.Root(), ErrorCode.ERR_ItemNotEnoughError);
                return;
            }

            long instanceid = self.InstanceId;

            M2C_PetHeXinChouKaResponse response = await PetNetHelper.RequestPetHeXinChouKa(self.Root(), choukaType);
            if (response.Error != 0 || instanceid != self.InstanceId)
            {
                return;
            }

            self.UpdateMoney();

            await self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_CommonReward);
            DlgCommonReward dlgCommonReward = self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgCommonReward>();
            dlgCommonReward.OnUpdateUI(response.RewardList);
        }
    }
}
