using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_SkillLearn : Entity,IAwake<Transform>,IDestroy,IUILogic 
	{
		public bool LinShiSkillStatus;
		public SkillPro SkillPro;
		public List<SkillPro> ShowLearnSkillPros = new();
		public Dictionary<int, EntityRef<Scroll_Item_SkillLearnItem>> ScrollItemSkillLearnItems = new();
		public List<string> AssetList { get; set; } = new();
		
		public ToggleGroup E_BtnItemTypeSetToggleGroup
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_BtnItemTypeSetToggleGroup == null )
     			{
		    		this.m_E_BtnItemTypeSetToggleGroup = UIFindHelper.FindDeepChild<ToggleGroup>(this.uiTransform.gameObject,"Right/E_BtnItemTypeSet");
     			}
     			return this.m_E_BtnItemTypeSetToggleGroup;
     		}
     	}

		public RectTransform EG_SkillInfoPanelRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_SkillInfoPanelRectTransform == null )
     			{
		    		this.m_EG_SkillInfoPanelRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"Right/EG_SkillInfoPanel");
     			}
     			return this.m_EG_SkillInfoPanelRectTransform;
     		}
     	}

		public Image E_SkillIconImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SkillIconImage == null )
     			{
		    		this.m_E_SkillIconImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"Right/EG_SkillInfoPanel/Mask/E_SkillIcon");
     			}
     			return this.m_E_SkillIconImage;
     		}
     	}

		public Text E_SkillNameText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SkillNameText == null )
     			{
		    		this.m_E_SkillNameText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"Right/EG_SkillInfoPanel/E_SkillName");
     			}
     			return this.m_E_SkillNameText;
     		}
     	}

		public Text E_SkillTypeText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SkillTypeText == null )
     			{
		    		this.m_E_SkillTypeText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"Right/EG_SkillInfoPanel/E_SkillType");
     			}
     			return this.m_E_SkillTypeText;
     		}
     	}

		public Text E_SkillLvText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SkillLvText == null )
     			{
		    		this.m_E_SkillLvText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"Right/EG_SkillInfoPanel/E_SkillLv");
     			}
     			return this.m_E_SkillLvText;
     		}
     	}

		public Text E_SkillDesText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SkillDesText == null )
     			{
		    		this.m_E_SkillDesText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"Right/EG_SkillInfoPanel/Scroll View/Viewport/Content/Item/TextBg/E_SkillDes");
     			}
     			return this.m_E_SkillDesText;
     		}
     	}

		public Text E_SkillCoinText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SkillCoinText == null )
     			{
		    		this.m_E_SkillCoinText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"Right/EG_SkillInfoPanel/E_SkillCoin");
     			}
     			return this.m_E_SkillCoinText;
     		}
     	}

		public Text E_SkillPointText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SkillPointText == null )
     			{
		    		this.m_E_SkillPointText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"Right/EG_SkillInfoPanel/E_SkillPoint");
     			}
     			return this.m_E_SkillPointText;
     		}
     	}

		public Button E_SkillLearnButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SkillLearnButton == null )
     			{
		    		this.m_E_SkillLearnButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"Right/EG_SkillInfoPanel/E_SkillLearn");
     			}
     			return this.m_E_SkillLearnButton;
     		}
     	}

		public Image E_SkillLearnImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SkillLearnImage == null )
     			{
		    		this.m_E_SkillLearnImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"Right/EG_SkillInfoPanel/E_SkillLearn");
     			}
     			return this.m_E_SkillLearnImage;
     		}
     	}

		public Image E_SkillLearnItemsImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SkillLearnItemsImage == null )
     			{
		    		this.m_E_SkillLearnItemsImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"Left/E_SkillLearnItems");
     			}
     			return this.m_E_SkillLearnItemsImage;
     		}
     	}

		public ScrollRect E_SkillLearnItemsLoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SkillLearnItemsLoopVerticalScrollRect == null )
     			{
		    		this.m_E_SkillLearnItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<ScrollRect>(this.uiTransform.gameObject,"Left/E_SkillLearnItems");
     			}
     			return this.m_E_SkillLearnItemsLoopVerticalScrollRect;
     		}
     	}

		public Text E_Text_LeftSpText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_LeftSpText == null )
     			{
		    		this.m_E_Text_LeftSpText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"Left/E_Text_LeftSp");
     			}
     			return this.m_E_Text_LeftSpText;
     		}
     	}

		public Button E_ButtonResetButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonResetButton == null )
     			{
		    		this.m_E_ButtonResetButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"Left/E_ButtonReset");
     			}
     			return this.m_E_ButtonResetButton;
     		}
     	}

		public Image E_ButtonResetImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ButtonResetImage == null )
     			{
		    		this.m_E_ButtonResetImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"Left/E_ButtonReset");
     			}
     			return this.m_E_ButtonResetImage;
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
			this.m_E_BtnItemTypeSetToggleGroup = null;
			this.m_EG_SkillInfoPanelRectTransform = null;
			this.m_E_SkillIconImage = null;
			this.m_E_SkillNameText = null;
			this.m_E_SkillTypeText = null;
			this.m_E_SkillLvText = null;
			this.m_E_SkillDesText = null;
			this.m_E_SkillCoinText = null;
			this.m_E_SkillPointText = null;
			this.m_E_SkillLearnButton = null;
			this.m_E_SkillLearnImage = null;
			this.m_E_SkillLearnItemsImage = null;
			this.m_E_SkillLearnItemsLoopVerticalScrollRect = null;
			this.m_E_Text_LeftSpText = null;
			this.m_E_ButtonResetButton = null;
			this.m_E_ButtonResetImage = null;
			this.uiTransform = null;
		}

		private ToggleGroup m_E_BtnItemTypeSetToggleGroup = null;
		private RectTransform m_EG_SkillInfoPanelRectTransform = null;
		private Image m_E_SkillIconImage = null;
		private Text m_E_SkillNameText = null;
		private Text m_E_SkillTypeText = null;
		private Text m_E_SkillLvText = null;
		private Text m_E_SkillDesText = null;
		private Text m_E_SkillCoinText = null;
		private Text m_E_SkillPointText = null;
		private Button m_E_SkillLearnButton = null;
		private Image m_E_SkillLearnImage = null;
		private Image m_E_SkillLearnItemsImage = null;
		private ScrollRect m_E_SkillLearnItemsLoopVerticalScrollRect = null;
		private Text m_E_Text_LeftSpText = null;
		private Button m_E_ButtonResetButton = null;
		private Image m_E_ButtonResetImage = null;
		public Transform uiTransform = null;
	}
}
