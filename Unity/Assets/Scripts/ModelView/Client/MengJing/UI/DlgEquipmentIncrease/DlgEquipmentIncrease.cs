using UnityEngine;

namespace ET.Client
{
    [ComponentOf(typeof(UIBaseWindow))]
    public class DlgEquipmentIncrease : Entity, IAwake, IUILogic
    {
        public DlgEquipmentIncreaseViewComponent View { get => this.GetComponent<DlgEquipmentIncreaseViewComponent>(); }

        private EntityRef<ES_EquipmentIncreaseShow> m_es_equipmentincreaseshow = null;

        public ES_EquipmentIncreaseShow ES_EquipmentIncreaseShow
        {
            get
            {
                ES_EquipmentIncreaseShow es = this.m_es_equipmentincreaseshow;
                if (es == null)
                {
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>()
                            .LoadAssetSync<GameObject>("Assets/Bundles/UI/Common/ES_EquipmentIncreaseShow.prefab");
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.View.EG_SubViewRectTransform);
                    go.SetActive(false);
                    this.m_es_equipmentincreaseshow = this.AddChild<ES_EquipmentIncreaseShow, Transform>(go.transform);
                }

                return this.m_es_equipmentincreaseshow;
            }
        }

        private EntityRef<ES_EquipmentIncreaseTransfer> m_es_equipmentincreasetransfer = null;

        public ES_EquipmentIncreaseTransfer ES_EquipmentIncreaseTransfer
        {
            get
            {
                ES_EquipmentIncreaseTransfer es = this.m_es_equipmentincreasetransfer;
                if (es == null)
                {
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>()
                            .LoadAssetSync<GameObject>("Assets/Bundles/UI/Common/ES_EquipmentIncreaseTransfer.prefab");
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.View.EG_SubViewRectTransform);
                    go.SetActive(false);
                    this.m_es_equipmentincreasetransfer = this.AddChild<ES_EquipmentIncreaseTransfer, Transform>(go.transform);
                }

                return this.m_es_equipmentincreasetransfer;
            }
        }
    }
}