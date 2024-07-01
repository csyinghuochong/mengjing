using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof (UIShouJiTreasureItemComponent))]
    [EntitySystemOf(typeof (UIShouJiTreasureItemComponent))]
    public static partial class UIShouJiTreasureItemComponentSystem
    {
        [EntitySystem]
        private static void Awake(this UIShouJiTreasureItemComponent self, GameObject gameObject)
        {
            self.GameObject = gameObject;
            ReferenceCollector rc = gameObject.GetComponent<ReferenceCollector>();

            self.RedDot = rc.Get<GameObject>("RedDot");
            self.TextAttribute = rc.Get<GameObject>("TextAttribute");
            self.ButtonActive = rc.Get<GameObject>("ButtonActive");
            self.ImageActived = rc.Get<GameObject>("ImageActived");
            self.ES_CommonItem = rc.Get<GameObject>("ES_CommonItem");
            self.TextNumber = rc.Get<GameObject>("TextNumber");

            self.UIItemComponent = self.AddChild<ES_CommonItem, Transform>(self.ES_CommonItem.transform);
            self.ButtonActive.GetComponent<Button>().onClick.AddListener(() => { self.OnButtonActive().Coroutine(); });

            self.RedDot.SetActive(false);
        }

        public static async ETTask OnButtonActive(this UIShouJiTreasureItemComponent self)
        {
            await self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_ShouJiSelect);
            DlgShouJiSelect dlgShouJiSelect = self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgShouJiSelect>();
            dlgShouJiSelect.OnInitUI(self.ShoujiId, self.UpdateRedDotState);
        }

        /// <summary>
        /// 更新红点状态
        /// </summary>
        /// <param name="self"></param>
        public static void UpdateRedDotState(this UIShouJiTreasureItemComponent self)
        {
            ShouJiItemConfig shouJiItemConfig = ShouJiItemConfigCategory.Instance.Get(self.ShoujiId);
            KeyValuePairInt keyValuePairInt = self.Root().GetComponent<ShoujiComponentC>().GetTreasureInfo(self.ShoujiId);
            int haveNumber = keyValuePairInt != null? (int)keyValuePairInt.Value : 0;
            self.TextNumber.GetComponent<Text>().text = $"激活:{haveNumber}/{shouJiItemConfig.AcitveNum}";
            bool actived = haveNumber >= shouJiItemConfig.AcitveNum;

            // 显示红点
            BagComponentC bagComponent = self.Root().GetComponent<BagComponentC>();
            self.RedDot.SetActive(bagComponent.GetItemNumber(shouJiItemConfig.ItemID) > 0 && !actived);

            self.GetParent<ES_ShouJiTreasure>().UpdateRedDot();
        }

        public static void OnInitUI(this UIShouJiTreasureItemComponent self, int shouijId)
        {
            self.ShoujiId = shouijId;
            ShouJiItemConfig shouJiItemConfig = ShouJiItemConfigCategory.Instance.Get(shouijId);

            self.UIItemComponent.UpdateItem(new BagInfo() { ItemID = shouJiItemConfig.ItemID }, ItemOperateEnum.None);
            self.UIItemComponent.E_ItemNumText.gameObject.SetActive(false);

            string attributeStr = string.Empty;

            string[] attributeInfoList = shouJiItemConfig.AddPropreListStr.Split('@');
            for (int i = 0; i < attributeInfoList.Length; i++)
            {
                string[] attributeInfo = attributeInfoList[i].Split(',');
                int numericType = int.Parse(attributeInfo[0]);

                if (NumericHelp.GetNumericValueType(numericType) == 2)
                {
                    float fvalue = float.Parse(attributeInfo[1]);
                    string svalue = fvalue.ToString("0.#####");
                    attributeStr = attributeStr + $"{ItemViewHelp.GetAttributeName(numericType)} {svalue}% ";
                }
                else
                {
                    attributeStr = attributeStr + $"提升{ItemViewHelp.GetAttributeName(numericType)}{int.Parse(attributeInfo[1])}点";
                }

                if (i < attributeInfoList.Length - 1)
                {
                    attributeStr += "\n";
                }
            }

            self.TextAttribute.GetComponent<Text>().text = attributeStr;

            KeyValuePairInt keyValuePairInt = self.Root().GetComponent<ShoujiComponentC>().GetTreasureInfo(shouijId);
            int haveNumber = keyValuePairInt != null? (int)keyValuePairInt.Value : 0;
            self.TextNumber.GetComponent<Text>().text = $"激活:{haveNumber}/{shouJiItemConfig.AcitveNum}";

            CommonViewHelper.SetImageGray(self.Root(), self.UIItemComponent.E_ItemIconImage.gameObject, haveNumber == 0);
            CommonViewHelper.SetImageGray(self.Root(), self.UIItemComponent.E_ItemQualityImage.gameObject, haveNumber == 0);

            bool actived = haveNumber >= shouJiItemConfig.AcitveNum;

            // 显示红点
            BagComponentC bagComponent = self.Root().GetComponent<BagComponentC>();
            self.RedDot.SetActive(bagComponent.GetItemNumber(shouJiItemConfig.ItemID) > 0 && !actived);

            self.ButtonActive.SetActive(!actived);
            self.ImageActived.SetActive(actived);
        }
    }
}