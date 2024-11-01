using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(DlgJiaYuanMysteryViewComponent))]
    [ComponentOf(typeof(UIBaseWindow))]
    public class DlgJiaYuanMystery : Entity, IAwake, IUILogic
    {
        public DlgJiaYuanMysteryViewComponent View { get => this.GetComponent<DlgJiaYuanMysteryViewComponent>(); }
        
        private EntityRef<ES_JiaYuanMystery_A> m_es_jiayuanmystery_a = null;

        public ES_JiaYuanMystery_A ES_JiaYuanMystery_A
        {
            get
            {
                ES_JiaYuanMystery_A es = this.m_es_jiayuanmystery_a;
                if (es == null)
                {
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>()
                            .LoadAssetSync<GameObject>("Assets/Bundles/UI/Common/ES_JiaYuanMystery_A.prefab");
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.View.EG_SubViewRectTransform);
                    go.SetActive(false);
                    this.m_es_jiayuanmystery_a = this.AddChild<ES_JiaYuanMystery_A, Transform>(go.transform);
                }

                return this.m_es_jiayuanmystery_a;
            }
        }
        
        
        private EntityRef<ES_JiaYuanMystery_B> m_es_jiayuanmystery_b = null;

        public ES_JiaYuanMystery_B ES_JiaYuanMystery_B
        {
            get
            {
                ES_JiaYuanMystery_B es = this.m_es_jiayuanmystery_b;
                if (es == null)
                {
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>()
                            .LoadAssetSync<GameObject>("Assets/Bundles/UI/Common/ES_JiaYuanMystery_B.prefab");
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.View.EG_SubViewRectTransform);
                    go.SetActive(false);
                    this.m_es_jiayuanmystery_b = this.AddChild<ES_JiaYuanMystery_B, Transform>(go.transform);
                }

                return this.m_es_jiayuanmystery_b;
            }
        }
    }
}