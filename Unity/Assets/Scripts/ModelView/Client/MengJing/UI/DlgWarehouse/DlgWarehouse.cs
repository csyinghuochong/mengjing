using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(DlgWarehouseViewComponent))]
    [ComponentOf(typeof(UIBaseWindow))]
    public class DlgWarehouse : Entity, IAwake, IUILogic
    {
        public DlgWarehouseViewComponent View { get => this.GetComponent<DlgWarehouseViewComponent>(); }

        private EntityRef<ES_WarehouseRole> m_es_warehouserole = null;

        public ES_WarehouseRole ES_WarehouseRole
        {
            get
            {
                ES_WarehouseRole es = this.m_es_warehouserole;
                if (es == null)
                {
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>()
                            .LoadAssetSync<GameObject>("Assets/Bundles/UI/Common/ES_WarehouseRole.prefab");
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.View.EG_SubViewRectTransform);
                    go.SetActive(false);
                    this.m_es_warehouserole = this.AddChild<ES_WarehouseRole, Transform>(go.transform);
                }

                return this.m_es_warehouserole;
            }
        }

        private EntityRef<ES_WarehouseAccount> m_es_warehouseaccount = null;

        public ES_WarehouseAccount ES_WarehouseAccount
        {
            get
            {
                ES_WarehouseAccount es = this.m_es_warehouseaccount;
                if (es == null)
                {
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>()
                            .LoadAssetSync<GameObject>("Assets/Bundles/UI/Common/ES_WarehouseAccount.prefab");
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.View.EG_SubViewRectTransform);
                    go.SetActive(false);
                    this.m_es_warehouseaccount = this.AddChild<ES_WarehouseAccount, Transform>(go.transform);
                }

                return this.m_es_warehouseaccount;
            }
        }

        private EntityRef<ES_WarehouseGem> m_es_warehousegem = null;

        public ES_WarehouseGem ES_WarehouseGem
        {
            get
            {
                ES_WarehouseGem es = this.m_es_warehousegem;
                if (es == null)
                {
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>()
                            .LoadAssetSync<GameObject>("Assets/Bundles/UI/Common/ES_WarehouseGem.prefab");
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.View.EG_SubViewRectTransform);
                    go.SetActive(false);
                    this.m_es_warehousegem = this.AddChild<ES_WarehouseGem, Transform>(go.transform);
                }

                return this.m_es_warehousegem;
            }
        }
    }
}