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
		
		public UnityEngine.UI.Button E_ButtonJingXuanButton
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
		    		this.m_E_ButtonJingXuanButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_ButtonJingXuan");
     			}
     			return this.m_E_ButtonJingXuanButton;
     		}
     	}

		public UnityEngine.UI.Image E_ButtonJingXuanImage
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
		    		this.m_E_ButtonJingXuanImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_ButtonJingXuan");
     			}
     			return this.m_E_ButtonJingXuanImage;
     		}
     	}

		public UnityEngine.UI.Text E_TextJingXuanEndTimeText
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
		    		this.m_E_TextJingXuanEndTimeText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_ButtonJingXuan/E_TextJingXuanEndTime");
     			}
     			return this.m_E_TextJingXuanEndTimeText;
     		}
     	}

		public UnityEngine.RectTransform EG_LeftRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_LeftRectTransform == null )
     			{
		    		this.m_EG_LeftRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_Left");
     			}
     			return this.m_EG_LeftRectTransform;
     		}
     	}

		public UnityEngine.RectTransform EG_LeadNodeRectTransform
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
		    		this.m_EG_LeadNodeRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_Left/EG_LeadNode");
     			}
     			return this.m_EG_LeadNodeRectTransform;
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
		    		this.m_E_InputFieldNameInputField = UIFindHelper.FindDeepChild<UnityEngine.UI.InputField>(this.uiTransform.gameObject,"EG_Left/EG_LeadNode/E_InputFieldName");
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
		    		this.m_E_InputFieldNameImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_Left/EG_LeadNode/E_InputFieldName");
     			}
     			return this.m_E_InputFieldNameImage;
     		}
     	}

		public UnityEngine.UI.Button E_ButtonNameButton
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
		    		this.m_E_ButtonNameButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EG_Left/EG_LeadNode/E_ButtonName");
     			}
     			return this.m_E_ButtonNameButton;
     		}
     	}

		public UnityEngine.UI.Image E_ButtonNameImage
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
		    		this.m_E_ButtonNameImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_Left/EG_LeadNode/E_ButtonName");
     			}
     			return this.m_E_ButtonNameImage;
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
		    		this.m_E_InputFieldPurposeInputField = UIFindHelper.FindDeepChild<UnityEngine.UI.InputField>(this.uiTransform.gameObject,"EG_Left/EG_LeadNode/E_InputFieldPurpose");
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
		    		this.m_E_InputFieldPurposeImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_Left/EG_LeadNode/E_InputFieldPurpose");
     			}
     			return this.m_E_InputFieldPurposeImage;
     		}
     	}

		public UnityEngine.UI.Button E_ButtonModifyButton
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
		    		this.m_E_ButtonModifyButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EG_Left/EG_LeadNode/E_ButtonModify");
     			}
     			return this.m_E_ButtonModifyButton;
     		}
     	}

		public UnityEngine.UI.Image E_ButtonModifyImage
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
		    		this.m_E_ButtonModifyImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_Left/EG_LeadNode/E_ButtonModify");
     			}
     			return this.m_E_ButtonModifyImage;
     		}
     	}

		public UnityEngine.UI.Button E_Text_Button_1Button
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
		    		this.m_E_Text_Button_1Button = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EG_Left/E_Text_Button_1");
     			}
     			return this.m_E_Text_Button_1Button;
     		}
     	}

		public UnityEngine.UI.Text E_Text_Button_1Text
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
		    		this.m_E_Text_Button_1Text = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EG_Left/E_Text_Button_1");
     			}
     			return this.m_E_Text_Button_1Text;
     		}
     	}

		public UnityEngine.UI.Text E_Text_UnionNameText
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
		    		this.m_E_Text_UnionNameText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EG_Left/E_Text_UnionName");
     			}
     			return this.m_E_Text_UnionNameText;
     		}
     	}

		public UnityEngine.UI.Text E_Text_LeaderText
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
		    		this.m_E_Text_LeaderText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EG_Left/E_Text_Leader");
     			}
     			return this.m_E_Text_LeaderText;
     		}
     	}

		public UnityEngine.UI.Text E_Text_NumberText
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
		    		this.m_E_Text_NumberText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EG_Left/E_Text_Number");
     			}
     			return this.m_E_Text_NumberText;
     		}
     	}

		public UnityEngine.UI.Text E_Text_PurposeText
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
		    		this.m_E_Text_PurposeText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EG_Left/E_Text_Purpose");
     			}
     			return this.m_E_Text_PurposeText;
     		}
     	}

		public UnityEngine.UI.Button E_Text_LevelButton
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
		    		this.m_E_Text_LevelButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EG_Left/GameObject/E_Text_Level");
     			}
     			return this.m_E_Text_LevelButton;
     		}
     	}

		public UnityEngine.UI.Text E_Text_LevelText
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
		    		this.m_E_Text_LevelText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EG_Left/GameObject/E_Text_Level");
     			}
     			return this.m_E_Text_LevelText;
     		}
     	}

		public UnityEngine.UI.Button E_Text_ExpButton
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
		    		this.m_E_Text_ExpButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EG_Left/GameObject (1)/E_Text_Exp");
     			}
     			return this.m_E_Text_ExpButton;
     		}
     	}

		public UnityEngine.UI.Text E_Text_ExpText
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
		    		this.m_E_Text_ExpText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EG_Left/GameObject (1)/E_Text_Exp");
     			}
     			return this.m_E_Text_ExpText;
     		}
     	}

		public UnityEngine.UI.Text E_Text_UnionGoldText
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
		    		this.m_E_Text_UnionGoldText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EG_Left/E_Text_UnionGold");
     			}
     			return this.m_E_Text_UnionGoldText;
     		}
     	}

		public UnityEngine.RectTransform EG_RightRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_RightRectTransform == null )
     			{
		    		this.m_EG_RightRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_Right");
     			}
     			return this.m_EG_RightRectTransform;
     		}
     	}

		public UnityEngine.UI.Text E_Text_OnLineText
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
		    		this.m_E_Text_OnLineText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EG_Right/Image (5)/E_Text_OnLine");
     			}
     			return this.m_E_Text_OnLineText;
     		}
     	}

		public UnityEngine.UI.LoopVerticalScrollRect E_UnionMyItemsLoopVerticalScrollRect
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
		    		this.m_E_UnionMyItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopVerticalScrollRect>(this.uiTransform.gameObject,"EG_Right/E_UnionMyItems");
     			}
     			return this.m_E_UnionMyItemsLoopVerticalScrollRect;
     		}
     	}

		public UnityEngine.UI.Button E_Text_EnterUnionButton
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
		    		this.m_E_Text_EnterUnionButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EG_Right/ButtonList/E_Text_EnterUnion");
     			}
     			return this.m_E_Text_EnterUnionButton;
     		}
     	}

		public UnityEngine.UI.Image E_Text_EnterUnionImage
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
		    		this.m_E_Text_EnterUnionImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_Right/ButtonList/E_Text_EnterUnion");
     			}
     			return this.m_E_Text_EnterUnionImage;
     		}
     	}

		public UnityEngine.UI.Button E_Button_UpgradeButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_UpgradeButton == null )
     			{
		    		this.m_E_Button_UpgradeButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EG_Right/ButtonList/E_Button_Upgrade");
     			}
     			return this.m_E_Button_UpgradeButton;
     		}
     	}

		public UnityEngine.UI.Image E_Button_UpgradeImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_UpgradeImage == null )
     			{
		    		this.m_E_Button_UpgradeImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_Right/ButtonList/E_Button_Upgrade");
     			}
     			return this.m_E_Button_UpgradeImage;
     		}
     	}

		public UnityEngine.UI.Button E_UnionRecordsBtnButton
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
		    		this.m_E_UnionRecordsBtnButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EG_Right/ButtonList/E_UnionRecordsBtn");
     			}
     			return this.m_E_UnionRecordsBtnButton;
     		}
     	}

		public UnityEngine.UI.Image E_UnionRecordsBtnImage
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
		    		this.m_E_UnionRecordsBtnImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_Right/ButtonList/E_UnionRecordsBtn");
     			}
     			return this.m_E_UnionRecordsBtnImage;
     		}
     	}

		public UnityEngine.UI.Button E_ButtonApplyListButton
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
		    		this.m_E_ButtonApplyListButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EG_Right/ButtonList/E_ButtonApplyList");
     			}
     			return this.m_E_ButtonApplyListButton;
     		}
     	}

		public UnityEngine.UI.Image E_ButtonApplyListImage
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
		    		this.m_E_ButtonApplyListImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_Right/ButtonList/E_ButtonApplyList");
     			}
     			return this.m_E_ButtonApplyListImage;
     		}
     	}

		public UnityEngine.UI.Button E_ButtonLeaveButton
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
		    		this.m_E_ButtonLeaveButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EG_Right/ButtonList/E_ButtonLeave");
     			}
     			return this.m_E_ButtonLeaveButton;
     		}
     	}

		public UnityEngine.UI.Image E_ButtonLeaveImage
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
		    		this.m_E_ButtonLeaveImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_Right/ButtonList/E_ButtonLeave");
     			}
     			return this.m_E_ButtonLeaveImage;
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
			this.m_E_ButtonJingXuanButton = null;
			this.m_E_ButtonJingXuanImage = null;
			this.m_E_TextJingXuanEndTimeText = null;
			this.m_EG_LeftRectTransform = null;
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
			this.m_E_Text_LevelButton = null;
			this.m_E_Text_LevelText = null;
			this.m_E_Text_ExpButton = null;
			this.m_E_Text_ExpText = null;
			this.m_E_Text_UnionGoldText = null;
			this.m_EG_RightRectTransform = null;
			this.m_E_Text_OnLineText = null;
			this.m_E_UnionMyItemsLoopVerticalScrollRect = null;
			this.m_E_Text_EnterUnionButton = null;
			this.m_E_Text_EnterUnionImage = null;
			this.m_E_Button_UpgradeButton = null;
			this.m_E_Button_UpgradeImage = null;
			this.m_E_UnionRecordsBtnButton = null;
			this.m_E_UnionRecordsBtnImage = null;
			this.m_E_ButtonApplyListButton = null;
			this.m_E_ButtonApplyListImage = null;
			this.m_E_ButtonLeaveButton = null;
			this.m_E_ButtonLeaveImage = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.Button m_E_ButtonJingXuanButton = null;
		private UnityEngine.UI.Image m_E_ButtonJingXuanImage = null;
		private UnityEngine.UI.Text m_E_TextJingXuanEndTimeText = null;
		private UnityEngine.RectTransform m_EG_LeftRectTransform = null;
		private UnityEngine.RectTransform m_EG_LeadNodeRectTransform = null;
		private UnityEngine.UI.InputField m_E_InputFieldNameInputField = null;
		private UnityEngine.UI.Image m_E_InputFieldNameImage = null;
		private UnityEngine.UI.Button m_E_ButtonNameButton = null;
		private UnityEngine.UI.Image m_E_ButtonNameImage = null;
		private UnityEngine.UI.InputField m_E_InputFieldPurposeInputField = null;
		private UnityEngine.UI.Image m_E_InputFieldPurposeImage = null;
		private UnityEngine.UI.Button m_E_ButtonModifyButton = null;
		private UnityEngine.UI.Image m_E_ButtonModifyImage = null;
		private UnityEngine.UI.Button m_E_Text_Button_1Button = null;
		private UnityEngine.UI.Text m_E_Text_Button_1Text = null;
		private UnityEngine.UI.Text m_E_Text_UnionNameText = null;
		private UnityEngine.UI.Text m_E_Text_LeaderText = null;
		private UnityEngine.UI.Text m_E_Text_NumberText = null;
		private UnityEngine.UI.Text m_E_Text_PurposeText = null;
		private UnityEngine.UI.Button m_E_Text_LevelButton = null;
		private UnityEngine.UI.Text m_E_Text_LevelText = null;
		private UnityEngine.UI.Button m_E_Text_ExpButton = null;
		private UnityEngine.UI.Text m_E_Text_ExpText = null;
		private UnityEngine.UI.Text m_E_Text_UnionGoldText = null;
		private UnityEngine.RectTransform m_EG_RightRectTransform = null;
		private UnityEngine.UI.Text m_E_Text_OnLineText = null;
		private UnityEngine.UI.LoopVerticalScrollRect m_E_UnionMyItemsLoopVerticalScrollRect = null;
		private UnityEngine.UI.Button m_E_Text_EnterUnionButton = null;
		private UnityEngine.UI.Image m_E_Text_EnterUnionImage = null;
		private UnityEngine.UI.Button m_E_Button_UpgradeButton = null;
		private UnityEngine.UI.Image m_E_Button_UpgradeImage = null;
		private UnityEngine.UI.Button m_E_UnionRecordsBtnButton = null;
		private UnityEngine.UI.Image m_E_UnionRecordsBtnImage = null;
		private UnityEngine.UI.Button m_E_ButtonApplyListButton = null;
		private UnityEngine.UI.Image m_E_ButtonApplyListImage = null;
		private UnityEngine.UI.Button m_E_ButtonLeaveButton = null;
		private UnityEngine.UI.Image m_E_ButtonLeaveImage = null;
		public Transform uiTransform = null;
	}
}
