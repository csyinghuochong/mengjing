
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ComponentOf(typeof(DlgFriend))]
	[EnableMethod]
	public  class DlgFriendViewComponent : Entity,IAwake,IDestroy 
	{
		public List<string> AssetList = new();
		
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
		    		this.m_E_FunctionSetBtnToggleGroup = UIFindHelper.FindDeepChild<UnityEngine.UI.ToggleGroup>(this.uiTransform.gameObject,"Left/E_FunctionSetBtn");
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
		    		this.m_E_Type_0Toggle = UIFindHelper.FindDeepChild<UnityEngine.UI.Toggle>(this.uiTransform.gameObject,"Left/E_FunctionSetBtn/E_Type_0");
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
		    		this.m_E_Type_1Toggle = UIFindHelper.FindDeepChild<UnityEngine.UI.Toggle>(this.uiTransform.gameObject,"Left/E_FunctionSetBtn/E_Type_1");
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
	                string path = "Assets/Bundles/UI/Common/ES_FriendList.prefab";
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<GameObject>(path);
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.EG_SubViewNodeRectTransform);
                    go.SetActive(true);
                    this.AssetList.Add(path);
                    this.m_es_friendlist = this.AddChild<ES_FriendList, Transform>(go.transform);
                    go.SetActive(false);
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
	                string path = "Assets/Bundles/UI/Common/ES_FriendApply.prefab";
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<GameObject>(path);
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.EG_SubViewNodeRectTransform);
                    go.SetActive(true);
                    this.AssetList.Add(path);
                    this.m_es_friendapply = this.AddChild<ES_FriendApply, Transform>(go.transform);
                    go.SetActive(false);
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
	                string path = "Assets/Bundles/UI/Common/ES_FriendBlack.prefab";
                    GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<GameObject>(path);
                    GameObject go = UnityEngine.Object.Instantiate(prefab, this.EG_SubViewNodeRectTransform);
                    go.SetActive(true);
                    this.AssetList.Add(path);
                    this.m_es_friendblack = this.AddChild<ES_FriendBlack, Transform>(go.transform);
                    go.SetActive(false);
                }

                return this.m_es_friendblack;
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
			this.uiTransform = null;
			
			ResourcesLoaderComponent resourcesLoaderComponent = this.Root().GetComponent<ResourcesLoaderComponent>();
			for (int i = 0; i < this.AssetList.Count; i++)
			{
				resourcesLoaderComponent.UnLoadAsset(this.AssetList[i]);
			}
			this.AssetList.Clear();
			this.AssetList = null;
		}

		private UnityEngine.RectTransform m_EG_SubViewNodeRectTransform = null;
		private UnityEngine.UI.ToggleGroup m_E_FunctionSetBtnToggleGroup = null;
		private UnityEngine.UI.Toggle m_E_Type_0Toggle = null;
		private UnityEngine.UI.Toggle m_E_Type_1Toggle = null;
		private EntityRef<ES_FriendList> m_es_friendlist = null;
		private EntityRef<ES_FriendApply> m_es_friendapply = null;
		private EntityRef<ES_FriendBlack> m_es_friendblack = null;
		
		public Transform uiTransform = null;
	}
}
