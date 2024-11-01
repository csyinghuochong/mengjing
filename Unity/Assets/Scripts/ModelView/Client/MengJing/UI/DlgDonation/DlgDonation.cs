using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(ES_RoleBag))]
    [ComponentOf(typeof(UIBaseWindow))]
    public class DlgDonation : Entity, IAwake, IUILogic
    {
        public DlgDonationViewComponent View { get => this.GetComponent<DlgDonationViewComponent>(); }

        private EntityRef<ES_DonationShow> m_es_donationshow = null;

        public ES_DonationShow ES_DonationShow
        {
            get
            {
                ES_DonationShow es = this.m_es_donationshow;
                if (es == null)
                {
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>()
                            .LoadAssetSync<GameObject>("Assets/Bundles/UI/Common/ES_DonationShow.prefab");
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.View.EG_SubViewRectTransform);
                    go.SetActive(false);
                    this.m_es_donationshow = this.AddChild<ES_DonationShow, Transform>(go.transform);
                }

                return this.m_es_donationshow;
            }
        }

        private EntityRef<ES_DonationUnion> m_es_donationunion = null;

        public ES_DonationUnion ES_DonationUnion
        {
            get
            {
                ES_DonationUnion es = this.m_es_donationunion;
                if (es == null)
                {
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>()
                            .LoadAssetSync<GameObject>("Assets/Bundles/UI/Common/ES_DonationUnion.prefab");
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.View.EG_SubViewRectTransform);
                    go.SetActive(false);
                    this.m_es_donationunion = this.AddChild<ES_DonationUnion, Transform>(go.transform);
                }

                return this.m_es_donationunion;
            }
        }

        private EntityRef<ES_RankUnion> m_es_rankunion = null;

        public ES_RankUnion ES_RankUnion
        {
            get
            {
                ES_RankUnion es = this.m_es_rankunion;
                if (es == null)
                {
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>()
                            .LoadAssetSync<GameObject>("Assets/Bundles/UI/Common/ES_RankUnion.prefab");
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.View.EG_SubViewRectTransform);
                    go.SetActive(false);
                    this.m_es_rankunion = this.AddChild<ES_RankUnion, Transform>(go.transform);
                }

                return this.m_es_rankunion;
            }
        }
    }
}