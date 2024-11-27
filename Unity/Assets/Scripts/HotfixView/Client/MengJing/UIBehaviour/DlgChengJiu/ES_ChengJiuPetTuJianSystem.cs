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
            self.E_ActivateButton.AddListenerAsync(self.OnButtonActivate);
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
            scrollItemChengJiuJinglingItem.OnInitUI(self.ShowJingLing[index].Id, chengJiuComponent.JingLingList[self.ShowJingLing[index].Id]);
        }

        public static void RefreshChengJiuJinglingItems(this ES_ChengJiuPetTuJian self)
        {
            self.ShowJingLing.Clear();
            foreach (JingLingConfig jingLingConfig in JingLingConfigCategory.Instance.GetAll().Values)
            {
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

        private static async ETTask OnButtonActivate(this ES_ChengJiuPetTuJian self)
        {
            ChengJiuComponentC chengJiuComponent = self.Root().GetComponent<ChengJiuComponentC>();
            JingLingInfo jingLingInfo = chengJiuComponent.JingLingList[self.JingLingId];
            if (jingLingInfo.State == 1)
            {
                FlyTipComponent.Instance.ShowFlyTip("精灵已激活！");
                return;
            }

            int error = await JingLingNetHelper.RequestJingLingActivate(self.Root(), self.JingLingId);
            if (error != 0)
            {
                return;
            }

            jingLingInfo = chengJiuComponent.JingLingList[self.JingLingId];
            foreach (Scroll_Item_ChengJiuPetTuJianItem item in self.ScrollItemChengJiuJinglingItems.Values)
            {
                if (item.uiTransform == null)
                {
                    continue;
                }

                if (item.JingLingId == self.JingLingId)
                {
                    item.OnInitUI(self.JingLingId, jingLingInfo);
                }
            }

            self.OnUpdateUI(self.JingLingId);
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

            GameObject gameObject = self.ES_ModelShow.EG_RootRectTransform.gameObject;
            // self.ES_ModelShow.ShowOtherModel("JingLing/" + jingLingConfig.Assets).Coroutine();
            self.ES_ModelShow.ShowOtherModel("JingLing/70001001").Coroutine();
            gameObject.transform.Find("Camera").localPosition = new Vector3(0f, 40f, 200f);
            gameObject.transform.localPosition = new Vector2(jingLingConfig.Id % 10 * 1000, 0);
            gameObject.transform.Find("ModelParent").localRotation = Quaternion.Euler(0f, -45f, 0f);

            self.E_NameText.text = jingLingConfig.Name;
            using (zstring.Block())
            {
                self.E_LvText.text = zstring.Format("境界：{0}", jingLingConfig.Lv);
            }

            self.E_ProDesText.text = jingLingConfig.ProDes;

            if (jingLingConfig.GetWay == 1)
            {
                self.E_GetWayText.text = "获取方式：使用道具";
                self.E_ProbabilityText.gameObject.SetActive(false);
            }
            else if (jingLingConfig.GetWay == 2)
            {
                string name = "";
                for (int i = 0; i < jingLingConfig.GetValue.Length; i++)
                {
                    MonsterConfig monsterConfig = MonsterConfigCategory.Instance.Get(jingLingConfig.GetValue[i]);
                    name += monsterConfig.MonsterName;

                    if (i != jingLingConfig.GetValue.Length - 1)
                    {
                        name += "、";
                    }
                }

                using (zstring.Block())
                {
                    self.E_GetWayText.text = zstring.Format("获取方式：击败{0}", name);
                    self.E_ProbabilityText.gameObject.SetActive(true);
                    self.E_ProbabilityText.text = zstring.Format("直接激活概率：{0}%", jingLingConfig.ActivePro.ToString());
                }
            }

            ChengJiuComponentC chengJiuComponent = self.Root().GetComponent<ChengJiuComponentC>();
            JingLingInfo jingLingInfo = chengJiuComponent.JingLingList[self.JingLingId];

            int num = 0;
            foreach (JingLingInfo lingInfo in chengJiuComponent.JingLingList.Values)
            {
                if (lingInfo.IsActive == 1)
                {
                    num++;
                }
            }

            using (zstring.Block())
            {
                self.E_TotalProgressText.text = zstring.Format("总进度：{0}/{1}", num, chengJiuComponent.JingLingList.Count);
            }

            using (zstring.Block())
            {
                self.E_ProgressTxtText.text = zstring.Format("{0}/{1}",
                    jingLingInfo.Progess > jingLingConfig.NeedPoint ? jingLingConfig.NeedPoint : jingLingInfo.Progess, jingLingConfig.NeedPoint);
            }

            self.E_ProgressImgImage.fillAmount = jingLingInfo.Progess * 1f / jingLingConfig.NeedPoint;

            if (jingLingInfo.IsActive == 1)
            {
                bool current = chengJiuComponent.GetFightJingLing() == self.JingLingId;
                self.E_UnactivateText.gameObject.SetActive(false);
                self.E_ActivateButton.gameObject.SetActive(false);
                self.E_UseButton.gameObject.SetActive(!current);
                self.E_ShouHuiButton.gameObject.SetActive(current);
            }
            else
            {
                if (jingLingInfo.Progess >= jingLingConfig.NeedPoint)
                {
                    self.E_UnactivateText.gameObject.SetActive(false);
                    self.E_ActivateButton.gameObject.SetActive(true);
                }
                else
                {
                    self.E_UnactivateText.gameObject.SetActive(true);
                    self.E_ActivateButton.gameObject.SetActive(false);
                }

                self.E_UseButton.gameObject.SetActive(false);
                self.E_ShouHuiButton.gameObject.SetActive(false);
            }
        }
    }
}