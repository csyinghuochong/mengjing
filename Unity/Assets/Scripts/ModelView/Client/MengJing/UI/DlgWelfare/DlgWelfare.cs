using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(DlgWelfareViewComponent))]
    [ComponentOf(typeof(UIBaseWindow))]
    public class DlgWelfare : Entity, IAwake, IUILogic
    {
        public DlgWelfareViewComponent View { get => this.GetComponent<DlgWelfareViewComponent>(); }

        private EntityRef<ES_ActivityLogin> m_es_activitylogin = null;

        public ES_ActivityLogin ES_ActivityLogin
        {
            get
            {
                ES_ActivityLogin es = this.m_es_activitylogin;
                if (es == null)
                {
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>()
                            .LoadAssetSync<GameObject>("Assets/Bundles/UI/Common/ES_ActivityLogin.prefab");
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.View.EG_SubViewRectTransform);
                    go.SetActive(false);
                    this.m_es_activitylogin = this.AddChild<ES_ActivityLogin, Transform>(go.transform);
                }

                return this.m_es_activitylogin;
            }
        }

        private EntityRef<ES_WelfareTask> m_es_welfaretask = null;

        public ES_WelfareTask ES_WelfareTask
        {
            get
            {
                ES_WelfareTask es = this.m_es_welfaretask;
                if (es == null)
                {
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>()
                            .LoadAssetSync<GameObject>("Assets/Bundles/UI/Common/ES_WelfareTask.prefab");
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.View.EG_SubViewRectTransform);
                    go.SetActive(false);
                    this.m_es_welfaretask = this.AddChild<ES_WelfareTask, Transform>(go.transform);
                }

                return this.m_es_welfaretask;
            }
        }

        private EntityRef<ES_WelfareDraw> m_es_welfaredraw = null;

        public ES_WelfareDraw ES_WelfareDraw
        {
            get
            {
                ES_WelfareDraw es = this.m_es_welfaredraw;
                if (es == null)
                {
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>()
                            .LoadAssetSync<GameObject>("Assets/Bundles/UI/Common/ES_WelfareDraw.prefab");
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.View.EG_SubViewRectTransform);
                    go.SetActive(false);
                    this.m_es_welfaredraw = this.AddChild<ES_WelfareDraw, Transform>(go.transform);
                }

                return this.m_es_welfaredraw;
            }
        }

        private EntityRef<ES_WelfareInvest> m_es_welfareinvest = null;

        public ES_WelfareInvest ES_WelfareInvest
        {
            get
            {
                ES_WelfareInvest es = this.m_es_welfareinvest;
                if (es == null)
                {
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>()
                            .LoadAssetSync<GameObject>("Assets/Bundles/UI/Common/ES_WelfareInvest.prefab");
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.View.EG_SubViewRectTransform);
                    go.SetActive(false);
                    this.m_es_welfareinvest = this.AddChild<ES_WelfareInvest, Transform>(go.transform);
                }

                return this.m_es_welfareinvest;
            }
        }

        private EntityRef<ES_WelfareDraw2> m_es_welfaredraw2 = null;

        public ES_WelfareDraw2 ES_WelfareDraw2
        {
            get
            {
                ES_WelfareDraw2 es = this.m_es_welfaredraw2;
                if (es == null)
                {
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>()
                            .LoadAssetSync<GameObject>("Assets/Bundles/UI/Common/ES_WelfareDraw2.prefab");
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.View.EG_SubViewRectTransform);
                    go.SetActive(false);
                    this.m_es_welfaredraw2 = this.AddChild<ES_WelfareDraw2, Transform>(go.transform);
                }

                return this.m_es_welfaredraw2;
            }
        }
    }
}