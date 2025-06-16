using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_PetChouKaItem))]
    [EntitySystemOf(typeof(ES_PetChouKa))]
    [FriendOf(typeof(ES_PetChouKa))]
    public static partial class ES_PetChouKaSystem
    {
        [EntitySystem]
        private static void Awake(this ES_PetChouKa self, Transform transform)
        {
            self.uiTransform = transform;
            
            self.E_ButtonOpenButton.AddListener(() => { self.OnButtonOpen().Coroutine(); });
            
            self.OnStopTurn = false;
            self.E_ImageSelectImage.gameObject.SetActive(false);
            
            self.OnInitUI();
        }

        [EntitySystem]
        private static void Destroy(this ES_PetChouKa self)
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

        private static void UpdateCostItemNum(this ES_PetChouKa self)
        {
            string[] itemInfo = GlobalValueConfigCategory.Instance.Get(137).Value.Split(';');
            ItemConfig itemConfig = ItemConfigCategory.Instance.Get(int.Parse(itemInfo[0]));
            self.E_OpenCostItemIconImage.overrideSprite = self.Root().GetComponent<ResourcesLoaderComponent>()
                    .LoadAssetSync<Sprite>(ABPathHelper.GetAtlasPath_2(ABAtlasTypes.ItemIcon, itemConfig.Icon));
            int costNum = int.Parse(itemInfo[1]);
            long haveNum = self.Root().GetComponent<BagComponentC>().GetItemNumber(int.Parse(itemInfo[0]));
            self.E_OpenCostNumText.text = $"{haveNum}/{costNum}";
            self.E_OpenCostNumText.color = costNum < haveNum ? new Color(166f / 255f, 255f / 255f, 28f / 255f) : new Color(255f / 255f, 135f / 255f, 81f / 255f);
        }

        private static void OnInitUI(this ES_PetChouKa self)
        {
            self.UpdateCostItemNum();

            self.RewardShowItems = DropHelper.DropIDToShowItem_2(GlobalValueConfigCategory.Instance.PetChouKaDropId);

            ResourcesLoaderComponent resourcesLoaderComponent = self.Root().GetComponent<ResourcesLoaderComponent>();
            for (int i = 0; i < self.RewardShowItems.Count; i++)
            {
                if (!self.ScrollItemPetChouKaItems.ContainsKey(i))
                {
                    Scroll_Item_PetChouKaItem item = self.AddChild<Scroll_Item_PetChouKaItem>();
                    string path = "Assets/Bundles/UI/Item/Item_PetChouKaItem.prefab";
                    if (!self.AssetList.Contains(path))
                    {
                        self.AssetList.Add(path);
                    }

                    GameObject prefab = resourcesLoaderComponent.LoadAssetSync<GameObject>(path);
                    GameObject go = UnityEngine.Object.Instantiate(prefab, self.E_BagItemsScrollRect.transform.Find("Content").gameObject.transform);
                    item.BindTrans(go.transform);
                    self.ScrollItemPetChouKaItems.Add(i, item);
                }

                Scroll_Item_PetChouKaItem scrollItemPetChouKaItem = self.ScrollItemPetChouKaItems[i];
                scrollItemPetChouKaItem.uiTransform.gameObject.SetActive(true);
                ItemInfo bagInfo = new ItemInfo();
                bagInfo.ItemID = self.RewardShowItems[i].ItemID;
                bagInfo.ItemNum = self.RewardShowItems[i].ItemNum;
                scrollItemPetChouKaItem.Refresh(bagInfo);
            }

            if (self.ScrollItemPetChouKaItems.Count > self.RewardShowItems.Count)
            {
                for (int i = self.RewardShowItems.Count; i < self.ScrollItemPetChouKaItems.Count; i++)
                {
                    Scroll_Item_PetChouKaItem scrollItemPetChouKaItem = self.ScrollItemPetChouKaItems[i];
                    scrollItemPetChouKaItem.uiTransform.gameObject.SetActive(false);
                }
            }
        }

        public static async ETTask OnStartTurn(this ES_PetChouKa self)
        {
            long instanceId = self.InstanceId;
            self.Interval = 100;
            self.TargetIndex = 0;
            self.CurrentIndex = 0;

            int circle = 0;
            while (!self.OnStopTurn)
            {
                self.E_ImageSelectImage.gameObject.SetActive(true);
                Scroll_Item_PetChouKaItem item = self.ScrollItemPetChouKaItems[self.CurrentIndex];
                if (item.uiTransform != null)
                {
                    CommonViewHelper.SetParent(self.E_ImageSelectImage.gameObject, item.uiTransform.gameObject);
                }

                self.CurrentIndex++;
                if (self.CurrentIndex == self.ScrollItemPetChouKaItems.Count)
                {
                    circle++;
                    self.CurrentIndex = 0;
                }

                // 开始默认转2圈
                if (circle >= 2)
                {
                    self.OnButtonStop().Coroutine();
                }

                await self.Root().GetComponent<TimerComponent>().WaitAsync(self.Interval);
                if (instanceId != self.InstanceId)
                {
                    return;
                }
            }
        }

        private static async ETTask OnButtonStop(this ES_PetChouKa self)
        {
            if (self.OnStopTurn)
            {
                return;
            }
            
            self.OnStopTurn = true;
            NumericComponentC numericComponent = UnitHelper.GetMyUnitFromClientScene(self.Root()).GetComponent<NumericComponentC>();
            int targetItem = numericComponent.GetAsInt(NumericType.PetChouKaRewardItemId);
            for (int i = 0; i < self.ScrollItemPetChouKaItems.Count; i++)
            {
                Scroll_Item_PetChouKaItem item = self.ScrollItemPetChouKaItems[i];
                if (item.uiTransform != null)
                {
                    if (item.Baginfo.ItemID == targetItem)
                    {
                        self.TargetIndex = i;
                        break;
                    }
                }
            };

            int moveNumber = 0;
            if (self.TargetIndex > self.CurrentIndex)
            {
                moveNumber = self.TargetIndex - self.CurrentIndex;
            }
            else
            {
                moveNumber = self.TargetIndex + self.ScrollItemPetChouKaItems.Count - self.CurrentIndex;
            }

            long instanceId = self.InstanceId;
            while (moveNumber >= 0)
            {
                if (moveNumber < 5)
                {
                    self.Interval += 50;
                }

                self.E_ImageSelectImage.gameObject.SetActive(true);
                Scroll_Item_PetChouKaItem item = self.ScrollItemPetChouKaItems[self.CurrentIndex];
                if (item.uiTransform != null)
                {
                    CommonViewHelper.SetParent(self.E_ImageSelectImage.gameObject, item.uiTransform.gameObject);
                }

                self.CurrentIndex++;
                if (self.CurrentIndex == self.ScrollItemPetChouKaItems.Count)
                {
                    self.CurrentIndex = 0;
                }

                moveNumber--;
                await self.Root().GetComponent<TimerComponent>().WaitAsync(self.Interval); ;
                if (instanceId != self.InstanceId)
                {
                    return;
                }
            }

            int itemId = numericComponent.GetAsInt(NumericType.PetChouKaRewardItemId);
            int itemNum = numericComponent.GetAsInt(NumericType.PetChouKaRewardItemNum);
            self.Root().GetComponent<BagComponentC>().RealAddItem--;
            int error =await PetNetHelper.RequestPetChouKaEnd(self.Root());
            self.Root().GetComponent<BagComponentC>().RealAddItem++;
            if (error == ErrorCode.ERR_Success)
            {
                self.ShotTip(itemId, itemNum);
            }

            self.OnStopTurn = false;
            self.E_ButtonOpenButton.interactable = true;
        }

        public static void ShotTip(this ES_PetChouKa self, int itemId, int itemNum)
        {
            ItemConfig itemConfig = ItemConfigCategory.Instance.Get(itemId);
            using (zstring.Block())
            {
                FlyTipComponent.Instance.ShowFlyTip(zstring.Format("获得物品 {0} ×{1}", itemConfig.ItemName, itemNum));
            }
        }

        private static async ETTask OnButtonOpen(this ES_PetChouKa self)
        {
            int error = await PetNetHelper.RequestPetChouKaStart(self.Root());

            if (error != ErrorCode.ERR_Success)
            {
                return;
            }
            
            self.UpdateCostItemNum();

            self.E_ButtonOpenButton.interactable = false;
            
            self.OnStartTurn().Coroutine();
        }
    }
}