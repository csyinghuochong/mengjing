using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(DlgUnionMysteryViewComponent))]
    [ComponentOf(typeof(UIBaseWindow))]
    public class DlgUnionMystery : Entity, IAwake, IUILogic
    {
        public DlgUnionMysteryViewComponent View { get => this.GetComponent<DlgUnionMysteryViewComponent>(); }

        private EntityRef<ES_UnionMystery_A> m_es_unionmystery_a = null;

        public ES_UnionMystery_A ES_UnionMystery_A
        {
            get
            {
                ES_UnionMystery_A es = this.m_es_unionmystery_a;
                if (es == null)
                {
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>()
                            .LoadAssetSync<GameObject>("Assets/Bundles/UI/Common/ES_UnionMystery_A.prefab");
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.View.EG_SubViewRectTransform);
                    go.SetActive(false);
                    this.m_es_unionmystery_a = this.AddChild<ES_UnionMystery_A, Transform>(go.transform);
                }

                return this.m_es_unionmystery_a;
            }
        }

        private EntityRef<ES_UnionMystery_B> m_es_unionmystery_b = null;

        public ES_UnionMystery_B ES_UnionMystery_B
        {
            get
            {
                ES_UnionMystery_B es = this.m_es_unionmystery_b;
                if (es == null)
                {
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>()
                            .LoadAssetSync<GameObject>("Assets/Bundles/UI/Common/ES_UnionMystery_B.prefab");
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.View.EG_SubViewRectTransform);
                    go.SetActive(false);
                    this.m_es_unionmystery_b = this.AddChild<ES_UnionMystery_B, Transform>(go.transform);
                }

                return this.m_es_unionmystery_b;
            }
        }
    }
}