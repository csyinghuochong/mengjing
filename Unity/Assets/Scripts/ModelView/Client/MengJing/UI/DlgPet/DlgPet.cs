using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(DlgPetViewComponent))]
    [ComponentOf(typeof(UIBaseWindow))]
    public class DlgPet : Entity, IAwake, IUILogic
    {
        public DlgPetViewComponent View
        {
            get => this.GetComponent<DlgPetViewComponent>();
        }

        public int PetItemWeizhi; //-1左 1 右边

        private EntityRef<ES_PetList> m_es_petlist = null;

        public ES_PetList ES_PetList
        {
            get
            {
                ES_PetList es = this.m_es_petlist;
                if (es == null)
                {
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>()
                            .LoadAssetSync<GameObject>("Assets/Bundles/UI/Common/ES_PetList.prefab");
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.View.EG_SubViewRectTransform);
                    go.SetActive(false);
                    this.m_es_petlist = this.AddChild<ES_PetList, Transform>(go.transform);
                }

                return this.m_es_petlist;
            }
        }

        private EntityRef<ES_PetHeCheng> m_es_pethecheng = null;

        public ES_PetHeCheng ES_PetHeCheng
        {
            get
            {
                ES_PetHeCheng es = this.m_es_pethecheng;
                if (es == null)
                {
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>()
                            .LoadAssetSync<GameObject>("Assets/Bundles/UI/Common/ES_PetHeCheng.prefab");
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.View.EG_SubViewRectTransform);
                    go.SetActive(false);
                    this.m_es_pethecheng = this.AddChild<ES_PetHeCheng, Transform>(go.transform);
                }

                return this.m_es_pethecheng;
            }
        }

        private EntityRef<ES_PetXiLian> m_es_petxilian = null;

        public ES_PetXiLian ES_PetXiLian
        {
            get
            {
                ES_PetXiLian es = this.m_es_petxilian;
                if (es == null)
                {
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>()
                            .LoadAssetSync<GameObject>("Assets/Bundles/UI/Common/ES_PetXiLian.prefab");
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.View.EG_SubViewRectTransform);
                    go.SetActive(false);
                    this.m_es_petxilian = this.AddChild<ES_PetXiLian, Transform>(go.transform);
                }

                return this.m_es_petxilian;
            }
        }
        
        private EntityRef<ES_PetShouHu> m_es_petshouhu = null;

        public ES_PetShouHu ES_PetShouHu
        {
            get
            {
                ES_PetShouHu es = this.m_es_petshouhu;
                if (es == null)
                {
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>()
                            .LoadAssetSync<GameObject>("Assets/Bundles/UI/Common/ES_PetShouHu.prefab");
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.View.EG_SubViewRectTransform);
                    go.SetActive(false);
                    this.m_es_petshouhu = this.AddChild<ES_PetShouHu, Transform>(go.transform);
                }

                return this.m_es_petshouhu;
            }
        }
    }
}