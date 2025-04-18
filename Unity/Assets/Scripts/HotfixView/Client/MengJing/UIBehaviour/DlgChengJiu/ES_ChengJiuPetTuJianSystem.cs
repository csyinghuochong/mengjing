using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_ChengJiuPetTuJianItem))]
    [EntitySystemOf(typeof(ES_ChengJiuPetTuJian))]
    [FriendOfAttribute(typeof(ES_ChengJiuPetTuJian))]
    public static partial class ES_ChengJiuPetTuJianSystem
    {
        [EntitySystem]
        private static void Awake(this ES_ChengJiuPetTuJian self, Transform transform)
        {
            self.uiTransform = transform;

            self.E_ItemTypeSetToggleGroup.AddListener(self.OnItemTypeSet);
            self.E_ChengJiuJinglingItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnChengJiuJinglingItemsRefresh);
            self.E_ActivateButton.AddListener(self.OnButtonActivate);
            self.E_UseButton.AddListenerAsync(self.OnButtonUse);
            self.E_ShouHuiButton.AddListenerAsync(self.OnButtonUse);

            self.E_ItemTypeSetToggleGroup.OnSelectIndex(0);
        }

        [EntitySystem]
        private static void Destroy(this ES_ChengJiuPetTuJian self)
        {
            self.DestroyWidget();
        }

        private static void OnItemTypeSet(this ES_ChengJiuPetTuJian self, int index)
        {
            self.RefreshChengJiuJinglingItems();
        }

        private static void OnChengJiuJinglingItemsRefresh(this ES_ChengJiuPetTuJian self, Transform transform, int index)
        {
            foreach (Scroll_Item_ChengJiuPetTuJianItem item in self.ScrollItemChengJiuJinglingItems.Values)
            {
                if (item.uiTransform == transform)
                {
                    item.uiTransform = null;
                }
            }

            Scroll_Item_ChengJiuPetTuJianItem scrollItemChengJiuJinglingItem = self.ScrollItemChengJiuJinglingItems[index].BindTrans(transform);
            ChengJiuComponentC chengJiuComponent = self.Root().GetComponent<ChengJiuComponentC>();
            scrollItemChengJiuJinglingItem.OnInitUI(self.ShowJingLing[index].Id, chengJiuComponent.IsActiveJingLing(self.ShowJingLing[index].Id));
        }

        public static void RefreshChengJiuJinglingItems(this ES_ChengJiuPetTuJian self)
        {
            self.ShowJingLing.Clear();
            foreach (JingLingConfig jingLingConfig in JingLingConfigCategory.Instance.GetAll().Values)
            {
                if (jingLingConfig.GetWay !=1)
                {
                    continue;
                }

                if (self.E_ItemTypeSetToggleGroup.GetCurrentIndex() == 0)
                {
                    self.ShowJingLing.Add(jingLingConfig);
                    continue;
                }

                if (self.E_ItemTypeSetToggleGroup.GetCurrentIndex() == jingLingConfig.JingLingType)
                {
                    self.ShowJingLing.Add(jingLingConfig);
                }
            }

            self.AddUIScrollItems(ref self.ScrollItemChengJiuJinglingItems, self.ShowJingLing.Count);
            self.E_ChengJiuJinglingItemsLoopVerticalScrollRect.SetVisible(true, self.ShowJingLing.Count);

            self.OnUpdateUI(self.ShowJingLing[0].Id);
        }

        private static  void OnButtonActivate(this ES_ChengJiuPetTuJian self)
        {
            Log.Debug($"OnButtonActivate");
        }

        private static async ETTask OnButtonUse(this ES_ChengJiuPetTuJian self)
        {
            ChengJiuComponentC chengJiuComponent = self.Root().GetComponent<ChengJiuComponentC>();
            JingLingInfo jingLingInfo = chengJiuComponent.JingLingList[self.JingLingId];
            if (jingLingInfo.IsActive == 0)
            {
                FlyTipComponent.Instance.ShowFlyTip("未激活此精灵！");
                return;
            }
            
            int error = await JingLingNetHelper.RequestJingLingUse(self.Root(), self.JingLingId, 1);
            if (error != 0)
            {
                return;
            }
            
            self.OnUpdateUI(self.JingLingId);
            
            EventSystem.Instance.Publish(self.Root(), new JingLingButton());
        }

        public static void OnUpdateUI(this ES_ChengJiuPetTuJian self, int jingLingId)
        {
            self.JingLingId = jingLingId;

            foreach (Scroll_Item_ChengJiuPetTuJianItem item in self.ScrollItemChengJiuJinglingItems.Values)
            {
                if (item.uiTransform == null)
                {
                    continue;
                }

                item.E_SelectedImage.gameObject.SetActive(self.JingLingId == item.JingLingId);
            }

            JingLingConfig jingLingConfig = JingLingConfigCategory.Instance.Get(self.JingLingId);
            
            // self.ES_ModelShow.ShowOtherModel("JingLing/" + jingLingConfig.Assets).Coroutine();
            self.ES_ModelShow.ShowOtherModel($"Pet/{jingLingConfig.Assets}").Coroutine();
            self.ES_ModelShow.SetCameraPosition(new Vector3(0f, 40f, 200f));
            // self.ES_ModelShow.SetRootPosition(new Vector2(jingLingConfig.Id % 10 * 1000, 0));
            self.ES_ModelShow.SetModelParentRotation(Quaternion.Euler(0f, -45f, 0f));

            self.E_NameText.text = jingLingConfig.Name;
            using (zstring.Block())
            {
                self.E_LvText.text = zstring.Format("境界：{0}", jingLingConfig.Lv);
            }

            self.E_ProDesText.text = jingLingConfig.ProDes;

            self.E_GetWayText.text = "获取方式：捕捉";
            self.E_ProbabilityText.gameObject.SetActive(false);

            ChengJiuComponentC chengJiuComponent = self.Root().GetComponent<ChengJiuComponentC>();

            int num = chengJiuComponent.GetActiveJingLing(1).Count;

            using (zstring.Block())
            {
                self.E_TotalProgressText.text = zstring.Format("总进度：{0}/{1}", num, PetHelper.GetJingLingByGetWay(1).Count);
            }


            int progress = chengJiuComponent.IsActiveJingLing(jingLingId) ? 1 : 0;
            using (zstring.Block())
            {
                // self.E_ProgressTxtText.text = zstring.Format("{0}/{1}", progress, jingLingConfig.NeedPoint);
                self.E_ProgressTxtText.text = zstring.Format("{0}/{1}", progress, 1);
            }

            // self.E_ProgressImgImage.fillAmount =progress * 1f / jingLingConfig.NeedPoint;
            self.E_ProgressImgImage.fillAmount = progress * 1f / 1;
            self.E_UnactivateText.gameObject.SetActive(true);
            if (progress == 1)
            {
                self.E_UnactivateText.text = "已激活";
                
                bool current = chengJiuComponent.GetFightJingLing() == self.JingLingId;
                self.E_UnactivateText.gameObject.SetActive(false);
                self.E_ActivateButton.gameObject.SetActive(false);
                self.E_UseButton.gameObject.SetActive(!current);
                self.E_ShouHuiButton.gameObject.SetActive(current);
            }
            else
            {
                self.E_UnactivateText.text = "未激活";
                
                self.E_ActivateButton.gameObject.SetActive(false);
                self.E_UseButton.gameObject.SetActive(false);
                self.E_ShouHuiButton.gameObject.SetActive(false);
            }
        }
    }
}