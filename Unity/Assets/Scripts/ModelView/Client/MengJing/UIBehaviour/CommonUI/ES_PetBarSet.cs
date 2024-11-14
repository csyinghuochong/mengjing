
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_PetBarSet : Entity,ET.IAwake<UnityEngine.Transform>,IDestroy 
	{
		public UnityEngine.RectTransform EG_PlanSetRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_PlanSetRectTransform == null )
     			{
		    		this.m_EG_PlanSetRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Left/EG_PlanSet");
     			}
     			return this.m_EG_PlanSetRectTransform;
     		}
     	}

		public UnityEngine.UI.ToggleGroup E_PetTypeSetToggleGroup
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_PetTypeSetToggleGroup == null )
     			{
		    		this.m_E_PetTypeSetToggleGroup = UIFindHelper.FindDeepChild<UnityEngine.UI.ToggleGroup>(this.uiTransform.gameObject,"Right/E_PetTypeSet");
     			}
     			return this.m_E_PetTypeSetToggleGroup;
     		}
     	}

		public UnityEngine.UI.Button E_ConfirmButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ConfirmButton == null )
     			{
		    		this.m_E_ConfirmButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/E_Confirm");
     			}
     			return this.m_E_ConfirmButton;
     		}
     	}

		public UnityEngine.UI.Image E_ConfirmImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ConfirmImage == null )
     			{
		    		this.m_E_ConfirmImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_Confirm");
     			}
     			return this.m_E_ConfirmImage;
     		}
     	}

		    public Transform UITransform
         {
     	    get
     	    {
     		    return this.uiTransform;
     	    }
     	    set
     	    {
     		    this.uiTransform = value;
     	    }
         }

		public void DestroyWidget()
		{
			this.m_EG_PlanSetRectTransform = null;
			this.m_E_PetTypeSetToggleGroup = null;
			this.m_E_ConfirmButton = null;
			this.m_E_ConfirmImage = null;
			this.uiTransform = null;
		}

		private UnityEngine.RectTransform m_EG_PlanSetRectTransform = null;
		private UnityEngine.UI.ToggleGroup m_E_PetTypeSetToggleGroup = null;
		private UnityEngine.UI.Button m_E_ConfirmButton = null;
		private UnityEngine.UI.Image m_E_ConfirmImage = null;
		public Transform uiTransform = null;
	}
}
