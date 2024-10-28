using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof(DlgJiaYuanOneKeyPlant))]
    public static class DlgJiaYuanOneKeyPlantSystem
    {
        public static void RegisterUIEvent(this DlgJiaYuanOneKeyPlant self)
        {
            self.View.E_Btn_CloseButton.AddListener(() =>
            {
                self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_JiaYuanOneKeyPlant);
            });
            self.View.E_Btn_OnePlantButton.AddListenerAsync(self.OnBtn_OnePlantButton);
            self.View.E_ItemDiButton.AddListener(self.OnItemDiButton);
            self.View.E_ItemClickButton.AddListener(self.OnItemClickButton);
            self.View.E_ItemDragButton.AddListener(self.OnItemDragButton);
            self.View.E_LockButton.AddListener(self.OnLockButton);
            
            self.View.EG_SeedToggleRectTransform.gameObject.SetActive(false);
            self.UpdateInfo();
        }

        public static void ShowWindow(this DlgJiaYuanOneKeyPlant self, Entity contextData = null)
        {
        }

        public static void UpdateInfo(this DlgJiaYuanOneKeyPlant self)
        {
            self.Lands.Clear();
            JiaYuanComponentC jiaYuanComponent = self.Root().GetComponent<JiaYuanComponentC>();
            foreach (int cellIndex in jiaYuanComponent.PlanOpenList_7)
            {
                Unit unit = JiaYuanHelper.GetUnitByCellIndex(self.Root().CurrentScene(), cellIndex);
                if (unit == null)
                {
                    self.Lands.Add(cellIndex);
                }
            }

            using (zstring.Block())
            {
                self.View.E_NumTextText.text = zstring.Format("可种植地数量:{0}/{1}", self.Lands.Count, jiaYuanComponent.PlanOpenList_7.Count);
            }

            self.SeedToggles.Clear();
            BagComponentC bagComponent = self.Root().GetComponent<BagComponentC>();
            List<ItemInfo> bagInfos = bagComponent.GetItemsByType(2);
            int num = 0;
            for (int i = 0; i < bagInfos.Count; i++)
            {
                ItemConfig itemConfig = ItemConfigCategory.Instance.Get(bagInfos[i].ItemID);
                if (itemConfig.ItemType != 2 || itemConfig.ItemSubType != 101)
                {
                    continue;
                }

                for (int j = 0; j < bagInfos[i].ItemNum; j++)
                {
                    GameObject go = UnityEngine.Object.Instantiate(self.View.EG_SeedToggleRectTransform.gameObject);

                    int index = num;
                    ES_CommonItem uI = null;
                    uI = self.AddChild<ES_CommonItem, Transform>(go.GetComponent<ReferenceCollector>().Get<GameObject>("UICommonItem").transform);
                    ItemInfo bagInfo = new ItemInfo();
                    bagInfo.ItemID = bagInfos[i].ItemID;
                    bagInfo.ItemNum = 1;
                    uI.UpdateItem(bagInfo, ItemOperateEnum.None);
                    go.GetComponent<ReferenceCollector>().Get<GameObject>("Btn_Click").GetComponent<Button>()
                            .AddListener(() => { self.OnSeedToggle(index); });

                    if (num < self.Lands.Count) // 默认是从1开始全部勾选指定数量的
                    {
                        go.GetComponent<ReferenceCollector>().Get<GameObject>("Image_Click").SetActive(true);
                        self.Seeds.Add(bagInfos[i].ItemID);
                    }
                    else
                    {
                        go.GetComponent<ReferenceCollector>().Get<GameObject>("Image_Click").SetActive(false);
                    }

                    go.SetActive(true);
                    CommonViewHelper.SetParent(go, self.View.EG_ItemListNodeRectTransform.gameObject);
                    self.SeedToggles.Add(num, bagInfos[i].ItemID);
                    self.SeedToggleGameObjects.Add(num, go);
                    num++;
                }
            }
        }

        public static void OnSeedToggle(this DlgJiaYuanOneKeyPlant self, int index)
        {
            bool active = self.SeedToggleGameObjects[index].GetComponent<ReferenceCollector>().Get<GameObject>("Image_Click").activeSelf;

            if (active)
            {
                self.Seeds.Remove(self.SeedToggles[index]);
                self.SeedToggleGameObjects[index].GetComponent<ReferenceCollector>().Get<GameObject>("Image_Click").SetActive(false);
            }
            else
            {
                if (self.Seeds.Count < self.Lands.Count)
                {
                    self.Seeds.Add(self.SeedToggles[index]);
                    self.SeedToggleGameObjects[index].GetComponent<ReferenceCollector>().Get<GameObject>("Image_Click").SetActive(true);
                }
                else
                {
                    FlyTipComponent.Instance.ShowFlyTip("空地数量不足！");
                }
            }
        }

        public static async ETTask OnBtn_OnePlantButton(this DlgJiaYuanOneKeyPlant self)
        {
            if (self.Seeds.Count <= 0)
            {
                return;
            }

            long instanceid = self.InstanceId;
            for (int i = 0; i < self.Seeds.Count; i++)
            {
                await JiaYuanNetHelper.JiaYuanPlantRequest(self.Root(), self.Lands[i], self.Seeds[i]);

                if (instanceid != self.InstanceId)
                {
                    break;
                }
            }

            if (instanceid != self.InstanceId)
            {
                return;
            }

            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_JiaYuanOneKeyPlant);
        }
        public static void OnItemDiButton(this DlgJiaYuanOneKeyPlant self)
        {
        }
        public static void OnItemClickButton(this DlgJiaYuanOneKeyPlant self)
        {
        }
        public static void OnItemDragButton(this DlgJiaYuanOneKeyPlant self)
        {
        }
        public static void OnLockButton(this DlgJiaYuanOneKeyPlant self)
        {
        }
    }
}
