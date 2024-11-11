using System.Linq;
using UnityEngine;
using UnityEngine.UI;

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
            self.E_ActivateButton.AddListenerAsync(self.OnButtonActivite);

            self.E_ItemTypeSetToggleGroup.OnSelectIndex(0);
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

            self.OnUpdateUI(self.ShowJingLing[0].Id);
        }

        private static async ETTask OnButtonActivite(this ES_ChengJiuJingling self)
        {
            int error = await JingLingNetHelper.RequestJingLingUse(self.Root(), self.JingLingId, 1);
            if (error != 0)
            {
                return;
            }

            self.OnUpdateUI(self.JingLingId);

            EventSystem.Instance.Publish(self.Root(), new JingLingButton());
        }

        public static void OnUpdateUI(this ES_ChengJiuJingling self, int jingLingId)
        {
            self.JingLingId = jingLingId;

            foreach (Scroll_Item_ChengJiuJinglingItem item in self.ScrollItemChengJiuJinglingItems.Values)
            {
                if (item.uiTransform == null)
                {
                    return;
                }

                item.E_SelectedImage.gameObject.SetActive(self.JingLingId == item.JingLingId);
            }

            JingLingConfig jingLingConfig = JingLingConfigCategory.Instance.Get(self.JingLingId);

            GameObject gameObject = self.ES_ModelShow.EG_RootRectTransform.gameObject;
            self.ES_ModelShow.ShowOtherModel("JingLing/" + jingLingConfig.Assets).Coroutine();
            gameObject.transform.Find("Camera").localPosition = new Vector3(0f, 40f, 200f);
            gameObject.transform.localPosition = new Vector2(jingLingConfig.Id % 10 * 1000, 0);
            gameObject.transform.Find("ModelParent").localRotation = Quaternion.Euler(0f, -45f, 0f);

            self.E_NameText.text = jingLingConfig.Name;

            CommonViewHelper.DestoryChild(self.EG_AttributeListNodeRectTransform.gameObject);
            self.ShowAttributeItemList(jingLingConfig.AddProperty, self.EG_AttributeListNodeRectTransform.gameObject,
                self.EG_TextAttributeItemRectTransform.gameObject);

            if (jingLingConfig.GetWay == 1)
            {
                self.E_GetWayText.text = "使用道具";
                self.E_ProbabilityText.gameObject.SetActive(false);
            }
            else
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

            using (zstring.Block())
            {
                self.E_ProgressTxtText.text = zstring.Format("{0}/{1}", jingLingInfo.Progess, jingLingConfig.NeedPoint);
            }

            self.E_ProgressImgImage.fillAmount = jingLingInfo.Progess * 1f / jingLingConfig.NeedPoint;

            bool active = jingLingInfo.Progess >= jingLingConfig.NeedPoint;

            self.E_ActivateButton.gameObject.SetActive(active);
            self.E_UnactivateText.gameObject.SetActive(!active);
        }

        private static void ShowAttributeItemList(this ES_ChengJiuJingling self, string itemList, GameObject itemNodeList, GameObject attributeItem)
        {
            string[] attributeinfos = itemList.Split('@');
            for (int i = 0; i < attributeinfos.Length; i++)
            {
                if (string.IsNullOrEmpty(attributeinfos[i]))
                {
                    continue;
                }

                string[] attributeInfo = attributeinfos[i].Split(';');
                int numberType = int.Parse(attributeInfo[0]);
                float numberValue = float.Parse(attributeInfo[1]);
                GameObject gameObject = UnityEngine.Object.Instantiate(attributeItem);
                gameObject.SetActive(true);
                CommonViewHelper.SetParent(gameObject, itemNodeList);

                int showType = NumericHelp.GetNumericValueType(numberType);
                string attribute;
                if (showType == 2)
                {
                    using (zstring.Block())
                    {
                        attribute = zstring.Format("{0}+{1}%", ItemViewHelp.GetAttributeName(numberType), numberValue * 100);
                    }
                }
                else
                {
                    using (zstring.Block())
                    {
                        attribute = zstring.Format("{0}+{1}", ItemViewHelp.GetAttributeName(numberType), numberValue);
                    }
                }

                gameObject.transform.GetComponent<Text>().text = attribute;
            }
        }
    }
}