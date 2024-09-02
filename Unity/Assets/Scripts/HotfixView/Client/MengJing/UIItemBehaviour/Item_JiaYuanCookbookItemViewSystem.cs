using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_JiaYuanCookbookItem))]
    [EntitySystemOf(typeof(Scroll_Item_JiaYuanCookbookItem))]
    public static partial class Scroll_Item_JiaYuanCookbookItemSystem
    {
        [EntitySystem]
        private static void Awake(this Scroll_Item_JiaYuanCookbookItem self)
        {
        }

        [EntitySystem]
        private static void Destroy(this Scroll_Item_JiaYuanCookbookItem self)
        {
            self.DestroyWidget();
        }

        public static void OnImage_Lock(this Scroll_Item_JiaYuanCookbookItem self)
        {
            if (self.MakeItemId == 0)
            {
                return;
            }

            UserInfoComponentC userInfoComponent = self.Root().GetComponent<UserInfoComponentC>();
            ItemConfig itemCof = ItemConfigCategory.Instance.Get(self.MakeItemId);
            long needcost = ET.JiaYuanHelper.GetCookBookCost(itemCof.UseLv);

            JiaYuanComponentC jiaYuanComponentC = self.Root().GetComponent<JiaYuanComponentC>();
            if (jiaYuanComponentC.LearnMakeIds_7.Contains(self.MakeItemId))
            {
                FlyTipComponent.Instance.ShowFlyTip("已经学习过该食谱！");
                return;
            }

            if (userInfoComponent.UserInfo.JiaYuanFund < needcost)
            {
                FlyTipComponent.Instance.ShowFlyTip("家园资金不足！");
                return;
            }

            using (zstring.Block())
            {
                PopupTipHelp.OpenPopupTip(self.Root(), "学习食谱", zstring.Format("是否消耗{0}家园资金学习该食谱?", needcost),
                    () => { self.RequestLearn(self.MakeItemId).Coroutine(); }, null).Coroutine();
            }
        }

        public static async ETTask RequestLearn(this Scroll_Item_JiaYuanCookbookItem self, int itemid)
        {
            M2C_JiaYuanCookBookOpen response = await JiaYuanNetHelper.JiaYuanCookBookOpen(self.Root(), itemid);
            if (response.Error != ErrorCode.ERR_Success || self.IsDisposed)
            {
                return;
            }

            JiaYuanComponentC jiaYuanComponentC = self.Root().GetComponent<JiaYuanComponentC>();
            jiaYuanComponentC.LearnMakeIds_7 = response.LearnMakeIds;
            self.OnUpdateUI(self.MakeItemId, true);
        }

        public static void OnUpdateUI(this Scroll_Item_JiaYuanCookbookItem self, int itmeid, bool active)
        {
            self.EG_MakeItemRectTransform.gameObject.SetActive(false);
            self.EG_MakeItemRectTransform.SetParent(self.uiTransform);

            self.MakeItemId = itmeid;
            self.ES_CommonItem.UpdateItem(new() { ItemID = itmeid, ItemNum = 1 }, ItemOperateEnum.None);
            self.ES_CommonItem.E_ItemNumText.gameObject.SetActive(false);
            self.ES_CommonItem.E_ItemNameText.gameObject.SetActive(true);
            CommonViewHelper.SetImageGray(self.Root(), self.ES_CommonItem.E_LockButton.gameObject, !active);
            int makeid = EquipMakeConfigCategory.Instance.GetMakeId(itmeid);

            EquipMakeConfig equipMakeConfig = EquipMakeConfigCategory.Instance.Get(makeid);
            string[] iteminfos = equipMakeConfig.NeedItems.Split('@');

            CommonViewHelper.DestoryChild(self.EG_MakeItemListRectTransform.gameObject);
            for (int i = 0; i < iteminfos.Length; i++)
            {
                ES_CommonItem uIItemComponent = null;
                int needitmeid = int.Parse(iteminfos[i].Split(';')[0]);

                GameObject go = UnityEngine.Object.Instantiate(self.EG_MakeItemRectTransform.gameObject);
                CommonViewHelper.SetParent(go, self.EG_MakeItemListRectTransform.gameObject);
                uIItemComponent = self.AddChild<ES_CommonItem, Transform>(go.transform);
                uIItemComponent.E_LockButton.AddListener(self.OnImage_Lock);

                go.SetActive(true);

                ItemInfo bagInfoNew = new ItemInfo();
                bagInfoNew.ItemID = needitmeid;
                bagInfoNew.ItemNum = 1;
                ItemInfo bagInfo = active ? bagInfoNew : null;
                uIItemComponent.UpdateItem(bagInfo, ItemOperateEnum.None);
                uIItemComponent.E_ItemQualityImage.gameObject.SetActive(true);
                if (active)
                {
                    uIItemComponent.E_LockButton.gameObject.SetActive(false);
                }
                else
                {
                    uIItemComponent.E_LockButton.gameObject.SetActive(true);
                }
            }
        }
    }
}