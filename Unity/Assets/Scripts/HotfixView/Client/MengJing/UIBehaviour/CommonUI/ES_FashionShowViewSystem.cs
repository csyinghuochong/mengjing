using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [EntitySystemOf(typeof (ES_FashionShow))]
    [FriendOfAttribute(typeof (ES_FashionShow))]
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
                GameObject Button_key = rc.Get<GameObject>($"Button_{keyid}");
                Button_key.GetComponent<Button>().AddListener(() => { self.OnClickSubButton(keyid); });
                self.ButtonList.Add(keyid, Button_key);
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
            self.ES_ModelShow.SetRootPosition(new Vector2(2000, 20000));
            //配置摄像机位置[0,115,257]
            self.ES_ModelShow.Camera.localPosition = new Vector3(-20f, 80f, 250f);
            self.ES_ModelShow.Camera.GetComponent<Camera>().fieldOfView = 35;
            self.ES_ModelShow.Camera.GetComponent<Camera>().cullingMask = 1 << 0;
            self.ES_ModelShow.Camera.GetComponent<Camera>().cullingMask = 1 << 11;
        }

        private static void OnFashionShowItemsRefresh(this ES_FashionShow self, Transform transform, int index)
        {
            Scroll_Item_FashionShowItem scrollItemFashionShowItem = self.ScrollItemFashionShowItems[index].BindTrans(transform);
        }

        public static void OnFashionWear(this ES_FashionShow self)
        {
            int occ = self.ZoneScene().GetComponent<UserInfoComponent>().UserInfo.Occ;
            List<int> fashionids = self.ZoneScene().GetComponent<BagComponent>().FashionEquipList;

            ////////把拼装后的模型显示在RawImages
            BagInfo bagInfo = new BagInfo() { ItemID = UnitHelper.GetWuqiItemID(self.ZoneScene()) };
            self.UIModelShowComponent.ShowPlayerPreviewModel(bagInfo, fashionids, occ);

            for (int i = 0; i < self.FashionItemList.Count; i++)
            {
                self.FashionItemList[i].Position = i + 2;
                self.FashionItemList[i].OnUpdateUI(self.FashionItemList[i].FashionId);
            }
        }

        public static void OnFashionPreview(this ES_FashionShow self, int fashionid)
        {
            int occ = self.ZoneScene().GetComponent<UserInfoComponent>().UserInfo.Occ;
            List<int> equipids = self.ZoneScene().GetComponent<BagComponent>().FashionEquipList;

            List<int> fashionids = new List<int>() { };
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
            BagInfo bagInfo = new BagInfo() { ItemID = UnitHelper.GetWuqiItemID(self.ZoneScene()) };
            self.UIModelShowComponent.ShowPlayerPreviewModel(bagInfo, fashionids, occ);
        }

        public static void OnClickSubButton(this ES_FashionShow self, int subType)
        {
            UICommonHelper.SetParent(self.Image_Select, self.ButtonList[subType]);
            self.Image_Select.transform.SetAsFirstSibling();

            self.OnUpdateFashionList(subType);

            self.OnFashionWear();
        }

        public static void OnUpdateFashionList(this ES_FashionShow self, int subType)
        {
            int occ = self.ZoneScene().GetComponent<UserInfoComponent>().UserInfo.Occ;
            List<int> occfashionids = FashionConfigCategory.Instance.GetOccFashionList(occ, subType);

            for (int i = 0; i < occfashionids.Count; i++)
            {
                UIFashionShowItemComponent uiitem = null;
                if (i < self.FashionItemList.Count)
                {
                    uiitem = self.FashionItemList[i];
                    uiitem.GameObject.SetActive(true);
                }
                else
                {
                    GameObject go = GameObject.Instantiate(self.UIFashionShowItem);
                    go.SetActive(true);
                    UICommonHelper.SetParent(go, self.BuildingList);
                    uiitem = self.AddChild<UIFashionShowItemComponent, GameObject>(go);
                    self.FashionItemList.Add(uiitem);
                }

                self.FashionItemList[i].Position = i + 2;
                uiitem.OnUpdateUI(occfashionids[i]);
                uiitem.FashionWearHandler = self.OnFashionWear;
                uiitem.PreviewHandler = self.OnFashionPreview;
            }

            for (int i = occfashionids.Count; i < self.FashionItemList.Count; i++)
            {
                self.FashionItemList[i].GameObject.SetActive(false);
            }
        }
    }
}