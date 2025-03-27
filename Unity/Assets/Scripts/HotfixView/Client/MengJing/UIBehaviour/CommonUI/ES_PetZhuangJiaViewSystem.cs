using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof(ES_PetZhuangJiaItem))]
    [EntitySystemOf(typeof(ES_PetZhuangJia))]
    [FriendOfAttribute(typeof(ES_PetZhuangJia))]
    public static partial class ES_PetZhuangJiaSystem
    {
        [EntitySystem]
        private static void Awake(this ES_PetZhuangJia self, Transform transform)
        {
            self.uiTransform = transform;

            self.E_UpButton.AddListener(() => { self.OnUp().Coroutine(); });

            self.ES_PetZhuangJiaItem_1.Position = 0;
            self.ES_PetZhuangJiaItem_1.ClickHandler = self.OnClickHandler;
            self.UIPetZhuangJiaItemList.Add(self.ES_PetZhuangJiaItem_1);

            self.ES_PetZhuangJiaItem_2.Position = 1;
            self.ES_PetZhuangJiaItem_2.ClickHandler = self.OnClickHandler;
            self.UIPetZhuangJiaItemList.Add(self.ES_PetZhuangJiaItem_2);

            self.ES_PetZhuangJiaItem_3.Position = 2;
            self.ES_PetZhuangJiaItem_3.ClickHandler = self.OnClickHandler;
            self.UIPetZhuangJiaItemList.Add(self.ES_PetZhuangJiaItem_3);

            self.ES_PetZhuangJiaItem_4.Position = 3;
            self.ES_PetZhuangJiaItem_4.ClickHandler = self.OnClickHandler;
            self.UIPetZhuangJiaItemList.Add(self.ES_PetZhuangJiaItem_4);

            self.ES_PetZhuangJiaItem_5.Position = 4;
            self.ES_PetZhuangJiaItem_5.ClickHandler = self.OnClickHandler;
            self.UIPetZhuangJiaItemList.Add(self.ES_PetZhuangJiaItem_5);

            self.E_ProText.gameObject.SetActive(false);

            ES_PetZhuangJiaItem esPetZhuangJiaItem = self.UIPetZhuangJiaItemList[0];
            esPetZhuangJiaItem.ClickHandler?.Invoke(0);
        }

        [EntitySystem]
        private static void Destroy(this ES_PetZhuangJia self)
        {
            self.DestroyWidget();
        }

        private static void OnClickHandler(this ES_PetZhuangJia self, int position)
        {
            self.Position = position;
            for (int i = 0; i < self.UIPetZhuangJiaItemList.Count; i++)
            {
                ES_PetZhuangJiaItem esPetZhuangJiaItem = self.UIPetZhuangJiaItemList[i];
                esPetZhuangJiaItem.E_ImageSelectImage.gameObject.SetActive(position == i);
            }

            ES_PetZhuangJiaItem item = self.UIPetZhuangJiaItemList[position];
            self.E_IconImage.sprite = item.E_ImageIconImage.sprite;

            self.OnUpdateUI();
        }

        private static async ETTask OnUp(this ES_PetZhuangJia self)
        {
            PetComponentC petComponent = self.Root().GetComponent<PetComponentC>();
            if (self.Position < 0 || self.Position >= petComponent.PetZhuangJiaList.Count)
            {
                return;
            }

            int id = petComponent.PetZhuangJiaList[self.Position];
            PetZhuangJiaConfig petZhuangJiaConfig = PetZhuangJiaConfigCategory.Instance.Get(id);
            if (petZhuangJiaConfig.NextID == 0)
            {
                FlyTipComponent.Instance.ShowFlyTip("已经达到最大等级");
                return;
            }

            BagComponentC bagComponent = self.Root().GetComponent<BagComponentC>();
            if (!bagComponent.CheckNeedItem(petZhuangJiaConfig.CostItem))
            {
                FlyTipComponent.Instance.ShowFlyTip("道具不足!");
                return;
            }

            await PetNetHelper.PetZhuangJiaUpRequest(self.Root(), self.Position);
            
            self.OnUpdateUI();
        }

        private static void OnUpdateUI(this ES_PetZhuangJia self)
        {
            for (int i = 0; i < self.UIPetZhuangJiaItemList.Count; i++)
            {
                ES_PetZhuangJiaItem esPetZhuangJiaItem = self.UIPetZhuangJiaItemList[i];
                esPetZhuangJiaItem.OnUpdateUI(i);
            }

            PetComponentC petComponentC = self.Root().GetComponent<PetComponentC>();

            int id = petComponentC.PetZhuangJiaList[self.Position];
            PetZhuangJiaConfig petZhuangJiaConfig = PetZhuangJiaConfigCategory.Instance.Get(id);
            self.E_NameText.text = petZhuangJiaConfig.Name;
            using (zstring.Block())
            {
                self.E_NowLvText.text = zstring.Format("当前等级：{0}", petZhuangJiaConfig.Lv);
            }

            CommonViewHelper.DestoryChild(self.EG_ProListRectTransform.gameObject);
            if (!CommonHelp.IfNull(petZhuangJiaConfig.PropreAdd))
            {
                string[] attributeInfoList = petZhuangJiaConfig.PropreAdd.Split('@');
                for (int i = 0; i < attributeInfoList.Length; i++)
                {
                    string attributeStr = string.Empty;
                    string[] attributeInfo = attributeInfoList[i].Split(';');
                    int numericType = int.Parse(attributeInfo[0]);

                    if (NumericHelp.GetNumericValueType(numericType) == 2)
                    {
                        float fvalue = float.Parse(attributeInfo[1]) * 100;
                        string svalue = fvalue.ToString("0.#####");
                        attributeStr = $"{ItemViewHelp.GetAttributeName(numericType)}提升{svalue}% ";
                    }
                    else
                    {
                        attributeStr = $"{ItemViewHelp.GetAttributeName(numericType)}提升{int.Parse(attributeInfo[1])}点";
                    }

                    GameObject go = UnityEngine.Object.Instantiate(self.E_ProText.gameObject, self.EG_ProListRectTransform);
                    go.SetActive(true);
                    go.GetComponent<Text>().text = attributeStr;
                }
            }

            self.ES_CostList.Refresh(petZhuangJiaConfig.CostItem);
        }
    }
}