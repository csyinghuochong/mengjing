using UnityEngine;

namespace ET.Client
{
    [ComponentOf(typeof(UIBaseWindow))]
    public class DlgSkill : Entity, IAwake, IUILogic
    {
        public DlgSkillViewComponent View { get => this.GetComponent<DlgSkillViewComponent>(); }

        private EntityRef<ES_SkillLearn> m_es_skilllearn = null;

        public ES_SkillLearn ES_SkillLearn
        {
            get
            {
                ES_SkillLearn es = this.m_es_skilllearn;
                if (es == null)
                {
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>()
                            .LoadAssetSync<GameObject>("Assets/Bundles/UI/Common/ES_SkillLearn.prefab");
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.View.EG_SubViewNodeRectTransform);
                    go.SetActive(false);
                    this.m_es_skilllearn = this.AddChild<ES_SkillLearn, Transform>(go.transform);
                }

                return this.m_es_skilllearn;
            }
        }

        private EntityRef<ES_SkillSet> m_es_skillset = null;

        public ES_SkillSet ES_SkillSet
        {
            get
            {
                ES_SkillSet es = this.m_es_skillset;
                if (es == null)
                {
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>()
                            .LoadAssetSync<GameObject>("Assets/Bundles/UI/Common/ES_SkillSet.prefab");
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.View.EG_SubViewNodeRectTransform);
                    go.SetActive(false);
                    this.m_es_skillset = this.AddChild<ES_SkillSet, Transform>(go.transform);
                }

                return this.m_es_skillset;
            }
        }

        private EntityRef<ES_SkillTianFu> m_es_skilltianfu = null;

        public ES_SkillTianFu ES_SkillTianFu
        {
            get
            {
                ES_SkillTianFu es = this.m_es_skilltianfu;
                if (es == null)
                {
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>()
                            .LoadAssetSync<GameObject>("Assets/Bundles/UI/Common/ES_SkillTianFu.prefab");
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.View.EG_SubViewNodeRectTransform);
                    go.SetActive(false);
                    this.m_es_skilltianfu = this.AddChild<ES_SkillTianFu, Transform>(go.transform);
                }

                return this.m_es_skilltianfu;
            }
        }

        private EntityRef<ES_SkillMake> m_es_skillmake = null;

        public ES_SkillMake ES_SkillMake
        {
            get
            {
                ES_SkillMake es = this.m_es_skillmake;
                if (es == null)
                {
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>()
                            .LoadAssetSync<GameObject>("Assets/Bundles/UI/Common/ES_SkillMake.prefab");
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.View.EG_SubViewNodeRectTransform);
                    go.SetActive(false);
                    this.m_es_skillmake = this.AddChild<ES_SkillMake, Transform>(go.transform);
                }

                return this.m_es_skillmake;
            }
        }

        private EntityRef<ES_SkillLifeShield> m_es_skilllifeshield = null;

        public ES_SkillLifeShield ES_SkillLifeShield
        {
            get
            {
                ES_SkillLifeShield es = this.m_es_skilllifeshield;
                if (es == null)
                {
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>()
                            .LoadAssetSync<GameObject>("Assets/Bundles/UI/Common/ES_SkillLifeShield.prefab");
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.View.EG_SubViewNodeRectTransform);
                    go.SetActive(false);
                    this.m_es_skilllifeshield = this.AddChild<ES_SkillLifeShield, Transform>(go.transform);
                }

                return this.m_es_skilllifeshield;
            }
        }
    }
}