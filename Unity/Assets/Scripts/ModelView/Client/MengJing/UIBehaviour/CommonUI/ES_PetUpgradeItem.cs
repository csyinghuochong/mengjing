
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_PetUpgradeItem : Entity,ET.IAwake<UnityEngine.Transform>,IDestroy 
	{
		public UnityEngine.UI.Image EPetBarIconSelectImageImage
		{
			get
			{
				if (this.uiTransform == null)
				{
					Log.Error("uiTransform is null.");
					return null;
				}
				if( this.m_E_PetBarIconSelectImage == null )
				{
					this.m_E_PetBarIconSelectImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_PetBarIconSelect");
				}
				return this.m_E_PetBarIconSelectImage;
			}
		}
				
		public UnityEngine.UI.Image E_PetBarIconImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_PetBarIconImage == null )
     			{
		    		this.m_E_PetBarIconImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_PetBarIcon");
     			}
     			return this.m_E_PetBarIconImage;
     		}
     	}

		public UnityEngine.UI.Text E_PetBarNameText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_PetBarNameText == null )
     			{
		    		this.m_E_PetBarNameText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_PetBarName");
     			}
     			return this.m_E_PetBarNameText;
     		}
     	}

		public UnityEngine.UI.Text E_PetBarLvText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_PetBarLvText == null )
     			{
		    		this.m_E_PetBarLvText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_PetBarLv");
     			}
     			return this.m_E_PetBarLvText;
     		}
     	}

		public UnityEngine.UI.Button E_TouchButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TouchButton == null )
     			{
		    		this.m_E_TouchButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_Touch");
     			}
     			return this.m_E_TouchButton;
     		}
     	}

		public UnityEngine.UI.Image E_TouchImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TouchImage == null )
     			{
		    		this.m_E_TouchImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Touch");
     			}
     			return this.m_E_TouchImage;
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
			this.m_E_PetBarIconSelectImage = null;
			this.m_E_PetBarIconImage = null;
			this.m_E_PetBarNameText = null;
			this.m_E_PetBarLvText = null;
			this.m_E_TouchButton = null;
			this.m_E_TouchImage = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.Image m_E_PetBarIconSelectImage = null;
		private UnityEngine.UI.Image m_E_PetBarIconImage = null;
		private UnityEngine.UI.Text m_E_PetBarNameText = null;
		private UnityEngine.UI.Text m_E_PetBarLvText = null;
		private UnityEngine.UI.Button m_E_TouchButton = null;
		private UnityEngine.UI.Image m_E_TouchImage = null;
		public Transform uiTransform = null;
	}
}
