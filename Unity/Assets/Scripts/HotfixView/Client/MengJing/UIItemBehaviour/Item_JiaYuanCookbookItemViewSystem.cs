using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof (Scroll_Item_JiaYuanCookbookItem))]
    [EntitySystemOf(typeof (Scroll_Item_JiaYuanCookbookItem))]
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

            JiaYuanComponent jiaYuanComponent = self.Root().GetComponent<JiaYuanComponent>();
            if (jiaYuanComponent.LearnMakeIds_7.Contains(self.MakeItemId))
            {
                FlyTipComponent.Instance.ShowFlyTipDi("已经学习过该食谱！");
                return;
            }

            if (userInfoComponent.UserInfo.JiaYuanFund < needcost)
            {
                FlyTipComponent.Instance.ShowFlyTipDi("家园资金不足！");
                return;
            }

            PopupTipHelp.OpenPopupTip(self.Root(), "学习食谱", $"是否消耗{needcost}家园资金学习该食谱?",
                () => { self.RequestLearn(self.MakeItemId).Coroutine(); }, null).Coroutine();
        }

        public static async ETTask RequestLearn(this Scroll_Item_JiaYuanCookbookItem self, int itemid)
        {
            M2C_JiaYuanCookBookOpen response = await JiaYuanNetHelper.JiaYuanCookBookOpen(self.Root(), itemid);
            if (response.Error != ErrorCode.ERR_Success || self.IsDisposed)
            {
                return;
            }

            JiaYuanComponent jiaYuanComponent = self.Root().GetComponent<JiaYuanComponent>();
            jiaYuanComponent.LearnMakeIds_7 = response.LearnMakeIds;
            self.OnUpdateUI(self.MakeItemId, true);
        }

        public static void OnUpdateUI(this Scroll_Item_JiaYuanCookbookItem self, int itmeid, bool active)
        {
            self.MakeItemId = itmeid;
            self.ES_CommonItem.UpdateItem(new() { ItemID = itmeid, ItemNum = 1 }, ItemOperateEnum.None);
            self.ES_CommonItem.E_ItemNumText.gameObject.SetActive(false);
            CommonViewHelper.SetImageGray(self.Root(), self.ES_CommonItem.E_LockButton.gameObject, !active);
            int makeid = EquipMakeConfigCategory.Instance.GetMakeId(itmeid);

            EquipMakeConfig equipMakeConfig = EquipMakeConfigCategory.Instance.Get(makeid);
            string[] iteminfos = equipMakeConfig.NeedItems.Split('@');

            for (int i = 0; i < iteminfos.Length; i++)
            {
                UIItemComponent uIItemComponent = null;
                int needitmeid = int.Parse(iteminfos[i].Split(';')[0]);
                if (i < self.NeedItemList.Count)
                {
                    uIItemComponent = self.NeedItemList[i];
                    uIItemComponent.GameObject.SetActive(true);
                }
                else
                {
                    GameObject go = GameObject.Instantiate(self.MakeItem);
                    UICommonHelper.SetParent(go, self.MakeItemList);
                    uIItemComponent = self.AddChild<UIItemComponent, GameObject>(go);
                    uIItemComponent.Image_Lock.GetComponent<Button>().onClick.AddListener(self.OnImage_Lock);
                    self.NeedItemList.Add(uIItemComponent);
                    go.SetActive(true);
                }

                BagInfo bagInfo = active? new BagInfo() { ItemID = needitmeid, ItemNum = 1 } : null;
                uIItemComponent.UpdateItem(bagInfo, ItemOperateEnum.None);
                uIItemComponent.Image_ItemQuality.SetActive(true);
                if (active)
                {
                    uIItemComponent.Image_Lock.SetActive(false);
                }
                else
                {
                    uIItemComponent.Image_Lock.SetActive(true);
                }
            }
        }
    }
}