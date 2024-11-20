using System;
using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(ES_EquipTips))]
    [FriendOf(typeof(ES_ItemAppraisalTips))]
    [FriendOf(typeof(DlgEquipDuiBiTips))]
    public static class DlgEquipDuiBiTipsSystem
    {
        public static void RegisterUIEvent(this DlgEquipDuiBiTips self)
        {
            self.View.E_CloseButton.AddListener(self.OnCloseButton);
        }

        public static void ShowWindow(this DlgEquipDuiBiTips self, Entity contextData = null)
        {
        }

        private static void OnCloseButton(this DlgEquipDuiBiTips self)
        {
            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_EquipDuiBiTips);
        }

        public static void OnUpdateEquipUI(this DlgEquipDuiBiTips self, ShowItemTips args)
        {
            self.View.ES_EquipTips_1.uiTransform.gameObject.SetActive(true);
            self.View.ES_EquipTips_1.RefreshInfo(args.BagInfo, args.ItemOperateEnum, args.CurrentHouse, 0, args.EquipList);
        }

        public static void OnUpdateAppraisalUI(this DlgEquipDuiBiTips self, ShowItemTips args)
        {
            self.View.ES_ItemAppraisalTips_1.uiTransform.gameObject.SetActive(true);
            self.View.ES_ItemAppraisalTips_1.RefreshInfo(args.BagInfo, args.ItemOperateEnum, args.CurrentHouse);
        }

        public static void OnUpdateDuiBiUI(this DlgEquipDuiBiTips self, ItemInfo bagInfo_1, ShowItemTips args, int weight,
        ItemOperateEnum itemOperateEnum)
        {
            float height_1 = 0;
            float height_2 = 0;
            ItemInfo bagInfo_2 = args.BagInfo;

            height_1 = self.View.ES_EquipTips_1.E_BackImage.GetComponent<RectTransform>().sizeDelta.y;
            self.View.ES_EquipTips_1.RefreshInfo(bagInfo_1, ItemOperateEnum.None, args.CurrentHouse, 0, args.EquipList);
            self.View.ES_EquipTips_1.uiTransform.gameObject.SetActive(true);
            float exceedWidth = self.View.ES_EquipTips_1.ExceedWidth;
            if (bagInfo_2.IfJianDing == false)
            {
                height_2 = self.View.ES_EquipTips_2.E_BackImage.GetComponent<RectTransform>().sizeDelta.y;
                self.View.ES_EquipTips_2.RefreshInfo(bagInfo_2, itemOperateEnum, args.CurrentHouse, 0, args.EquipList);
                self.View.ES_EquipTips_2.uiTransform.gameObject.SetActive(true);
                exceedWidth = Math.Max(exceedWidth,self.View.ES_EquipTips_2.ExceedWidth );
            }
            else
            {
                height_2 = self.View.ES_ItemAppraisalTips_2.E_BackImage.GetComponent<RectTransform>().sizeDelta.y;
                self.View.ES_ItemAppraisalTips_2.RefreshInfo(bagInfo_2, itemOperateEnum, args.CurrentHouse);
                self.View.ES_ItemAppraisalTips_2.uiTransform.gameObject.SetActive(true);
                exceedWidth = Math.Max(exceedWidth, self.View.ES_ItemAppraisalTips_2.ExceedWidth );
            }
            
            Vector2 vectorPoint;
            GlobalComponent globalComponent = self.Root().GetComponent<GlobalComponent>();
            RectTransform canvas = globalComponent.NormalRoot.GetComponent<RectTransform>();
            Camera uiCamera = globalComponent.UICamera.GetComponent<Camera>();
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas, new Vector2(x: args.InputPoint.x, y: args.InputPoint.y), uiCamera,
                out vectorPoint);

            if (vectorPoint.x <= 0)
            {
                if (height_1 > height_2)
                {
                    vectorPoint.x += (int)(weight * 0.5);
                    vectorPoint.y = 0f;
                    vectorPoint.x -= 50;
                    self.View.EG_Tips1RectTransform.GetComponent<RectTransform>().anchoredPosition = vectorPoint;

                    vectorPoint.x += 50 + weight;
                    vectorPoint.y = (height_1 - height_2) * 0.5f;
                    self.View.EG_Tips2RectTransform.GetComponent<RectTransform>().anchoredPosition = vectorPoint;
                }
                else
                {
                    vectorPoint.x += (int)(weight * 0.5);
                    vectorPoint.y = (height_2 - height_1) * 0.5f;
                    vectorPoint.x -= 50;
                    self.View.EG_Tips1RectTransform.GetComponent<RectTransform>().anchoredPosition = vectorPoint;

                    vectorPoint.x += weight;
                    vectorPoint.y = 0f;
                    self.View.EG_Tips2RectTransform.GetComponent<RectTransform>().anchoredPosition = vectorPoint;
                }
            }
            else
            {
                if (height_1 > height_2)
                {
                    vectorPoint.x -= (int)(weight * 0.5);
                    vectorPoint.y = (height_1 - height_2) * 0.5f;
                    self.View.EG_Tips2RectTransform.GetComponent<RectTransform>().anchoredPosition = vectorPoint;

                    vectorPoint.x -= (20 + weight);
                    vectorPoint.y = 0f;
                    vectorPoint.x -= 30;
                    self.View.EG_Tips1RectTransform.GetComponent<RectTransform>().anchoredPosition = vectorPoint;
                }
                else
                {
                    vectorPoint.x -= (int)(weight * 0.5);
                    vectorPoint.y = 0f;
                    self.View.EG_Tips2RectTransform.GetComponent<RectTransform>().anchoredPosition = vectorPoint;

                    vectorPoint.x -= (20 + weight);
                    vectorPoint.y = (height_2 - height_1) * 0.5f;
                    vectorPoint.x -= 30;
                    self.View.EG_Tips1RectTransform.GetComponent<RectTransform>().anchoredPosition = vectorPoint;
                }
            }
        }
    }
}
