using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ComponentOf(typeof(DlgPetSet))]
	[EnableMethod]
	public  class DlgPetSetViewComponent : Entity,IAwake,IDestroy 
	{
		public RectTransform EG_SubViewRectTransform
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
		    		this.m_EG_SubViewRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_SubView");
     			}
     			return this.m_EG_SubViewRectTransform;
     		}
     	}

		public ES_PetChallenge ES_PetChallenge
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			ES_PetChallenge es = this.m_es_petchallenge;
     			if( es == null )

     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_SubView/ES_PetChallenge");
		    	   this.m_es_petchallenge = this.AddChild<ES_PetChallenge,Transform>(subTrans);
     			}
     			return this.m_es_petchallenge;
     		}
     	}

		public ES_PetMining ES_PetMining
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			ES_PetMining es = this.m_es_petmining;
     			if( es == null )

     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_SubView/ES_PetMining");
		    	   this.m_es_petmining = this.AddChild<ES_PetMining,Transform>(subTrans);
     			}
     			return this.m_es_petmining;
     		}
     	}

		public ToggleGroup E_FunctionSetBtnToggleGroup
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
		    		this.m_E_FunctionSetBtnToggleGroup = UIFindHelper.FindDeepChild<ToggleGroup>(this.uiTransform.gameObject,"E_FunctionSetBtn");
     			}
     			return this.m_E_FunctionSetBtnToggleGroup;
     		}
     	}

		public Toggle E_Type_1Toggle
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
		    		this.m_E_Type_1Toggle = UIFindHelper.FindDeepChild<Toggle>(this.uiTransform.gameObject,"E_FunctionSetBtn/E_Type_1");
     			}
     			return this.m_E_Type_1Toggle;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_EG_SubViewRectTransform = null;
			this.m_es_petchallenge = null;
			this.m_es_petmining = null;
			this.m_E_FunctionSetBtnToggleGroup = null;
			this.m_E_Type_1Toggle = null;
			this.uiTransform = null;
		}

		private RectTransform m_EG_SubViewRectTransform = null;
		private EntityRef<ES_PetChallenge> m_es_petchallenge = null;
		private EntityRef<ES_PetMining> m_es_petmining = null;
		private ToggleGroup m_E_FunctionSetBtnToggleGroup = null;
		private Toggle m_E_Type_1Toggle = null;
		public Transform uiTransform = null;
	}
}
