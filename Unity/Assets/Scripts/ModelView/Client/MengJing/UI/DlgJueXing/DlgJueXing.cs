using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(DlgJueXingViewComponent))]
    [ComponentOf(typeof(UIBaseWindow))]
    public class DlgJueXing : Entity, IAwake, IUILogic
    {
        public DlgJueXingViewComponent View { get => this.GetComponent<DlgJueXingViewComponent>(); }

        private EntityRef<ES_JueXingShow> m_es_juexingshow = null;

        public ES_JueXingShow ES_JueXingShow
        {
            get
            {
                ES_JueXingShow es = this.m_es_juexingshow;
                if (es == null)
                {
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>()
                            .LoadAssetSync<GameObject>("Assets/Bundles/UI/Common/ES_JueXingShow.prefab");
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.View.EG_SubViewNodeRectTransform);
                    go.SetActive(false);
                    this.m_es_juexingshow = this.AddChild<ES_JueXingShow, Transform>(go.transform);
                }

                return this.m_es_juexingshow;
            }
        }
    }
}