using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(DlgJiaYuanPetViewComponent))]
    [ComponentOf(typeof(UIBaseWindow))]
    public class DlgJiaYuanPet : Entity, IAwake, IUILogic
    {
        public DlgJiaYuanPetViewComponent View { get => this.GetComponent<DlgJiaYuanPetViewComponent>(); }

        private EntityRef<ES_JiaYuanPetWalk> m_es_jiayuanpetwalk = null;

        public ES_JiaYuanPetWalk ES_JiaYuanPetWalk
        {
            get
            {
                ES_JiaYuanPetWalk es = this.m_es_jiayuanpetwalk;
                if (es == null)
                {
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>()
                            .LoadAssetSync<GameObject>("Assets/Bundles/UI/Common/ES_JiaYuanPetWalk.prefab");
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.View.EG_SubViewRectTransform);
                    go.SetActive(false);
                    this.m_es_jiayuanpetwalk = this.AddChild<ES_JiaYuanPetWalk, Transform>(go.transform);
                }

                return this.m_es_jiayuanpetwalk;
            }
        }

        private EntityRef<ES_PetCangKu> m_es_petcangku = null;

        public ES_PetCangKu ES_PetCangKu
        {
            get
            {
                ES_PetCangKu es = this.m_es_petcangku;
                if (es == null)
                {
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>()
                            .LoadAssetSync<GameObject>("Assets/Bundles/UI/Common/ES_PetCangKu.prefab");
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.View.EG_SubViewRectTransform);
                    go.SetActive(false);
                    this.m_es_petcangku = this.AddChild<ES_PetCangKu, Transform>(go.transform);
                }

                return this.m_es_petcangku;
            }
        }
    }
}