using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(DlgNewYearViewComponent))]
    [ComponentOf(typeof(UIBaseWindow))]
    public class DlgNewYear : Entity, IAwake, IUILogic
    {
        public DlgNewYearViewComponent View { get => this.GetComponent<DlgNewYearViewComponent>(); }

        private EntityRef<ES_NewYearCollectionWord> m_es_newyearcollectionword = null;

        public ES_NewYearCollectionWord ES_NewYearCollectionWord
        {
            get
            {
                ES_NewYearCollectionWord es = this.m_es_newyearcollectionword;
                if (es == null)
                {
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>()
                            .LoadAssetSync<GameObject>("Assets/Bundles/UI/Common/ES_NewYearCollectionWord.prefab");
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.View.EG_SubViewRectTransform);
                    go.SetActive(false);
                    this.m_es_newyearcollectionword = this.AddChild<ES_NewYearCollectionWord, Transform>(go.transform);
                }

                return this.m_es_newyearcollectionword;
            }
        }

        private EntityRef<ES_NewYearMonster> m_es_newyearmonster = null;

        public ES_NewYearMonster ES_NewYearMonster
        {
            get
            {
                ES_NewYearMonster es = this.m_es_newyearmonster;
                if (es == null)
                {
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>()
                            .LoadAssetSync<GameObject>("Assets/Bundles/UI/Common/ES_NewYearMonster.prefab");
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.View.EG_SubViewRectTransform);
                    go.SetActive(false);
                    this.m_es_newyearmonster = this.AddChild<ES_NewYearMonster, Transform>(go.transform);
                }

                return this.m_es_newyearmonster;
            }
        }
    }
}