using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(DlgHuntViewComponent))]
    [ComponentOf(typeof(UIBaseWindow))]
    public class DlgHunt : Entity, IAwake, IUILogic
    {
        public DlgHuntViewComponent View { get => this.GetComponent<DlgHuntViewComponent>(); }

        private EntityRef<ES_HuntRanking> m_es_huntranking = null;

        public ES_HuntRanking ES_HuntRanking
        {
            get
            {
                ES_HuntRanking es = this.m_es_huntranking;
                if (es == null)
                {
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>()
                            .LoadAssetSync<GameObject>("Assets/Bundles/UI/Common/ES_HuntRanking.prefab");
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.View.EG_SubViewRectTransform);
                    go.SetActive(false);
                    this.m_es_huntranking = this.AddChild<ES_HuntRanking, Transform>(go.transform);
                }

                return this.m_es_huntranking;
            }
        }

        private EntityRef<ES_HuntTask> m_es_hunttask = null;

        public ES_HuntTask ES_HuntTask
        {
            get
            {
                ES_HuntTask es = this.m_es_hunttask;
                if (es == null)
                {
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>()
                            .LoadAssetSync<GameObject>("Assets/Bundles/UI/Common/ES_HuntTask.prefab");
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.View.EG_SubViewRectTransform);
                    go.SetActive(false);
                    this.m_es_hunttask = this.AddChild<ES_HuntTask, Transform>(go.transform);
                }

                return this.m_es_hunttask;
            }
        }
    }
}