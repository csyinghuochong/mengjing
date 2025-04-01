using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof(ES_CommonItem))]
    [FriendOf(typeof(ES_ModelShow))]
    [FriendOf(typeof(Scroll_Item_FashionShowItem))]
    [EntitySystemOf(typeof(Scroll_Item_FashionShowItem))]
    public static partial class Scroll_Item_FashionShowItemSystem
    {
        [EntitySystem]
        private static void Awake(this Scroll_Item_FashionShowItem self)
        {
        }

        [EntitySystem]
        private static void Destroy(this Scroll_Item_FashionShowItem self)
        {
            self.DestroyWidget();
        }

        public static void OnImageDi(this Scroll_Item_FashionShowItem self)
        {
            if (self.Status == 0)
            {
                self.PreviewHandler(self.FashionId);
            }
        }

        public static async ETTask OnBtn_Desc(this Scroll_Item_FashionShowItem self)
        {
            await self.Root().GetComponent<UIComponent>().ShowWindowAsync(WindowID.WindowID_FashionExplain);
            self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgFashionExplain>().OnInitData(self.FashionId);
        }

        public static async ETTask OnBtn_Active(this Scroll_Item_FashionShowItem self)
        {
            long instanceid = self.InstanceId;
            FashionConfig fashionConfig = FashionConfigCategory.Instance.Get(self.FashionId);
            BagComponentC bagComponent = self.Root().GetComponent<BagComponentC>();
            switch (self.Status)
            {
                case 0:
                {
                    if (!bagComponent.CheckNeedItem(fashionConfig.ActiveCost))
                    {
                        FlyTipComponent.Instance.ShowFlyTip("道具不足");
                        return;
                    }

                    M2C_FashionActiveResponse response = await BagClientNetHelper.FashionActive(self.Root(), self.FashionId);
                    if (instanceid != self.InstanceId)
                    {
                        return;
                    }

                    if (response.Error == ErrorCode.ERR_Success && !bagComponent.FashionActiveIds.Contains(self.FashionId))
                    {
                        bagComponent.FashionActiveIds.Add(self.FashionId);
                    }

                    self.OnUpdateUI(self.FashionId);
                    break;
                }
                case 1:
                case 2:
                {
                    M2C_FashionWearResponse response = await BagClientNetHelper.FashionWear(self.Root(), self.FashionId, self.Status);
                    if (instanceid != self.InstanceId)
                    {
                        return;
                    }

                    self.FashionWearHandler?.Invoke();
                    break;
                }
            }
        }

        public static void OnUpdateUI(this Scroll_Item_FashionShowItem self, int fashionid)
        {
            self.E_ImageDiButton.AddListener(self.OnImageDi);
            self.E_Btn_ActiveButton.AddListenerAsync(self.OnBtn_Active);
            self.E_Btn_DescButton.AddListenerAsync(self.OnBtn_Desc);
            self.FashionId = fashionid;
            BagComponentC bagComponent = self.Root().GetComponent<BagComponentC>();

            int status = 0; //0 未激活  1没穿戴 2 已穿戴
            if (bagComponent.FashionActiveIds.Contains(fashionid))
            {
                status = bagComponent.FashionEquipList.Contains(fashionid) ? 2 : 1;
            }

            self.Status = status;

            switch (self.Status)
            {
                case 0:
                    self.E_EquipingedImage.gameObject.SetActive(false);
                    self.E_Btn_ActiveButton.gameObject.SetActive(true);
                    self.E_Btn_ActiveButton.transform.Find("Text").GetComponent<Text>().text = "激活";
                    CommonViewHelper.SetRawImageGray(self.Root(), self.ES_ModelShow.E_RenderRawImage.gameObject, true);
                    break;
                case 1:
                    self.E_EquipingedImage.gameObject.SetActive(false);
                    self.E_Btn_ActiveButton.gameObject.SetActive(true);
                    self.E_Btn_ActiveButton.transform.Find("Text").GetComponent<Text>().text = "穿戴";
                    CommonViewHelper.SetRawImageGray(self.Root(), self.ES_ModelShow.E_RenderRawImage.gameObject, false);
                    break;
                case 2:
                    self.E_EquipingedImage.gameObject.SetActive(true);
                    self.E_Btn_ActiveButton.gameObject.SetActive(false);
                    CommonViewHelper.SetRawImageGray(self.Root(), self.ES_ModelShow.E_RenderRawImage.gameObject, false);
                    break;
            }

            FashionConfig fashionConfig = FashionConfigCategory.Instance.Get(fashionid);
            self.E_Text_111Text.text = fashionConfig.Name;
            if (fashionConfig.ActiveCost == "0;0" || fashionConfig.ActiveCost == "0")
            {
                self.E_Text_222Text.gameObject.SetActive(false);
                self.ES_CommonItem.uiTransform.gameObject.SetActive(false);
            }
            else
            {
                string[] costitem = fashionConfig.ActiveCost.Split(';');
                using (zstring.Block())
                {
                    self.E_Text_222Text.text = zstring.Format("需要:{0}个", int.Parse(costitem[1]));
                }

                int havenumber = (int)bagComponent.GetItemNumber(int.Parse(costitem[0]));
                ItemInfo bagInfo = new ItemInfo();
                bagInfo.ItemID = int.Parse(costitem[0]);
                bagInfo.ItemNum = havenumber;
                self.ES_CommonItem.UpdateItem(bagInfo, ItemOperateEnum.None);
                self.ES_CommonItem.E_ItemNameText.gameObject.SetActive(true);
                self.ES_CommonItem.E_ItemNumText.gameObject.SetActive(false);
            }

            // self.E_Btn_DescButton.gameObject.SetActive(!string.IsNullOrEmpty(fashionConfig.PropertyDes));

            bool isbasefashion = false;
            int occ = self.Root().GetComponent<UserInfoComponentC>().UserInfo.Occ;
            OccupationConfig occupationConfig = OccupationConfigCategory.Instance.Get(occ);
            for (int i = 0; i < occupationConfig.FashionBase.Length; i++)
            {
                if (occupationConfig.FashionBase[i] == fashionid)
                {
                    isbasefashion = true;
                    break;
                }
            }

            List<string> assetList = FashionConfigCategory.Instance.GetModelList(fashionid);
            using (zstring.Block())
            {
                string initPath = isbasefashion ? zstring.Format("Parts/{0}/", occ) : "Parts/Fashion/";
                self.ES_ModelShow.ShowModelList(initPath, assetList).Coroutine();
            }

            self.ES_ModelShow.SetCameraPosition(new Vector3((float)fashionConfig.Camera[0], (float)fashionConfig.Camera[1], (float)fashionConfig.Camera[2]));
            self.ES_ModelShow.Camera.fieldOfView = (float)fashionConfig.Camera[3];
            // self.ES_ModelShow.SetRootPosition(new Vector2(self.Position * 1000, -20000));
            self.ES_ModelShow.ModelParent.localRotation = Quaternion.Euler(0f, -45f, 0f);
            self.ES_ModelShow.Camera.cullingMask = 1 << 0;
            self.ES_ModelShow.Camera.cullingMask = 1 << 11;
        }
    }
}