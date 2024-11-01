using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(DlgBattleViewComponent))]
    [ComponentOf(typeof(UIBaseWindow))]
    public class DlgBattle : Entity, IAwake, IUILogic
    {
        public DlgBattleViewComponent View { get => this.GetComponent<DlgBattleViewComponent>(); }

        private EntityRef<ES_BattleEnter> m_es_battleenter = null;

        public ES_BattleEnter ES_BattleEnter
        {
            get
            {
                ES_BattleEnter es = this.m_es_battleenter;
                if (es == null)
                {
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>()
                            .LoadAssetSync<GameObject>("Assets/Bundles/UI/Common/ES_BattleEnter.prefab");
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.View.EG_SubViewRectTransform);
                    go.SetActive(false);
                    this.m_es_battleenter = this.AddChild<ES_BattleEnter, Transform>(go.transform);
                }

                return this.m_es_battleenter;
            }
        }

        private EntityRef<ES_BattleTask> m_es_battletask = null;

        public ES_BattleTask ES_BattleTask
        {
            get
            {
                ES_BattleTask es = this.m_es_battletask;
                if (es == null)
                {
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>()
                            .LoadAssetSync<GameObject>("Assets/Bundles/UI/Common/ES_BattleTask.prefab");
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.View.EG_SubViewRectTransform);
                    go.SetActive(false);
                    this.m_es_battletask = this.AddChild<ES_BattleTask, Transform>(go.transform);
                }

                return this.m_es_battletask;
            }
        }
        
        private EntityRef<ES_BattleShop> m_es_battleshop = null;

        public ES_BattleShop ES_BattleShop
        {
            get
            {
                ES_BattleShop es = this.m_es_battleshop;
                if (es == null)
                {
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>()
                            .LoadAssetSync<GameObject>("Assets/Bundles/UI/Common/ES_BattleShop.prefab");
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.View.EG_SubViewRectTransform);
                    go.SetActive(false);
                    this.m_es_battleshop = this.AddChild<ES_BattleShop, Transform>(go.transform);
                }

                return this.m_es_battleshop;
            }
        }
    }
}