using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(DlgWatchViewComponent))]
    [ComponentOf(typeof(UIBaseWindow))]
    public class DlgWatch : Entity, IAwake, IUILogic
    {
        public DlgWatchViewComponent View
        {
            get => this.GetComponent<DlgWatchViewComponent>();
        }

        public F2C_WatchPlayerResponse F2C_WatchPlayerResponse { get; set; }
        public bool CanClick;

        private EntityRef<ES_WatchEquip> m_es_watchequip = null;

        public ES_WatchEquip ES_WatchEquip
        {
            get
            {
                ES_WatchEquip es = this.m_es_watchequip;
                if (es == null)
                {
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>()
                            .LoadAssetSync<GameObject>("Assets/Bundles/UI/Common/ES_WatchEquip.prefab");
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.View.EG_SubViewRectTransform);
                    go.SetActive(false);
                    this.m_es_watchequip = this.AddChild<ES_WatchEquip, Transform>(go.transform);
                }

                return this.m_es_watchequip;
            }
        }

        private EntityRef<ES_WatchPet> m_es_watchpet = null;

        public ES_WatchPet ES_WatchPet
        {
            get
            {
                ES_WatchPet es = this.m_es_watchpet;
                if (es == null)
                {
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>()
                            .LoadAssetSync<GameObject>("Assets/Bundles/UI/Common/ES_WatchPet.prefab");
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.View.EG_SubViewRectTransform);
                    go.SetActive(false);
                    this.m_es_watchpet = this.AddChild<ES_WatchPet, Transform>(go.transform);
                }

                return this.m_es_watchpet;
            }
        }
    }
}