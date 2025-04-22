using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_PetEggSelectItem))]
    [FriendOf(typeof(Scroll_Item_CommonItem))]
    [FriendOf(typeof(ES_PetEggListItem))]
    [EntitySystemOf(typeof(ES_PetEggList))]
    [FriendOfAttribute(typeof(ES_PetEggList))]
    public static partial class ES_PetEggListSystem
    {
        [EntitySystem]
        private static void Awake(this ES_PetEggList self, Transform transform)
        {
            self.uiTransform = transform;

            self.PetList.Add(self.ES_PetEggListItem);
            self.PetList.Add(self.AddChild<ES_PetEggListItem, Transform>(UnityEngine.Object.Instantiate(self.ES_PetEggListItem.uiTransform.gameObject, self.EG_PetNodeListRectTransform).transform));
            self.PetList.Add(self.AddChild<ES_PetEggListItem, Transform>(UnityEngine.Object.Instantiate(self.ES_PetEggListItem.uiTransform.gameObject, self.EG_PetNodeListRectTransform).transform));
            self.PetList.Add(self.AddChild<ES_PetEggListItem, Transform>(UnityEngine.Object.Instantiate(self.ES_PetEggListItem.uiTransform.gameObject, self.EG_PetNodeListRectTransform).transform));

            self.E_Btn_ClosePetEggSelectButton.AddListener(() => { self.EG_PetEggSelectRootRectTransform.gameObject.SetActive(false); });
            
            self.EG_PetEggSelectRootRectTransform.gameObject.SetActive(false);
        }

        [EntitySystem]
        private static void Destroy(this ES_PetEggList self)
        {
            ResourcesLoaderComponent resourcesLoaderComponent = self.Root().GetComponent<ResourcesLoaderComponent>();
            for (int i = 0; i < self.AssetList.Count; i++)
            {
                resourcesLoaderComponent.UnLoadAsset(self.AssetList[i]);
            }

            self.AssetList.Clear();
            self.AssetList = null;
            
            self.DestroyWidget();
        }

        public static void OnUpdateUI(this ES_PetEggList self)
        {
            int eggNum = 0;
            List<ItemInfo> bagInfos = self.Root().GetComponent<BagComponentC>().GetBagList();
            for (int i = 0; i < bagInfos.Count; i++)
            {
                ItemConfig itemConfig = ItemConfigCategory.Instance.Get(bagInfos[i].ItemID);
                if (itemConfig.ItemSubType == 102 && itemConfig.ItemType == 1)
                {
                    eggNum++;
                }
            }
            using (zstring.Block())
            {
                self.E_PetEggNumText.text = zstring.Format("{0}个", eggNum);
            }
            
            PetComponentC petComponent = self.Root().GetComponent<PetComponentC>();
            for (int i = 0; i < self.PetList.Count; i++)
            {
                ES_PetEggListItem esPetEggListItem = self.PetList[i];
                esPetEggListItem.OnUpdateUI(petComponent.RolePetEggs[i], i);
            }
        }

        public static async ETTask PetEggItemSelect(this ES_PetEggList self, int index, int itemConfigId)
        {
            self.EG_PetEggSelectRootRectTransform.gameObject.SetActive(false);
            
            List<ItemInfo> bagInfos = self.Root().GetComponent<BagComponentC>().GetBagList();
            long bagInfoID = 0;
            for (int i = 0; i < bagInfos.Count; i++)
            {
                if (bagInfos[i].ItemID == itemConfigId)
                {
                    bagInfoID = bagInfos[i].BagInfoID;
                    break;
                }
            }
            
            int error = await PetNetHelper.RequestPetEggPut(self.Root(), index, bagInfoID);
            if (error != ErrorCode.ERR_Success)
            {
                return;
            }

            self.OnUpdateUI();
        }

        public static void OnOpenSlotButton(this ES_PetEggList self, int index)
        {
            string[] costItemsList = GlobalValueConfigCategory.Instance.Get(135).Value.Split('@');
            string[] costItems = costItemsList[index].Split(';');
            string itemName = ItemConfigCategory.Instance.Get(int.Parse(costItems[0])).ItemName;
            string itemNum = costItems[1];
            using (zstring.Block())
            {
                string tip = zstring.Format("开启新的位置需要{0}{1}，是否继续？", itemNum, itemName);
                using (zstring.Block())
                {
                    PopupTipHelp.OpenPopupTip(self.Root(), "提示", tip, async () =>
                    {
                        int error = await PetNetHelper.RequestPetEggOpenSlot(self.Root(), index);
                        if (error != ErrorCode.ERR_Success)
                        {
                            return;
                        }

                        self.OnUpdateUI();

                    }, null).Coroutine();
                }
            }
        }
        
        public static void ShowPetEggSelectList(this ES_PetEggList self, int index)
        {
            self.EG_PetEggSelectRootRectTransform.gameObject.SetActive(true);
            // Camera uiCamera = self.Root().GetComponent<GlobalComponent>().UICamera.GetComponent<Camera>();
            // Vector2 localPoint;
            // RectTransformUtility.ScreenPointToLocalPointInRectangle(self.EG_PetEggSelectRootRectTransform, Input.mousePosition, uiCamera, out localPoint);
            // self.E_PetEggSelectPanelImage.rectTransform.localPosition = localPoint;
            
            Dictionary<int, int> itemDic = new Dictionary<int, int>();
            List<ItemInfo> bagInfos = self.Root().GetComponent<BagComponentC>().GetBagList();
            for (int i = 0; i < bagInfos.Count; i++)
            {
                ItemConfig itemConfig = ItemConfigCategory.Instance.Get(bagInfos[i].ItemID);
                if (itemConfig.ItemSubType == 102 && itemConfig.ItemType == 1)
                {
                    if (itemDic.ContainsKey(itemConfig.Id))
                    {
                        itemDic[itemConfig.Id]++;
                    }
                    else
                    {
                        itemDic[itemConfig.Id] = 1;
                    }
                }
            }

            ResourcesLoaderComponent resourcesLoaderComponent = self.Root().GetComponent<ResourcesLoaderComponent>();
            List<KeyValuePair<int, int>> itemList = itemDic.ToList();
            for (int i = 0; i < itemList.Count; i++)
            {
                if (!self.ScrollItemPetEggSelectItems.ContainsKey(i))
                {
                    Scroll_Item_PetEggSelectItem item = self.AddChild<Scroll_Item_PetEggSelectItem>();
                    string path = "Assets/Bundles/UI/Item/Item_PetEggSelectItem.prefab";
                    if (!self.AssetList.Contains(path))
                    {
                        self.AssetList.Add(path);
                    }

                    GameObject prefab = resourcesLoaderComponent.LoadAssetSync<GameObject>(path);
                    GameObject go = UnityEngine.Object.Instantiate(prefab, self.E_PetEggSelectItemsScrollRect.transform.Find("Content").gameObject.transform);
                    item.BindTrans(go.transform);
                    self.ScrollItemPetEggSelectItems.Add(i, item);
                }

                Scroll_Item_PetEggSelectItem scrollItemPetEggSelectItem = self.ScrollItemPetEggSelectItems[i];
                scrollItemPetEggSelectItem.uiTransform.gameObject.SetActive(true);
                scrollItemPetEggSelectItem.OnInitData(index, itemList[i].Key, itemList[i].Value);
            }

            if (self.ScrollItemPetEggSelectItems.Count > itemList.Count)
            {
                for (int i = itemList.Count; i < self.ScrollItemPetEggSelectItems.Count; i++)
                {
                    Scroll_Item_PetEggSelectItem scrollItemPetEggSelectItem = self.ScrollItemPetEggSelectItems[i];
                    scrollItemPetEggSelectItem.uiTransform.gameObject.SetActive(false);
                }
            }
        }
        
        public static void OnButtonOpenButton(this ES_PetEggList self, KeyValuePairLong4 rolePetEgg, int index)
        {
            UserInfo userInfo = self.Root().GetComponent<UserInfoComponentC>().UserInfo;
            PetComponentC petComponent = self.Root().GetComponent<PetComponentC>();
            int petexpendNumber = UnitHelper.GetMyUnitFromClientScene(self.Root()).GetComponent<NumericComponentC>().GetAsInt(NumericType.PetExtendNumber);
            int maxNum = PetHelper.GetPetMaxNumber(userInfo.Lv, petexpendNumber);
            if (maxNum <= PetHelper.GetCangKuPetNum(petComponent.RolePetInfos))
            {
                FlyTipComponent.Instance.ShowFlyTip("已达到最大宠物数量");
                return;
            }

            int costValue = CommonHelp.ReturnPetOpenTimeDiamond((int)rolePetEgg.KeyId, rolePetEgg.Value);
            using (zstring.Block())
            {
                PopupTipHelp.OpenPopupTip(self.Root(), "开启宠物蛋", zstring.Format("开启需要花费 {0}钻石", costValue),
                    () => { self.OnButtonGetButton(index).Coroutine(); }).Coroutine();
            }
        }

        public static async ETTask OnButtonFuHuaButton(this ES_PetEggList self, int index)
        {
            int error = await PetNetHelper.RequestPetEggHatch(self.Root(), index);

            if (error != ErrorCode.ERR_Success)
            {
                return;
            }

            self.OnUpdateUI();
        }

        public static async ETTask RequestXieXia(this ES_PetEggList self, int binfo)
        {
            if (self.Root().GetComponent<BagComponentC>().GetBagLeftCell(ItemLocType.ItemLocBag) < 1)
            {
                FlyTipComponent.Instance.ShowFlyTip("背包空间不足！");
                return;
            }

            int error = await PetNetHelper.RequestPetEggPutOut(self.Root(), binfo);
            if (error != ErrorCode.ERR_Success)
            {
                return;
            }

            self.OnUpdateUI();
        }

        public static async ETTask OnButtonGetButton(this ES_PetEggList self, int index)
        {
            UserInfo userInfo = self.Root().GetComponent<UserInfoComponentC>().UserInfo;
            int maxNum = PetHelper.GetPetMaxNumber(self.Root().GetComponent<UserInfoComponentC>().UserInfo.Lv, userInfo.Lv);
            PetComponentC petComponent = self.Root().GetComponent<PetComponentC>();
            if (maxNum <= PetHelper.GetBagPetNum(petComponent.RolePetInfos))
            {
                FlyTipComponent.Instance.ShowFlyTip("已达到最大宠物数量");
                return;
            }

            KeyValuePairLong4 rolePetEgg = petComponent.RolePetEggs[index];
            if (rolePetEgg.KeyId == 0)
            {
                return;
            }

            int needCost = 0;
            if (TimeHelper.ServerNow() < rolePetEgg.Value)
            {
                needCost = CommonHelp.ReturnPetOpenTimeDiamond((int)rolePetEgg.KeyId, rolePetEgg.Value);
            }

            if (userInfo.Diamond < needCost)
            {
                FlyTipComponent.Instance.ShowFlyTip("钻石不足！");
                return;
            }

            int error = await PetNetHelper.RequestPetEggOpen(self.Root(), index);
            if (error != ErrorCode.ERR_Success)
            {
                return;
            }

            self.OnUpdateUI();
        }
    }
}