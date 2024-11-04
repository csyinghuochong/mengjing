using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(DlgZuoQiViewComponent))]
    [ComponentOf(typeof(UIBaseWindow))]
    public class DlgZuoQi : Entity, IAwake, IUILogic
    {
        public DlgZuoQiViewComponent View { get => this.GetComponent<DlgZuoQiViewComponent>(); }

        private EntityRef<ES_ZuoQiShow> m_es_zuoqishow = null;

        public ES_ZuoQiShow ES_ZuoQiShow
        {
            get
            {
                ES_ZuoQiShow es = this.m_es_zuoqishow;
                if (es == null)
                {
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>()
                            .LoadAssetSync<GameObject>("Assets/Bundles/UI/Common/ES_ZuoQiShow.prefab");
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.View.EG_SubViewRectTransform);
                    go.SetActive(false);
                    this.m_es_zuoqishow = this.AddChild<ES_ZuoQiShow, Transform>(go.transform);
                }

                return this.m_es_zuoqishow;
            }
        }
    }
}