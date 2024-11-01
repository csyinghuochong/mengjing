using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(DlgFenXiangViewComponent))]
    [ComponentOf(typeof(UIBaseWindow))]
    public class DlgFenXiang : Entity, IAwake, IUILogic
    {
        public DlgFenXiangViewComponent View { get => this.GetComponent<DlgFenXiangViewComponent>(); }

        private EntityRef<ES_FenXiangSet> m_es_fenxiangset = null;

        public ES_FenXiangSet ES_FenXiangSet
        {
            get
            {
                ES_FenXiangSet es = this.m_es_fenxiangset;
                if (es == null)
                {
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>()
                            .LoadAssetSync<GameObject>("Assets/Bundles/UI/Common/ES_FenXiangSet.prefab");
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.View.EG_SubViewRectTransform);
                    go.SetActive(false);
                    this.m_es_fenxiangset = this.AddChild<ES_FenXiangSet, Transform>(go.transform);
                }

                return this.m_es_fenxiangset;
            }
        }

        private EntityRef<ES_Popularize> m_es_popularize = null;

        public ES_Popularize ES_Popularize
        {
            get
            {
                ES_Popularize es = this.m_es_popularize;
                if (es == null)
                {
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>()
                            .LoadAssetSync<GameObject>("Assets/Bundles/UI/Common/ES_Popularize.prefab");
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.View.EG_SubViewRectTransform);
                    go.SetActive(false);
                    this.m_es_popularize = this.AddChild<ES_Popularize, Transform>(go.transform);
                }

                return this.m_es_popularize;
            }
        }

        private EntityRef<ES_Serial> m_es_serial = null;

        public ES_Serial ES_Serial
        {
            get
            {
                ES_Serial es = this.m_es_serial;
                if (es == null)
                {
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>()
                            .LoadAssetSync<GameObject>("Assets/Bundles/UI/Common/ES_Serial.prefab");
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.View.EG_SubViewRectTransform);
                    go.SetActive(false);
                    this.m_es_serial = this.AddChild<ES_Serial, Transform>(go.transform);
                }

                return this.m_es_serial;
            }
        }

        private EntityRef<ES_LunTan> m_es_luntan = null;

        public ES_LunTan ES_LunTan
        {
            get
            {
                ES_LunTan es = this.m_es_luntan;
                if (es == null)
                {
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>()
                            .LoadAssetSync<GameObject>("Assets/Bundles/UI/Common/ES_LunTan.prefab");
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.View.EG_SubViewRectTransform);
                    go.SetActive(false);
                    this.m_es_luntan = this.AddChild<ES_LunTan, Transform>(go.transform);
                }

                return this.m_es_luntan;
            }
        }

        private EntityRef<ES_FenXiangQQAddSet> m_es_fenxiangqqaddset = null;

        public ES_FenXiangQQAddSet ES_FenXiangQQAddSet
        {
            get
            {
                ES_FenXiangQQAddSet es = this.m_es_fenxiangqqaddset;
                if (es == null)
                {
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>()
                            .LoadAssetSync<GameObject>("Assets/Bundles/UI/Common/ES_FenXiangQQAddSet.prefab");
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.View.EG_SubViewRectTransform);
                    go.SetActive(false);
                    this.m_es_fenxiangqqaddset = this.AddChild<ES_FenXiangQQAddSet, Transform>(go.transform);
                }

                return this.m_es_fenxiangqqaddset;
            }
        }
    }
}