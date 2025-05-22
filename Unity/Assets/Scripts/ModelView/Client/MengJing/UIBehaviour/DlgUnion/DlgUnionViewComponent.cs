using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ComponentOf(typeof(DlgUnion))]
	[EnableMethod]
	public  class DlgUnionViewComponent : Entity,IAwake,IDestroy 
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

		public ES_UnionShow ES_UnionShow
		{
			get
			{
				ES_UnionShow es = this.m_es_unionshow;
				if (es == null)
				{
					string path = "Assets/Bundles/UI/Common/ES_UnionShow.prefab";
					GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<GameObject>(path);
					GameObject go = UnityEngine.Object.Instantiate(prefab, this.EG_SubViewNodeRectTransform);
					go.SetActive(true);
					this.AssetList.Add(path);
					this.m_es_unionshow = this.AddChild<ES_UnionShow, Transform>(go.transform);
					go.SetActive(false);
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
					string path = "Assets/Bundles/UI/Common/ES_UnionMy.prefab";
					GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<GameObject>(path);
					GameObject go = UnityEngine.Object.Instantiate(prefab, this.EG_SubViewNodeRectTransform);
					go.SetActive(true);
					this.AssetList.Add(path);
					this.m_es_unionmy = this.AddChild<ES_UnionMy, Transform>(go.transform);
					go.SetActive(false);
				}

				return this.m_es_unionmy;
			}
		}
		
		public ES_UnionMember ES_UnionMember
		{
			get
			{
				ES_UnionMember es = this.m_es_unionmember;
				if (es == null)
				{
					string path = "Assets/Bundles/UI/Common/ES_UnionMember.prefab";
					GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<GameObject>(path);
					GameObject go = UnityEngine.Object.Instantiate(prefab, this.EG_SubViewNodeRectTransform);
					go.SetActive(true);
					this.AssetList.Add(path);
					this.m_es_unionmember = this.AddChild<ES_UnionMember, Transform>(go.transform);
					go.SetActive(false);
				}

				return this.m_es_unionmember;
			}
		}

		public ES_UnionWish ES_UnionWish
		{
			get
			{
				ES_UnionWish es = this.m_es_unionwish;
				if (es == null)
				{
					string path = "Assets/Bundles/UI/Common/ES_UnionWish.prefab";
					GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<GameObject>(path);
					GameObject go = UnityEngine.Object.Instantiate(prefab, this.EG_SubViewNodeRectTransform);
					go.SetActive(true);
					this.AssetList.Add(path);
					this.m_es_unionwish = this.AddChild<ES_UnionWish, Transform>(go.transform);
					go.SetActive(false);
				}

				return this.m_es_unionwish;
			}
		}
		
		//m_es_unionorder
		public ES_UnionOrder ES_UnionOrder
        {
        	get
        	{
		        ES_UnionOrder es = this.m_es_unionorder;
        		if (es == null)
        		{
        			string path = "Assets/Bundles/UI/Common/ES_UnionOrder.prefab";
        			GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<GameObject>(path);
        			GameObject go = UnityEngine.Object.Instantiate(prefab, this.EG_SubViewNodeRectTransform);
        			go.SetActive(true);
        			this.AssetList.Add(path);
        			this.m_es_unionorder = this.AddChild<ES_UnionOrder, Transform>(go.transform);
			        go.SetActive(false);
        		}

        		return this.m_es_unionorder;
        	}
        }
		
		public ES_UnionMystery ES_UnionMystery
		{
			get
			{
				ES_UnionMystery es = this.m_es_unionmystery;
				if (es == null)
				{
					string path = "Assets/Bundles/UI/Common/ES_UnionMystery.prefab";
					GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<GameObject>(path);
					GameObject go = UnityEngine.Object.Instantiate(prefab, this.EG_SubViewNodeRectTransform);
					go.SetActive(true);
					this.AssetList.Add(path);
					this.m_es_unionmystery = this.AddChild<ES_UnionMystery, Transform>(go.transform);
					go.SetActive(false);
				}

				return this.m_es_unionmystery;
			}
		}
		
		public ES_UnionBoss ES_UnionBoss
		{
			get
			{
				ES_UnionBoss es = this.m_es_unionboss;
				if (es == null)
				{
					string path = "Assets/Bundles/UI/Common/ES_UnionBoss.prefab";
					GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>().LoadAssetSync<GameObject>(path);
					GameObject go = UnityEngine.Object.Instantiate(prefab, this.EG_SubViewNodeRectTransform);
					go.SetActive(true);
					this.AssetList.Add(path);
					this.m_es_unionboss = this.AddChild<ES_UnionBoss, Transform>(go.transform);
					go.SetActive(false);
				}

				return this.m_es_unionboss;
			}
		}
        
		public void DestroyWidget()
		{
			this.m_EG_SubViewNodeRectTransform = null;
			this.m_E_FunctionSetBtnToggleGroup = null;
			this.m_es_unionshow = null;
			this.m_es_unionmy = null;
			this.m_es_unionmystery = null;
			this.m_es_unionboss = null;
			this.uiTransform = null;
			this.m_es_unionmember = null;
			this.m_es_unionwish = null;
			this.m_es_unionorder = null;
			
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
		private EntityRef<ES_UnionShow> m_es_unionshow = null;
		private EntityRef<ES_UnionMy> m_es_unionmy = null;
		private EntityRef<ES_UnionMember> m_es_unionmember = null;
		private EntityRef<ES_UnionMystery> m_es_unionmystery = null;
		private EntityRef<ES_UnionBoss> m_es_unionboss = null;
		private EntityRef<ES_UnionWish> m_es_unionwish = null;
		private EntityRef<ES_UnionOrder> m_es_unionorder = null;
        public Transform uiTransform = null;
	}
}
