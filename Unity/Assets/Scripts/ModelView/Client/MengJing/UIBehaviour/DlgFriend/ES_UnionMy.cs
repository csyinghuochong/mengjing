using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_UnionMy : Entity,IAwake<Transform>,IDestroy,IUILogic
	{
		public UnionInfo UnionInfo;
		public List<long> OnLinePlayer;
		public long UnionJingXuanTimer;
		public List<UnionPlayerInfo> ShowUnionPlayerInfos = new();
		public Dictionary<int, EntityRef<Scroll_Item_UnionMyItem>> ScrollItemUnionMyItems;
		
		public RectTransform EG_ShowSetRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_ShowSetRectTransform == null )
     			{
		    		this.m_EG_ShowSetRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_ShowSet");
     			}
     			return this.m_EG_ShowSetRectTransform;
     		}
     	}

		public Text E_Text_OnLineText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_OnLineText == null )
     			{
		    		this.m_E_Text_OnLineText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"EG_ShowSet/Image (5)/E_Text_OnLine");
     			}
     			return this.m_E_Text_OnLineText;
     		}
     	}

		public LoopVerticalScrollRect E_UnionMyItemsLoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_UnionMyItemsLoopVerticalScrollRect == null )
     			{
		    		this.m_E_UnionMyItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<LoopVerticalScrollRect>(this.uiTransform.gameObject,"EG_ShowSet/E_UnionMyItems");
     			}
     			return this.m_E_UnionMyItemsLoopVerticalScrollRect;
     		}
     	}

		public Button E_ButtonLeaveButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonLeaveButton == null )
     			{
		    		this.m_E_ButtonLeaveButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"EG_ShowSet/ButtonList/E_ButtonLeave");
     			}
     			return this.m_E_ButtonLeaveButton;
     		}
     	}

		public Image E_ButtonLeaveImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonLeaveImage == null )
     			{
		    		this.m_E_ButtonLeaveImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_ShowSet/ButtonList/E_ButtonLeave");
     			}
     			return this.m_E_ButtonLeaveImage;
     		}
     	}

		public Button E_ButtonApplyListButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonApplyListButton == null )
     			{
		    		this.m_E_ButtonApplyListButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"EG_ShowSet/ButtonList/E_ButtonApplyList");
     			}
     			return this.m_E_ButtonApplyListButton;
     		}
     	}

		public Image E_ButtonApplyListImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonApplyListImage == null )
     			{
		    		this.m_E_ButtonApplyListImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_ShowSet/ButtonList/E_ButtonApplyList");
     			}
     			return this.m_E_ButtonApplyListImage;
     		}
     	}

		public Button E_ButtonJingXuanButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonJingXuanButton == null )
     			{
		    		this.m_E_ButtonJingXuanButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"EG_ShowSet/ButtonList/E_ButtonJingXuan");
     			}
     			return this.m_E_ButtonJingXuanButton;
     		}
     	}

		public Image E_ButtonJingXuanImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonJingXuanImage == null )
     			{
		    		this.m_E_ButtonJingXuanImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_ShowSet/ButtonList/E_ButtonJingXuan");
     			}
     			return this.m_E_ButtonJingXuanImage;
     		}
     	}

		public Text E_TextJingXuanEndTimeText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TextJingXuanEndTimeText == null )
     			{
		    		this.m_E_TextJingXuanEndTimeText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"EG_ShowSet/ButtonList/E_ButtonJingXuan/E_TextJingXuanEndTime");
     			}
     			return this.m_E_TextJingXuanEndTimeText;
     		}
     	}

		public RectTransform EG_LeadNodeRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_LeadNodeRectTransform == null )
     			{
		    		this.m_EG_LeadNodeRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_ShowSet/EG_LeadNode");
     			}
     			return this.m_EG_LeadNodeRectTransform;
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
		    		this.m_E_InputFieldNameInputField = UIFindHelper.FindDeepChild<InputField>(this.uiTransform.gameObject,"EG_ShowSet/EG_LeadNode/E_InputFieldName");
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
		    		this.m_E_InputFieldNameImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_ShowSet/EG_LeadNode/E_InputFieldName");
     			}
     			return this.m_E_InputFieldNameImage;
     		}
     	}

		public Button E_ButtonNameButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonNameButton == null )
     			{
		    		this.m_E_ButtonNameButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"EG_ShowSet/EG_LeadNode/E_ButtonName");
     			}
     			return this.m_E_ButtonNameButton;
     		}
     	}

		public Image E_ButtonNameImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonNameImage == null )
     			{
		    		this.m_E_ButtonNameImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_ShowSet/EG_LeadNode/E_ButtonName");
     			}
     			return this.m_E_ButtonNameImage;
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
		    		this.m_E_InputFieldPurposeInputField = UIFindHelper.FindDeepChild<InputField>(this.uiTransform.gameObject,"EG_ShowSet/EG_LeadNode/E_InputFieldPurpose");
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
		    		this.m_E_InputFieldPurposeImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_ShowSet/EG_LeadNode/E_InputFieldPurpose");
     			}
     			return this.m_E_InputFieldPurposeImage;
     		}
     	}

		public Button E_ButtonModifyButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonModifyButton == null )
     			{
		    		this.m_E_ButtonModifyButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"EG_ShowSet/EG_LeadNode/E_ButtonModify");
     			}
     			return this.m_E_ButtonModifyButton;
     		}
     	}

		public Image E_ButtonModifyImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonModifyImage == null )
     			{
		    		this.m_E_ButtonModifyImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_ShowSet/EG_LeadNode/E_ButtonModify");
     			}
     			return this.m_E_ButtonModifyImage;
     		}
     	}

		public Button E_Text_Button_1Button
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_Button_1Button == null )
     			{
		    		this.m_E_Text_Button_1Button = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"EG_ShowSet/E_Text_Button_1");
     			}
     			return this.m_E_Text_Button_1Button;
     		}
     	}

		public Text E_Text_Button_1Text
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_Button_1Text == null )
     			{
		    		this.m_E_Text_Button_1Text = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"EG_ShowSet/E_Text_Button_1");
     			}
     			return this.m_E_Text_Button_1Text;
     		}
     	}

		public Text E_Text_UnionNameText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_UnionNameText == null )
     			{
		    		this.m_E_Text_UnionNameText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"EG_ShowSet/E_Text_UnionName");
     			}
     			return this.m_E_Text_UnionNameText;
     		}
     	}

		public Text E_Text_LeaderText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_LeaderText == null )
     			{
		    		this.m_E_Text_LeaderText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"EG_ShowSet/E_Text_Leader");
     			}
     			return this.m_E_Text_LeaderText;
     		}
     	}

		public Text E_Text_NumberText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_NumberText == null )
     			{
		    		this.m_E_Text_NumberText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"EG_ShowSet/E_Text_Number");
     			}
     			return this.m_E_Text_NumberText;
     		}
     	}

		public Text E_Text_PurposeText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_PurposeText == null )
     			{
		    		this.m_E_Text_PurposeText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"EG_ShowSet/E_Text_Purpose");
     			}
     			return this.m_E_Text_PurposeText;
     		}
     	}

		public Button E_Text_EnterUnionButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_EnterUnionButton == null )
     			{
		    		this.m_E_Text_EnterUnionButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"EG_ShowSet/E_Text_EnterUnion");
     			}
     			return this.m_E_Text_EnterUnionButton;
     		}
     	}

		public Image E_Text_EnterUnionImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_EnterUnionImage == null )
     			{
		    		this.m_E_Text_EnterUnionImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_ShowSet/E_Text_EnterUnion");
     			}
     			return this.m_E_Text_EnterUnionImage;
     		}
     	}

		public Button E_Text_LevelButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_LevelButton == null )
     			{
		    		this.m_E_Text_LevelButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"EG_ShowSet/GameObject/E_Text_Level");
     			}
     			return this.m_E_Text_LevelButton;
     		}
     	}

		public Text E_Text_LevelText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_LevelText == null )
     			{
		    		this.m_E_Text_LevelText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"EG_ShowSet/GameObject/E_Text_Level");
     			}
     			return this.m_E_Text_LevelText;
     		}
     	}

		public Button E_Text_ExpButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_ExpButton == null )
     			{
		    		this.m_E_Text_ExpButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"EG_ShowSet/GameObject (1)/E_Text_Exp");
     			}
     			return this.m_E_Text_ExpButton;
     		}
     	}

		public Text E_Text_ExpText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_ExpText == null )
     			{
		    		this.m_E_Text_ExpText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"EG_ShowSet/GameObject (1)/E_Text_Exp");
     			}
     			return this.m_E_Text_ExpText;
     		}
     	}

		public Button E_UnionRecordsBtnButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_UnionRecordsBtnButton == null )
     			{
		    		this.m_E_UnionRecordsBtnButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"EG_ShowSet/E_UnionRecordsBtn");
     			}
     			return this.m_E_UnionRecordsBtnButton;
     		}
     	}

		public Image E_UnionRecordsBtnImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_UnionRecordsBtnImage == null )
     			{
		    		this.m_E_UnionRecordsBtnImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_ShowSet/E_UnionRecordsBtn");
     			}
     			return this.m_E_UnionRecordsBtnImage;
     		}
     	}

		public Text E_Text_UnionGoldText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_UnionGoldText == null )
     			{
		    		this.m_E_Text_UnionGoldText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"EG_ShowSet/E_Text_UnionGold");
     			}
     			return this.m_E_Text_UnionGoldText;
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
			this.m_EG_ShowSetRectTransform = null;
			this.m_E_Text_OnLineText = null;
			this.m_E_UnionMyItemsLoopVerticalScrollRect = null;
			this.m_E_ButtonLeaveButton = null;
			this.m_E_ButtonLeaveImage = null;
			this.m_E_ButtonApplyListButton = null;
			this.m_E_ButtonApplyListImage = null;
			this.m_E_ButtonJingXuanButton = null;
			this.m_E_ButtonJingXuanImage = null;
			this.m_E_TextJingXuanEndTimeText = null;
			this.m_EG_LeadNodeRectTransform = null;
			this.m_E_InputFieldNameInputField = null;
			this.m_E_InputFieldNameImage = null;
			this.m_E_ButtonNameButton = null;
			this.m_E_ButtonNameImage = null;
			this.m_E_InputFieldPurposeInputField = null;
			this.m_E_InputFieldPurposeImage = null;
			this.m_E_ButtonModifyButton = null;
			this.m_E_ButtonModifyImage = null;
			this.m_E_Text_Button_1Button = null;
			this.m_E_Text_Button_1Text = null;
			this.m_E_Text_UnionNameText = null;
			this.m_E_Text_LeaderText = null;
			this.m_E_Text_NumberText = null;
			this.m_E_Text_PurposeText = null;
			this.m_E_Text_EnterUnionButton = null;
			this.m_E_Text_EnterUnionImage = null;
			this.m_E_Text_LevelButton = null;
			this.m_E_Text_LevelText = null;
			this.m_E_Text_ExpButton = null;
			this.m_E_Text_ExpText = null;
			this.m_E_UnionRecordsBtnButton = null;
			this.m_E_UnionRecordsBtnImage = null;
			this.m_E_Text_UnionGoldText = null;
			this.uiTransform = null;
		}

		private RectTransform m_EG_ShowSetRectTransform = null;
		private Text m_E_Text_OnLineText = null;
		private LoopVerticalScrollRect m_E_UnionMyItemsLoopVerticalScrollRect = null;
		private Button m_E_ButtonLeaveButton = null;
		private Image m_E_ButtonLeaveImage = null;
		private Button m_E_ButtonApplyListButton = null;
		private Image m_E_ButtonApplyListImage = null;
		private Button m_E_ButtonJingXuanButton = null;
		private Image m_E_ButtonJingXuanImage = null;
		private Text m_E_TextJingXuanEndTimeText = null;
		private RectTransform m_EG_LeadNodeRectTransform = null;
		private InputField m_E_InputFieldNameInputField = null;
		private Image m_E_InputFieldNameImage = null;
		private Button m_E_ButtonNameButton = null;
		private Image m_E_ButtonNameImage = null;
		private InputField m_E_InputFieldPurposeInputField = null;
		private Image m_E_InputFieldPurposeImage = null;
		private Button m_E_ButtonModifyButton = null;
		private Image m_E_ButtonModifyImage = null;
		private Button m_E_Text_Button_1Button = null;
		private Text m_E_Text_Button_1Text = null;
		private Text m_E_Text_UnionNameText = null;
		private Text m_E_Text_LeaderText = null;
		private Text m_E_Text_NumberText = null;
		private Text m_E_Text_PurposeText = null;
		private Button m_E_Text_EnterUnionButton = null;
		private Image m_E_Text_EnterUnionImage = null;
		private Button m_E_Text_LevelButton = null;
		private Text m_E_Text_LevelText = null;
		private Button m_E_Text_ExpButton = null;
		private Text m_E_Text_ExpText = null;
		private Button m_E_UnionRecordsBtnButton = null;
		private Image m_E_UnionRecordsBtnImage = null;
		private Text m_E_Text_UnionGoldText = null;
		public Transform uiTransform = null;
	}
}
