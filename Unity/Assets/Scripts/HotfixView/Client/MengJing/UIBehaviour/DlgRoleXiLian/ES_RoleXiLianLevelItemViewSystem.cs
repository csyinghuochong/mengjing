using System.Collections.Generic;
using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_CommonSkillItem))]
    [EntitySystemOf(typeof(ES_RoleXiLianLevelItem))]
    [FriendOfAttribute(typeof(ES_RoleXiLianLevelItem))]
    public static partial class ES_RoleXiLianLevelItemSystem
    {
        [EntitySystem]
        private static void Awake(this ES_RoleXiLianLevelItem self, Transform transform)
        {
            self.uiTransform = transform;

            self.E_CommonSkillItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnCommonSkillItemsRefresh);
            self.E_ButtonGetButton.AddListenerAsync(self.OnButtonGetButton);
        }

        [EntitySystem]
        private static void Destroy(this ES_RoleXiLianLevelItem self)
        {
            self.DestroyWidget();
        }

        private static void OnCommonSkillItemsRefresh(this ES_RoleXiLianLevelItem self, Transform transform, int index)
        {
            foreach (Scroll_Item_CommonSkillItem item in self.ScrollItemCommonSkillItems.Values)
            {
                if (item.uiTransform == transform)
                {
                    item.uiTransform = null;
                }
            }
            
            Scroll_Item_CommonSkillItem scrollItemCommonSkillItem = self.ScrollItemCommonSkillItems[index].BindTrans(transform);
            scrollItemCommonSkillItem.OnUpdateUI((int)self.ShowSkill[index].Value, ABAtlasTypes.RoleSkillIcon, false,
                ItemViewHelp.XiLianWeiZhiTip(self.ShowSkill[index].KeyId));
        }

        public static async ETTask OnButtonGetButton(this ES_RoleXiLianLevelItem self)
        {
            int error = await BagClientNetHelper.RquestItemXiLianReward(self.Root(), self.XiLianLevelId);
            if (error != ErrorCode.ERR_Success)
            {
                return;
            }

            self.Root().GetComponent<UserInfoComponentC>().UserInfo.XiuLianRewardIds.Add(self.XiLianLevelId);
            self.OnUpdateUI(self.XiLianLevelId);
        }

        public static void OnUpdateUI(this ES_RoleXiLianLevelItem self, int xilianId)
        {
            self.XiLianLevelId = xilianId;
            EquipXiLianConfig equipXiLianConfig = EquipXiLianConfigCategory.Instance.Get(xilianId);
            Unit unit = UnitHelper.GetMyUnitFromClientScene(self.Root());
            int shuliandu = unit.GetComponent<NumericComponentC>().GetAsInt(NumericType.ItemXiLianDu);

            UserInfo userInfo = self.Root().GetComponent<UserInfoComponentC>().UserInfo;
            self.ES_RewardList.Refresh(equipXiLianConfig.RewardList);

            int xilianLevel = EquipXiLianConfigCategory.Instance.Get(xilianId).XiLianLevel;
            List<KeyValuePairInt> xilianSkill = XiLianHelper.GetLevelSkill(xilianLevel);
            self.ShowSkill = xilianSkill;
            self.AddUIScrollItems(ref self.ScrollItemCommonSkillItems, xilianSkill.Count);
            self.E_CommonSkillItemsLoopVerticalScrollRect.SetVisible(true, xilianSkill.Count);

            bool actived = shuliandu >= equipXiLianConfig.NeedShuLianDu;
            self.E_Image_AcvityedImage.gameObject.SetActive(userInfo.XiuLianRewardIds.Contains(xilianId));
            self.E_ButtonGetButton.gameObject.SetActive(actived && !userInfo.XiuLianRewardIds.Contains(xilianId));
            using (zstring.Block())
            {
                self.E_TextShuLianDuText.text = actived ? zstring.Format("{0}/{1}", equipXiLianConfig.NeedShuLianDu, equipXiLianConfig.NeedShuLianDu)
                        : zstring.Format("{0}/{1}", shuliandu, equipXiLianConfig.NeedShuLianDu);
                float progress = shuliandu * 1f / equipXiLianConfig.NeedShuLianDu;
                self.E_ImageExpImage.fillAmount = Mathf.Min(progress, 1f);
                self.E_TextTitleText.text = equipXiLianConfig.Title;
                self.E_TextLevelTipText.text = zstring.Format("获得{0}，洗练获得高品质属性概率提升。", equipXiLianConfig.Title);

                if (equipXiLianConfig.ProList_Type[0] != 0)
                {
                    if (NumericHelp.GetNumericValueType(equipXiLianConfig.ProList_Type[0]) == 2)
                    {
                        float fvalue = equipXiLianConfig.ProList_Value[0] * 0.001f;
                        string svalue = fvalue.ToString("0.#####");
                        self.E_TextAttributeText.text =
                                zstring.Format("{0} +{1}%", ItemViewHelp.GetAttributeName(equipXiLianConfig.ProList_Type[0]), svalue);
                    }
                    else
                    {
                        self.E_TextAttributeText.text = zstring.Format("{0} +{1}", ItemViewHelp.GetAttributeName(equipXiLianConfig.ProList_Type[0]),
                            equipXiLianConfig.ProList_Value[0]);
                    }
                }
            }
        }
    }
}
