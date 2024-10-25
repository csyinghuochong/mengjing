using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ET.Client
{
    [FriendOf(typeof(Scroll_Item_PetMeleeItem))]
    [EntitySystemOf(typeof(Scroll_Item_PetMeleeItem))]
    public static partial class Scroll_Item_PetMeleeItemSystem
    {
        [EntitySystem]
        private static void Awake(this Scroll_Item_PetMeleeItem self)
        {
        }

        [EntitySystem]
        private static void Destroy(this Scroll_Item_PetMeleeItem self)
        {
            self.DestroyWidget();
        }

        public static void Refresh(this Scroll_Item_PetMeleeItem self, RolePetInfo rolePetInfo)
        {
            self.RolePetInfo = rolePetInfo;
            self.E_IconEventTrigger.RegisterEvent(EventTriggerType.BeginDrag, (pdata) => { self.BeginDrag(pdata as PointerEventData); });
            self.E_IconEventTrigger.RegisterEvent(EventTriggerType.Drag, (pdata) => { self.Drag(pdata as PointerEventData); });
            self.E_IconEventTrigger.RegisterEvent(EventTriggerType.EndDrag, (pdata) => { self.EndDrag(pdata as PointerEventData); });

            PetConfig petConfig = PetConfigCategory.Instance.Get(rolePetInfo.ConfigId);
            PetSkinConfig petSkinConfig = PetSkinConfigCategory.Instance.Get(rolePetInfo.SkinId);
            string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.PetHeadIcon, petSkinConfig.IconID.ToString());
            Sprite sp = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path);
            self.E_IconImage.sprite = sp;
        }

        private static void BeginDrag(this Scroll_Item_PetMeleeItem self, PointerEventData pdata)
        {
        }

        private static void Drag(this Scroll_Item_PetMeleeItem self, PointerEventData pdata)
        {
        }

        private static void EndDrag(this Scroll_Item_PetMeleeItem self, PointerEventData pdata)
        {
        }

        public static void RefreshCD(this Scroll_Item_PetMeleeItem self)
        {
            long timeNow = TimeInfo.Instance.ServerNow();
            if (self.EndTime <= timeNow)
            {
                self.E_CDImage.fillAmount = 0;
            }
            else
            {
                self.E_CDImage.fillAmount = (float)(self.EndTime - timeNow) / self.CD;
            }
        }

        public static void SetCD(this Scroll_Item_PetMeleeItem self)
        {
            self.EndTime = TimeHelper.ServerNow() + self.CD;
        }

        private static void OnClick(this Scroll_Item_PetMeleeItem self)
        {
            if (self.EndTime > TimeHelper.ServerNow())
            {
                FlyTipComponent.Instance.ShowFlyTip("冷却中。。。");
                return;
            }

            self.Root().GetComponent<UIComponent>().GetDlgLogic<DlgPetMeleeMain>().OnClickItem(self.CostMoLi, self.RolePetInfo.Id);
        }
    }
}