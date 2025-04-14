using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace ET.Client
{
    [Event(SceneType.Demo)]
    public class DataUpdate_HuiShouSelect_DlgJiaYuanPetFeedRefresh : AEvent<Scene, HuiShouSelect>
    {
        protected override async ETTask Run(Scene scene, HuiShouSelect args)
        {
            scene.GetComponent<UIComponent>().GetDlgLogic<DlgJiaYuanPetFeed>()?.OnHuiShouSelect(args.DataParamString);
            await ETTask.CompletedTask;
        }
    }

    [FriendOf(typeof(Scroll_Item_CommonItem))]
    [FriendOf(typeof(DlgJiaYuanPetFeed))]
    public static class DlgJiaYuanPetFeedSystem
    {
        public static void RegisterUIEvent(this DlgJiaYuanPetFeed self)
        {
            self.View.E_BagItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnBagItemsRefresh);
            self.View.E_ImageCloseButton.AddListener(self.OnImageCloseButton);
            self.View.E_Btn_CloseDiButton.AddListener(self.OnImageCloseButton);
            self.View.E_ButtonEatButton.AddListenerAsync(self.OnButtonEatButton);

            self.MoodList[0] = self.View.E_Image_Mood_0Image.gameObject;
            self.MoodList[1] = self.View.E_Image_Mood_1Image.gameObject;
            self.MoodList[2] = self.View.E_Image_Mood_2Image.gameObject;
            self.MoodList[3] = self.View.E_Image_Mood_3Image.gameObject;
            self.MoodList[4] = self.View.E_Image_Mood_4Image.gameObject;

            self.CostItemList[0] = self.View.ES_CommonItem_0;
            self.CostItemList[1] = self.View.ES_CommonItem_1;
            self.CostItemList[2] = self.View.ES_CommonItem_2;
        }

        public static void ShowWindow(this DlgJiaYuanPetFeed self, Entity contextData = null)
        {
        }

        public static void OnImageCloseButton(this DlgJiaYuanPetFeed self)
        {
            self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgJiaYuanMain>().WaitPetWalk(self.JiaYuanPet);
            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_JiaYuanPetFeed);
        }

        public static void OnInitUI(this DlgJiaYuanPetFeed self, JiaYuanPet jiaYuanPet)
        {
            self.JiaYuanPet = jiaYuanPet;

            PetConfig petConfig = PetConfigCategory.Instance.Get(jiaYuanPet.ConfigId);
            self.View.ES_ModelShow.ShowOtherModel("Pet/" + petConfig.PetModel).Coroutine();
            self.View.ES_ModelShow.SetCameraPosition(new Vector3(0f, 100f, 450f));
            self.View.ES_ModelShow.Camera.fieldOfView = 30;
            // self.View.ES_ModelShow.SetRootPosition(new Vector2(1000, 0));
            self.View.ES_ModelShow.ModelParent.localRotation = Quaternion.Euler(0f, -45f, 0f);

            self.OnUpdateItemList();
            self.OnUpdatePetInfo();
        }

        public static void OnUpdatePetInfo(this DlgJiaYuanPetFeed self)
        {
            JiaYuanComponentC jiaYuanComponent = self.Root().GetComponent<JiaYuanComponentC>();
            JiaYuanPet jiaYuanPet = jiaYuanComponent.GetJiaYuanPet(self.JiaYuanPet.unitId);
            if (jiaYuanPet == null)
            {
                using (zstring.Block())
                {
                    Log.Error(zstring.Format("UIJiaYuanPetFeed:  {0}", self.Root().GetComponent<PlayerInfoComponent>().CurrentRoleId));
                }

                return;
            }

            for (int i = 0; i < self.MoodList.Length; i++)
            {
                self.MoodList[i].SetActive(i < ET.JiaYuanHelper.GetPetMoodStar(jiaYuanPet.MoodValue));
            }

            int addExp = CommonHelp.GetJiaYuanPetExp(jiaYuanPet.PetLv, jiaYuanPet.MoodValue);
            using (zstring.Block())
            {
                self.View.E_Text_HourExpText.text = zstring.Format("经验收益: {0}/小时", addExp);
            }

            self.View.E_Text_PetNameText.text = jiaYuanPet.PetName;
        }

        private static void OnBagItemsRefresh(this DlgJiaYuanPetFeed self, Transform transform, int index)
        {
            foreach (Scroll_Item_CommonItem item in self.ScrollItemCommonItems.Values)
            {
                if (item.uiTransform == transform)
                {
                    item.uiTransform = null;
                }
            }
            
            Scroll_Item_CommonItem scrollItemCommonItem = self.ScrollItemCommonItems[index].BindTrans(transform);

            scrollItemCommonItem.Refresh(self.ShowBagInfos[index], ItemOperateEnum.HuishouBag);

            scrollItemCommonItem.PointerDownHandler = (binfo, pdata) => { self.OnPointerDown(binfo, pdata).Coroutine(); };
            scrollItemCommonItem.PointerUpHandler = (binfo, pdata) => { self.OnPointerUp(binfo, pdata); };
            scrollItemCommonItem.SetEventTrigger(true);
        }

        public static void OnUpdateItemList(this DlgJiaYuanPetFeed self)
        {
            BagComponentC bagComponent = self.Root().GetComponent<BagComponentC>();
            List<ItemInfo> bagInfos = bagComponent.GetBagList();

            self.ShowBagInfos.Clear();
            for (int i = 0; i < bagInfos.Count; i++)
            {
                ItemConfig itemConfig = ItemConfigCategory.Instance.Get(bagInfos[i].ItemID);
                bool ifShow = false;
                if (!ifShow && itemConfig.ItemType == 1 && itemConfig.ItemSubType == 131)
                {
                    ifShow = true;
                    //continue;
                }

                if (!ifShow && itemConfig.ItemType == 2 && itemConfig.ItemSubType == 101 ||
                    itemConfig.ItemSubType == 201 && itemConfig.ItemSubType == 301)
                {
                    ifShow = true;
                    //continue;
                }

                if (ifShow)
                {
                    self.ShowBagInfos.Add(bagInfos[i]);
                }
            }

            self.AddUIScrollItems(ref self.ScrollItemCommonItems, self.ShowBagInfos.Count);
            self.View.E_BagItemsLoopVerticalScrollRect.SetVisible(true, self.ShowBagInfos.Count);
        }

        public static void OnHuiShouSelect(this DlgJiaYuanPetFeed self, string dataparams)
        {
            string[] huishouInfo = dataparams.Split('_');
            BagComponentC bagComponent = self.Root().GetComponent<BagComponentC>();
            ItemInfo bagInfo = bagComponent.GetBagInfo(long.Parse(huishouInfo[1]));
            if (bagInfo == null)
            {
                return;
            }

            for (int i = 0; i < self.CostItemList.Length; i++)
            {
                ES_CommonItem item = self.CostItemList[i];
                if (item.Baginfo == null)
                {
                    continue;
                }

                if (item.Baginfo.BagInfoID == bagInfo.BagInfoID)
                {
                    item.UpdateItem(null, ItemOperateEnum.None);
                    item.E_ItemNameText.gameObject.SetActive(false);
                }
            }

            //1新增  2移除 
            if (huishouInfo[0] == "1")
            {
                for (int i = 0; i < self.CostItemList.Length; i++)
                {
                    ES_CommonItem item = self.CostItemList[i];
                    if (item.Baginfo == null)
                    {
                        item.UpdateItem(bagInfo, ItemOperateEnum.HuishouShow);
                        item.E_ItemNumText.text = "1";
                        item.E_ItemNameText.gameObject.SetActive(true);
                        break;
                    }
                }
            }

            self.UpdateSelected();
        }

        public static async ETTask OnButtonEatButton(this DlgJiaYuanPetFeed self)
        {
            List<long> idslist = new List<long>();
            for (int h = 0; h < self.CostItemList.Length; h++)
            {
                ES_CommonItem item = self.CostItemList[h];
                if (item.Baginfo != null)
                {
                    idslist.Add(item.Baginfo.BagInfoID);
                }
            }

            M2C_JiaYuanPetFeedResponse response = await JiaYuanNetHelper.JiaYuanPetFeedRequest(self.Root(), self.JiaYuanPet.unitId, idslist);
            self.Root().GetComponent<JiaYuanComponentC>().JiaYuanPetList_2 = response.JiaYuanPetList;

            using (zstring.Block())
            {
                FlyTipComponent.Instance.ShowFlyTip(zstring.Format("宠物增加 {0}心情值", response.MoodAdd));
            }

            self.OnUpdateItemList();
            self.OnUpdatePetInfo();
            self.UpdateCostList();
            self.UpdateSelected();
        }

        public static void UpdateCostList(this DlgJiaYuanPetFeed self)
        {
            BagComponentC bagComponent = self.Root().GetComponent<BagComponentC>();
            for (int h = 0; h < self.CostItemList.Length; h++)
            {
                ES_CommonItem esCommonItem = self.CostItemList[h];
                if (esCommonItem.Baginfo == null)
                {
                    continue;
                }

                if (null == bagComponent.GetBagInfo(esCommonItem.Baginfo.BagInfoID))
                {
                    esCommonItem.UpdateItem(null, ItemOperateEnum.None);
                    esCommonItem.E_ItemNameText.gameObject.SetActive(false);
                }
            }
        }

        public static void UpdateSelected(this DlgJiaYuanPetFeed self)
        {
            if (self.ScrollItemCommonItems != null)
            {
                foreach (Scroll_Item_CommonItem item in self.ScrollItemCommonItems.Values)
                {
                    if (item.uiTransform == null)
                    {
                        continue;
                    }

                    ItemInfo bagInfo = item.Baginfo;
                    if (bagInfo == null)
                    {
                        continue;
                    }

                    bool have = false;
                    for (int h = 0; h < self.CostItemList.Length; h++)
                    {
                        ES_CommonItem esCommonItem = self.CostItemList[h];
                        if (esCommonItem.Baginfo != null && esCommonItem.Baginfo.BagInfoID == bagInfo.BagInfoID)
                        {
                            have = true;
                        }
                    }

                    item.E_XuanZhongImage.gameObject.SetActive(have);
                }
            }
        }

        public static async ETTask OnPointerDown(this DlgJiaYuanPetFeed self, ItemInfo binfo, PointerEventData pdata)
        {
            if (binfo == null)
            {
                return;
            }

            self.IsHoldDown = true;
            using (zstring.Block())
            {
                EventSystem.Instance.Publish(self.Root(), new HuiShouSelect() { DataParamString = zstring.Format("1_{0}", binfo.BagInfoID) });
            }

            await self.Root().GetComponent<TimerComponent>().WaitAsync(500);
            if (!self.IsHoldDown)
            {
                return;
            }

            EventSystem.Instance.Publish(self.Root(),
                new ShowItemTips()
                {
                    BagInfo = binfo,
                    ItemOperateEnum = ItemOperateEnum.None,
                    InputPoint = Input.mousePosition,
                    Occ = self.Root().GetComponent<UserInfoComponentC>().UserInfo.Occ,
                    EquipList = new()
                });
        }

        public static void OnPointerUp(this DlgJiaYuanPetFeed self, ItemInfo binfo, PointerEventData pdata)
        {
            self.IsHoldDown = false;
            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_EquipDuiBiTips);
        }
    }
}
