using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ET.Client
{
    [EntitySystemOf(typeof(ES_PetMeleeCard))]
    [FriendOfAttribute(typeof(ES_PetMeleeCard))]
    public static partial class ES_PetMeleeCardSystem
    {
        [EntitySystem]
        private static void Awake(this ES_PetMeleeCard self, Transform transform)
        {
            self.uiTransform = transform;
            self.E_TouchEventTrigger.RegisterEvent(EventTriggerType.BeginDrag, (pdata) => { self.BeginDrag(pdata as PointerEventData); });
            self.E_TouchEventTrigger.RegisterEvent(EventTriggerType.Drag, (pdata) => { self.Drag(pdata as PointerEventData); });
            self.E_TouchEventTrigger.RegisterEvent(EventTriggerType.EndDrag, (pdata) => { self.EndDrag(pdata as PointerEventData); });
        }

        [EntitySystem]
        private static void Destroy(this ES_PetMeleeCard self)
        {
            self.DestroyWidget();
        }

        public static void InitCard(this ES_PetMeleeCard self, PetMeleeCardInfo cardInfo)
        {
            self.PetMeleeCardInfo = cardInfo;

            switch (self.PetMeleeCardInfo.Type)
            {
                case (int)PetMeleeCarType.MainPet:
                {
                    RolePetInfo rolePetInfo = self.Root().GetComponent<PetComponentC>().GetPetInfoByID(self.PetMeleeCardInfo.PetId);
                    PetConfig petConfig = PetConfigCategory.Instance.Get(rolePetInfo.ConfigId);
                    PetSkinConfig petSkinConfig = PetSkinConfigCategory.Instance.Get(rolePetInfo.SkinId);
                    string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.PetHeadIcon, petSkinConfig.IconID.ToString());
                    Sprite sp = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path);
                    self.E_IconImage.sprite = sp;
                    using (zstring.Block())
                    {
                        self.E_DesText.text = zstring.Format("主战卡：{0}", rolePetInfo.PetName);
                        self.E_CostText.text = zstring.Format("魔力：{0}", ConfigData.PetMeleeMainPetCost);
                    }

                    break;
                }
                case (int)PetMeleeCarType.AssistPet:
                {
                    PetTuJianConfig petTuJianConfig = PetTuJianConfigCategory.Instance.Get(self.PetMeleeCardInfo.ConfigId);
                    string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.PetHeadIcon, petTuJianConfig.Icon.ToString());
                    Sprite sp = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path);
                    self.E_IconImage.sprite = sp;
                    using (zstring.Block())
                    {
                        self.E_DesText.text = zstring.Format("辅战卡：{0}", petTuJianConfig.Name);
                        self.E_CostText.text = zstring.Format("魔力：{0}", petTuJianConfig.Cost);
                    }

                    break;
                }
                case (int)PetMeleeCarType.Magic:
                {
                    PetMagicCardConfig petMagicCardConfig = PetMagicCardConfigCategory.Instance.Get(self.PetMeleeCardInfo.ConfigId);
                    string path = ABPathHelper.GetAtlasPath_2(ABAtlasTypes.RoleSkillIcon, petMagicCardConfig.Icon.ToString());
                    Sprite sp = self.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<Sprite>(path);
                    self.E_IconImage.sprite = sp;
                    using (zstring.Block())
                    {
                        self.E_DesText.text = zstring.Format("魔法卡：{0}", petMagicCardConfig.Name);
                        self.E_CostText.text = zstring.Format("魔力：{0}", petMagicCardConfig.Cost);
                    }

                    break;
                }
            }
        }

        private static void BeginDrag(this ES_PetMeleeCard self, PointerEventData pdata)
        {
            self.uiTransform.localScale = new Vector3(1.2f, 1.2f, 1f);
            self.GetParent<DlgPetMeleeMain>().View.E_IconImage.sprite = self.E_IconImage.sprite;
            self.GetParent<DlgPetMeleeMain>().View.E_IconImage.gameObject.SetActive(true);
        }

        private static void Drag(this ES_PetMeleeCard self, PointerEventData pdata)
        {
            Vector2 localPoint = new Vector2();
            RectTransform canvas = self.uiTransform.parent.parent.GetComponent<RectTransform>();
            Camera uiCamera = self.Root().GetComponent<GlobalComponent>().UICamera.GetComponent<Camera>();
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas, pdata.position, uiCamera, out localPoint);
            self.GetParent<DlgPetMeleeMain>().View.E_IconImage.transform.localPosition = localPoint;
        }

        private static void EndDrag(this ES_PetMeleeCard self, PointerEventData pdata)
        {
            self.uiTransform.localScale = new Vector3(1f, 1f, 1f);

            self.GetParent<DlgPetMeleeMain>().View.E_IconImage.gameObject.SetActive(false);

            RaycastHit raycastHit;
            Ray Ray = self.Root().GetComponent<GlobalComponent>().MainCamera.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
            bool hit = Physics.Raycast(Ray, out raycastHit, 100, 1 << LayerMask.NameToLayer(LayerEnum.Map.ToString()));
            if (!hit)
            {
                return;
            }

            Vector3 pos = raycastHit.point;

            if ((self.PetMeleeCardInfo.Type == (int)PetMeleeCarType.MainPet || self.PetMeleeCardInfo.Type == (int)PetMeleeCarType.AssistPet) &&
                pos.x > 0)
            {
                FlyTipComponent.Instance.ShowFlyTip("请放置在左边");
                return;
            }

            self.GetParent<DlgPetMeleeMain>().UseCard(self, pos).Coroutine();
        }
    }
}