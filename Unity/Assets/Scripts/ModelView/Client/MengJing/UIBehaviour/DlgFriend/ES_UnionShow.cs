using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_UnionShow : Entity,IAwake<Transform>,IDestroy,IUILogic
	{
		public Dictionary<int, EntityRef<Scroll_Item_UnionListItem>> ScrollItemUnionListItems;
		public List<UnionListItem> ShowUnionListItems;
		
		public RectTransform EG_UIUnionCreateRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_UIUnionCreateRectTransform == null )
     			{
		    		this.m_EG_UIUnionCreateRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_UIUnionCreate");
     			}
     			return this.m_EG_UIUnionCreateRectTransform;
     		}
     	}

		public InputField E_InputFieldPurposeInputField
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_InputFieldPurposeInputField == null )
     			{
		    		this.m_E_InputFieldPurposeInputField = UIFindHelper.FindDeepChild<InputField>(this.uiTransform.gameObject,"EG_UIUnionCreate/E_InputFieldPurpose");
     			}
     			return this.m_E_InputFieldPurposeInputField;
     		}
     	}

		public Image E_InputFieldPurposeImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_InputFieldPurposeImage == null )
     			{
		    		this.m_E_InputFieldPurposeImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_UIUnionCreate/E_InputFieldPurpose");
     			}
     			return this.m_E_InputFieldPurposeImage;
     		}
     	}

		public InputField E_InputFieldNameInputField
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_InputFieldNameInputField == null )
     			{
		    		this.m_E_InputFieldNameInputField = UIFindHelper.FindDeepChild<InputField>(this.uiTransform.gameObject,"EG_UIUnionCreate/E_InputFieldName");
     			}
     			return this.m_E_InputFieldNameInputField;
     		}
     	}

		public Image E_InputFieldNameImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_InputFieldNameImage == null )
     			{
		    		this.m_E_InputFieldNameImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_UIUnionCreate/E_InputFieldName");
     			}
     			return this.m_E_InputFieldNameImage;
     		}
     	}

		public Button E_Btn_CreateButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_CreateButton == null )
     			{
		    		this.m_E_Btn_CreateButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"EG_UIUnionCreate/E_Btn_Create");
     			}
     			return this.m_E_Btn_CreateButton;
     		}
     	}

		public Image E_Btn_CreateImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_CreateImage == null )
     			{
		    		this.m_E_Btn_CreateImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_UIUnionCreate/E_Btn_Create");
     			}
     			return this.m_E_Btn_CreateImage;
     		}
     	}

		public Text E_Text_Contion1Text
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_Contion1Text == null )
     			{
		    		this.m_E_Text_Contion1Text = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"EG_UIUnionCreate/E_Text_Contion1");
     			}
     			return this.m_E_Text_Contion1Text;
     		}
     	}

		public Text E_Text_Contion2Text
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_Contion2Text == null )
     			{
		    		this.m_E_Text_Contion2Text = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"EG_UIUnionCreate/E_Text_Contion2");
     			}
     			return this.m_E_Text_Contion2Text;
     		}
     	}

		public Button E_Btn_ReturnButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_ReturnButton == null )
     			{
		    		this.m_E_Btn_ReturnButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"EG_UIUnionCreate/E_Btn_Return");
     			}
     			return this.m_E_Btn_ReturnButton;
     		}
     	}

		public Image E_Btn_ReturnImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_ReturnImage == null )
     			{
		    		this.m_E_Btn_ReturnImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_UIUnionCreate/E_Btn_Return");
     			}
     			return this.m_E_Btn_ReturnImage;
     		}
     	}

		public RectTransform EG_UIUnionListRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_UIUnionListRectTransform == null )
     			{
		    		this.m_EG_UIUnionListRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_UIUnionList");
     			}
     			return this.m_EG_UIUnionListRectTransform;
     		}
     	}

		public LoopVerticalScrollRect E_UnionListItemsLoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_UnionListItemsLoopVerticalScrollRect == null )
     			{
		    		this.m_E_UnionListItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<LoopVerticalScrollRect>(this.uiTransform.gameObject,"EG_UIUnionList/E_UnionListItems");
     			}
     			return this.m_E_UnionListItemsLoopVerticalScrollRect;
     		}
     	}

		public Button E_ButtonCreateButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonCreateButton == null )
     			{
		    		this.m_E_ButtonCreateButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"EG_UIUnionList/E_ButtonCreate");
     			}
     			return this.m_E_ButtonCreateButton;
     		}
     	}

		public Image E_ButtonCreateImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonCreateImage == null )
     			{
		    		this.m_E_ButtonCreateImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_UIUnionList/E_ButtonCreate");
     			}
     			return this.m_E_ButtonCreateImage;
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
			this.m_EG_UIUnionCreateRectTransform = null;
			this.m_E_InputFieldPurposeInputField = null;
			this.m_E_InputFieldPurposeImage = null;
			this.m_E_InputFieldNameInputField = null;
			this.m_E_InputFieldNameImage = null;
			this.m_E_Btn_CreateButton = null;
			this.m_E_Btn_CreateImage = null;
			this.m_E_Text_Contion1Text = null;
			this.m_E_Text_Contion2Text = null;
			this.m_E_Btn_ReturnButton = null;
			this.m_E_Btn_ReturnImage = null;
			this.m_EG_UIUnionListRectTransform = null;
			this.m_E_UnionListItemsLoopVerticalScrollRect = null;
			this.m_E_ButtonCreateButton = null;
			this.m_E_ButtonCreateImage = null;
			this.uiTransform = null;
		}

		private RectTransform m_EG_UIUnionCreateRectTransform = null;
		private InputField m_E_InputFieldPurposeInputField = null;
		private Image m_E_InputFieldPurposeImage = null;
		private InputField m_E_InputFieldNameInputField = null;
		private Image m_E_InputFieldNameImage = null;
		private Button m_E_Btn_CreateButton = null;
		private Image m_E_Btn_CreateImage = null;
		private Text m_E_Text_Contion1Text = null;
		private Text m_E_Text_Contion2Text = null;
		private Button m_E_Btn_ReturnButton = null;
		private Image m_E_Btn_ReturnImage = null;
		private RectTransform m_EG_UIUnionListRectTransform = null;
		private LoopVerticalScrollRect m_E_UnionListItemsLoopVerticalScrollRect = null;
		private Button m_E_ButtonCreateButton = null;
		private Image m_E_ButtonCreateImage = null;
		public Transform uiTransform = null;
	}
}
