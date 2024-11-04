using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(DlgUnionKeJiViewComponent))]
    [ComponentOf(typeof(UIBaseWindow))]
    public class DlgUnionKeJi : Entity, IAwake, IUILogic
    {
        public DlgUnionKeJiViewComponent View { get => this.GetComponent<DlgUnionKeJiViewComponent>(); }

        private EntityRef<ES_UnionKeJiResearch> m_es_unionkejiresearch = null;

        public ES_UnionKeJiResearch ES_UnionKeJiResearch
        {
            get
            {
                ES_UnionKeJiResearch es = this.m_es_unionkejiresearch;
                if (es == null)
                {
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>()
                            .LoadAssetSync<GameObject>("Assets/Bundles/UI/Common/ES_UnionKeJiResearch.prefab");
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.View.EG_SubViewRectTransform);
                    go.SetActive(false);
                    this.m_es_unionkejiresearch = this.AddChild<ES_UnionKeJiResearch, Transform>(go.transform);
                }

                return this.m_es_unionkejiresearch;
            }
        }

        private EntityRef<ES_UnionKeJiLearn> m_es_unionkejilearn = null;

        public ES_UnionKeJiLearn ES_UnionKeJiLearn
        {
            get
            {
                ES_UnionKeJiLearn es = this.m_es_unionkejilearn;
                if (es == null)
                {
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>()
                            .LoadAssetSync<GameObject>("Assets/Bundles/UI/Common/ES_UnionKeJiLearn.prefab");
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.View.EG_SubViewRectTransform);
                    go.SetActive(false);
                    this.m_es_unionkejilearn = this.AddChild<ES_UnionKeJiLearn, Transform>(go.transform);
                }

                return this.m_es_unionkejilearn;
            }
        }
    }
}