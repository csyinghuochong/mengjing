using System;
using UnityEngine;

namespace ET.Client
{
    [EntitySystemOf(typeof(ES_JueXingShowItem))]
    [FriendOfAttribute(typeof(ES_JueXingShowItem))]
    public static partial class ES_JueXingShowItemSystem
    {
        [EntitySystem]
        private static void Awake(this ES_JueXingShowItem self, Transform transform)
        {
            self.uiTransform = transform;
            self.E_ImageIconButton.AddListener(self.OnImageIconButton);
        }

        [EntitySystem]
        private static void Destroy(this ES_JueXingShowItem self)
        {
            self.DestroyWidget();
        }

        public static void SetSelected(this ES_JueXingShowItem self, int skillid)
        {
            self.E_ImageKuangImage.gameObject.SetActive(self.SkillId == skillid);
        }

        public static void OnClickImageIcon(this ES_JueXingShowItem self)
        {
            self.ClickHandler.Invoke(self.SkillId);
        }

        public static void OnUpdateUI(this ES_JueXingShowItem self)
        {
            SkillSetComponentC skillSetComponent = self.Root().GetComponent<SkillSetComponentC>();
            CommonViewHelper.SetImageGray(self.Root(), self.E_ImageIconImage.gameObject, null == skillSetComponent.GetBySkillID(self.SkillId));
        }

        public static void OnInitUI(this ES_JueXingShowItem self, Action<int> action, int skillId)
        {
            self.E_ImageIconButton.AddListener(self.OnClickImageIcon);
            self.SkillId = skillId;
            self.ClickHandler = action;

            SkillConfig skillConfig = SkillConfigCategory.Instance.Get(skillId);
            string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.RoleSkillIcon, skillConfig.SkillIcon);
            Sprite sp = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path);

            self.E_ImageIconImage.sprite = sp;

            self.E_TextSkillNameText.text = skillConfig.SkillName;

            self.OnUpdateUI();
        }
        public static void OnImageIconButton(this ES_JueXingShowItem self)
        {
        }
    }
}
