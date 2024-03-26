
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

		public void DestroyWidget()
		{
			this.m_E_FunctionSetBtnToggleGroup = null;
			this.m_E_PetToggle = null;
			this.m_E_HeChengToggle = null;
			this.m_E_XiLianToggle = null;
			this.m_E_ShouHuToggle = null;
			this.m_EG_SubViewRectTransform = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.ToggleGroup m_E_FunctionSetBtnToggleGroup = null;
		private UnityEngine.UI.Toggle m_E_PetToggle = null;
		private UnityEngine.UI.Toggle m_E_HeChengToggle = null;
		private UnityEngine.UI.Toggle m_E_XiLianToggle = null;
		private UnityEngine.UI.Toggle m_E_ShouHuToggle = null;
		private UnityEngine.RectTransform m_EG_SubViewRectTransform = null;
		public Transform uiTransform = null;
	}
}
