using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(DlgShouJiViewComponent))]
    [ComponentOf(typeof(UIBaseWindow))]
    public class DlgShouJi : Entity, IAwake, IUILogic
    {
        public DlgShouJiViewComponent View { get => this.GetComponent<DlgShouJiViewComponent>(); }

        private EntityRef<ES_ShouJiList> m_es_shoujilist = null;

        public ES_ShouJiList ES_ShouJiList
        {
            get
            {
                ES_ShouJiList es = this.m_es_shoujilist;
                if (es == null)
                {
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>()
                            .LoadAssetSync<GameObject>("Assets/Bundles/UI/Common/ES_ShouJiList.prefab");
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.View.EG_SubViewRectTransform);
                    go.SetActive(false);
                    this.m_es_shoujilist = this.AddChild<ES_ShouJiList, Transform>(go.transform);
                }

                return this.m_es_shoujilist;
            }
        }

        private EntityRef<ES_ShouJiTreasure> m_es_shoujitreasure = null;

        public ES_ShouJiTreasure ES_ShouJiTreasure
        {
            get
            {
                ES_ShouJiTreasure es = this.m_es_shoujitreasure;
                if (es == null)
                {
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>()
                            .LoadAssetSync<GameObject>("Assets/Bundles/UI/Common/ES_ShouJiTreasure.prefab");
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.View.EG_SubViewRectTransform);
                    go.SetActive(false);
                    this.m_es_shoujitreasure = this.AddChild<ES_ShouJiTreasure, Transform>(go.transform);
                }

                return this.m_es_shoujitreasure;
            }
        }
    }
}