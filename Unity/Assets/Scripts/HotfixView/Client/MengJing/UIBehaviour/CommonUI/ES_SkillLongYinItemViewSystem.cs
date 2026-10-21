using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [EntitySystemOf(typeof(ES_SkillLongYinItem))]
    [FriendOfAttribute(typeof(ES_SkillLongYinItem))]
    public static partial class ES_SkillLongYinItemSystem
    {
        [EntitySystem]
        private static void Awake(this ES_SkillLongYinItem self, Transform transform)
        {
            self.uiTransform = transform;
            self.ImageKuang = transform.Find("ImageKuang").gameObject;

            Transform icon = transform.Find("ImageIcon");
            self.ImageIcon = icon.GetComponent<Image>();
            self.Button = icon.GetComponent<Button>();

            self.Button.AddListener(self.OnClickImageIcon);
        }

        [EntitySystem]
        private static void Destroy(this ES_SkillLongYinItem self)
        {
            self.uiTransform = null;
            self.ImageKuang = null;
            self.ImageIcon = null;
            self.Button = null;
        }

        public static void Init(this ES_SkillLongYinItem self, int index)
        {
            self.Index = index;
            self.LongYinId = 0;
            self.Visible = false;
        }

        public static void Refresh(this ES_SkillLongYinItem self, int occ, int selectId)
        {
            self.LongYinId = LongYinHelper.GetLongYinId(occ, self.Index);
            LongYinConfig longYinConfig = LongYinConfigCategory.Instance.GetOrDefault(self.LongYinId);
            if (longYinConfig == null || longYinConfig.Occ != occ)
            {
                self.Visible = false;
                self.uiTransform.gameObject.SetActive(false);
                return;
            }

            self.Visible = true;
            self.uiTransform.gameObject.SetActive(true);

            SkillSetComponentC skillSetComponent = self.Root().GetComponent<SkillSetComponentC>();
            bool active = skillSetComponent.GetLongYinLevel(self.LongYinId) > 0;

            //选中显示选择框
            if (self.ImageKuang != null)
            {
                self.ImageKuang.SetActive(selectId == self.LongYinId);
            }

            //前置激活后显示连线
            for (int i = 0; i < longYinConfig.PreId.Length; i++)
            {
                Transform line = self.uiTransform.Find($"Img_line_{i}");
                if (line == null)
                {
                    continue;
                }

                int preId = longYinConfig.PreId[i];
                line.gameObject.SetActive(preId != 0 && skillSetComponent.GetLongYinLevel(preId) > 0);
            }

            Color activeIconColor = new Color(0.2f, 0.85f, 1f, 0.55f);
            self.ImageIcon.color = active ? activeIconColor : Color.white;
        }

        public static void SetSelected(this ES_SkillLongYinItem self, bool selected)
        {
            self.ImageKuang.SetActive(selected);
        }

        private static void OnClickImageIcon(this ES_SkillLongYinItem self)
        {
            self.GetParent<ES_SkillLongYin>().OnClickLongYinItem(self);
        }
    }
}