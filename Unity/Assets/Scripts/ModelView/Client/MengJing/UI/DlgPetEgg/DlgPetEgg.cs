using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(DlgPetEggViewComponent))]
    [ComponentOf(typeof(UIBaseWindow))]
    public class DlgPetEgg : Entity, IAwake, IUILogic
    {
        public DlgPetEggViewComponent View { get => this.GetComponent<DlgPetEggViewComponent>(); }

        private EntityRef<ES_PetEggList> m_es_petegglist = null;

        public ES_PetEggList ES_PetEggList
        {
            get
            {
                ES_PetEggList es = this.m_es_petegglist;
                if (es == null)
                {
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>()
                            .LoadAssetSync<GameObject>("Assets/Bundles/UI/Common/ES_PetEggList.prefab");
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.View.EG_SubViewRectTransform);
                    go.SetActive(false);
                    this.m_es_petegglist = this.AddChild<ES_PetEggList, Transform>(go.transform);
                }

                return this.m_es_petegglist;
            }
        }

        private EntityRef<ES_PetEggDuiHuan> m_es_peteggduihuan = null;

        public ES_PetEggDuiHuan ES_PetEggDuiHuan
        {
            get
            {
                ES_PetEggDuiHuan es = this.m_es_peteggduihuan;
                if (es == null)
                {
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>()
                            .LoadAssetSync<GameObject>("Assets/Bundles/UI/Common/ES_PetEggDuiHuan.prefab");
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.View.EG_SubViewRectTransform);
                    go.SetActive(false);
                    this.m_es_peteggduihuan = this.AddChild<ES_PetEggDuiHuan, Transform>(go.transform);
                }

                return this.m_es_peteggduihuan;
            }
        }

        private EntityRef<ES_PetEggChouKa> m_es_peteggchouka = null;

        public ES_PetEggChouKa ES_PetEggChouKa
        {
            get
            {
                ES_PetEggChouKa es = this.m_es_peteggchouka;
                if (es == null)
                {
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>()
                            .LoadAssetSync<GameObject>("Assets/Bundles/UI/Common/ES_PetEggChouKa.prefab");
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.View.EG_SubViewRectTransform);
                    go.SetActive(false);
                    this.m_es_peteggchouka = this.AddChild<ES_PetEggChouKa, Transform>(go.transform);
                }

                return this.m_es_peteggchouka;
            }
        }

        private EntityRef<ES_PetHeXinChouKa> m_es_pethexinchouka = null;

        public ES_PetHeXinChouKa ES_PetHeXinChouKa
        {
            get
            {
                ES_PetHeXinChouKa es = this.m_es_pethexinchouka;
                if (es == null)
                {
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>()
                            .LoadAssetSync<GameObject>("Assets/Bundles/UI/Common/ES_PetHeXinChouKa.prefab");
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.View.EG_SubViewRectTransform);
                    go.SetActive(false);
                    this.m_es_pethexinchouka = this.AddChild<ES_PetHeXinChouKa, Transform>(go.transform);
                }

                return this.m_es_pethexinchouka;
            }
        }
    }
}