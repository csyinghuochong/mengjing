using UnityEngine;

namespace ET.Client
{
    [ComponentOf(typeof(UIBaseWindow))]
    public class DlgPetMelee : Entity, IAwake, IUILogic
    {
        public DlgPetMeleeViewComponent View { get => this.GetComponent<DlgPetMeleeViewComponent>(); }

        private EntityRef<ES_PetMeleeSet> m_es_petMeleeSet = null;

        public ES_PetMeleeSet ES_PetMeleeSet
        {
            get
            {
                ES_PetMeleeSet es = this.m_es_petMeleeSet;
                if (es == null)
                {
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>()
                            .LoadAssetSync<GameObject>("Assets/Bundles/UI/Common/ES_PetMeleeSet.prefab");
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.View.EG_SubViewRectTransform);
                    go.SetActive(false);
                    this.m_es_petMeleeSet = this.AddChild<ES_PetMeleeSet, Transform>(go.transform);
                }

                return this.m_es_petMeleeSet;
            }
        }
    }
}