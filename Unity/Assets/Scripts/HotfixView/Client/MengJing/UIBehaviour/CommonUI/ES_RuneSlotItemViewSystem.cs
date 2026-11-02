using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [EntitySystemOf(typeof(ES_RuneSlotItem))]
    [FriendOfAttribute(typeof(ES_RuneSlotItem))]
    public static partial class ES_RuneSlotItemSystem
    {
        [EntitySystem]
        private static void Awake(this ES_RuneSlotItem self, Transform transform)
        {
            self.uiTransform = transform;

            self.E_ImageLockImage = UIFindHelper.FindDeepChild<Image>(transform.gameObject, "ImageLock");
            self.E_ImageAddImage = UIFindHelper.FindDeepChild<Image>(transform.gameObject, "ImageAdd");
            self.E_ImageIconImage = UIFindHelper.FindDeepChild<Image>(transform.gameObject, "ImageIcon");
            self.E_ImageSelectImage = UIFindHelper.FindDeepChild<Image>(transform.gameObject, "ImageSelect");
            self.E_ImageClickButton = UIFindHelper.FindDeepChild<Button>(transform.gameObject, "ImageClick");

            self.E_ImageClickButton.AddListener(self.OnImageClickButton);

            self.E_ImageLockImage.gameObject.SetActive(false);
            self.E_ImageAddImage.gameObject.SetActive(false);
            self.E_ImageIconImage.gameObject.SetActive(false);
            self.E_ImageSelectImage.gameObject.SetActive(false);
        }

        [EntitySystem]
        private static void Destroy(this ES_RuneSlotItem self)
        {
            self.SlotId = 0;
            self.uiTransform = null;
            self.E_ImageLockImage = null;
            self.E_ImageAddImage = null;
            self.E_ImageIconImage = null;
            self.E_ImageSelectImage = null;
            self.E_ImageClickButton = null;
        }

        /// <summary>
        /// 绑定孔位id（RuneSlotConfig.Id）
        /// </summary>
        public static void Init(this ES_RuneSlotItem self, int slotId)
        {
            self.SlotId = slotId;
        }

        /// <summary>
        /// unlocked：孔位是否已解锁；hasRune：孔位里是否镶了符文；selected：是否当前选中。
        /// 未解锁只显示锁，解锁后空槽显示加号，镶了符文显示图标
        /// </summary>
        public static void OnUpdateUI(this ES_RuneSlotItem self, bool unlocked, bool hasRune, bool selected)
        {
            self.E_ImageLockImage.gameObject.SetActive(!unlocked);
            self.E_ImageAddImage.gameObject.SetActive(unlocked && !hasRune);
            self.E_ImageIconImage.gameObject.SetActive(hasRune);
            self.E_ImageSelectImage.gameObject.SetActive(selected);
        }

        private static void OnImageClickButton(this ES_RuneSlotItem self)
        {
            self.GetParent<ES_Rune>().OnClickRuneSlot(self.SlotId);
        }
    }
}
