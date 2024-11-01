using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(DlgChengJiuViewComponent))]
    [ComponentOf(typeof(UIBaseWindow))]
    public class DlgChengJiu : Entity, IAwake, IUILogic
    {
        public DlgChengJiuViewComponent View { get => this.GetComponent<DlgChengJiuViewComponent>(); }

        private EntityRef<ES_ChengJiuReward> m_es_chengjiureward = null;

        public ES_ChengJiuReward ES_ChengJiuReward
        {
            get
            {
                ES_ChengJiuReward es = this.m_es_chengjiureward;
                if (es == null)
                {
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>()
                            .LoadAssetSync<GameObject>("Assets/Bundles/UI/Common/ES_ChengJiuReward.prefab");
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.View.EG_SubViewRectTransform);
                    go.SetActive(false);
                    this.m_es_chengjiureward = this.AddChild<ES_ChengJiuReward, Transform>(go.transform);
                }

                return this.m_es_chengjiureward;
            }
        }

        private EntityRef<ES_ChengJiuShow> m_es_chengjiushow = null;

        public ES_ChengJiuShow ES_ChengJiuShow
        {
            get
            {
                ES_ChengJiuShow es = this.m_es_chengjiushow;
                if (es == null)
                {
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>()
                            .LoadAssetSync<GameObject>("Assets/Bundles/UI/Common/ES_ChengJiuShow.prefab");
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.View.EG_SubViewRectTransform);
                    go.SetActive(false);
                    this.m_es_chengjiushow = this.AddChild<ES_ChengJiuShow, Transform>(go.transform);
                }

                return this.m_es_chengjiushow;
            }
        }

        private EntityRef<ES_ChengJiuJingling> m_es_chengjiujingling = null;

        public ES_ChengJiuJingling ES_ChengJiuJingling
        {
            get
            {
                ES_ChengJiuJingling es = this.m_es_chengjiujingling;
                if (es == null)
                {
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>()
                            .LoadAssetSync<GameObject>("Assets/Bundles/UI/Common/ES_ChengJiuJingling.prefab");
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.View.EG_SubViewRectTransform);
                    go.SetActive(false);
                    this.m_es_chengjiujingling = this.AddChild<ES_ChengJiuJingling, Transform>(go.transform);
                }

                return this.m_es_chengjiujingling;
            }
        }

        private EntityRef<ES_PetTuJian> m_es_pettujian = null;

        public ES_PetTuJian ES_PetTuJian
        {
            get
            {
                ES_PetTuJian es = this.m_es_pettujian;
                if (es == null)
                {
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>()
                            .LoadAssetSync<GameObject>("Assets/Bundles/UI/Common/ES_PetTuJian.prefab");
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.View.EG_SubViewRectTransform);
                    go.SetActive(false);
                    this.m_es_pettujian = this.AddChild<ES_PetTuJian, Transform>(go.transform);
                }

                return this.m_es_pettujian;
            }
        }
    }
}