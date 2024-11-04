using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(DlgPetSetViewComponent))]
    [ComponentOf(typeof(UIBaseWindow))]
    public class DlgPetSet : Entity, IAwake, IUILogic
    {
        public DlgPetSetViewComponent View { get => this.GetComponent<DlgPetSetViewComponent>(); }

        private EntityRef<ES_PetChallenge> m_es_petchallenge = null;

        public ES_PetChallenge ES_PetChallenge
        {
            get
            {
                ES_PetChallenge es = this.m_es_petchallenge;
                if (es == null)
                {
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>()
                            .LoadAssetSync<GameObject>("Assets/Bundles/UI/Common/ES_PetChallenge.prefab");
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.View.EG_SubViewRectTransform);
                    go.SetActive(false);
                    this.m_es_petchallenge = this.AddChild<ES_PetChallenge, Transform>(go.transform);
                }

                return this.m_es_petchallenge;
            }
        }

        private EntityRef<ES_PetMining> m_es_petmining = null;

        public ES_PetMining ES_PetMining
        {
            get
            {
                ES_PetMining es = this.m_es_petmining;
                if (es == null)
                {
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>()
                            .LoadAssetSync<GameObject>("Assets/Bundles/UI/Common/ES_PetMining.prefab");
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.View.EG_SubViewRectTransform);
                    go.SetActive(false);
                    this.m_es_petmining = this.AddChild<ES_PetMining, Transform>(go.transform);
                }

                return this.m_es_petmining;
            }
        }
    }
}