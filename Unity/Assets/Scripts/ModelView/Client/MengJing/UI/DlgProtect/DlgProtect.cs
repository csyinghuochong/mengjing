using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(DlgProtectViewComponent))]
    [ComponentOf(typeof(UIBaseWindow))]
    public class DlgProtect : Entity, IAwake, IUILogic
    {
        public DlgProtectViewComponent View { get => this.GetComponent<DlgProtectViewComponent>(); }

        private EntityRef<ES_ProtectEquip> m_es_protectequip = null;

        public ES_ProtectEquip ES_ProtectEquip
        {
            get
            {
                ES_ProtectEquip es = this.m_es_protectequip;
                if (es == null)
                {
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>()
                            .LoadAssetSync<GameObject>("Assets/Bundles/UI/Common/ES_ProtectEquip.prefab");
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.View.EG_SubViewRectTransform);
                    go.SetActive(false);
                    this.m_es_protectequip = this.AddChild<ES_ProtectEquip, Transform>(go.transform);
                }

                return this.m_es_protectequip;
            }
        }

        private EntityRef<ES_ProtectPet> m_es_protectpet = null;

        public ES_ProtectPet ES_ProtectPet
        {
            get
            {
                ES_ProtectPet es = this.m_es_protectpet;
                if (es == null)
                {
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>()
                            .LoadAssetSync<GameObject>("Assets/Bundles/UI/Common/ES_ProtectPet.prefab");
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.View.EG_SubViewRectTransform);
                    go.SetActive(false);
                    this.m_es_protectpet = this.AddChild<ES_ProtectPet, Transform>(go.transform);
                }

                return this.m_es_protectpet;
            }
        }
    }
}