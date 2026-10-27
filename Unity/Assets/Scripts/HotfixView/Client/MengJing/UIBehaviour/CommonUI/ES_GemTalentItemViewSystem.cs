using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [EntitySystemOf(typeof(ES_GemTalentItem))]
    [FriendOfAttribute(typeof(ES_GemTalentItem))]
    public static partial class ES_GemTalentItemSystem
    {
        /// <summary>
        /// 未解锁/未激活时节点底图的透明度
        /// </summary>
        private const float InactiveAlpha = 0.4f;

        [EntitySystem]
        private static void Awake(this ES_GemTalentItem self, Transform transform)
        {
            self.uiTransform = transform;

            self.E_ImageBGImage = UIFindHelper.FindDeepChild<Image>(transform.gameObject, "ImageBG");
            self.ImageBGColor = self.E_ImageBGImage.color;
            self.E_ImageIconImage = UIFindHelper.FindDeepChild<Image>(transform.gameObject, "ImageIcon");
            self.E_ImageIconButton = UIFindHelper.FindDeepChild<Button>(transform.gameObject, "ImageIcon");
            self.E_ImageSelectImage = UIFindHelper.FindDeepChild<Image>(transform.gameObject, "ImageSelect");

            self.E_ImageIconButton.AddListener(self.OnImageIconButton);
            self.E_ImageSelectImage.gameObject.SetActive(false);
        }

        [EntitySystem]
        private static void Destroy(this ES_GemTalentItem self)
        {
            self.GemTalentId = 0;
            self.uiTransform = null;
            self.E_ImageBGImage = null;
            self.E_ImageIconImage = null;
            self.E_ImageIconButton = null;
            self.E_ImageSelectImage = null;
        }

        /// <summary>
        /// 图标由配置决定且不会变，绑定节点时取一次就行
        /// </summary>
        public static void Init(this ES_GemTalentItem self, int gemTalentId)
        {
            self.GemTalentId = gemTalentId;

            GemTalentConfig gemTalentConfig = GemTalentConfigCategory.Instance.GetOrDefault(gemTalentId);
            if (gemTalentConfig == null)
            {
                self.uiTransform.gameObject.SetActive(false);
                return;
            }

            string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.RoleSkillIcon, gemTalentConfig.Icon.ToString());
            self.E_ImageIconImage.sprite = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path);
        }

        /// <summary>
        /// unlocked：所在区域是否已解锁（未解锁不能选择）；active：是否已激活（未激活底图变淡）；selected：是否当前选中
        /// </summary>
        public static void OnUpdateUI(this ES_GemTalentItem self, bool unlocked, bool active, bool selected)
        {
            //未解锁区域内的天赋不能选择，未解锁或未激活的底图降低透明度
            self.E_ImageIconButton.interactable = unlocked;

            Color bgColor = self.ImageBGColor;
            bgColor.a = !unlocked || !active ? InactiveAlpha : self.ImageBGColor.a;
            self.E_ImageBGImage.color = bgColor;

            self.E_ImageSelectImage.gameObject.SetActive(selected);
        }

        private static void OnImageIconButton(this ES_GemTalentItem self)
        {
            self.GetParent<ES_GemTalent>().OnClickGemTalentItem(self.GemTalentId);
        }
    }
}
