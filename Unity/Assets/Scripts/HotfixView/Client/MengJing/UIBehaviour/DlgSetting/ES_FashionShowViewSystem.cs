using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_FashionShowItem))]
    [EntitySystemOf(typeof(ES_FashionShow))]
    [FriendOfAttribute(typeof(ES_FashionShow))]
    public static partial class ES_FashionShowSystem
    {
        [EntitySystem]
        private static void Awake(this ES_FashionShow self, Transform transform)
        {
            self.uiTransform = transform;
            self.E_FashionShowItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnFashionShowItemsRefresh);

            self.OnInitModelShow();
            ReferenceCollector rc = self.uiTransform.GetComponent<ReferenceCollector>();
            List<int> keys = new List<int> { 1001, 2001, 3001 };
            for (int i = 0; i < keys.Count; i++)
            {
                int keyid = keys[i];
                using (zstring.Block())
                {
                    GameObject Button_key = rc.Get<GameObject>(zstring.Format("Button_{0}", keyid));
                    Button_key.GetComponent<Button>().AddListener(() => { self.OnClickSubButton(keyid); });
                    self.ButtonList.Add(keyid, Button_key);
                }
            }

            self.OnClickSubButton(keys[0]);
        }

        [EntitySystem]
        private static void Destroy(this ES_FashionShow self)
        {
            self.DestroyWidget();
        }

        public static void OnInitModelShow(this ES_FashionShow self)
        {
            //模型展示界面
            // self.ES_ModelShow.SetRootPosition(new Vector2(2000, 20000));
            //配置摄像机位置[0,115,257]
            self.ES_ModelShow.SetCameraPosition(new Vector3(-20f, 80f, 250f));
            self.ES_ModelShow.Camera.fieldOfView = 35;
            self.ES_ModelShow.Camera.cullingMask = 1 << 0;
            self.ES_ModelShow.Camera.cullingMask = 1 << 11;
        }

        private static void OnFashionShowItemsRefresh(this ES_FashionShow self, Transform transform, int index)
        {
            foreach (Scroll_Item_FashionShowItem item in self.ScrollItemFashionShowItems.Values)
            {
                if (item.uiTransform == transform)
                {
                    item.uiTransform = null;
                }
            }
            
            Scroll_Item_FashionShowItem scrollItemFashionShowItem = self.ScrollItemFashionShowItems[index].BindTrans(transform);
            scrollItemFashionShowItem.Position = index + 2;
            scrollItemFashionShowItem.OnUpdateUI(self.ShowFashion[index]);
            scrollItemFashionShowItem.FashionWearHandler = self.OnFashionWear;
            scrollItemFashionShowItem.PreviewHandler = self.OnFashionPreview;
        }

        public static void OnFashionWear(this ES_FashionShow self)
        {
            int occ = self.Root().GetComponent<UserInfoComponentC>().UserInfo.Occ;
            List<int> fashionids = self.Root().GetComponent<BagComponentC>().FashionEquipList;

            ////////把拼装后的模型显示在RawImages
            ItemInfo bagInfo = new() { ItemID = UnitHelper.GetWuqiItemID(self.Root()) };
            self.ES_ModelShow.ShowPlayerPreviewModel(bagInfo, fashionids, occ);

            if (self.ScrollItemFashionShowItems != null)
            {
                for (int i = 0; i < self.ScrollItemFashionShowItems.Count; i++)
                {
                    Scroll_Item_FashionShowItem scrollItemFashionShowItem = self.ScrollItemFashionShowItems[i];
                    if (scrollItemFashionShowItem.uiTransform == null)
                    {
                        continue;
                    }

                    scrollItemFashionShowItem.Position = i + 2;
                    scrollItemFashionShowItem.OnUpdateUI(scrollItemFashionShowItem.FashionId);
                }
            }
        }

        public static void OnFashionPreview(this ES_FashionShow self, int fashionid)
        {
            int occ = self.Root().GetComponent<UserInfoComponentC>().UserInfo.Occ;
            List<int> equipids = self.Root().GetComponent<BagComponentC>().FashionEquipList;

            List<int> fashionids = new List<int>();
            fashionids.AddRange(equipids);

            bool have = false;
            FashionConfig fashionConfig = FashionConfigCategory.Instance.Get(fashionid);
            for (int i = 0; i < fashionids.Count; i++)
            {
                FashionConfig fashionConfig_2 = FashionConfigCategory.Instance.Get(fashionids[i]);
                if (fashionConfig_2.SubType == fashionConfig.SubType)
                {
                    have = true;
                    fashionids[i] = fashionid;
                    break;
                }
            }

            if (!have)
            {
                fashionids.Add(fashionid);
            }

            ////////把拼装后的模型显示在RawImages
            ItemInfo bagInfo = new() { ItemID = UnitHelper.GetWuqiItemID(self.Root()) };
            self.ES_ModelShow.ShowPlayerPreviewModel(bagInfo, fashionids, occ);
        }

        public static void OnClickSubButton(this ES_FashionShow self, int subType)
        {
            CommonViewHelper.SetParent(self.E_Image_SelectImage.gameObject, self.ButtonList[subType]);
            self.E_Image_SelectImage.transform.SetAsFirstSibling();

            self.OnUpdateFashionList(subType);

            self.OnFashionWear();
        }

        public static void OnUpdateFashionList(this ES_FashionShow self, int subType)
        {
            int occ = self.Root().GetComponent<UserInfoComponentC>().UserInfo.Occ;

            self.ShowFashion.Clear();
            self.ShowFashion.AddRange(FashionConfigCategory.Instance.GetOccFashionList(occ, subType));

            self.AddUIScrollItems(ref self.ScrollItemFashionShowItems, self.ShowFashion.Count);
            self.E_FashionShowItemsLoopVerticalScrollRect.SetVisible(true, self.ShowFashion.Count);
        }
    }
}
