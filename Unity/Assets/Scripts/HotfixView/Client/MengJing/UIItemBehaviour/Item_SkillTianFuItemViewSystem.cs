using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_SkillTianFuItem))]
    [EntitySystemOf(typeof(Scroll_Item_SkillTianFuItem))]
    public static partial class Scroll_Item_SkillTianFuItemSystem
    {
        [EntitySystem]
        private static void Awake(this Scroll_Item_SkillTianFuItem self)
        {
        }

        [EntitySystem]
        private static void Destroy(this Scroll_Item_SkillTianFuItem self)
        {
            self.DestroyWidget();
        }

        public static GameObject GetKuangByIndex(this Scroll_Item_SkillTianFuItem self, int index)
        {
            if (index == 0)
                return self.E_ImageIcon1Button.gameObject;
            else if (index == 1)
                return self.E_ImageIcon2Button.gameObject;
            else
                return self.E_ImageIcon3Button.gameObject;
        }

        public static void OnClickTianFu(this Scroll_Item_SkillTianFuItem self, int index)
        {
            self.ClickHandler(self.TianFuList[index]);
        }

        public static void SetClickHanlder(this Scroll_Item_SkillTianFuItem self, Action<int> action)
        {
            self.ClickHandler = action;
        }

        public static void InitTianFuList(this Scroll_Item_SkillTianFuItem self, List<int> tianfus)
        {
            self.E_ImageIcon3Button.AddListener(() => { self.OnClickTianFu(2); });
            self.E_ImageIcon2Button.onClick.AddListener(() => { self.OnClickTianFu(1); });
            self.E_ImageIcon1Button.AddListener(() => { self.OnClickTianFu(0); });

            self.TianFuList = tianfus;

            TalentConfig skillConfig = TalentConfigCategory.Instance.Get(tianfus[0]);
            string path1 = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.RoleSkillIcon, skillConfig.Icon.ToString());
            Sprite sp1 = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path1);

            self.E_ImageIcon1Image.sprite = sp1;
            self.E_TextName1Text.text = skillConfig.Name;

            skillConfig = TalentConfigCategory.Instance.Get(tianfus[1]);
            string path2 = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.RoleSkillIcon, skillConfig.Icon.ToString());
            Sprite sp2 = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path2);

            self.E_ImageIcon2Image.sprite = sp2;
            self.E_TextName2Text.text = skillConfig.Name;

            skillConfig = TalentConfigCategory.Instance.Get(tianfus[2]);
            string path3 = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.RoleSkillIcon, skillConfig.Icon.ToString());
            Sprite sp3 = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path3);

            self.E_ImageIcon3Image.sprite = sp3;
            self.E_TextName3Text.text = skillConfig.Name;

            using (zstring.Block())
            {
                self.E_TextLvText.text = zstring.Format("{0}级激活此天赋", skillConfig.LearnRoseLv);
            }
        }

        public static void OnActiveTianFu(this Scroll_Item_SkillTianFuItem self)
        {
            SkillSetComponentC skillSetComponent = self.Root().GetComponent<SkillSetComponentC>();

            List<KeyValuePairInt> activeList = skillSetComponent.TianFuList();
            CommonViewHelper.SetImageGray(self.Root(), self.E_ImageIcon3Image.gameObject, !activeList.Any(keyValuePairInt => keyValuePairInt.KeyId == self.TianFuList[2]));
            CommonViewHelper.SetImageGray(self.Root(), self.E_ImageIcon2Image.gameObject, !activeList.Any(keyValuePairInt => keyValuePairInt.KeyId == self.TianFuList[1]));
            CommonViewHelper.SetImageGray(self.Root(), self.E_ImageIcon1Image.gameObject, !activeList.Any(keyValuePairInt => keyValuePairInt.KeyId == self.TianFuList[0]));
        }
    }
}