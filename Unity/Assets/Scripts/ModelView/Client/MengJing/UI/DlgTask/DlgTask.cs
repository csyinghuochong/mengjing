using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(DlgTaskViewComponent))]
    [ComponentOf(typeof(UIBaseWindow))]
    public class DlgTask : Entity, IAwake, IUILogic
    {
        public DlgTaskViewComponent View { get => this.GetComponent<DlgTaskViewComponent>(); }

        private EntityRef<ES_TaskDetail> m_es_taskdetail = null;

        public ES_TaskDetail ES_TaskDetail
        {
            get
            {
                ES_TaskDetail es = this.m_es_taskdetail;
                if (es == null)
                {
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>()
                            .LoadAssetSync<GameObject>("Assets/Bundles/UI/Common/ES_TaskDetail.prefab");
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.View.EG_SubViewRectTransform);
                    go.SetActive(false);
                    this.m_es_taskdetail = this.AddChild<ES_TaskDetail, Transform>(go.transform);
                }

                return this.m_es_taskdetail;
            }
        }

        private EntityRef<ES_TaskGrowUp> m_es_taskgrowup = null;

        public ES_TaskGrowUp ES_TaskGrowUp
        {
            get
            {
                ES_TaskGrowUp es = this.m_es_taskgrowup;
                if (es == null)
                {
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>()
                            .LoadAssetSync<GameObject>("Assets/Bundles/UI/Common/ES_TaskGrowUp.prefab");
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.View.EG_SubViewRectTransform);
                    go.SetActive(false);
                    this.m_es_taskgrowup = this.AddChild<ES_TaskGrowUp, Transform>(go.transform);
                }

                return this.m_es_taskgrowup;
            }
        }
    }
}