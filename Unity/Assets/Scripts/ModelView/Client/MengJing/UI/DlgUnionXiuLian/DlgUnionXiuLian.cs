using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(DlgUnionXiuLianViewComponent))]
    [ComponentOf(typeof(UIBaseWindow))]
    public class DlgUnionXiuLian : Entity, IAwake, IUILogic
    {
        public DlgUnionXiuLianViewComponent View { get => this.GetComponent<DlgUnionXiuLianViewComponent>(); }

        private EntityRef<ES_UnionRoleXiuLian> m_es_unionrolexiulian = null;

        public ES_UnionRoleXiuLian ES_UnionRoleXiuLian
        {
            get
            {
                ES_UnionRoleXiuLian es = this.m_es_unionrolexiulian;
                if (es == null)
                {
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>()
                            .LoadAssetSync<GameObject>("Assets/Bundles/UI/Common/ES_UnionRoleXiuLian.prefab");
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.View.EG_SubViewRectTransform);
                    go.SetActive(false);
                    this.m_es_unionrolexiulian = this.AddChild<ES_UnionRoleXiuLian, Transform>(go.transform);
                }

                return this.m_es_unionrolexiulian;
            }
        }

        private EntityRef<ES_UnionPetXiuLian> m_es_unionpetxiulian = null;

        public ES_UnionPetXiuLian ES_UnionPetXiuLian
        {
            get
            {
                ES_UnionPetXiuLian es = this.m_es_unionpetxiulian;
                if (es == null)
                {
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>()
                            .LoadAssetSync<GameObject>("Assets/Bundles/UI/Common/ES_UnionPetXiuLian.prefab");
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.View.EG_SubViewRectTransform);
                    go.SetActive(false);
                    this.m_es_unionpetxiulian = this.AddChild<ES_UnionPetXiuLian, Transform>(go.transform);
                }

                return this.m_es_unionpetxiulian;
            }
        }

        private EntityRef<ES_UnionBloodStone> m_es_unionbloodstone = null;

        public ES_UnionBloodStone ES_UnionBloodStone
        {
            get
            {
                ES_UnionBloodStone es = this.m_es_unionbloodstone;
                if (es == null)
                {
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>()
                            .LoadAssetSync<GameObject>("Assets/Bundles/UI/Common/ES_UnionBloodStone.prefab");
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.View.EG_SubViewRectTransform);
                    go.SetActive(false);
                    this.m_es_unionbloodstone = this.AddChild<ES_UnionBloodStone, Transform>(go.transform);
                }

                return this.m_es_unionbloodstone;
            }
        }
    }
}