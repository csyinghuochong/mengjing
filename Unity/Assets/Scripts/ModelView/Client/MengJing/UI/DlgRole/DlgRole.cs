using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(DlgRoleViewComponent))]
    [ComponentOf(typeof(UIBaseWindow))]
    public class DlgRole : Entity, IAwake, IUILogic
    {
        public DlgRoleViewComponent View
        {
            get => this.GetComponent<DlgRoleViewComponent>();
        }

        public int Position;
        public int Index;

        private EntityRef<ES_RoleBag> m_es_rolebag = null;

        public ES_RoleBag ES_RoleBag
        {
            get
            {
                ES_RoleBag es = this.m_es_rolebag;
                if (es == null)
                {
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>()
                            .LoadAssetSync<GameObject>("Assets/Bundles/UI/Common/ES_RoleBag.prefab");
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.View.EG_SubViewRectTransform);
                    this.m_es_rolebag = this.AddChild<ES_RoleBag, Transform>(go.transform);
                }

                return this.m_es_rolebag;
            }
        }

        private EntityRef<ES_RoleProperty> m_es_roleproperty = null;

        public ES_RoleProperty ES_RoleProperty
        {
            get
            {
                ES_RoleProperty es = this.m_es_roleproperty;
                if (es == null)
                {
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>()
                            .LoadAssetSync<GameObject>("Assets/Bundles/UI/Common/ES_RoleProperty.prefab");
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.View.EG_SubViewRectTransform);
                    this.m_es_roleproperty = this.AddChild<ES_RoleProperty, Transform>(go.transform);
                }

                return this.m_es_roleproperty;
            }
        }

        private EntityRef<ES_RoleGem> m_es_rolegem = null;

        public ES_RoleGem ES_RoleGem
        {
            get
            {
                ES_RoleGem es = this.m_es_rolegem;
                if (es == null)
                {
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>()
                            .LoadAssetSync<GameObject>("Assets/Bundles/UI/Common/ES_RoleGem.prefab");
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.View.EG_SubViewRectTransform);
                    this.m_es_rolegem = this.AddChild<ES_RoleGem, Transform>(go.transform);
                }

                return this.m_es_rolegem;
            }
        }

        private EntityRef<ES_RoleHuiShou> m_es_rolehuishou = null;

        public ES_RoleHuiShou ES_RoleHuiShou
        {
            get
            {
                ES_RoleHuiShou es = this.m_es_rolehuishou;
                if (es == null)
                {
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>()
                            .LoadAssetSync<GameObject>("Assets/Bundles/UI/Common/ES_RoleHuiShou.prefab");
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.View.EG_SubViewRectTransform);
                    this.m_es_rolehuishou = this.AddChild<ES_RoleHuiShou, Transform>(go.transform);
                }

                return this.m_es_rolehuishou;
            }
        }

        private EntityRef<ES_RoleQiangHua> m_es_roleqianghua = null;

        public ES_RoleQiangHua ES_RoleQiangHua
        {
            get
            {
                ES_RoleQiangHua es = this.m_es_roleqianghua;
                if (es == null)
                {
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>()
                            .LoadAssetSync<GameObject>("Assets/Bundles/UI/Common/ES_RoleQiangHua.prefab");
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.View.EG_SubViewRectTransform);
                    this.m_es_roleqianghua = this.AddChild<ES_RoleQiangHua, Transform>(go.transform);
                }

                return this.m_es_roleqianghua;
            }
        }
    }
}