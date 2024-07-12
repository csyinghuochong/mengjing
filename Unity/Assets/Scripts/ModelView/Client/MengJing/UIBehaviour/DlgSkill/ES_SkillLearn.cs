
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_SkillLearn : Entity,ET.IAwake<UnityEngine.Transform>,IDestroy,IUILogic
	{
		public int CurrentItemType;
		public bool LinShiSkillStatus;
		public SkillPro SkillPro;
		public List<SkillPro> ShowLearnSkillPros = new();
		public Dictionary<int, EntityRef<Scroll_Item_SkillLearnItem>> ScrollItemSkillLearnItems;
		public List<SkillPro> ShowLearnSkillSkillPros = new();
		public Dictionary<int, EntityRef<Scroll_Item_SkillLearnSkillItem>> ScrollItemSkillLearnSkillItems;

		public UnityEngine.UI.Button E_ButtonResetButton
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
		    		this.m_E_ButtonResetButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/E_ButtonReset");
     			}
     			return this.m_E_ButtonResetButton;
     		}
     	}

		public UnityEngine.UI.Image E_ButtonResetImage
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
		    		this.m_E_ButtonResetImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_ButtonReset");
     			}
     			return this.m_E_ButtonResetImage;
     		}
     	}

		public UnityEngine.UI.ToggleGroup E_BtnItemTypeSetToggleGroup
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
		    		this.m_E_BtnItemTypeSetToggleGroup = UIFindHelper.FindDeepChild<UnityEngine.UI.ToggleGroup>(this.uiTransform.gameObject,"Right/E_BtnItemTypeSet");
     			}
     			return this.m_E_BtnItemTypeSetToggleGroup;
     		}
     	}

		public UnityEngine.RectTransform EG_SkillInfoPanelRectTransform
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
		    		this.m_EG_SkillInfoPanelRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Right/EG_SkillInfoPanel");
     			}
     			return this.m_EG_SkillInfoPanelRectTransform;
     		}
     	}

		public UnityEngine.UI.Button E_SkillInfoconImgButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SkillInfoconImgButton == null )
     			{
		    		this.m_E_SkillInfoconImgButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/EG_SkillInfoPanel/Img_SkillIconDi/E_SkillInfoconImg");
     			}
     			return this.m_E_SkillInfoconImgButton;
     		}
     	}

		public UnityEngine.UI.Image E_SkillInfoconImgImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SkillInfoconImgImage == null )
     			{
		    		this.m_E_SkillInfoconImgImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/EG_SkillInfoPanel/Img_SkillIconDi/E_SkillInfoconImg");
     			}
     			return this.m_E_SkillInfoconImgImage;
     		}
     	}

		public UnityEngine.EventSystems.EventTrigger E_SkillInfoconImgEventTrigger
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SkillInfoconImgEventTrigger == null )
     			{
		    		this.m_E_SkillInfoconImgEventTrigger = UIFindHelper.FindDeepChild<UnityEngine.EventSystems.EventTrigger>(this.uiTransform.gameObject,"Right/EG_SkillInfoPanel/Img_SkillIconDi/E_SkillInfoconImg");
     			}
     			return this.m_E_SkillInfoconImgEventTrigger;
     		}
     	}

		public UnityEngine.UI.Text E_SkillInfoNameTextText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SkillInfoNameTextText == null )
     			{
		    		this.m_E_SkillInfoNameTextText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Right/EG_SkillInfoPanel/E_SkillInfoNameText");
     			}
     			return this.m_E_SkillInfoNameTextText;
     		}
     	}

		public UnityEngine.UI.Text E_NowTextText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_NowTextText == null )
     			{
		    		this.m_E_NowTextText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Right/EG_SkillInfoPanel/E_NowText");
     			}
     			return this.m_E_NowTextText;
     		}
     	}

		public UnityEngine.UI.Text E_NextTextText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_NextTextText == null )
     			{
		    		this.m_E_NextTextText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Right/EG_SkillInfoPanel/E_NextText");
     			}
     			return this.m_E_NextTextText;
     		}
     	}

		public UnityEngine.UI.Text E_ConsumeTextText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ConsumeTextText == null )
     			{
		    		this.m_E_ConsumeTextText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Right/EG_SkillInfoPanel/E_ConsumeText");
     			}
     			return this.m_E_ConsumeTextText;
     		}
     	}

		public UnityEngine.UI.Button E_SkillInfoLearnBtnButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SkillInfoLearnBtnButton == null )
     			{
		    		this.m_E_SkillInfoLearnBtnButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/EG_SkillInfoPanel/E_SkillInfoLearnBtn");
     			}
     			return this.m_E_SkillInfoLearnBtnButton;
     		}
     	}

		public UnityEngine.UI.Image E_SkillInfoLearnBtnImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SkillInfoLearnBtnImage == null )
     			{
		    		this.m_E_SkillInfoLearnBtnImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/EG_SkillInfoPanel/E_SkillInfoLearnBtn");
     			}
     			return this.m_E_SkillInfoLearnBtnImage;
     		}
     	}

		public UnityEngine.UI.Image E_SkillLearnItemsImage
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
		    		this.m_E_SkillLearnItemsImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Left/E_SkillLearnItems");
     			}
     			return this.m_E_SkillLearnItemsImage;
     		}
     	}

		public UnityEngine.UI.LoopVerticalScrollRect E_SkillLearnItemsLoopVerticalScrollRect
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
		    		this.m_E_SkillLearnItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopVerticalScrollRect>(this.uiTransform.gameObject,"Left/E_SkillLearnItems");
     			}
     			return this.m_E_SkillLearnItemsLoopVerticalScrollRect;
     		}
     	}

		public UnityEngine.UI.Text E_Text_LeftSpText
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
		    		this.m_E_Text_LeftSpText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Left/E_Text_LeftSp");
     			}
     			return this.m_E_Text_LeftSpText;
     		}
     	}

		public UnityEngine.UI.Image E_SkillLearnSkillItemsImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SkillLearnSkillItemsImage == null )
     			{
		    		this.m_E_SkillLearnSkillItemsImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Left/E_SkillLearnSkillItems");
     			}
     			return this.m_E_SkillLearnSkillItemsImage;
     		}
     	}

		public UnityEngine.UI.LoopVerticalScrollRect E_SkillLearnSkillItemsLoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SkillLearnSkillItemsLoopVerticalScrollRect == null )
     			{
		    		this.m_E_SkillLearnSkillItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopVerticalScrollRect>(this.uiTransform.gameObject,"Left/E_SkillLearnSkillItems");
     			}
     			return this.m_E_SkillLearnSkillItemsLoopVerticalScrollRect;
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
			this.m_E_ButtonResetButton = null;
			this.m_E_ButtonResetImage = null;
			this.m_E_BtnItemTypeSetToggleGroup = null;
			this.m_EG_SkillInfoPanelRectTransform = null;
			this.m_E_SkillInfoconImgButton = null;
			this.m_E_SkillInfoconImgImage = null;
			this.m_E_SkillInfoconImgEventTrigger = null;
			this.m_E_SkillInfoNameTextText = null;
			this.m_E_NowTextText = null;
			this.m_E_NextTextText = null;
			this.m_E_ConsumeTextText = null;
			this.m_E_SkillInfoLearnBtnButton = null;
			this.m_E_SkillInfoLearnBtnImage = null;
			this.m_E_SkillLearnItemsImage = null;
			this.m_E_SkillLearnItemsLoopVerticalScrollRect = null;
			this.m_E_Text_LeftSpText = null;
			this.m_E_SkillLearnSkillItemsImage = null;
			this.m_E_SkillLearnSkillItemsLoopVerticalScrollRect = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.Button m_E_ButtonResetButton = null;
		private UnityEngine.UI.Image m_E_ButtonResetImage = null;
		private UnityEngine.UI.ToggleGroup m_E_BtnItemTypeSetToggleGroup = null;
		private UnityEngine.RectTransform m_EG_SkillInfoPanelRectTransform = null;
		private UnityEngine.UI.Button m_E_SkillInfoconImgButton = null;
		private UnityEngine.UI.Image m_E_SkillInfoconImgImage = null;
		private UnityEngine.EventSystems.EventTrigger m_E_SkillInfoconImgEventTrigger = null;
		private UnityEngine.UI.Text m_E_SkillInfoNameTextText = null;
		private UnityEngine.UI.Text m_E_NowTextText = null;
		private UnityEngine.UI.Text m_E_NextTextText = null;
		private UnityEngine.UI.Text m_E_ConsumeTextText = null;
		private UnityEngine.UI.Button m_E_SkillInfoLearnBtnButton = null;
		private UnityEngine.UI.Image m_E_SkillInfoLearnBtnImage = null;
		private UnityEngine.UI.Image m_E_SkillLearnItemsImage = null;
		private UnityEngine.UI.LoopVerticalScrollRect m_E_SkillLearnItemsLoopVerticalScrollRect = null;
		private UnityEngine.UI.Text m_E_Text_LeftSpText = null;
		private UnityEngine.UI.Image m_E_SkillLearnSkillItemsImage = null;
		private UnityEngine.UI.LoopVerticalScrollRect m_E_SkillLearnSkillItemsLoopVerticalScrollRect = null;
		public Transform uiTransform = null;
	}
}
