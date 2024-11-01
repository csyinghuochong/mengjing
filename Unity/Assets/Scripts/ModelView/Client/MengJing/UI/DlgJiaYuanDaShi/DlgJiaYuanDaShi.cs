using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(DlgJiaYuanDaShiViewComponent))]
    [ComponentOf(typeof(UIBaseWindow))]
    public class DlgJiaYuanDaShi : Entity, IAwake, IUILogic
    {
        public DlgJiaYuanDaShiViewComponent View { get => this.GetComponent<DlgJiaYuanDaShiViewComponent>(); }

        private EntityRef<ES_JiaYuanDaShiPro> m_es_jiayuandashipro = null;

        public ES_JiaYuanDaShiPro ES_JiaYuanDaShiPro
        {
            get
            {
                ES_JiaYuanDaShiPro es = this.m_es_jiayuandashipro;
                if (es == null)
                {
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>()
                            .LoadAssetSync<GameObject>("Assets/Bundles/UI/Common/ES_JiaYuanDaShiPro.prefab");
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.View.EG_SubViewRectTransform);
                    go.SetActive(false);
                    this.m_es_jiayuandashipro = this.AddChild<ES_JiaYuanDaShiPro, Transform>(go.transform);
                }

                return this.m_es_jiayuandashipro;
            }
        }

        private EntityRef<ES_JiaYuanDaShiShow> m_es_jiayuandashishow = null;

        public ES_JiaYuanDaShiShow ES_JiaYuanDaShiShow
        {
            get
            {
                ES_JiaYuanDaShiShow es = this.m_es_jiayuandashishow;
                if (es == null)
                {
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>()
                            .LoadAssetSync<GameObject>("Assets/Bundles/UI/Common/ES_JiaYuanDaShiShow.prefab");
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.View.EG_SubViewRectTransform);
                    go.SetActive(false);
                    this.m_es_jiayuandashishow = this.AddChild<ES_JiaYuanDaShiShow, Transform>(go.transform);
                }

                return this.m_es_jiayuandashishow;
            }
        }
    }
}