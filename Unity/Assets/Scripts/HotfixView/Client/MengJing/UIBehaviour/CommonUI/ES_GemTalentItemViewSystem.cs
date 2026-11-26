using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [EntitySystemOf(typeof(ES_GemTalentItem))]
    [FriendOfAttribute(typeof(ES_GemTalentItem))]
    public static partial class ES_GemTalentItemSystem
    {
        private const float ClickAlphaThreshold = 0.1f;

        [EntitySystem]
        private static void Awake(this ES_GemTalentItem self, Transform transform)
        {
            self.uiTransform = transform;

            self.BGHuiButton = UIFindHelper.FindDeepChild<Button>(transform.gameObject, "BG_Hui");
            self.BGOpen = transform.Find("BG_Open").gameObject;
            self.BGActivate = transform.Find("BG_Activate").gameObject;
            self.E_ImageIconImage = UIFindHelper.FindDeepChild<Image>(transform.gameObject, "ImageIcon");
            self.E_ImageSelectImage = UIFindHelper.FindDeepChild<Image>(transform.gameObject, "ImageSelect");

            self.BGHuiButton.image.alphaHitTestMinimumThreshold = ClickAlphaThreshold;
            self.BGHuiButton.transition = Selectable.Transition.None;
            self.BGHuiButton.AddListener(self.OnBGHuiButton);
            self.OnUpdateUI(false, false, false);
        }

        [EntitySystem]
        private static void Destroy(this ES_GemTalentItem self)
        {
            if (self.BGHuiButton != null)
            {
                self.BGHuiButton.onClick.RemoveListener(self.OnBGHuiButton);
            }

            if (self.E_ImageSelectImage != null && self.uiTransform != null)
            {
                self.SetSelectionVisible(false);
            }

            self.GemTalentId = 0;
            self.uiTransform = null;
            self.BGHuiButton = null;
            self.BGOpen = null;
            self.BGActivate = null;
            self.E_ImageIconImage = null;
            self.E_ImageSelectImage = null;
        }

        public static void Init(this ES_GemTalentItem self, int gemTalentId)
        {
            self.GemTalentId = gemTalentId;

            if (GemTalentConfigCategory.Instance.GetOrDefault(gemTalentId) == null)
            {
                self.uiTransform.gameObject.SetActive(false);
            }
        }

        public static void OnUpdateUI(this ES_GemTalentItem self, bool unlocked, bool active, bool selected)
        {
            self.BGOpen.SetActive(unlocked);
            self.BGActivate.SetActive(unlocked && active);
            self.SetSelectionVisible(selected);
        }

        private static void SetSelectionVisible(this ES_GemTalentItem self, bool selected)
        {
            RectTransform selection = self.E_ImageSelectImage.rectTransform;
            Transform parent = selected ? self.GetParent<ES_GemTalent>().UITransform : self.uiTransform;
            if (selection.parent != parent)
            {
                // 切换绘制层级时保持选中框和节点对齐。
                selection.SetParent(parent, true);
            }

            if (selected)
            {
                selection.SetAsLastSibling();
            }

            self.E_ImageSelectImage.gameObject.SetActive(selected);
        }

        private static void OnBGHuiButton(this ES_GemTalentItem self)
        {
            self.GetParent<ES_GemTalent>().OnClickGemTalentItem(self.GemTalentId);
        }
    }
}
