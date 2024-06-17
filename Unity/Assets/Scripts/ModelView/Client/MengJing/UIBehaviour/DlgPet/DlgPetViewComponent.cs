
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ComponentOf(typeof(DlgPet))]
	[EnableMethod]
	public  class DlgPetViewComponent : Entity,IAwake,IDestroy 
	{
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

		public UnityEngine.UI.Toggle E_PetToggle
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_PetToggle == null )
     			{
		    		this.m_E_PetToggle = UIFindHelper.FindDeepChild<UnityEngine.UI.Toggle>(this.uiTransform.gameObject,"E_FunctionSetBtn/E_Pet");
     			}
     			return this.m_E_PetToggle;
     		}
     	}

		public UnityEngine.UI.Toggle E_HeChengToggle
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_HeChengToggle == null )
     			{
		    		this.m_E_HeChengToggle = UIFindHelper.FindDeepChild<UnityEngine.UI.Toggle>(this.uiTransform.gameObject,"E_FunctionSetBtn/E_HeCheng");
     			}
     			return this.m_E_HeChengToggle;
     		}
     	}

		public UnityEngine.UI.Toggle E_XiLianToggle
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_XiLianToggle == null )
     			{
		    		this.m_E_XiLianToggle = UIFindHelper.FindDeepChild<UnityEngine.UI.Toggle>(this.uiTransform.gameObject,"E_FunctionSetBtn/E_XiLian");
     			}
     			return this.m_E_XiLianToggle;
     		}
     	}

		public UnityEngine.UI.Toggle E_ShouHuToggle
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ShouHuToggle == null )
     			{
		    		this.m_E_ShouHuToggle = UIFindHelper.FindDeepChild<UnityEngine.UI.Toggle>(this.uiTransform.gameObject,"E_FunctionSetBtn/E_ShouHu");
     			}
     			return this.m_E_ShouHuToggle;
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

		public ES_PetList ES_PetList
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_es_petlist ==null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_SubView/ES_PetList");
		    	   this.m_es_petlist = this.AddChild<ES_PetList,Transform>(subTrans);
     			}
     			return this.m_es_petlist;
     		}
     	}

		public ES_PetHeCheng ES_PetHeCheng
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_es_pethecheng ==null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_SubView/ES_PetHeCheng");
		    	   this.m_es_pethecheng = this.AddChild<ES_PetHeCheng,Transform>(subTrans);
     			}
     			return this.m_es_pethecheng;
     		}
     	}

		public ES_PetXiLian ES_PetXiLian
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_es_petxilian ==null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_SubView/ES_PetXiLian");
		    	   this.m_es_petxilian = this.AddChild<ES_PetXiLian,Transform>(subTrans);
     			}
     			return this.m_es_petxilian;
     		}
     	}

		public ES_PetShouHu ES_PetShouHu
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_es_petshouhu ==null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"EG_SubView/ES_PetShouHu");
		    	   this.m_es_petshouhu = this.AddChild<ES_PetShouHu,Transform>(subTrans);
     			}
     			return this.m_es_petshouhu;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_FunctionSetBtnToggleGroup = null;
			this.m_E_PetToggle = null;
			this.m_E_HeChengToggle = null;
			this.m_E_XiLianToggle = null;
			this.m_E_ShouHuToggle = null;
			this.m_EG_SubViewRectTransform = null;
			this.m_es_petlist = null;
			this.m_es_pethecheng = null;
			this.m_es_petxilian = null;
			this.m_es_petshouhu = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.ToggleGroup m_E_FunctionSetBtnToggleGroup = null;
		private UnityEngine.UI.Toggle m_E_PetToggle = null;
		private UnityEngine.UI.Toggle m_E_HeChengToggle = null;
		private UnityEngine.UI.Toggle m_E_XiLianToggle = null;
		private UnityEngine.UI.Toggle m_E_ShouHuToggle = null;
		private UnityEngine.RectTransform m_EG_SubViewRectTransform = null;
		private EntityRef<ES_PetList> m_es_petlist = null;
		private EntityRef<ES_PetHeCheng> m_es_pethecheng = null;
		private EntityRef<ES_PetXiLian> m_es_petxilian = null;
		private EntityRef<ES_PetShouHu> m_es_petshouhu = null;
		public Transform uiTransform = null;
	}
}
