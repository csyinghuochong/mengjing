using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(DlgZhanQuViewComponent))]
    [ComponentOf(typeof(UIBaseWindow))]
    public class DlgZhanQu : Entity, IAwake, IUILogic
    {
        public DlgZhanQuViewComponent View { get => this.GetComponent<DlgZhanQuViewComponent>(); }

        private EntityRef<ES_ZhanQuLevel> m_es_zhanqulevel = null;

        public ES_ZhanQuLevel ES_ZhanQuLevel
        {
            get
            {
                ES_ZhanQuLevel es = this.m_es_zhanqulevel;
                if (es == null)
                {
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>()
                            .LoadAssetSync<GameObject>("Assets/Bundles/UI/Common/ES_ZhanQuLevel.prefab");
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.View.EG_SubViewRectTransform);
                    go.SetActive(false);
                    this.m_es_zhanqulevel = this.AddChild<ES_ZhanQuLevel, Transform>(go.transform);
                }

                return this.m_es_zhanqulevel;
            }
        }

        private EntityRef<ES_ZhanQuCombat> m_es_zhanqucombat = null;

        public ES_ZhanQuCombat ES_ZhanQuCombat
        {
            get
            {
                ES_ZhanQuCombat es = this.m_es_zhanqucombat;
                if (es == null)
                {
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>()
                            .LoadAssetSync<GameObject>("Assets/Bundles/UI/Common/ES_ZhanQuCombat.prefab");
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.View.EG_SubViewRectTransform);
                    go.SetActive(false);
                    this.m_es_zhanqucombat = this.AddChild<ES_ZhanQuCombat, Transform>(go.transform);
                }

                return this.m_es_zhanqucombat;
            }
        }

        private EntityRef<ES_FirstWin> m_es_firstwin = null;

        public ES_FirstWin ES_FirstWin
        {
            get
            {
                ES_FirstWin es = this.m_es_firstwin;
                if (es == null)
                {
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>()
                            .LoadAssetSync<GameObject>("Assets/Bundles/UI/Common/ES_FirstWin.prefab");
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.View.EG_SubViewRectTransform);
                    go.SetActive(false);
                    this.m_es_firstwin = this.AddChild<ES_FirstWin, Transform>(go.transform);
                }

                return this.m_es_firstwin;
            }
        }
    }
}