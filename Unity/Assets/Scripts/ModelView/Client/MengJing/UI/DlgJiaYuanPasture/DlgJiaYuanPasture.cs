using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(DlgJiaYuanPastureViewComponent))]
    [ComponentOf(typeof(UIBaseWindow))]
    public class DlgJiaYuanPasture : Entity, IAwake, IUILogic
    {
        public DlgJiaYuanPastureViewComponent View { get => this.GetComponent<DlgJiaYuanPastureViewComponent>(); }

        private EntityRef<ES_JiaYuanPasture_A> m_es_jiayuanpasture_a = null;

        public ES_JiaYuanPasture_A ES_JiaYuanPasture_A
        {
            get
            {
                ES_JiaYuanPasture_A es = this.m_es_jiayuanpasture_a;
                if (es == null)
                {
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>()
                            .LoadAssetSync<GameObject>("Assets/Bundles/UI/Common/ES_JiaYuanPasture_A.prefab");
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.View.EG_SubViewRectTransform);
                    go.SetActive(false);
                    this.m_es_jiayuanpasture_a = this.AddChild<ES_JiaYuanPasture_A, Transform>(go.transform);
                }

                return this.m_es_jiayuanpasture_a;
            }
        }

        private EntityRef<ES_JiaYuanPasture_B> m_es_jiayuanpasture_b = null;

        public ES_JiaYuanPasture_B ES_JiaYuanPasture_B
        {
            get
            {
                ES_JiaYuanPasture_B es = this.m_es_jiayuanpasture_b;
                if (es == null)
                {
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>()
                            .LoadAssetSync<GameObject>("Assets/Bundles/UI/Common/ES_JiaYuanPasture_B.prefab");
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.View.EG_SubViewRectTransform);
                    go.SetActive(false);
                    this.m_es_jiayuanpasture_b = this.AddChild<ES_JiaYuanPasture_B, Transform>(go.transform);
                }

                return this.m_es_jiayuanpasture_b;
            }
        }
    }
}