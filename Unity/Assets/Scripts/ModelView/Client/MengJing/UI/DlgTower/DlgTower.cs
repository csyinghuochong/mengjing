using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(DlgTowerViewComponent))]
    [ComponentOf(typeof(UIBaseWindow))]
    public class DlgTower : Entity, IAwake, IUILogic
    {
        public DlgTowerViewComponent View { get => this.GetComponent<DlgTowerViewComponent>(); }

        private EntityRef<ES_TowerDungeon> m_es_towerdungeon = null;

        public ES_TowerDungeon ES_TowerDungeon
        {
            get
            {
                ES_TowerDungeon es = this.m_es_towerdungeon;
                if (es == null)
                {
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>()
                            .LoadAssetSync<GameObject>("Assets/Bundles/UI/Common/ES_TowerDungeon.prefab");
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.View.EG_SubViewRectTransform);
                    go.SetActive(false);
                    this.m_es_towerdungeon = this.AddChild<ES_TowerDungeon, Transform>(go.transform);
                }

                return this.m_es_towerdungeon;
            }
        }

        private EntityRef<ES_TowerShop> m_es_towershop = null;

        public ES_TowerShop ES_TowerShop
        {
            get
            {
                ES_TowerShop es = this.m_es_towershop;
                if (es == null)
                {
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>()
                            .LoadAssetSync<GameObject>("Assets/Bundles/UI/Common/ES_TowerShop.prefab");
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.View.EG_SubViewRectTransform);
                    go.SetActive(false);
                    this.m_es_towershop = this.AddChild<ES_TowerShop, Transform>(go.transform);
                }

                return this.m_es_towershop;
            }
        }
    }
}