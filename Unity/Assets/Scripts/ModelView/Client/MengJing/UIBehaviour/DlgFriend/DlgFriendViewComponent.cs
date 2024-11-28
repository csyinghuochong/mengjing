
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ComponentOf(typeof(DlgFriend))]
	[EnableMethod]
	public  class DlgFriendViewComponent : Entity,IAwake,IDestroy 
	{
		public UnityEngine.RectTransform EG_SubViewNodeRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_SubViewNodeRectTransform == null )
     			{
		    		this.m_EG_SubViewNodeRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_SubViewNode");
     			}
     			return this.m_EG_SubViewNodeRectTransform;
     		}
     	}

		public UnityEngine.UI.ToggleGroup E_FunctionSetBtnToggleGroup
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_FunctionSetBtnToggleGroup == null )
     			{
		    		this.m_E_FunctionSetBtnToggleGroup = UIFindHelper.FindDeepChild<UnityEngine.UI.ToggleGroup>(this.uiTransform.gameObject,"E_FunctionSetBtn");
     			}
     			return this.m_E_FunctionSetBtnToggleGroup;
     		}
     	}

		public UnityEngine.UI.Toggle E_Type_0Toggle
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Type_0Toggle == null )
     			{
		    		this.m_E_Type_0Toggle = UIFindHelper.FindDeepChild<UnityEngine.UI.Toggle>(this.uiTransform.gameObject,"E_FunctionSetBtn/E_Type_0");
     			}
     			return this.m_E_Type_0Toggle;
     		}
     	}

		public UnityEngine.UI.Toggle E_Type_1Toggle
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Type_1Toggle == null )
     			{
		    		this.m_E_Type_1Toggle = UIFindHelper.FindDeepChild<UnityEngine.UI.Toggle>(this.uiTransform.gameObject,"E_FunctionSetBtn/E_Type_1");
     			}
     			return this.m_E_Type_1Toggle;
     		}
     	}
		
        public ES_FriendList ES_FriendList
        {
            get
            {
                ES_FriendList es = this.m_es_friendlist;
                if (es == null)
                {
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>()
                            .LoadAssetSync<GameObject>("Assets/Bundles/UI/Common/ES_FriendList.prefab");
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.EG_SubViewNodeRectTransform);
                    go.SetActive(false);
                    this.m_es_friendlist = this.AddChild<ES_FriendList, Transform>(go.transform);
                }

                return this.m_es_friendlist;
            }
        }

        public ES_FriendApply ES_FriendApply
        {
            get
            {
                ES_FriendApply es = this.m_es_friendapply;
                if (es == null)
                {
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>()
                            .LoadAssetSync<GameObject>("Assets/Bundles/UI/Common/ES_FriendApply.prefab");
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.EG_SubViewNodeRectTransform);
                    go.SetActive(false);
                    this.m_es_friendapply = this.AddChild<ES_FriendApply, Transform>(go.transform);
                }

                return this.m_es_friendapply;
            }
        }

        public ES_FriendBlack ES_FriendBlack
        {
            get
            {
                ES_FriendBlack es = this.m_es_friendblack;
                if (es == null)
                {
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>()
                            .LoadAssetSync<GameObject>("Assets/Bundles/UI/Common/ES_FriendBlack.prefab");
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.EG_SubViewNodeRectTransform);
                    go.SetActive(false);
                    this.m_es_friendblack = this.AddChild<ES_FriendBlack, Transform>(go.transform);
                }

                return this.m_es_friendblack;
            }
        }

        public ES_UnionShow ES_UnionShow
        {
            get
            {
                ES_UnionShow es = this.m_es_unionshow;
                if (es == null)
                {
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>()
                            .LoadAssetSync<GameObject>("Assets/Bundles/UI/Common/ES_UnionShow.prefab");
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.EG_SubViewNodeRectTransform);
                    go.SetActive(false);
                    this.m_es_unionshow = this.AddChild<ES_UnionShow, Transform>(go.transform);
                }

                return this.m_es_unionshow;
            }
        }

        public ES_UnionMy ES_UnionMy
        {
            get
            {
                ES_UnionMy es = this.m_es_unionmy;
                if (es == null)
                {
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>()
                            .LoadAssetSync<GameObject>("Assets/Bundles/UI/Common/ES_UnionMy.prefab");
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.EG_SubViewNodeRectTransform);
                    go.SetActive(false);
                    this.m_es_unionmy = this.AddChild<ES_UnionMy, Transform>(go.transform);
                }

                return this.m_es_unionmy;
            }
        }

		public void DestroyWidget()
		{
			this.m_EG_SubViewNodeRectTransform = null;
			this.m_E_FunctionSetBtnToggleGroup = null;
			this.m_E_Type_0Toggle = null;
			this.m_E_Type_1Toggle = null;
			this.m_es_friendlist = null;
			this.m_es_friendapply = null;
			this.m_es_friendblack = null;
			this.m_es_unionshow = null;
			this.m_es_unionmy = null;
			this.uiTransform = null;
		}

		private UnityEngine.RectTransform m_EG_SubViewNodeRectTransform = null;
		private UnityEngine.UI.ToggleGroup m_E_FunctionSetBtnToggleGroup = null;
		private UnityEngine.UI.Toggle m_E_Type_0Toggle = null;
		private UnityEngine.UI.Toggle m_E_Type_1Toggle = null;
		private EntityRef<ES_FriendList> m_es_friendlist = null;
		private EntityRef<ES_FriendApply> m_es_friendapply = null;
		private EntityRef<ES_FriendBlack> m_es_friendblack = null;
		private EntityRef<ES_UnionShow> m_es_unionshow = null;
		private EntityRef<ES_UnionMy> m_es_unionmy = null;
		public Transform uiTransform = null;
	}
}
