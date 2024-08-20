using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(DlgBuffTips))]
    public static class DlgBuffTipsSystem
    {
        public static void RegisterUIEvent(this DlgBuffTips self)
        {
            self.View.E_ImageButtonButton.AddListener(self.OnImageButtonButton);
        }

        public static void ShowWindow(this DlgBuffTips self, Entity contextData = null)
        {
            self.View.E_ImageButtonButton.gameObject.SetActive(false);
        }

        public static void OnImageButtonButton(this DlgBuffTips self)
        {
            self.Root().GetComponent<UIComponent>().CloseWindow(WindowID.WindowID_SkillTips);
        }

        public static void OnUpdateData(this DlgBuffTips self, int buffid, Vector3 vector3, string spellcast, string aBAtlasTypes, string bufficon)
        {
            self.BuffId = buffid;
            SkillBuffConfig skillBufConfig = SkillBuffConfigCategory.Instance.Get(buffid);

            string path = ABPathHelper.GetAtlasPath_2(aBAtlasTypes, bufficon);
            Sprite sprite = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path);

            self.View.E_Image_SkillIconImage.sprite = sprite;

            self.View.E_Lab_SkillNameText.text = skillBufConfig.BuffName;
            self.View.E_Lab_SkillDesText.text = skillBufConfig.BuffDescribe;

            using (zstring.Block())
            {
                self.View.EG_PositionNodeRectTransform.localPosition = vector3 + new Vector3(100, 0f, 0f);
                if (!string.IsNullOrEmpty(spellcast))
                {
                    self.View.E_Lab_SpellcasterText.text = zstring.Format("施法者：{0}", spellcast);
                }
                else
                {
                    self.View.E_Lab_SpellcasterText.text = "";
                }
            }
        }
    }
}