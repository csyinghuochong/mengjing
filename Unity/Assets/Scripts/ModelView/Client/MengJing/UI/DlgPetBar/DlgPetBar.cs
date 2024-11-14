using UnityEngine;

namespace ET.Client
{
    [ComponentOf(typeof(UIBaseWindow))]
    public class DlgPetBar : Entity, IAwake, IUILogic
    {
        public DlgPetBarViewComponent View { get => this.GetComponent<DlgPetBarViewComponent>(); }

        private EntityRef<ES_PetBarSet> m_es_petBarSet = null;

        public ES_PetBarSet ES_PetBarSet
        {
            get
            {
                ES_PetBarSet es = this.m_es_petBarSet;
                if (es == null)
                {
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>()
                            .LoadAssetSync<GameObject>("Assets/Bundles/UI/Common/ES_PetBarSet.prefab");
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.View.EG_SubViewRectTransform);
                    go.SetActive(false);
                    this.m_es_petBarSet = this.AddChild<ES_PetBarSet, Transform>(go.transform);
                }

                return this.m_es_petBarSet;
            }
        }

        private EntityRef<ES_PetBarUpgrade> m_es_petBarUpgrade = null;

        public ES_PetBarUpgrade ES_PetBarUpgrade
        {
            get
            {
                ES_PetBarUpgrade es = this.m_es_petBarUpgrade;
                if (es == null)
                {
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>()
                            .LoadAssetSync<GameObject>("Assets/Bundles/UI/Common/ES_PetBarUpgrade.prefab");
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.View.EG_SubViewRectTransform);
                    go.SetActive(false);
                    this.m_es_petBarUpgrade = this.AddChild<ES_PetBarUpgrade, Transform>(go.transform);
                }

                return this.m_es_petBarUpgrade;
            }
        }
    }
}