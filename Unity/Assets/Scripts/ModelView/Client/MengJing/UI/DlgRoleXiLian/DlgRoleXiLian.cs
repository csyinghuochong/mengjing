using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(DlgRoleXiLianViewComponent))]
    [ComponentOf(typeof(UIBaseWindow))]
    public class DlgRoleXiLian : Entity, IAwake, IUILogic
    {
        public DlgRoleXiLianViewComponent View { get => this.GetComponent<DlgRoleXiLianViewComponent>(); }

        private EntityRef<ES_RoleXiLianShow> m_es_rolexilianshow = null;

        public ES_RoleXiLianShow ES_RoleXiLianShow
        {
            get
            {
                ES_RoleXiLianShow es = this.m_es_rolexilianshow;
                if (es == null)
                {
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>()
                            .LoadAssetSync<GameObject>("Assets/Bundles/UI/Common/ES_RoleXiLianShow.prefab");
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.View.EG_SubViewRectTransform);
                    go.SetActive(false);
                    this.m_es_rolexilianshow = this.AddChild<ES_RoleXiLianShow, Transform>(go.transform);
                }

                return this.m_es_rolexilianshow;
            }
        }

        private EntityRef<ES_RoleXiLianLevel> m_es_rolexilianlevel = null;

        public ES_RoleXiLianLevel ES_RoleXiLianLevel
        {
            get
            {
                ES_RoleXiLianLevel es = this.m_es_rolexilianlevel;
                if (es == null)
                {
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>()
                            .LoadAssetSync<GameObject>("Assets/Bundles/UI/Common/ES_RoleXiLianLevel.prefab");
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.View.EG_SubViewRectTransform);
                    go.SetActive(false);
                    this.m_es_rolexilianlevel = this.AddChild<ES_RoleXiLianLevel, Transform>(go.transform);
                }

                return this.m_es_rolexilianlevel;
            }
        }

        private EntityRef<ES_RoleXiLianSkill> m_es_rolexilianskill = null;

        public ES_RoleXiLianSkill ES_RoleXiLianSkill
        {
            get
            {
                ES_RoleXiLianSkill es = this.m_es_rolexilianskill;
                if (es == null)
                {
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>()
                            .LoadAssetSync<GameObject>("Assets/Bundles/UI/Common/ES_RoleXiLianSkill.prefab");
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.View.EG_SubViewRectTransform);
                    go.SetActive(false);
                    this.m_es_rolexilianskill = this.AddChild<ES_RoleXiLianSkill, Transform>(go.transform);
                }

                return this.m_es_rolexilianskill;
            }
        }

        private EntityRef<ES_RoleXiLianTransfer> m_es_rolexiliantransfer = null;

        public ES_RoleXiLianTransfer ES_RoleXiLianTransfer
        {
            get
            {
                ES_RoleXiLianTransfer es = this.m_es_rolexiliantransfer;
                if (es == null)
                {
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>()
                            .LoadAssetSync<GameObject>("Assets/Bundles/UI/Common/ES_RoleXiLianTransfer.prefab");
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.View.EG_SubViewRectTransform);
                    go.SetActive(false);
                    this.m_es_rolexiliantransfer = this.AddChild<ES_RoleXiLianTransfer, Transform>(go.transform);
                }

                return this.m_es_rolexiliantransfer;
            }
        }

        private EntityRef<ES_RoleXiLianInherit> m_es_rolexilianinherit = null;

        public ES_RoleXiLianInherit ES_RoleXiLianInherit
        {
            get
            {
                ES_RoleXiLianInherit es = this.m_es_rolexilianinherit;
                if (es == null)
                {
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>()
                            .LoadAssetSync<GameObject>("Assets/Bundles/UI/Common/ES_RoleXiLianInherit.prefab");
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.View.EG_SubViewRectTransform);
                    go.SetActive(false);
                    this.m_es_rolexilianinherit = this.AddChild<ES_RoleXiLianInherit, Transform>(go.transform);
                }

                return this.m_es_rolexilianinherit;
            }
        }
    }
}