using System.Linq;
using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_ChengJiuJinglingItem))]
    [EntitySystemOf(typeof(ES_ChengJiuJingling))]
    [FriendOfAttribute(typeof(ES_ChengJiuJingling))]
    public static partial class ES_ChengJiuJinglingSystem
    {
        [EntitySystem]
        private static void Awake(this ES_ChengJiuJingling self, Transform transform)
        {
            self.uiTransform = transform;

            self.E_ItemTypeSetToggleGroup.AddListener(self.OnItemTypeSet);
            self.E_ChengJiuJinglingItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnChengJiuJinglingItemsRefresh);

            self.E_ItemTypeSetToggleGroup.OnSelectIndex(0);
            // self.OnInitUI();
        }

        [EntitySystem]
        private static void Destroy(this ES_ChengJiuJingling self)
        {
            self.DestroyWidget();
        }

        private static void OnItemTypeSet(this ES_ChengJiuJingling self, int index)
        {
            self.RefreshChengJiuJinglingItems();
        }

        private static void OnChengJiuJinglingItemsRefresh(this ES_ChengJiuJingling self, Transform transform, int index)
        {
            Scroll_Item_ChengJiuJinglingItem scrollItemChengJiuJinglingItem = self.ScrollItemChengJiuJinglingItems[index].BindTrans(transform);
            ChengJiuComponentC chengJiuComponent = self.Root().GetComponent<ChengJiuComponentC>();
            scrollItemChengJiuJinglingItem.OnInitUI(self.ShowJingLing[index].Id, chengJiuComponent.JingLingList[self.ShowJingLing[index].Id]);
        }

        public static void RefreshChengJiuJinglingItems(this ES_ChengJiuJingling self)
        {
            self.ShowJingLing.Clear();
            foreach (JingLingConfig jingLingConfig in JingLingConfigCategory.Instance.GetAll().Values)
            {
                if (self.E_ItemTypeSetToggleGroup.GetCurrentIndex() == 0)
                {
                    self.ShowJingLing.Add(jingLingConfig);
                    return;
                }

                if (self.E_ItemTypeSetToggleGroup.GetCurrentIndex() == jingLingConfig.JingLingType)
                {
                    self.ShowJingLing.Add(jingLingConfig);
                }
            }

            self.AddUIScrollItems(ref self.ScrollItemChengJiuJinglingItems, self.ShowJingLing.Count);
            self.E_ChengJiuJinglingItemsLoopVerticalScrollRect.SetVisible(true, self.ShowJingLing.Count);
        }

        private static async ETTask OnButtonActivite(this ES_ChengJiuJingling self)
        {
            // ChengJiuComponentC chengJiuComponent = self.Root().GetComponent<ChengJiuComponentC>();
            //
            // int error = await JingLingNetHelper.RequestJingLingUse(self.Root(), self.JingLingId, 1);
            // if (error != 0)
            // {
            //     return;
            // }
            //
            // bool current = chengJiuComponent.GetFightJingLing() == self.JingLingId;
            // self.E_ButtonShouHuiButton.gameObject.SetActive(current);
            // self.E_ButtonActiviteButton.gameObject.SetActive(!current);
            //
            // EventSystem.Instance.Publish(self.Root(), new JingLingButton());
        }

        public static void OnUpdateUI(this ES_ChengJiuJingling self)
        {
            // for (int i = 0; i < self.ScrollItemChengJiuJinglingItems.Count; i++)
            // {
            //     Scroll_Item_ChengJiuJinglingItem scrollItemChengJiuJinglingItem = self.ScrollItemChengJiuJinglingItems[i];
            //     if (scrollItemChengJiuJinglingItem.uiTransform != null)
            //     {
            //         scrollItemChengJiuJinglingItem.OnUpdateUI();
            //     }
            // }
        }
    }
}