using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_ProtectPet : Entity,IAwake<Transform>,IDestroy,IUILogic
	{
		
		public long PetInfoId;
		public Dictionary<int, EntityRef<Scroll_Item_PetListItem>> ScrollItemPetListItems;
		public List<RolePetInfo> ShowRolePetInfos = new();
		
		public LoopVerticalScrollRect E_PetListItemsLoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_PetListItemsLoopVerticalScrollRect == null )
     			{
		    		this.m_E_PetListItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<LoopVerticalScrollRect>(this.uiTransform.gameObject,"Left/E_PetListItems");
     			}
     			return this.m_E_PetListItemsLoopVerticalScrollRect;
     		}
     	}

		public Button E_XiLianButtonButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_XiLianButtonButton == null )
     			{
		    		this.m_E_XiLianButtonButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"Right/E_XiLianButton");
     			}
     			return this.m_E_XiLianButtonButton;
     		}
     	}

		public Image E_XiLianButtonImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_XiLianButtonImage == null )
     			{
		    		this.m_E_XiLianButtonImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"Right/E_XiLianButton");
     			}
     			return this.m_E_XiLianButtonImage;
     		}
     	}

		public Button E_UnlockButtonButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_UnlockButtonButton == null )
     			{
		    		this.m_E_UnlockButtonButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"Right/E_UnlockButton");
     			}
     			return this.m_E_UnlockButtonButton;
     		}
     	}

		public Image E_UnlockButtonImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_UnlockButtonImage == null )
     			{
		    		this.m_E_UnlockButtonImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"Right/E_UnlockButton");
     			}
     			return this.m_E_UnlockButtonImage;
     		}
     	}

		public Text E_Text_NameText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_NameText == null )
     			{
		    		this.m_E_Text_NameText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"Right/E_Text_Name");
     			}
     			return this.m_E_Text_NameText;
     		}
     	}

		public Image E_PetIconImage
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
		    		this.m_E_PetIconImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"Right/E_PetIcon");
     			}
     			return this.m_E_PetIconImage;
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
			this.m_E_PetListItemsLoopVerticalScrollRect = null;
			this.m_E_XiLianButtonButton = null;
			this.m_E_XiLianButtonImage = null;
			this.m_E_UnlockButtonButton = null;
			this.m_E_UnlockButtonImage = null;
			this.m_E_Text_NameText = null;
			this.m_E_PetIconImage = null;
			this.uiTransform = null;
		}

		private LoopVerticalScrollRect m_E_PetListItemsLoopVerticalScrollRect = null;
		private Button m_E_XiLianButtonButton = null;
		private Image m_E_XiLianButtonImage = null;
		private Button m_E_UnlockButtonButton = null;
		private Image m_E_UnlockButtonImage = null;
		private Text m_E_Text_NameText = null;
		private Image m_E_PetIconImage = null;
		public Transform uiTransform = null;
	}
}
