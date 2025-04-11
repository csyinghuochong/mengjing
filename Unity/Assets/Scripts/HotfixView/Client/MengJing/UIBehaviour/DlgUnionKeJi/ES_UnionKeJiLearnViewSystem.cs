using System.Text.RegularExpressions;
using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(ES_UnionKeJiLearnItem))]
    [FriendOf(typeof(Scroll_Item_UnionKeJiLearnItem))]
    [EntitySystemOf(typeof(ES_UnionKeJiLearn))]
    [FriendOfAttribute(typeof(ES_UnionKeJiLearn))]
    public static partial class ES_UnionKeJiLearnSystem
    {
        [EntitySystem]
        private static void Awake(this ES_UnionKeJiLearn self, Transform transform)
        {
            self.uiTransform = transform;

            self.E_ActiveBtnButton.AddListenerAsync(self.OnStartBtnButton);
            self.E_UpBtnButton.AddListenerAsync(self.OnStartBtnButton);

            self.InitItemList();
        }

        [EntitySystem]
        private static void Destroy(this ES_UnionKeJiLearn self)
        {
            self.DestroyWidget();
        }

        private static void InitItemList(this ES_UnionKeJiLearn self)
        {
            self.UserInfo = self.Root().GetComponent<UserInfoComponentC>().UserInfo;

            if (self.Items.Count == 0)
            {
                for (int i = 0; i < self.EG_ContentRectTransform.childCount; i++)
                {
                    Transform subTrans = self.EG_ContentRectTransform.GetChild(i);
                    ES_UnionKeJiLearnItem item = self.AddChild<ES_UnionKeJiLearnItem, Transform>(subTrans);
                    item.Init(i);
                    self.Items.Add(item);
                }
            }
        }

        public static void UpdateInfo(this ES_UnionKeJiLearn self, int position)
        {
            self.Position = position;
            
            for (int i = 0; i < self.Items.Count; i++)
            {
                ES_UnionKeJiLearnItem item = self.Items[i];
                item.Refresh();
                if (position == item.Position)
                {
                    self.E_ImageSelectImage.transform.SetParent(item.EG_SelectRectTransform);
                    self.E_ImageSelectImage.transform.localPosition = Vector3.zero;
                    self.E_ImageSelectImage.gameObject.SetActive(true);
                }
            }

            UnionKeJiConfig nowUnionKeJiConfig = UnionKeJiConfigCategory.Instance.Get(self.UserInfo.UnionKeJiList[position]);

            ResourcesLoaderComponent resourcesLoaderComponent = self.Root().GetComponent<ResourcesLoaderComponent>();
            
            self.E_HeadImgImage.sprite = resourcesLoaderComponent.LoadAssetSync<Sprite>(ABPathHelper.GetAtlasPath_2(ABAtlasTypes.OtherIcon, nowUnionKeJiConfig.Icon));
            
            string keJiName = nowUnionKeJiConfig.EquipSpaceName.Substring(0, Regex.Match(nowUnionKeJiConfig.EquipSpaceName, @"\d").Index);
            self.E_NameTextText.text = keJiName;
            using (zstring.Block())
            {
                self.E_LvTextText.text = zstring.Format("当前科技等级：{0}", nowUnionKeJiConfig.QiangHuaLv.ToString());
                self.E_MaxLvTextText.text = zstring.Format("{0}可以提升至{1}级", keJiName, UnionKeJiConfigCategory.Instance.Get(self.UnionMyInfo.UnionKeJiList[position]).QiangHuaLv);
                if (nowUnionKeJiConfig.PreId.Length == 0 || nowUnionKeJiConfig.PreId[0] == 0)
                {
                    self.E_PreTextText.text = "";
                }
                else
                {
                    string preInfo = "需要";
                    for (int i = 0; i < nowUnionKeJiConfig.PreId.Length; i++)
                    {
                        if (i != 0)
                        {
                            preInfo += "或";
                        }
                        
                        UnionKeJiConfig config = UnionKeJiConfigCategory.Instance.Get(nowUnionKeJiConfig.PreId[i]);
                        preInfo += nowUnionKeJiConfig.EquipSpaceName.Substring(0, Regex.Match(nowUnionKeJiConfig.EquipSpaceName, @"\d").Index);
                        preInfo += "达到" + config.QiangHuaLv + "级";
                    }
                    self.E_PreTextText.text = preInfo;
                }

                self.E_CostPointTextText.text = zstring.Format("科技点数：{0}点", nowUnionKeJiConfig.Point);
            }
            
            // if (nowUnionKeJiConfig.QiangHuaLv == 0)
            // {
            //     UnionKeJiConfig unionKeJiConfig1 = UnionKeJiConfigCategory.Instance.Get(nowUnionKeJiConfig.NextID);
            //     using (zstring.Block())
            //     {
            //         self.E_AttributeTextText.text = zstring.Format("下一级：{0}", ItemViewHelp.GetAttributeDesc(unionKeJiConfig1.EquipPropreAdd));
            //     }
            // }
            // else
            // {
            //     self.E_AttributeTextText.text = ItemViewHelp.GetAttributeDesc(nowUnionKeJiConfig.EquipPropreAdd);
            // }

            self.ES_CostList.Refresh(nowUnionKeJiConfig.LearnCost);
            
            self.E_ActiveBtnButton.gameObject.SetActive(nowUnionKeJiConfig.QiangHuaLv == 0);
            self.E_UpBtnButton.gameObject.SetActive(nowUnionKeJiConfig.QiangHuaLv != 0);
        }

        private static async ETTask OnStartBtnButton(this ES_UnionKeJiLearn self)
        {
            UnionKeJiConfig unionKeJiConfig = UnionKeJiConfigCategory.Instance.Get(self.UserInfo.UnionKeJiList[self.Position]);

            if (unionKeJiConfig.NextID > self.UnionMyInfo.UnionKeJiList[self.Position])
            {
                FlyTipComponent.Instance.ShowFlyTip("已达当前最高等级！");
                return;
            }
            
            BagComponentC bagComponent = self.Root().GetComponent<BagComponentC>();
            if (!bagComponent.CheckNeedItem(unionKeJiConfig.LearnCost))
            {
                FlyTipComponent.Instance.ShowFlyTip("道具数量不足！");
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
