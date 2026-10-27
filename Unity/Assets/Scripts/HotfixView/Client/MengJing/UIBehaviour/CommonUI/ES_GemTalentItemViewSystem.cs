using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [EntitySystemOf(typeof(ES_GemTalentItem))]
    [FriendOfAttribute(typeof(ES_GemTalentItem))]
    public static partial class ES_GemTalentItemSystem
    {
        [EntitySystem]
        private static void Awake(this ES_GemTalentItem self, Transform transform)
        {
            self.uiTransform = transform;

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
        /// unlocked：所在区域是否已解锁（未解锁不能选择）；active：是否已激活（未激活图标置灰）；selected：是否当前选中
        /// </summary>
        public static void OnUpdateUI(this ES_GemTalentItem self, bool unlocked, bool active, bool selected)
        {
            //未解锁区域内的天赋不能选择，未解锁或未激活的图标都置灰
            self.E_ImageIconButton.interactable = unlocked;
            CommonViewHelper.SetImageGray(self.Root(), self.E_ImageIconImage.gameObject, !unlocked || !active);

            self.E_ImageSelectImage.gameObject.SetActive(selected);
        }

        private static void OnImageIconButton(this ES_GemTalentItem self)
        {
            self.GetParent<ES_GemTalent>().OnClickGemTalentItem(self.GemTalentId);
        }
    }
}
