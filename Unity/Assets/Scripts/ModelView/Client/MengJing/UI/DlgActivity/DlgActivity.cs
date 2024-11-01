using UnityEngine;

namespace ET.Client
{
    [ComponentOf(typeof(UIBaseWindow))]
    public class DlgActivity : Entity, IAwake, IUILogic
    {
        public DlgActivityViewComponent View { get => this.GetComponent<DlgActivityViewComponent>(); }

        private EntityRef<ES_ActivityYueKa> m_es_activityyueka = null;

        public ES_ActivityYueKa ES_ActivityYueKa
        {
            get
            {
                ES_ActivityYueKa es = this.m_es_activityyueka;
                if (es == null)
                {
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>()
                            .LoadAssetSync<GameObject>("Assets/Bundles/UI/Common/ES_ActivityYueKa.prefab");
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.View.EG_SubViewRectTransform);
                    go.SetActive(false);
                    this.m_es_activityyueka = this.AddChild<ES_ActivityYueKa, Transform>(go.transform);
                }

                return this.m_es_activityyueka;
            }
        }

        private EntityRef<ES_ActivityMaoXian> m_es_activitymaoxian = null;

        public ES_ActivityMaoXian ES_ActivityMaoXian
        {
            get
            {
                ES_ActivityMaoXian es = this.m_es_activitymaoxian;
                if (es == null)
                {
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>()
                            .LoadAssetSync<GameObject>("Assets/Bundles/UI/Common/ES_ActivityMaoXian.prefab");
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.View.EG_SubViewRectTransform);
                    go.SetActive(false);
                    this.m_es_activitymaoxian = this.AddChild<ES_ActivityMaoXian, Transform>(go.transform);
                }

                return this.m_es_activitymaoxian;
            }
        }

        private EntityRef<ES_ActivityToken> m_es_activitytoken = null;

        public ES_ActivityToken ES_ActivityToken
        {
            get
            {
                ES_ActivityToken es = this.m_es_activitytoken;
                if (es == null)
                {
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>()
                            .LoadAssetSync<GameObject>("Assets/Bundles/UI/Common/ES_ActivityToken.prefab");
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.View.EG_SubViewRectTransform);
                    go.SetActive(false);
                    this.m_es_activitytoken = this.AddChild<ES_ActivityToken, Transform>(go.transform);
                }

                return this.m_es_activitytoken;
            }
        }

        private EntityRef<ES_ActivityTeHui> m_es_activitytehui = null;

        public ES_ActivityTeHui ES_ActivityTeHui
        {
            get
            {
                ES_ActivityTeHui es = this.m_es_activitytehui;
                if (es == null)
                {
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>()
                            .LoadAssetSync<GameObject>("Assets/Bundles/UI/Common/ES_ActivityTeHui.prefab");
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.View.EG_SubViewRectTransform);
                    go.SetActive(false);
                    this.m_es_activitytehui = this.AddChild<ES_ActivityTeHui, Transform>(go.transform);
                }

                return this.m_es_activitytehui;
            }
        }

        private EntityRef<ES_ActivitySingleRecharge> m_es_activitysinglerecharge = null;

        public ES_ActivitySingleRecharge ES_ActivitySingleRecharge
        {
            get
            {
                ES_ActivitySingleRecharge es = this.m_es_activitysinglerecharge;
                if (es == null)
                {
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>()
                            .LoadAssetSync<GameObject>("Assets/Bundles/UI/Common/ES_ActivitySingleRecharge.prefab");
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.View.EG_SubViewRectTransform);
                    go.SetActive(false);
                    this.m_es_activitysinglerecharge = this.AddChild<ES_ActivitySingleRecharge, Transform>(go.transform);
                }

                return this.m_es_activitysinglerecharge;
            }
        }
    }
}