using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(DlgSettingViewComponent))]
    [ComponentOf(typeof(UIBaseWindow))]
    public class DlgSetting : Entity, IAwake, IUILogic
    {
        public DlgSettingViewComponent View { get => this.GetComponent<DlgSettingViewComponent>(); }

        private EntityRef<ES_SettingGame> m_es_settinggame = null;

        public ES_SettingGame ES_SettingGame
        {
            get
            {
                ES_SettingGame es = this.m_es_settinggame;
                if (es == null)
                {
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>()
                            .LoadAssetSync<GameObject>("Assets/Bundles/UI/Common/ES_SettingGame.prefab");
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.View.EG_SubViewRectTransform);
                    go.SetActive(false);
                    this.m_es_settinggame = this.AddChild<ES_SettingGame, Transform>(go.transform);
                }

                return this.m_es_settinggame;
            }
        }

        private EntityRef<ES_SettingTitle> m_es_settingtitle = null;

        public ES_SettingTitle ES_SettingTitle
        {
            get
            {
                ES_SettingTitle es = this.m_es_settingtitle;
                if (es == null)
                {
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>()
                            .LoadAssetSync<GameObject>("Assets/Bundles/UI/Common/ES_SettingTitle.prefab");
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.View.EG_SubViewRectTransform);
                    go.SetActive(false);
                    this.m_es_settingtitle = this.AddChild<ES_SettingTitle, Transform>(go.transform);
                }

                return this.m_es_settingtitle;
            }
        }

        private EntityRef<ES_SettingGuaJi> m_es_settingguaji = null;

        public ES_SettingGuaJi ES_SettingGuaJi
        {
            get
            {
                ES_SettingGuaJi es = this.m_es_settingguaji;
                if (es == null)
                {
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>()
                            .LoadAssetSync<GameObject>("Assets/Bundles/UI/Common/ES_SettingGuaJi.prefab");
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.View.EG_SubViewRectTransform);
                    go.SetActive(false);
                    this.m_es_settingguaji = this.AddChild<ES_SettingGuaJi, Transform>(go.transform);
                }

                return this.m_es_settingguaji;
            }
        }

        private EntityRef<ES_FashionShow> m_es_fashionshow = null;

        public ES_FashionShow ES_FashionShow
        {
            get
            {
                ES_FashionShow es = this.m_es_fashionshow;
                if (es == null)
                {
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>()
                            .LoadAssetSync<GameObject>("Assets/Bundles/UI/Common/ES_FashionShow.prefab");
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.View.EG_SubViewRectTransform);
                    go.SetActive(false);
                    this.m_es_fashionshow = this.AddChild<ES_FashionShow, Transform>(go.transform);
                }

                return this.m_es_fashionshow;
            }
        }
    }
}