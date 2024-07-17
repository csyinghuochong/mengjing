using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_UnionKeJiResearch : Entity,IAwake<Transform>,IDestroy,IUILogic
	{
		public long NeedTime;
		public int Position;
		public UnionInfo UnionMyInfo;
		public Dictionary<int, EntityRef<Scroll_Item_UnionKeJiResearchItem>> ScrollItemUnionKeJiResearchItems;
		
		public LoopVerticalScrollRect E_UnionKeJiResearchItemsLoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_UnionKeJiResearchItemsLoopVerticalScrollRect == null )
     			{
		    		this.m_E_UnionKeJiResearchItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<LoopVerticalScrollRect>(this.uiTransform.gameObject,"E_UnionKeJiResearchItems");
     			}
     			return this.m_E_UnionKeJiResearchItemsLoopVerticalScrollRect;
     		}
     	}

		public Image E_ProgressBarImgImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ProgressBarImgImage == null )
     			{
		    		this.m_E_ProgressBarImgImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_ProgressBarImg");
     			}
     			return this.m_E_ProgressBarImgImage;
     		}
     	}

		public Text E_ProgressBarTextText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ProgressBarTextText == null )
     			{
		    		this.m_E_ProgressBarTextText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_ProgressBarText");
     			}
     			return this.m_E_ProgressBarTextText;
     		}
     	}

		public Button E_QuickBtnButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_QuickBtnButton == null )
     			{
		    		this.m_E_QuickBtnButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_QuickBtn");
     			}
     			return this.m_E_QuickBtnButton;
     		}
     	}

		public Image E_QuickBtnImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_QuickBtnImage == null )
     			{
		    		this.m_E_QuickBtnImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_QuickBtn");
     			}
     			return this.m_E_QuickBtnImage;
     		}
     	}

		public Image E_HeadImgImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_HeadImgImage == null )
     			{
		    		this.m_E_HeadImgImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_HeadImg");
     			}
     			return this.m_E_HeadImgImage;
     		}
     	}

		public Text E_NameTextText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_NameTextText == null )
     			{
		    		this.m_E_NameTextText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_NameText");
     			}
     			return this.m_E_NameTextText;
     		}
     	}

		public Text E_LvTextText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_LvTextText == null )
     			{
		    		this.m_E_LvTextText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_LvText");
     			}
     			return this.m_E_LvTextText;
     		}
     	}

		public Text E_NeedUnionLvTextText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_NeedUnionLvTextText == null )
     			{
		    		this.m_E_NeedUnionLvTextText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_NeedUnionLvText");
     			}
     			return this.m_E_NeedUnionLvTextText;
     		}
     	}

		public Text E_UnderwayTextText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_UnderwayTextText == null )
     			{
		    		this.m_E_UnderwayTextText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_UnderwayText");
     			}
     			return this.m_E_UnderwayTextText;
     		}
     	}

		public ES_CommonItem ES_CommonItem
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
		        ES_CommonItem es = this.m_es_commonitem;
     			if( es == null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"ES_CommonItem");
		    	   this.m_es_commonitem = this.AddChild<ES_CommonItem,Transform>(subTrans);
     			}
     			return this.m_es_commonitem;
     		}
     	}

		public Text E_CostUnionGoldTextText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_CostUnionGoldTextText == null )
     			{
		    		this.m_E_CostUnionGoldTextText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_CostUnionGoldText");
     			}
     			return this.m_E_CostUnionGoldTextText;
     		}
     	}

		public Text E_NeedTimeTextText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_NeedTimeTextText == null )
     			{
		    		this.m_E_NeedTimeTextText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_NeedTimeText");
     			}
     			return this.m_E_NeedTimeTextText;
     		}
     	}

		public Button E_StartBtnButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_StartBtnButton == null )
     			{
		    		this.m_E_StartBtnButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_StartBtn");
     			}
     			return this.m_E_StartBtnButton;
     		}
     	}

		public Image E_StartBtnImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_StartBtnImage == null )
     			{
		    		this.m_E_StartBtnImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_StartBtn");
     			}
     			return this.m_E_StartBtnImage;
     		}
     	}

		public Text E_AttributeTextText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_AttributeTextText == null )
     			{
		    		this.m_E_AttributeTextText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_AttributeText");
     			}
     			return this.m_E_AttributeTextText;
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
			this.m_E_UnionKeJiResearchItemsLoopVerticalScrollRect = null;
			this.m_E_ProgressBarImgImage = null;
			this.m_E_ProgressBarTextText = null;
			this.m_E_QuickBtnButton = null;
			this.m_E_QuickBtnImage = null;
			this.m_E_HeadImgImage = null;
			this.m_E_NameTextText = null;
			this.m_E_LvTextText = null;
			this.m_E_NeedUnionLvTextText = null;
			this.m_E_UnderwayTextText = null;
			this.m_es_commonitem = null;
			this.m_E_CostUnionGoldTextText = null;
			this.m_E_NeedTimeTextText = null;
			this.m_E_StartBtnButton = null;
			this.m_E_StartBtnImage = null;
			this.m_E_AttributeTextText = null;
			this.uiTransform = null;
		}

		private LoopVerticalScrollRect m_E_UnionKeJiResearchItemsLoopVerticalScrollRect = null;
		private Image m_E_ProgressBarImgImage = null;
		private Text m_E_ProgressBarTextText = null;
		private Button m_E_QuickBtnButton = null;
		private Image m_E_QuickBtnImage = null;
		private Image m_E_HeadImgImage = null;
		private Text m_E_NameTextText = null;
		private Text m_E_LvTextText = null;
		private Text m_E_NeedUnionLvTextText = null;
		private Text m_E_UnderwayTextText = null;
		private EntityRef<ES_CommonItem> m_es_commonitem = null;
		private Text m_E_CostUnionGoldTextText = null;
		private Text m_E_NeedTimeTextText = null;
		private Button m_E_StartBtnButton = null;
		private Image m_E_StartBtnImage = null;
		private Text m_E_AttributeTextText = null;
		public Transform uiTransform = null;
	}
}
