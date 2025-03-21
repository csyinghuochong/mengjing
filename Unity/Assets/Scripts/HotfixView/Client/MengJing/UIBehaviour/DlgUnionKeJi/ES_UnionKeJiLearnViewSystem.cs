using System.Text.RegularExpressions;
using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_UnionKeJiLearnItem))]
    [EntitySystemOf(typeof(ES_UnionKeJiLearn))]
    [FriendOfAttribute(typeof(ES_UnionKeJiLearn))]
    public static partial class ES_UnionKeJiLearnSystem
    {
        [EntitySystem]
        private static void Awake(this ES_UnionKeJiLearn self, Transform transform)
        {
            self.uiTransform = transform;
            self.E_UnionKeJiLearnItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnUnionKeJiLearnItemsRefresh);
            self.E_StartBtnButton.AddListenerAsync(self.OnStartBtnButton);

            self.InitItemList().Coroutine();
        }

        [EntitySystem]
        private static void Destroy(this ES_UnionKeJiLearn self)
        {
            self.DestroyWidget();
        }

        private static void OnUnionKeJiLearnItemsRefresh(this ES_UnionKeJiLearn self, Transform transform, int index)
        {
            Scroll_Item_UnionKeJiLearnItem scrollItemUnionKeJiLearnItem = self.ScrollItemUnionKeJiLearnItems[index].BindTrans(transform);
            scrollItemUnionKeJiLearnItem.ClickAction = self.UpdateInfo;
            scrollItemUnionKeJiLearnItem.UpdateInfo(index, self.UserInfo.UnionKeJiList[index], self.UnionMyInfo.UnionKeJiList[index]);
        }

        public static async ETTask InitItemList(this ES_UnionKeJiLearn self)
        {
            U2C_UnionMyInfoResponse respose = await UnionNetHelper.UnionMyInfo(self.Root());

            self.UnionMyInfo = respose.UnionMyInfo;

            self.UserInfo = self.Root().GetComponent<UserInfoComponentC>().UserInfo;

            self.AddUIScrollItems(ref self.ScrollItemUnionKeJiLearnItems, self.UnionMyInfo.UnionKeJiList.Count);
            self.E_UnionKeJiLearnItemsLoopVerticalScrollRect.SetVisible(true, self.UnionMyInfo.UnionKeJiList.Count);

            self.UpdateInfo(0);
        }

        public static void UpdateInfo(this ES_UnionKeJiLearn self, int position)
        {
            self.Position = position;

            if (self.ScrollItemUnionKeJiLearnItems != null)
            {
                for (int i = 0; i < self.ScrollItemUnionKeJiLearnItems.Count; i++)
                {
                    Scroll_Item_UnionKeJiLearnItem item = self.ScrollItemUnionKeJiLearnItems[i];

                    if (item.uiTransform == null)
                    {
                        continue;
                    }

                    item.UpdateInfo(i, self.UserInfo.UnionKeJiList[i], self.UnionMyInfo.UnionKeJiList[i]);

                    GameObject highlightImg = item.E_HighlightImgImage.gameObject;
                    highlightImg.SetActive(item.Position == position);
                    if (item.Position == position)
                    {
                        self.E_HeadImgImage.sprite = item.E_IconImgImage.sprite;
                    }
                }
            }

            UnionKeJiConfig unionKeJiConfig = UnionKeJiConfigCategory.Instance.Get(self.UserInfo.UnionKeJiList[position]);

            Match match = Regex.Match(unionKeJiConfig.EquipSpaceName, @"\d");
            self.E_NameTextText.text = unionKeJiConfig.EquipSpaceName.Substring(0, match.Index);
            using (zstring.Block())
            {
                self.E_LvTextText.text = zstring.Format("等级：{0}", unionKeJiConfig.QiangHuaLv.ToString());
            }

            if (unionKeJiConfig.QiangHuaLv == 0)
            {
                UnionKeJiConfig unionKeJiConfig1 = UnionKeJiConfigCategory.Instance.Get(unionKeJiConfig.NextID);
                using (zstring.Block())
                {
                    self.E_AttributeTextText.text = zstring.Format("下一级：{0}", ItemViewHelp.GetAttributeDesc(unionKeJiConfig1.EquipPropreAdd));
                }
            }
            else
            {
                self.E_AttributeTextText.text = ItemViewHelp.GetAttributeDesc(unionKeJiConfig.EquipPropreAdd);
            }

            self.ES_CostList.Refresh(unionKeJiConfig.LearnCost);
        }

        public static async ETTask OnStartBtnButton(this ES_UnionKeJiLearn self)
        {
            UnionKeJiConfig unionKeJiConfig = UnionKeJiConfigCategory.Instance.Get(self.UserInfo.UnionKeJiList[self.Position]);
            if (unionKeJiConfig.NextID == 0)
            {
                FlyTipComponent.Instance.ShowFlyTip("已经达到满级！");
                return;
            }

            BagComponentC bagComponent = self.Root().GetComponent<BagComponentC>();
            if (!bagComponent.CheckNeedItem(unionKeJiConfig.LearnCost))
            {
                FlyTipComponent.Instance.ShowFlyTip("道具数量不足！");
                return;
            }

            if (unionKeJiConfig.NextID > self.UnionMyInfo.UnionKeJiList[self.Position])
            {
                FlyTipComponent.Instance.ShowFlyTip("等级不足！");
                return;
            }

            M2C_UnionKeJiLearnResponse response = await UnionNetHelper.UnionKeJiLearnRequest(self.Root(), self.Position);
            if (response.Error != ErrorCode.ERR_Success)
            {
                return;
            }

            self.UserInfo.UnionKeJiList = response.UnionKeJiList;
            self.UpdateInfo(self.Position);
        }
    }
}
