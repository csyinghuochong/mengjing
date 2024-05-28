using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof (Scroll_Item_CommonSkillItem))]
    [FriendOf(typeof (Scroll_Item_RoleXiLianSkillItem))]
    [EntitySystemOf(typeof (Scroll_Item_RoleXiLianSkillItem))]
    public static partial class Scroll_Item_RoleXiLianSkillItemSystem
    {
        [EntitySystem]
        private static void Awake(this Scroll_Item_RoleXiLianSkillItem self)
        {
        }

        [EntitySystem]
        private static void Destroy(this Scroll_Item_RoleXiLianSkillItem self)
        {
            self.DestroyWidget();
        }

        public static void OnInitUI(this Scroll_Item_RoleXiLianSkillItem self, EquipXiLianConfig equipXiLianConfig)
        {
            self.E_CommonSkillItemsLoopVerticalScrollRect.AddItemRefreshListener(self.OnCommonSkillItemsRefresh);

            self.EquipXiLianConfig = equipXiLianConfig;
            self.E_Text_XiLianNameText.text = equipXiLianConfig.Title + GameSettingLanguge.LoadLocalization("额外增加概率出现的特殊属性");
            self.XilianSkill = XiLianHelper.GetLevelSkill(equipXiLianConfig.XiLianLevel);

            int row = (self.XilianSkill.Count / 8);
            row += (self.XilianSkill.Count % 8 > 0? 1 : 0);
            self.uiTransform.GetComponent<RectTransform>().sizeDelta = new Vector2(1400f, 100f + row * 170f);

            self.AddUIScrollItems(ref self.ScrollItemCommonSkillItems, self.XilianSkill.Count);
            self.E_CommonSkillItemsLoopVerticalScrollRect.SetVisible(true, self.XilianSkill.Count);
        }

        private static void OnCommonSkillItemsRefresh(this Scroll_Item_RoleXiLianSkillItem self, Transform transform, int index)
        {
            Scroll_Item_CommonSkillItem scrollItemCommonSkillItem = self.ScrollItemCommonSkillItems[index].BindTrans(transform);
            scrollItemCommonSkillItem.OnUpdateUI((int)self.XilianSkill[index].Value, ABAtlasTypes.RoleSkillIcon, false,
                ItemViewHelp.XiLianWeiZhiTip(self.XilianSkill[index].KeyId));
            SkillConfig skillcof = SkillConfigCategory.Instance.Get((int)self.XilianSkill[index].Value);
            scrollItemCommonSkillItem.E_TextSkillNameText.text = skillcof.SkillName;
            scrollItemCommonSkillItem.E_TextSkillNameText.gameObject.SetActive(true);
        }

        public static void OnUpdateUI(this Scroll_Item_RoleXiLianSkillItem self, int xilianlv)
        {
            bool gray = xilianlv < self.EquipXiLianConfig.XiLianLevel;
            if (self.ScrollItemCommonSkillItems != null)
            {
                foreach (Scroll_Item_CommonSkillItem item in self.ScrollItemCommonSkillItems.Values)
                {
                    if (item.uiTransform == null)
                    {
                        continue;
                    }

                    UICommonHelper.SetImageGray(self.Root(), item.E_ImageIconImage.gameObject, gray);
                }
            }

            if (gray)
            {
                self.EG_JiHuoSetRectTransform.gameObject.SetActive(false);
            }
        }
    }
}