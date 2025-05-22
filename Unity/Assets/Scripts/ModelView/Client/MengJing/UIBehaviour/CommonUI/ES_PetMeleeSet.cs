
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_PetMeleeSet : Entity,ET.IAwake<UnityEngine.Transform>,IDestroy,IUILogic
	{
		public GameObject MainPetItem;
		public GameObject AssistPetItem;
		public GameObject MagicItem;
		public List<GameObject> MainPetItemList = new();
		public List<GameObject> AssistPetItemList = new();
		public List<GameObject> MagicItemList = new();
		public PetMeleeInfo PetMeleeInfo;
		public Dictionary<int, EntityRef<Scroll_Item_SelectMainPetItem>> ScrollItemSelectMainPetItems;
		public List<RolePetInfo> ShowMainPets = new();
		public List<long> SelectMainPets = new();
		public Dictionary<int, EntityRef<Scroll_Item_SelectAssistPetItem>> ScrollItemSelectAssistPetItems;
		public List<int> ShowAssistPets = new();
		public List<int> SelectAssistPets = new();
		public Dictionary<int, EntityRef<Scroll_Item_SelectMagicItem>> ScrollItemSelectMagicItems;
		public List<int> ShowMagics = new();
		public List<int> SelectMagics = new();
		
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

		public UnityEngine.RectTransform EG_MainPetListRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_MainPetListRectTransform == null )
     			{
		    		this.m_EG_MainPetListRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Left/EG_MainPetList");
     			}
     			return this.m_EG_MainPetListRectTransform;
     		}
     	}

		public UnityEngine.RectTransform EG_AssistPetListRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_AssistPetListRectTransform == null )
     			{
		    		this.m_EG_AssistPetListRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Left/EG_AssistPetList");
     			}
     			return this.m_EG_AssistPetListRectTransform;
     		}
     	}

		public UnityEngine.RectTransform EG_MagicListRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_MagicListRectTransform == null )
     			{
		    		this.m_EG_MagicListRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Left/EG_MagicList");
     			}
     			return this.m_EG_MagicListRectTransform;
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

		public UnityEngine.UI.Button E_CloseButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_CloseButton == null )
     			{
		    		this.m_E_CloseButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Center/E_Close");
     			}
     			return this.m_E_CloseButton;
     		}
     	}

		public UnityEngine.UI.Image E_CloseImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_CloseImage == null )
     			{
		    		this.m_E_CloseImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Center/E_Close");
     			}
     			return this.m_E_CloseImage;
     		}
     	}

		public UnityEngine.RectTransform EG_SelectMainPetItemPanelRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_SelectMainPetItemPanelRectTransform == null )
     			{
		    		this.m_EG_SelectMainPetItemPanelRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Center/EG_SelectMainPetItemPanel");
     			}
     			return this.m_EG_SelectMainPetItemPanelRectTransform;
     		}
     	}

		public UnityEngine.UI.Button E_SelectMainPetItemCloseButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SelectMainPetItemCloseButton == null )
     			{
		    		this.m_E_SelectMainPetItemCloseButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Center/EG_SelectMainPetItemPanel/E_SelectMainPetItemClose");
     			}
     			return this.m_E_SelectMainPetItemCloseButton;
     		}
     	}

		public UnityEngine.UI.Image E_SelectMainPetItemCloseImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SelectMainPetItemCloseImage == null )
     			{
		    		this.m_E_SelectMainPetItemCloseImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Center/EG_SelectMainPetItemPanel/E_SelectMainPetItemClose");
     			}
     			return this.m_E_SelectMainPetItemCloseImage;
     		}
     	}

		public UnityEngine.UI.Image E_SelectMainPetItemsImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SelectMainPetItemsImage == null )
     			{
		    		this.m_E_SelectMainPetItemsImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Center/EG_SelectMainPetItemPanel/E_SelectMainPetItems");
     			}
     			return this.m_E_SelectMainPetItemsImage;
     		}
     	}

		public UnityEngine.UI.LoopVerticalScrollRect E_SelectMainPetItemsLoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SelectMainPetItemsLoopVerticalScrollRect == null )
     			{
		    		this.m_E_SelectMainPetItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopVerticalScrollRect>(this.uiTransform.gameObject,"Center/EG_SelectMainPetItemPanel/E_SelectMainPetItems");
     			}
     			return this.m_E_SelectMainPetItemsLoopVerticalScrollRect;
     		}
     	}

		public UnityEngine.UI.Text E_SelectMainPetItemNumText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SelectMainPetItemNumText == null )
     			{
		    		this.m_E_SelectMainPetItemNumText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Center/EG_SelectMainPetItemPanel/E_SelectMainPetItemNum");
     			}
     			return this.m_E_SelectMainPetItemNumText;
     		}
     	}

		public UnityEngine.UI.Button E_SelectMainPetItemConfirmButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SelectMainPetItemConfirmButton == null )
     			{
		    		this.m_E_SelectMainPetItemConfirmButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Center/EG_SelectMainPetItemPanel/E_SelectMainPetItemConfirm");
     			}
     			return this.m_E_SelectMainPetItemConfirmButton;
     		}
     	}

		public UnityEngine.UI.Image E_SelectMainPetItemConfirmImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SelectMainPetItemConfirmImage == null )
     			{
		    		this.m_E_SelectMainPetItemConfirmImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Center/EG_SelectMainPetItemPanel/E_SelectMainPetItemConfirm");
     			}
     			return this.m_E_SelectMainPetItemConfirmImage;
     		}
     	}

		public UnityEngine.UI.Button E_SelectMainPetItemClose_2Button
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SelectMainPetItemClose_2Button == null )
     			{
		    		this.m_E_SelectMainPetItemClose_2Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Center/EG_SelectMainPetItemPanel/E_SelectMainPetItemClose_2");
     			}
     			return this.m_E_SelectMainPetItemClose_2Button;
     		}
     	}

		public UnityEngine.UI.Image E_SelectMainPetItemClose_2Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SelectMainPetItemClose_2Image == null )
     			{
		    		this.m_E_SelectMainPetItemClose_2Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Center/EG_SelectMainPetItemPanel/E_SelectMainPetItemClose_2");
     			}
     			return this.m_E_SelectMainPetItemClose_2Image;
     		}
     	}

		public UnityEngine.RectTransform EG_SelectAssistPetItemPanelRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_SelectAssistPetItemPanelRectTransform == null )
     			{
		    		this.m_EG_SelectAssistPetItemPanelRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Center/EG_SelectAssistPetItemPanel");
     			}
     			return this.m_EG_SelectAssistPetItemPanelRectTransform;
     		}
     	}

		public UnityEngine.UI.Button E_SelectAssistPetItemCloseButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SelectAssistPetItemCloseButton == null )
     			{
		    		this.m_E_SelectAssistPetItemCloseButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Center/EG_SelectAssistPetItemPanel/E_SelectAssistPetItemClose");
     			}
     			return this.m_E_SelectAssistPetItemCloseButton;
     		}
     	}

		public UnityEngine.UI.Image E_SelectAssistPetItemCloseImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SelectAssistPetItemCloseImage == null )
     			{
		    		this.m_E_SelectAssistPetItemCloseImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Center/EG_SelectAssistPetItemPanel/E_SelectAssistPetItemClose");
     			}
     			return this.m_E_SelectAssistPetItemCloseImage;
     		}
     	}

		public UnityEngine.UI.Image E_SelectAssistPetItemsImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SelectAssistPetItemsImage == null )
     			{
		    		this.m_E_SelectAssistPetItemsImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Center/EG_SelectAssistPetItemPanel/E_SelectAssistPetItems");
     			}
     			return this.m_E_SelectAssistPetItemsImage;
     		}
     	}

		public UnityEngine.UI.LoopVerticalScrollRect E_SelectAssistPetItemsLoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SelectAssistPetItemsLoopVerticalScrollRect == null )
     			{
		    		this.m_E_SelectAssistPetItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopVerticalScrollRect>(this.uiTransform.gameObject,"Center/EG_SelectAssistPetItemPanel/E_SelectAssistPetItems");
     			}
     			return this.m_E_SelectAssistPetItemsLoopVerticalScrollRect;
     		}
     	}

		public UnityEngine.UI.Text E_SelectAssistPetItemNumText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SelectAssistPetItemNumText == null )
     			{
		    		this.m_E_SelectAssistPetItemNumText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Center/EG_SelectAssistPetItemPanel/E_SelectAssistPetItemNum");
     			}
     			return this.m_E_SelectAssistPetItemNumText;
     		}
     	}

		public UnityEngine.UI.Button E_SelectAssistPetItemConfirmButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SelectAssistPetItemConfirmButton == null )
     			{
		    		this.m_E_SelectAssistPetItemConfirmButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Center/EG_SelectAssistPetItemPanel/E_SelectAssistPetItemConfirm");
     			}
     			return this.m_E_SelectAssistPetItemConfirmButton;
     		}
     	}

		public UnityEngine.UI.Image E_SelectAssistPetItemConfirmImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SelectAssistPetItemConfirmImage == null )
     			{
		    		this.m_E_SelectAssistPetItemConfirmImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Center/EG_SelectAssistPetItemPanel/E_SelectAssistPetItemConfirm");
     			}
     			return this.m_E_SelectAssistPetItemConfirmImage;
     		}
     	}

		public UnityEngine.UI.Button E_SelectAssistPetItemClose_2Button
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SelectAssistPetItemClose_2Button == null )
     			{
		    		this.m_E_SelectAssistPetItemClose_2Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Center/EG_SelectAssistPetItemPanel/E_SelectAssistPetItemClose_2");
     			}
     			return this.m_E_SelectAssistPetItemClose_2Button;
     		}
     	}

		public UnityEngine.UI.Image E_SelectAssistPetItemClose_2Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SelectAssistPetItemClose_2Image == null )
     			{
		    		this.m_E_SelectAssistPetItemClose_2Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Center/EG_SelectAssistPetItemPanel/E_SelectAssistPetItemClose_2");
     			}
     			return this.m_E_SelectAssistPetItemClose_2Image;
     		}
     	}

		public UnityEngine.RectTransform EG_SelectMagicItemPanelRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_SelectMagicItemPanelRectTransform == null )
     			{
		    		this.m_EG_SelectMagicItemPanelRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Center/EG_SelectMagicItemPanel");
     			}
     			return this.m_EG_SelectMagicItemPanelRectTransform;
     		}
     	}

		public UnityEngine.UI.Button E_SelectMagicItemCloseButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SelectMagicItemCloseButton == null )
     			{
		    		this.m_E_SelectMagicItemCloseButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Center/EG_SelectMagicItemPanel/E_SelectMagicItemClose");
     			}
     			return this.m_E_SelectMagicItemCloseButton;
     		}
     	}

		public UnityEngine.UI.Image E_SelectMagicItemCloseImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SelectMagicItemCloseImage == null )
     			{
		    		this.m_E_SelectMagicItemCloseImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Center/EG_SelectMagicItemPanel/E_SelectMagicItemClose");
     			}
     			return this.m_E_SelectMagicItemCloseImage;
     		}
     	}

		public UnityEngine.UI.Image E_SelectMagicItemsImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SelectMagicItemsImage == null )
     			{
		    		this.m_E_SelectMagicItemsImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Center/EG_SelectMagicItemPanel/E_SelectMagicItems");
     			}
     			return this.m_E_SelectMagicItemsImage;
     		}
     	}

		public UnityEngine.UI.LoopVerticalScrollRect E_SelectMagicItemsLoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SelectMagicItemsLoopVerticalScrollRect == null )
     			{
		    		this.m_E_SelectMagicItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopVerticalScrollRect>(this.uiTransform.gameObject,"Center/EG_SelectMagicItemPanel/E_SelectMagicItems");
     			}
     			return this.m_E_SelectMagicItemsLoopVerticalScrollRect;
     		}
     	}

		public UnityEngine.UI.Text E_SelectMagicItemNumText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SelectMagicItemNumText == null )
     			{
		    		this.m_E_SelectMagicItemNumText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Center/EG_SelectMagicItemPanel/E_SelectMagicItemNum");
     			}
     			return this.m_E_SelectMagicItemNumText;
     		}
     	}

		public UnityEngine.UI.Button E_SelectMagicItemConfirmButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SelectMagicItemConfirmButton == null )
     			{
		    		this.m_E_SelectMagicItemConfirmButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Center/EG_SelectMagicItemPanel/E_SelectMagicItemConfirm");
     			}
     			return this.m_E_SelectMagicItemConfirmButton;
     		}
     	}

		public UnityEngine.UI.Image E_SelectMagicItemConfirmImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SelectMagicItemConfirmImage == null )
     			{
		    		this.m_E_SelectMagicItemConfirmImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Center/EG_SelectMagicItemPanel/E_SelectMagicItemConfirm");
     			}
     			return this.m_E_SelectMagicItemConfirmImage;
     		}
     	}

		public UnityEngine.UI.Button E_SelectMagicItemClose_2Button
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SelectMagicItemClose_2Button == null )
     			{
		    		this.m_E_SelectMagicItemClose_2Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Center/EG_SelectMagicItemPanel/E_SelectMagicItemClose_2");
     			}
     			return this.m_E_SelectMagicItemClose_2Button;
     		}
     	}

		public UnityEngine.UI.Image E_SelectMagicItemClose_2Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SelectMagicItemClose_2Image == null )
     			{
		    		this.m_E_SelectMagicItemClose_2Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Center/EG_SelectMagicItemPanel/E_SelectMagicItemClose_2");
     			}
     			return this.m_E_SelectMagicItemClose_2Image;
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
			this.m_EG_MainPetListRectTransform = null;
			this.m_EG_AssistPetListRectTransform = null;
			this.m_EG_MagicListRectTransform = null;
			this.m_E_SetMainButton = null;
			this.m_E_SetMainImage = null;
			this.m_E_SetAssistButton = null;
			this.m_E_SetAssistImage = null;
			this.m_E_SetMagicButton = null;
			this.m_E_SetMagicImage = null;
			this.m_E_CloseButton = null;
			this.m_E_CloseImage = null;
			this.m_EG_SelectMainPetItemPanelRectTransform = null;
			this.m_E_SelectMainPetItemCloseButton = null;
			this.m_E_SelectMainPetItemCloseImage = null;
			this.m_E_SelectMainPetItemsImage = null;
			this.m_E_SelectMainPetItemsLoopVerticalScrollRect = null;
			this.m_E_SelectMainPetItemNumText = null;
			this.m_E_SelectMainPetItemConfirmButton = null;
			this.m_E_SelectMainPetItemConfirmImage = null;
			this.m_E_SelectMainPetItemClose_2Button = null;
			this.m_E_SelectMainPetItemClose_2Image = null;
			this.m_EG_SelectAssistPetItemPanelRectTransform = null;
			this.m_E_SelectAssistPetItemCloseButton = null;
			this.m_E_SelectAssistPetItemCloseImage = null;
			this.m_E_SelectAssistPetItemsImage = null;
			this.m_E_SelectAssistPetItemsLoopVerticalScrollRect = null;
			this.m_E_SelectAssistPetItemNumText = null;
			this.m_E_SelectAssistPetItemConfirmButton = null;
			this.m_E_SelectAssistPetItemConfirmImage = null;
			this.m_E_SelectAssistPetItemClose_2Button = null;
			this.m_E_SelectAssistPetItemClose_2Image = null;
			this.m_EG_SelectMagicItemPanelRectTransform = null;
			this.m_E_SelectMagicItemCloseButton = null;
			this.m_E_SelectMagicItemCloseImage = null;
			this.m_E_SelectMagicItemsImage = null;
			this.m_E_SelectMagicItemsLoopVerticalScrollRect = null;
			this.m_E_SelectMagicItemNumText = null;
			this.m_E_SelectMagicItemConfirmButton = null;
			this.m_E_SelectMagicItemConfirmImage = null;
			this.m_E_SelectMagicItemClose_2Button = null;
			this.m_E_SelectMagicItemClose_2Image = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.ToggleGroup m_E_PlanSetToggleGroup = null;
		private UnityEngine.RectTransform m_EG_MainPetListRectTransform = null;
		private UnityEngine.RectTransform m_EG_AssistPetListRectTransform = null;
		private UnityEngine.RectTransform m_EG_MagicListRectTransform = null;
		private UnityEngine.UI.Button m_E_SetMainButton = null;
		private UnityEngine.UI.Image m_E_SetMainImage = null;
		private UnityEngine.UI.Button m_E_SetAssistButton = null;
		private UnityEngine.UI.Image m_E_SetAssistImage = null;
		private UnityEngine.UI.Button m_E_SetMagicButton = null;
		private UnityEngine.UI.Image m_E_SetMagicImage = null;
		private UnityEngine.UI.Button m_E_CloseButton = null;
		private UnityEngine.UI.Image m_E_CloseImage = null;
		private UnityEngine.RectTransform m_EG_SelectMainPetItemPanelRectTransform = null;
		private UnityEngine.UI.Button m_E_SelectMainPetItemCloseButton = null;
		private UnityEngine.UI.Image m_E_SelectMainPetItemCloseImage = null;
		private UnityEngine.UI.Image m_E_SelectMainPetItemsImage = null;
		private UnityEngine.UI.LoopVerticalScrollRect m_E_SelectMainPetItemsLoopVerticalScrollRect = null;
		private UnityEngine.UI.Text m_E_SelectMainPetItemNumText = null;
		private UnityEngine.UI.Button m_E_SelectMainPetItemConfirmButton = null;
		private UnityEngine.UI.Image m_E_SelectMainPetItemConfirmImage = null;
		private UnityEngine.UI.Button m_E_SelectMainPetItemClose_2Button = null;
		private UnityEngine.UI.Image m_E_SelectMainPetItemClose_2Image = null;
		private UnityEngine.RectTransform m_EG_SelectAssistPetItemPanelRectTransform = null;
		private UnityEngine.UI.Button m_E_SelectAssistPetItemCloseButton = null;
		private UnityEngine.UI.Image m_E_SelectAssistPetItemCloseImage = null;
		private UnityEngine.UI.Image m_E_SelectAssistPetItemsImage = null;
		private UnityEngine.UI.LoopVerticalScrollRect m_E_SelectAssistPetItemsLoopVerticalScrollRect = null;
		private UnityEngine.UI.Text m_E_SelectAssistPetItemNumText = null;
		private UnityEngine.UI.Button m_E_SelectAssistPetItemConfirmButton = null;
		private UnityEngine.UI.Image m_E_SelectAssistPetItemConfirmImage = null;
		private UnityEngine.UI.Button m_E_SelectAssistPetItemClose_2Button = null;
		private UnityEngine.UI.Image m_E_SelectAssistPetItemClose_2Image = null;
		private UnityEngine.RectTransform m_EG_SelectMagicItemPanelRectTransform = null;
		private UnityEngine.UI.Button m_E_SelectMagicItemCloseButton = null;
		private UnityEngine.UI.Image m_E_SelectMagicItemCloseImage = null;
		private UnityEngine.UI.Image m_E_SelectMagicItemsImage = null;
		private UnityEngine.UI.LoopVerticalScrollRect m_E_SelectMagicItemsLoopVerticalScrollRect = null;
		private UnityEngine.UI.Text m_E_SelectMagicItemNumText = null;
		private UnityEngine.UI.Button m_E_SelectMagicItemConfirmButton = null;
		private UnityEngine.UI.Image m_E_SelectMagicItemConfirmImage = null;
		private UnityEngine.UI.Button m_E_SelectMagicItemClose_2Button = null;
		private UnityEngine.UI.Image m_E_SelectMagicItemClose_2Image = null;
		public Transform uiTransform = null;
	}
}
