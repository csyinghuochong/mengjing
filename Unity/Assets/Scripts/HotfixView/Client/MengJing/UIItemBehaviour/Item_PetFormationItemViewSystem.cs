using UnityEngine;
using UnityEngine.EventSystems;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_PetFormationItem))]
    [EntitySystemOf(typeof(Scroll_Item_PetFormationItem))]
    public static partial class Scroll_Item_PetFormationItemSystem
    {
        [EntitySystem]
        private static void Awake(this Scroll_Item_PetFormationItem self)
        {
        }

        [EntitySystem]
        private static void Destroy(this Scroll_Item_PetFormationItem self)
        {
            self.DestroyWidget();
        }

        public static void SetFighting(this Scroll_Item_PetFormationItem self, bool fighting)
        {
            self.E_ImageFightImage.gameObject.SetActive(fighting);
        }

        public static void SetDragEnable(this Scroll_Item_PetFormationItem self, bool enabled)
        {
            self.E_ImageIconEventTrigger.enabled = enabled;
        }

        public static void BeginDrag(this Scroll_Item_PetFormationItem self, PointerEventData pdata)
        {
            if (self.E_ImageFightImage.gameObject.activeSelf)
            {
                FlyTipComponent.Instance.ShowFlyTip("请先下阵！");
                return;
            }

            self.BeginDragHandler?.Invoke(self.RolePetInfo, pdata);
        }

        public static void Draging(this Scroll_Item_PetFormationItem self, PointerEventData pdata)
        {
            if (self.E_ImageFightImage.gameObject.activeSelf)
            {
                return;
            }

            self.DragingHandler?.Invoke(self.RolePetInfo, pdata);
        }

        public static void EndDrag(this Scroll_Item_PetFormationItem self, PointerEventData pdata)
        {
            if (self.E_ImageFightImage.gameObject.activeSelf)
            {
                return;
            }

            self.EndDragHandler?.Invoke(self.RolePetInfo, pdata);
        }

        public static void OnInitUI(this Scroll_Item_PetFormationItem self, RolePetInfo rolePetInfo, bool fighting = false)
        {
            self.E_ImageIconEventTrigger.triggers.Clear();
            self.E_ImageIconEventTrigger.RegisterEvent(EventTriggerType.BeginDrag, (pdata) => { self.BeginDrag(pdata as PointerEventData); });
            self.E_ImageIconEventTrigger.RegisterEvent(EventTriggerType.Drag, (pdata) => { self.Draging(pdata as PointerEventData); });
            self.E_ImageIconEventTrigger.RegisterEvent(EventTriggerType.EndDrag, (pdata) => { self.EndDrag(pdata as PointerEventData); });

            self.RolePetInfo = rolePetInfo;
            PetConfig petConfig = PetConfigCategory.Instance.Get(rolePetInfo.ConfigId);
            string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.PetHeadIcon, petConfig.HeadIcon);
            Sprite sp = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path);

            self.E_ImageIconImage.sprite = sp;
            self.E_ImageFightImage.gameObject.SetActive(fighting);
            using (zstring.Block())
            {
                self.E_TextLvText.text = zstring.Format("等级: {0}", rolePetInfo.PetLv);
            }

            self.E_TextNameText.text = rolePetInfo.PetName;
        }
    }
}