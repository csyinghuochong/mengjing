using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(DlgSeasonViewComponent))]
    [ComponentOf(typeof(UIBaseWindow))]
    public class DlgSeason : Entity, IAwake, IUILogic
    {
        public DlgSeasonViewComponent View { get => this.GetComponent<DlgSeasonViewComponent>(); }

        private EntityRef<ES_SeasonHome> m_es_seasonhome = null;

        public ES_SeasonHome ES_SeasonHome
        {
            get
            {
                ES_SeasonHome es = this.m_es_seasonhome;
                if (es == null)
                {
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>()
                            .LoadAssetSync<GameObject>("Assets/Bundles/UI/Common/ES_SeasonHome.prefab");
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.View.EG_SubViewRectTransform);
                    go.SetActive(false);
                    this.m_es_seasonhome = this.AddChild<ES_SeasonHome, Transform>(go.transform);
                }

                return this.m_es_seasonhome;
            }
        }

        private EntityRef<ES_SeasonTask> m_es_seasontask = null;

        public ES_SeasonTask ES_SeasonTask
        {
            get
            {
                ES_SeasonTask es = this.m_es_seasontask;
                if (es == null)
                {
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>()
                            .LoadAssetSync<GameObject>("Assets/Bundles/UI/Common/ES_SeasonTask.prefab");
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.View.EG_SubViewRectTransform);
                    go.SetActive(false);
                    this.m_es_seasontask = this.AddChild<ES_SeasonTask, Transform>(go.transform);
                }

                return this.m_es_seasontask;
            }
        }

        private EntityRef<ES_SeasonJingHe> m_es_seasonjinghe = null;

        public ES_SeasonJingHe ES_SeasonJingHe
        {
            get
            {
                ES_SeasonJingHe es = this.m_es_seasonjinghe;
                if (es == null)
                {
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>()
                            .LoadAssetSync<GameObject>("Assets/Bundles/UI/Common/ES_SeasonJingHe.prefab");
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.View.EG_SubViewRectTransform);
                    go.SetActive(false);
                    this.m_es_seasonjinghe = this.AddChild<ES_SeasonJingHe, Transform>(go.transform);
                }

                return this.m_es_seasonjinghe;
            }
        }

        private EntityRef<ES_SeasonStore> m_es_seasonstore = null;

        public ES_SeasonStore ES_SeasonStore
        {
            get
            {
                ES_SeasonStore es = this.m_es_seasonstore;
                if (es == null)
                {
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>()
                            .LoadAssetSync<GameObject>("Assets/Bundles/UI/Common/ES_SeasonStore.prefab");
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.View.EG_SubViewRectTransform);
                    go.SetActive(false);
                    this.m_es_seasonstore = this.AddChild<ES_SeasonStore, Transform>(go.transform);
                }

                return this.m_es_seasonstore;
            }
        }

        private EntityRef<ES_SeasonTower> m_es_seasontower = null;

        public ES_SeasonTower ES_SeasonTower
        {
            get
            {
                ES_SeasonTower es = this.m_es_seasontower;
                if (es == null)
                {
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>()
                            .LoadAssetSync<GameObject>("Assets/Bundles/UI/Common/ES_SeasonTower.prefab");
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.View.EG_SubViewRectTransform);
                    go.SetActive(false);
                    this.m_es_seasontower = this.AddChild<ES_SeasonTower, Transform>(go.transform);
                }

                return this.m_es_seasontower;
            }
        }
    }
}