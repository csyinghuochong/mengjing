﻿
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ComponentOf(typeof(DlgUnionMystery))]
	[EnableMethod]
	public  class DlgUnionMysteryViewComponent : Entity,IAwake,IDestroy 
	{
		public ES_ModelShow ES_ModelShow
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			ES_ModelShow es = this.m_es_modelshow;
     			if( es == null )

     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"ES_ModelShow");
		    	   this.m_es_modelshow = this.AddChild<ES_ModelShow,Transform>(subTrans);
     			}
     			return this.m_es_modelshow;
     		}
     	}

		public UnityEngine.RectTransform EG_SubViewRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_SubViewRectTransform == null )
     			{
		    		this.m_EG_SubViewRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_SubView");
     			}
     			return this.m_EG_SubViewRectTransform;
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

		public ES_UnionMystery_A ES_UnionMystery_A
		{
			get
			{
				ES_UnionMystery_A es = this.m_es_unionmystery_a;
				if (es == null)
				{
					GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>()
							.LoadAssetSync<GameObject>("Assets/Bundles/UI/Common/ES_UnionMystery_A.prefab");
					GameObject go = UnityEngine.Object.Instantiate(prefab, this.EG_SubViewRectTransform);
					go.SetActive(false);
					this.m_es_unionmystery_a = this.AddChild<ES_UnionMystery_A, Transform>(go.transform);
				}

				return this.m_es_unionmystery_a;
			}
		}

		public ES_UnionMystery_B ES_UnionMystery_B
		{
			get
			{
				ES_UnionMystery_B es = this.m_es_unionmystery_b;
				if (es == null)
				{
					GameObject prefab = this.Root().GetComponent<ResourcesLoaderComponent>()
							.LoadAssetSync<GameObject>("Assets/Bundles/UI/Common/ES_UnionMystery_B.prefab");
					GameObject go = UnityEngine.Object.Instantiate(prefab, this.EG_SubViewRectTransform);
					go.SetActive(false);
					this.m_es_unionmystery_b = this.AddChild<ES_UnionMystery_B, Transform>(go.transform);
				}

				return this.m_es_unionmystery_b;
			}
		}
		
		public void DestroyWidget()
		{
			this.m_es_modelshow = null;
			this.m_EG_SubViewRectTransform = null;
			this.m_E_FunctionSetBtnToggleGroup = null;
			this.m_es_unionmystery_a = null;
			this.m_es_unionmystery_b = null;
			this.uiTransform = null;
		}

		private EntityRef<ES_ModelShow> m_es_modelshow = null;
		private UnityEngine.RectTransform m_EG_SubViewRectTransform = null;
		private UnityEngine.UI.ToggleGroup m_E_FunctionSetBtnToggleGroup = null;
		private EntityRef<ES_UnionMystery_A> m_es_unionmystery_a = null;
		private EntityRef<ES_UnionMystery_B> m_es_unionmystery_b = null;
		public Transform uiTransform = null;
	}
}
