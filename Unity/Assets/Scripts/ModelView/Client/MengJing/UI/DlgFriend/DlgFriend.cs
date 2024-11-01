using UnityEngine;

namespace ET.Client
{
    [FriendOf(typeof(DlgFriendViewComponent))]
    [ComponentOf(typeof(UIBaseWindow))]
    public class DlgFriend : Entity, IAwake, IUILogic
    {
        public DlgFriendViewComponent View
        {
            get => this.GetComponent<DlgFriendViewComponent>();
        }

        public bool ClickEnabled;

        private EntityRef<ES_FriendList> m_es_friendlist = null;

        public ES_FriendList ES_FriendList
        {
            get
            {
                ES_FriendList es = this.m_es_friendlist;
                if (es == null)
                {
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>()
                            .LoadAssetSync<GameObject>("Assets/Bundles/UI/Common/ES_FriendList.prefab");
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.View.EG_SubViewNodeRectTransform);
                    go.SetActive(false);
                    this.m_es_friendlist = this.AddChild<ES_FriendList, Transform>(go.transform);
                }

                return this.m_es_friendlist;
            }
        }

        private EntityRef<ES_FriendApply> m_es_friendapply = null;

        public ES_FriendApply ES_FriendApply
        {
            get
            {
                ES_FriendApply es = this.m_es_friendapply;
                if (es == null)
                {
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>()
                            .LoadAssetSync<GameObject>("Assets/Bundles/UI/Common/ES_FriendApply.prefab");
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.View.EG_SubViewNodeRectTransform);
                    go.SetActive(false);
                    this.m_es_friendapply = this.AddChild<ES_FriendApply, Transform>(go.transform);
                }

                return this.m_es_friendapply;
            }
        }

        private EntityRef<ES_FriendBlack> m_es_friendblack = null;

        public ES_FriendBlack ES_FriendBlack
        {
            get
            {
                ES_FriendBlack es = this.m_es_friendblack;
                if (es == null)
                {
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>()
                            .LoadAssetSync<GameObject>("Assets/Bundles/UI/Common/ES_FriendBlack.prefab");
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.View.EG_SubViewNodeRectTransform);
                    go.SetActive(false);
                    this.m_es_friendblack = this.AddChild<ES_FriendBlack, Transform>(go.transform);
                }

                return this.m_es_friendblack;
            }
        }

        private EntityRef<ES_UnionShow> m_es_unionshow = null;

        public ES_UnionShow ES_UnionShow
        {
            get
            {
                ES_UnionShow es = this.m_es_unionshow;
                if (es == null)
                {
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>()
                            .LoadAssetSync<GameObject>("Assets/Bundles/UI/Common/ES_UnionShow.prefab");
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.View.EG_SubViewNodeRectTransform);
                    go.SetActive(false);
                    this.m_es_unionshow = this.AddChild<ES_UnionShow, Transform>(go.transform);
                }

                return this.m_es_unionshow;
            }
        }
        
        private EntityRef<ES_UnionMy> m_es_unionmy = null;

        public ES_UnionMy ES_UnionMy
        {
            get
            {
                ES_UnionMy es = this.m_es_unionmy;
                if (es == null)
                {
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>()
                            .LoadAssetSync<GameObject>("Assets/Bundles/UI/Common/ES_UnionMy.prefab");
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.View.EG_SubViewNodeRectTransform);
                    go.SetActive(false);
                    this.m_es_unionmy = this.AddChild<ES_UnionMy, Transform>(go.transform);
                }

                return this.m_es_unionmy;
            }
        }
    }
}