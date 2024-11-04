using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(DlgRankViewComponent))]
    [ComponentOf(typeof(UIBaseWindow))]
    public class DlgRank : Entity, IAwake, IUILogic
    {
        public DlgRankViewComponent View { get => this.GetComponent<DlgRankViewComponent>(); }

        private EntityRef<ES_RankShow> m_es_rankshow = null;

        public ES_RankShow ES_RankShow
        {
            get
            {
                ES_RankShow es = this.m_es_rankshow;
                if (es == null)
                {
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>()
                            .LoadAssetSync<GameObject>("Assets/Bundles/UI/Common/ES_RankShow.prefab");
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.View.EG_SubViewRectTransform);
                    go.SetActive(false);
                    this.m_es_rankshow = this.AddChild<ES_RankShow, Transform>(go.transform);
                }

                return this.m_es_rankshow;
            }
        }

        private EntityRef<ES_RankPet> m_es_rankpet = null;

        public ES_RankPet ES_RankPet
        {
            get
            {
                ES_RankPet es = this.m_es_rankpet;
                if (es == null)
                {
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>()
                            .LoadAssetSync<GameObject>("Assets/Bundles/UI/Common/ES_RankPet.prefab");
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.View.EG_SubViewRectTransform);
                    go.SetActive(false);
                    this.m_es_rankpet = this.AddChild<ES_RankPet, Transform>(go.transform);
                }

                return this.m_es_rankpet;
            }
        }

        private EntityRef<ES_RankReward> m_es_rankreward = null;

        public ES_RankReward ES_RankReward
        {
            get
            {
                ES_RankReward es = this.m_es_rankreward;
                if (es == null)
                {
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>()
                            .LoadAssetSync<GameObject>("Assets/Bundles/UI/Common/ES_RankReward.prefab");
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.View.EG_SubViewRectTransform);
                    go.SetActive(false);
                    this.m_es_rankreward = this.AddChild<ES_RankReward, Transform>(go.transform);
                }

                return this.m_es_rankreward;
            }
        }

        private EntityRef<ES_RankPetReward> m_es_rankpetreward = null;

        public ES_RankPetReward ES_RankPetReward
        {
            get
            {
                ES_RankPetReward es = this.m_es_rankpetreward;
                if (es == null)
                {
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>()
                            .LoadAssetSync<GameObject>("Assets/Bundles/UI/Common/ES_RankPetReward.prefab");
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.View.EG_SubViewRectTransform);
                    go.SetActive(false);
                    this.m_es_rankpetreward = this.AddChild<ES_RankPetReward, Transform>(go.transform);
                }

                return this.m_es_rankpetreward;
            }
        }
    }
}