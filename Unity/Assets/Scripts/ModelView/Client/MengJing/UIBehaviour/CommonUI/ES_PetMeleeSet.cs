
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_PetMeleeSet : Entity,ET.IAwake<UnityEngine.Transform>,IDestroy 
	{
		public UnityEngine.UI.ToggleGroup E_PlanSetToggleGroup
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_PlanSetToggleGroup == null )
     			{
		    		this.m_E_PlanSetToggleGroup = UIFindHelper.FindDeepChild<UnityEngine.UI.ToggleGroup>(this.uiTransform.gameObject,"Left/E_PlanSet");
     			}
     			return this.m_E_PlanSetToggleGroup;
     		}
     	}

		public UnityEngine.UI.Button E_SetMainButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SetMainButton == null )
     			{
		    		this.m_E_SetMainButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Left/E_SetMain");
     			}
     			return this.m_E_SetMainButton;
     		}
     	}

		public UnityEngine.UI.Image E_SetMainImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SetMainImage == null )
     			{
		    		this.m_E_SetMainImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Left/E_SetMain");
     			}
     			return this.m_E_SetMainImage;
     		}
     	}

		public UnityEngine.UI.Button E_SetAssistButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SetAssistButton == null )
     			{
		    		this.m_E_SetAssistButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Left/E_SetAssist");
     			}
     			return this.m_E_SetAssistButton;
     		}
     	}

		public UnityEngine.UI.Image E_SetAssistImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SetAssistImage == null )
     			{
		    		this.m_E_SetAssistImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Left/E_SetAssist");
     			}
     			return this.m_E_SetAssistImage;
     		}
     	}

		public UnityEngine.UI.Button E_PetBarSetIconButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_PetBarSetIconButton == null )
     			{
		    		this.m_E_PetBarSetIconButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Left/PetMask/E_PetBarSetIcon");
     			}
     			return this.m_E_PetBarSetIconButton;
     		}
     	}

		public UnityEngine.UI.Image E_PetBarSetIconImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_PetBarSetIconImage == null )
     			{
		    		this.m_E_PetBarSetIconImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Left/PetMask/E_PetBarSetIcon");
     			}
     			return this.m_E_PetBarSetIconImage;
     		}
     	}

		public UnityEngine.UI.Button E_SetMagicButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SetMagicButton == null )
     			{
		    		this.m_E_SetMagicButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Left/E_SetMagic");
     			}
     			return this.m_E_SetMagicButton;
     		}
     	}

		public UnityEngine.UI.Image E_SetMagicImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SetMagicImage == null )
     			{
		    		this.m_E_SetMagicImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Left/E_SetMagic");
     			}
     			return this.m_E_SetMagicImage;
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
			this.m_E_PlanSetToggleGroup = null;
			this.m_E_SetMainButton = null;
			this.m_E_SetMainImage = null;
			this.m_E_SetAssistButton = null;
			this.m_E_SetAssistImage = null;
			this.m_E_PetBarSetIconButton = null;
			this.m_E_PetBarSetIconImage = null;
			this.m_E_SetMagicButton = null;
			this.m_E_SetMagicImage = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.ToggleGroup m_E_PlanSetToggleGroup = null;
		private UnityEngine.UI.Button m_E_SetMainButton = null;
		private UnityEngine.UI.Image m_E_SetMainImage = null;
		private UnityEngine.UI.Button m_E_SetAssistButton = null;
		private UnityEngine.UI.Image m_E_SetAssistImage = null;
		private UnityEngine.UI.Button m_E_PetBarSetIconButton = null;
		private UnityEngine.UI.Image m_E_PetBarSetIconImage = null;
		private UnityEngine.UI.Button m_E_SetMagicButton = null;
		private UnityEngine.UI.Image m_E_SetMagicImage = null;
		public Transform uiTransform = null;
	}
}
