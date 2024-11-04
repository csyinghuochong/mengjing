using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(DlgTrialViewComponent))]
    [ComponentOf(typeof(UIBaseWindow))]
    public class DlgTrial : Entity, IAwake, IUILogic
    {
        public DlgTrialViewComponent View { get => this.GetComponent<DlgTrialViewComponent>(); }

        private EntityRef<ES_TrialDungeon> m_es_trialdungeon = null;

        public ES_TrialDungeon ES_TrialDungeon
        {
            get
            {
                ES_TrialDungeon es = this.m_es_trialdungeon;
                if (es == null)
                {
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>()
                            .LoadAssetSync<GameObject>("Assets/Bundles/UI/Common/ES_TrialDungeon.prefab");
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.View.EG_SubViewRectTransform);
                    go.SetActive(false);
                    this.m_es_trialdungeon = this.AddChild<ES_TrialDungeon, Transform>(go.transform);
                }

                return this.m_es_trialdungeon;
            }
        }

        private EntityRef<ES_TrialRank> m_es_trialrank = null;

        public ES_TrialRank ES_TrialRank
        {
            get
            {
                ES_TrialRank es = this.m_es_trialrank;
                if (es == null)
                {
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>()
                            .LoadAssetSync<GameObject>("Assets/Bundles/UI/Common/ES_TrialRank.prefab");
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.View.EG_SubViewRectTransform);
                    go.SetActive(false);
                    this.m_es_trialrank = this.AddChild<ES_TrialRank, Transform>(go.transform);
                }

                return this.m_es_trialrank;
            }
        }
    }
}