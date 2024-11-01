using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(DlgCountryViewComponent))]
    [ComponentOf(typeof(UIBaseWindow))]
    public class DlgCountry : Entity, IAwake, IUILogic
    {
        public DlgCountryViewComponent View { get => this.GetComponent<DlgCountryViewComponent>(); }

        private EntityRef<ES_CountryTask> m_es_countrytask = null;

        public ES_CountryTask ES_CountryTask
        {
            get
            {
                ES_CountryTask es = this.m_es_countrytask;
                if (es == null)
                {
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>()
                            .LoadAssetSync<GameObject>("Assets/Bundles/UI/Common/ES_CountryTask.prefab");
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.View.EG_SubViewRectTransform);
                    go.SetActive(false);
                    this.m_es_countrytask = this.AddChild<ES_CountryTask, Transform>(go.transform);
                }

                return this.m_es_countrytask;
            }
        }
        
        private EntityRef<ES_CountryHuoDong> m_es_countryhuodong = null;

        public ES_CountryHuoDong ES_CountryHuoDong
        {
            get
            {
                ES_CountryHuoDong es = this.m_es_countryhuodong;
                if (es == null)
                {
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>()
                            .LoadAssetSync<GameObject>("Assets/Bundles/UI/Common/ES_CountryHuoDong.prefab");
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.View.EG_SubViewRectTransform);
                    go.SetActive(false);
                    this.m_es_countryhuodong = this.AddChild<ES_CountryHuoDong, Transform>(go.transform);
                }

                return this.m_es_countryhuodong;
            }
        }
        
        private EntityRef<ES_ActivitySingIn> m_es_activitysingin = null;

        public ES_ActivitySingIn ES_ActivitySingIn
        {
            get
            {
                ES_ActivitySingIn es = this.m_es_activitysingin;
                if (es == null)
                {
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>()
                            .LoadAssetSync<GameObject>("Assets/Bundles/UI/Common/ES_ActivitySingIn.prefab");
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.View.EG_SubViewRectTransform);
                    go.SetActive(false);
                    this.m_es_activitysingin = this.AddChild<ES_ActivitySingIn, Transform>(go.transform);
                }

                return this.m_es_activitysingin;
            }
        }
    }
}