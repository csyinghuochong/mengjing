
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_MainPetFight : Entity,ET.IAwake<UnityEngine.Transform>,IDestroy 
	{

		public int FightIndex;
		public long Timer;
		public bool LongPress;
		public long LastTimer;
		
		public UnityEngine.UI.Image E_PetHPImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_PetHPImage == null )
     			{
		    		this.m_E_PetHPImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_PetHP");
     			}
     			return this.m_E_PetHPImage;
     		}
     	}

		public UnityEngine.UI.Image E_PetIconImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_PetIconImage == null )
     			{
		    		this.m_E_PetIconImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Mask/E_PetIcon");
     			}
     			return this.m_E_PetIconImage;
     		}
     	}

		public UnityEngine.UI.Text E_PetLvText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_PetLvText == null )
     			{
		    		this.m_E_PetLvText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Image/E_PetLv");
     			}
     			return this.m_E_PetLvText;
     		}
     	}

		public UnityEngine.UI.Image E_ClickImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ClickImage == null )
     			{
		    		this.m_E_ClickImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_Click");
     			}
     			return this.m_E_ClickImage;
     		}
     	}

		public UnityEngine.EventSystems.EventTrigger E_ClickEventTrigger
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ClickEventTrigger == null )
     			{
		    		this.m_E_ClickEventTrigger = UIFindHelper.FindDeepChild<UnityEngine.EventSystems.EventTrigger>(this.uiTransform.gameObject,"E_Click");
     			}
     			return this.m_E_ClickEventTrigger;
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
			this.m_E_PetHPImage = null;
			this.m_E_PetIconImage = null;
			this.m_E_PetLvText = null;
			this.m_E_ClickImage = null;
			this.m_E_ClickEventTrigger = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.Image m_E_PetHPImage = null;
		private UnityEngine.UI.Image m_E_PetIconImage = null;
		private UnityEngine.UI.Text m_E_PetLvText = null;
		private UnityEngine.UI.Image m_E_ClickImage = null;
		private UnityEngine.EventSystems.EventTrigger m_E_ClickEventTrigger = null;
		public Transform uiTransform = null;
	}
}
