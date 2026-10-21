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
            self.ImageActive = transform.Find("ImageActive")?.gameObject;
            self.ImageSelect = transform.Find("ImageSelect")?.gameObject;

            //预制体没有配置状态节点时运行时兜底创建，配置了则直接使用
            if (self.ImageSelect == null)
            {
                self.ImageSelect = CreateStateNode(transform, "ImageSelect", new Color(1f, 0.85f, 0.25f, 0.75f));
                self.ImageSelect.transform.SetAsLastSibling();
            }

            if (self.ImageActive == null)
            {
                self.ImageActive = CreateStateNode(transform, "ImageActive", new Color(0.2f, 0.85f, 1f, 0.55f));
                self.ImageActive.transform.SetAsLastSibling();
            }

            Transform icon = transform.Find("ImageIcon");
            if (icon != null)
            {
                self.ImageIcon = icon.GetComponent<Image>();
                self.Button = icon.GetComponent<Button>();
                if (self.Button != null)
                {
                    self.Button.AddListener(self.OnClickImageIcon);
                }
            }
        }

        private static GameObject CreateStateNode(Transform parent, string nodeName, Color color)
        {
            GameObject gameObject = new GameObject(nodeName, typeof(RectTransform), typeof(CanvasRenderer), typeof(Image));
            gameObject.transform.SetParent(parent, false);

            RectTransform rectTransform = gameObject.GetComponent<RectTransform>();
            rectTransform.anchorMin = new Vector2(0.5f, 0.5f);
            rectTransform.anchorMax = new Vector2(0.5f, 0.5f);
            rectTransform.anchoredPosition = Vector2.zero;
            rectTransform.sizeDelta = new Vector2(105f, 105f);

            Image image = gameObject.GetComponent<Image>();
            image.raycastTarget = false;
            image.color = color;

            Transform frame = parent.Find("ImageKuang");
            if (frame != null)
            {
                Image frameImage = frame.GetComponent<Image>();
                if (frameImage != null)
                {
                    image.sprite = frameImage.sprite;
                    image.type = frameImage.type;
                }
            }

            gameObject.SetActive(false);
            return gameObject;
        }

        [EntitySystem]
        private static void Destroy(this ES_SkillLongYinItem self)
        {
            self.uiTransform = null;
            self.ImageActive = null;
            self.ImageSelect = null;
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
            LongYinConfig longYinConfig = LongYinHelper.GetConfig(self.LongYinId);
            if (longYinConfig == null || longYinConfig.Occ != occ)
            {
                self.Visible = false;
                self.uiTransform.gameObject.SetActive(false);
                return;
            }

            self.Visible = true;
            self.uiTransform.gameObject.SetActive(true);

            SkillSetComponentC skillSetComponent = self.Root().GetComponent<SkillSetComponentC>();
            int level = skillSetComponent.GetLongYinLevel(self.LongYinId);
            bool active = level > 0;

            if (self.ImageActive != null)
            {
                self.ImageActive.SetActive(active);
            }

            if (self.ImageSelect != null)
            {
                self.ImageSelect.SetActive(selectId == self.LongYinId);
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

            if (self.ImageIcon != null)
            {
                string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.RoleSkillIcon, longYinConfig.Icon.ToString());
                Sprite sprite = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path);
                self.ImageIcon.sprite = sprite;
                CommonViewHelper.SetImageGray(self.Root(), self.ImageIcon.gameObject, !active);
            }
        }

        public static void SetSelected(this ES_SkillLongYinItem self, bool selected)
        {
            if (self.ImageSelect != null)
            {
                self.ImageSelect.SetActive(selected);
            }
        }

        private static void OnClickImageIcon(this ES_SkillLongYinItem self)
        {
            self.GetParent<ES_SkillLongYin>().OnClickLongYinItem(self);
        }
    }
}
