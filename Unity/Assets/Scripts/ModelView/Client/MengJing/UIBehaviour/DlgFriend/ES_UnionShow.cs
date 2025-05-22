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
		public UnionListItem UnionListItem;
		
		public UnityEngine.RectTransform EG_UIUnionCreateRectTransform
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
		    		this.m_EG_UIUnionCreateRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_UIUnionCreate");
     			}
     			return this.m_EG_UIUnionCreateRectTransform;
     		}
     	}

		public UnityEngine.UI.InputField E_InputFieldPurposeInputField
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
		    		this.m_E_InputFieldPurposeInputField = UIFindHelper.FindDeepChild<UnityEngine.UI.InputField>(this.uiTransform.gameObject,"EG_UIUnionCreate/Right/E_InputFieldPurpose");
     			}
     			return this.m_E_InputFieldPurposeInputField;
     		}
     	}

		public UnityEngine.UI.Image E_InputFieldPurposeImage
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
		    		this.m_E_InputFieldPurposeImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_UIUnionCreate/Right/E_InputFieldPurpose");
     			}
     			return this.m_E_InputFieldPurposeImage;
     		}
     	}

		public UnityEngine.UI.InputField E_InputFieldNameInputField
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
		    		this.m_E_InputFieldNameInputField = UIFindHelper.FindDeepChild<UnityEngine.UI.InputField>(this.uiTransform.gameObject,"EG_UIUnionCreate/Right/E_InputFieldName");
     			}
     			return this.m_E_InputFieldNameInputField;
     		}
     	}

		public UnityEngine.UI.Image E_InputFieldNameImage
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
		    		this.m_E_InputFieldNameImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_UIUnionCreate/Right/E_InputFieldName");
     			}
     			return this.m_E_InputFieldNameImage;
     		}
     	}

		public UnityEngine.UI.Button E_Btn_CreateButton
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
		    		this.m_E_Btn_CreateButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EG_UIUnionCreate/Right/E_Btn_Create");
     			}
     			return this.m_E_Btn_CreateButton;
     		}
     	}

		public UnityEngine.UI.Image E_Btn_CreateImage
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
		    		this.m_E_Btn_CreateImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_UIUnionCreate/Right/E_Btn_Create");
     			}
     			return this.m_E_Btn_CreateImage;
     		}
     	}

		public UnityEngine.UI.Text E_Text_Contion1Text
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
		    		this.m_E_Text_Contion1Text = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EG_UIUnionCreate/Right/E_Text_Contion1");
     			}
     			return this.m_E_Text_Contion1Text;
     		}
     	}

		public UnityEngine.UI.Text E_Text_Contion2Text
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
		    		this.m_E_Text_Contion2Text = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EG_UIUnionCreate/Right/E_Text_Contion2");
     			}
     			return this.m_E_Text_Contion2Text;
     		}
     	}

		public UnityEngine.UI.Button E_Btn_ReturnButton
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
		    		this.m_E_Btn_ReturnButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EG_UIUnionCreate/Right/E_Btn_Return");
     			}
     			return this.m_E_Btn_ReturnButton;
     		}
     	}

		public UnityEngine.UI.Image E_Btn_ReturnImage
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
		    		this.m_E_Btn_ReturnImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_UIUnionCreate/Right/E_Btn_Return");
     			}
     			return this.m_E_Btn_ReturnImage;
     		}
     	}

		public UnityEngine.RectTransform EG_UIUnionListRectTransform
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
		    		this.m_EG_UIUnionListRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_UIUnionList");
     			}
     			return this.m_EG_UIUnionListRectTransform;
     		}
     	}

		public UnityEngine.UI.LoopVerticalScrollRect E_UnionListItemsLoopVerticalScrollRect
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
		    		this.m_E_UnionListItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopVerticalScrollRect>(this.uiTransform.gameObject,"EG_UIUnionList/Left/E_UnionListItems");
     			}
     			return this.m_E_UnionListItemsLoopVerticalScrollRect;
     		}
     	}

		public UnityEngine.UI.Button E_ButtonCreateButton
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
		    		this.m_E_ButtonCreateButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EG_UIUnionList/Left/E_ButtonCreate");
     			}
     			return this.m_E_ButtonCreateButton;
     		}
     	}

		public UnityEngine.UI.Image E_ButtonCreateImage
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
		    		this.m_E_ButtonCreateImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_UIUnionList/Left/E_ButtonCreate");
     			}
     			return this.m_E_ButtonCreateImage;
     		}
     	}

		public UnityEngine.UI.Button E_ButtonJoinButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonJoinButton == null )
     			{
		    		this.m_E_ButtonJoinButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EG_UIUnionList/Right/E_ButtonJoin");
     			}
     			return this.m_E_ButtonJoinButton;
     		}
     	}

		public UnityEngine.UI.Image E_ButtonJoinImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonJoinImage == null )
     			{
		    		this.m_E_ButtonJoinImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_UIUnionList/Right/E_ButtonJoin");
     			}
     			return this.m_E_ButtonJoinImage;
     		}
     	}

		public UnityEngine.UI.Text E_Text_InfoText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_InfoText == null )
     			{
		    		this.m_E_Text_InfoText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EG_UIUnionList/Right/E_Text_Info");
     			}
     			return this.m_E_Text_InfoText;
     		}
     	}

		public UnityEngine.UI.Text E_Text_RequestText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_RequestText == null )
     			{
		    		this.m_E_Text_RequestText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EG_UIUnionList/Right/E_Text_Request");
     			}
     			return this.m_E_Text_RequestText;
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
			this.m_E_ButtonJoinButton = null;
			this.m_E_ButtonJoinImage = null;
			this.m_E_Text_InfoText = null;
			this.m_E_Text_RequestText = null;
			this.uiTransform = null;
		}

		private UnityEngine.RectTransform m_EG_UIUnionCreateRectTransform = null;
		private UnityEngine.UI.InputField m_E_InputFieldPurposeInputField = null;
		private UnityEngine.UI.Image m_E_InputFieldPurposeImage = null;
		private UnityEngine.UI.InputField m_E_InputFieldNameInputField = null;
		private UnityEngine.UI.Image m_E_InputFieldNameImage = null;
		private UnityEngine.UI.Button m_E_Btn_CreateButton = null;
		private UnityEngine.UI.Image m_E_Btn_CreateImage = null;
		private UnityEngine.UI.Text m_E_Text_Contion1Text = null;
		private UnityEngine.UI.Text m_E_Text_Contion2Text = null;
		private UnityEngine.UI.Button m_E_Btn_ReturnButton = null;
		private UnityEngine.UI.Image m_E_Btn_ReturnImage = null;
		private UnityEngine.RectTransform m_EG_UIUnionListRectTransform = null;
		private UnityEngine.UI.LoopVerticalScrollRect m_E_UnionListItemsLoopVerticalScrollRect = null;
		private UnityEngine.UI.Button m_E_ButtonCreateButton = null;
		private UnityEngine.UI.Image m_E_ButtonCreateImage = null;
		private UnityEngine.UI.Button m_E_ButtonJoinButton = null;
		private UnityEngine.UI.Image m_E_ButtonJoinImage = null;
		private UnityEngine.UI.Text m_E_Text_InfoText = null;
		private UnityEngine.UI.Text m_E_Text_RequestText = null;
		public Transform uiTransform = null;
	}
}
