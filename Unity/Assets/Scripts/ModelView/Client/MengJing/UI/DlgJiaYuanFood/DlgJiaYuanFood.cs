using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(DlgJiaYuanFoodViewComponent))]
    [ComponentOf(typeof(UIBaseWindow))]
    public class DlgJiaYuanFood : Entity, IAwake, IUILogic
    {
        public DlgJiaYuanFoodViewComponent View { get => this.GetComponent<DlgJiaYuanFoodViewComponent>(); }

        private EntityRef<ES_JiaYuanPurchase> m_es_jiayuanpurchase = null;

        public ES_JiaYuanPurchase ES_JiaYuanPurchase
        {
            get
            {
                ES_JiaYuanPurchase es = this.m_es_jiayuanpurchase;
                if (es == null)
                {
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>()
                            .LoadAssetSync<GameObject>("Assets/Bundles/UI/Common/ES_JiaYuanPurchase.prefab");
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.View.EG_SubViewRectTransform);
                    go.SetActive(false);
                    this.m_es_jiayuanpurchase = this.AddChild<ES_JiaYuanPurchase, Transform>(go.transform);
                }

                return this.m_es_jiayuanpurchase;
            }
        }

        private EntityRef<ES_JiaYuanCooking> m_es_jiayuancooking = null;

        public ES_JiaYuanCooking ES_JiaYuanCooking
        {
            get
            {
                ES_JiaYuanCooking es = this.m_es_jiayuancooking;
                if (es == null)
                {
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>()
                            .LoadAssetSync<GameObject>("Assets/Bundles/UI/Common/ES_JiaYuanCooking.prefab");
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.View.EG_SubViewRectTransform);
                    go.SetActive(false);
                    this.m_es_jiayuancooking = this.AddChild<ES_JiaYuanCooking, Transform>(go.transform);
                }

                return this.m_es_jiayuancooking;
            }
        }

        private EntityRef<ES_JiaYuanCookbook> m_es_jiayuancookbook = null;

        public ES_JiaYuanCookbook ES_JiaYuanCookbook
        {
            get
            {
                ES_JiaYuanCookbook es = this.m_es_jiayuancookbook;
                if (es == null)
                {
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>()
                            .LoadAssetSync<GameObject>("Assets/Bundles/UI/Common/ES_JiaYuanCookbook.prefab");
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.View.EG_SubViewRectTransform);
                    go.SetActive(false);
                    this.m_es_jiayuancookbook = this.AddChild<ES_JiaYuanCookbook, Transform>(go.transform);
                }

                return this.m_es_jiayuancookbook;
            }
        }
    }
}