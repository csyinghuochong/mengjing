using System;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [EntitySystemOf(typeof (ES_Shield))]
    [FriendOfAttribute(typeof (ES_Shield))]
    public static partial class ES_ShieldSystem
    {
        [EntitySystem]
        private static void Awake(this ES_Shield self, Transform transform)
        {
            self.uiTransform = transform;

            self.E_ImageIconButton.AddListener(self.OnButtonClick);
        }

        [EntitySystem]
        private static void Destroy(this ES_Shield self)
        {
            self.DestroyWidget();
        }

        public static void SetClickHandler(this ES_Shield self, Action<int> action)
        {
            self.ClickHandler = action;
        }

        public static void SetSelected(this ES_Shield self, int stype)
        {
            self.EG_SelectShowRectTransform.gameObject.SetActive(self.ShieldType == stype);
        }

        public static void OnButtonClick(this ES_Shield self)
        {
            self.ClickHandler?.Invoke(self.ShieldType);
        }

        public static void OnUpdateUI(this ES_Shield self)
        {
            int level = self.Root().GetComponent<SkillSetComponentC>().GetLifeShieldLevel(self.ShieldType);

            UICommonHelper.SetImageGray(self.Root(), self.E_ImageIconImage.gameObject, level == 0);
            int showId = self.Root().GetComponent<SkillSetComponentC>().GetLifeShieldShowId(self.ShieldType);
            self.E_TextNameText.text = LifeShieldConfigCategory.Instance.Get(showId).ShieldName;
        }

        public static void OnInitUI(this ES_Shield self, int stype)
        {
            self.ShieldType = stype;

            int showId = self.Root().GetComponent<SkillSetComponentC>().GetLifeShieldShowId(self.ShieldType);
            self.E_TextNameText.text = LifeShieldConfigCategory.Instance.Get(showId).ShieldName;
        }
    }
}