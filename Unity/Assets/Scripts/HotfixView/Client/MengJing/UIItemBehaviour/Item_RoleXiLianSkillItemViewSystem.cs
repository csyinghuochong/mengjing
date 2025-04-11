using System.Collections.Generic;
using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_CommonSkillItem))]
    [FriendOf(typeof(Scroll_Item_RoleXiLianSkillItem))]
    [EntitySystemOf(typeof(Scroll_Item_RoleXiLianSkillItem))]
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
            self.uIItems.Clear();
            self.EquipXiLianConfig = equipXiLianConfig;

            var bundleGameObject = self.Root().GetComponent<ResourcesLoaderComponent>()
                    .LoadAssetSync<GameObject>("Assets/Bundles/UI/Item/Item_CommonSkillItem.prefab");
            using (zstring.Block())
            {
                self.E_Text_XiLianNameText.text = zstring.Format("{0}{1}", equipXiLianConfig.Title,
                    LanguageComponent.Instance.LoadLocalization("额外增加概率出现的特殊属性"));
            }

            List<KeyValuePairInt> xilianSkill = XiLianHelper.GetLevelSkill(equipXiLianConfig.XiLianLevel);

            int row = (xilianSkill.Count / 8);
            row += (xilianSkill.Count % 8 > 0 ? 1 : 0);
            self.uiTransform.GetComponent<RectTransform>().sizeDelta = new Vector2(1400f, 100f + row * 170f);

            for (int i = 0; i < xilianSkill.Count; i++)
            {
                GameObject bagSpace = UnityEngine.Object.Instantiate(bundleGameObject);
                CommonViewHelper.SetParent(bagSpace, self.EG_ItemNodeRectTransform.gameObject);
                Scroll_Item_CommonSkillItem ui_item = self.AddChild<Scroll_Item_CommonSkillItem>();
                ui_item.uiTransform = bagSpace.transform;
                ui_item.OnUpdateUI((int)xilianSkill[i].Value, ABAtlasTypes.RoleSkillIcon, false, ItemViewHelp.XiLianWeiZhiTip(xilianSkill[i].KeyId));

                using (zstring.Block())
                {
                    Log.Info(zstring.Format("xilianSkill[i] = {0}", xilianSkill[i].ToString()));
                }

                SkillConfig skillcof = SkillConfigCategory.Instance.Get((int)xilianSkill[i].Value);
                ui_item.E_TextSkillNameText.text = skillcof.SkillName;
                ui_item.E_TextSkillNameText.gameObject.SetActive(true);
                self.uIItems.Add(ui_item);
            }
        }

        public static void OnUpdateUI(this Scroll_Item_RoleXiLianSkillItem self, int xilianlv)
        {
            bool gray = xilianlv < self.EquipXiLianConfig.XiLianLevel;
            for (int i = 0; i < self.uIItems.Count; i++)
            {
                Scroll_Item_CommonSkillItem item = self.uIItems[i];
                CommonViewHelper.SetImageGray(self.Root(), item.E_ImageIconImage.gameObject, gray);
            }

            self.EG_JiHuoSetRectTransform.gameObject.SetActive(!gray);
        }
    }
}