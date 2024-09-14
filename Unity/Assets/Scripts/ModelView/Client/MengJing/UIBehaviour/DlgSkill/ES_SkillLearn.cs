
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_SkillLearn : Entity,ET.IAwake<UnityEngine.Transform>,IDestroy,IUILogic 
	{
		public bool LinShiSkillStatus;
		public SkillPro SkillPro;
		public List<SkillPro> ShowLearnSkillPros = new();
		public Dictionary<int, EntityRef<Scroll_Item_SkillLearnItem>> ScrollItemSkillLearnItems;
		
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

		public UnityEngine.UI.Image E_SkillIconImage
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
		    		this.m_E_SkillIconImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/EG_SkillInfoPanel/Mask/E_SkillIcon");
     			}
     			return this.m_E_SkillIconImage;
     		}
     	}

		public UnityEngine.UI.Text E_SkillNameText
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
		    		this.m_E_SkillNameText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Right/EG_SkillInfoPanel/E_SkillName");
     			}
     			return this.m_E_SkillNameText;
     		}
     	}

		public UnityEngine.UI.Text E_SkillTypeText
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
		    		this.m_E_SkillTypeText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Right/EG_SkillInfoPanel/E_SkillType");
     			}
     			return this.m_E_SkillTypeText;
     		}
     	}

		public UnityEngine.UI.Text E_SkillLvText
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
		    		this.m_E_SkillLvText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Right/EG_SkillInfoPanel/E_SkillLv");
     			}
     			return this.m_E_SkillLvText;
     		}
     	}

		public UnityEngine.UI.Text E_SkillDesText
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
		    		this.m_E_SkillDesText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Right/EG_SkillInfoPanel/E_SkillDes");
     			}
     			return this.m_E_SkillDesText;
     		}
     	}

		public UnityEngine.UI.Text E_SkillCoinText
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
		    		this.m_E_SkillCoinText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Right/EG_SkillInfoPanel/E_SkillCoin");
     			}
     			return this.m_E_SkillCoinText;
     		}
     	}

		public UnityEngine.UI.Text E_SkillPointText
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
		    		this.m_E_SkillPointText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Right/EG_SkillInfoPanel/E_SkillPoint");
     			}
     			return this.m_E_SkillPointText;
     		}
     	}

		public UnityEngine.UI.Button E_SkillLearnButton
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
		    		this.m_E_SkillLearnButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/EG_SkillInfoPanel/E_SkillLearn");
     			}
     			return this.m_E_SkillLearnButton;
     		}
     	}

		public UnityEngine.UI.Image E_SkillLearnImage
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
		    		this.m_E_SkillLearnImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/EG_SkillInfoPanel/E_SkillLearn");
     			}
     			return this.m_E_SkillLearnImage;
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
		    		this.m_E_ButtonResetButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Left/E_ButtonReset");
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
		    		this.m_E_ButtonResetImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Left/E_ButtonReset");
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

		private UnityEngine.UI.ToggleGroup m_E_BtnItemTypeSetToggleGroup = null;
		private UnityEngine.RectTransform m_EG_SkillInfoPanelRectTransform = null;
		private UnityEngine.UI.Image m_E_SkillIconImage = null;
		private UnityEngine.UI.Text m_E_SkillNameText = null;
		private UnityEngine.UI.Text m_E_SkillTypeText = null;
		private UnityEngine.UI.Text m_E_SkillLvText = null;
		private UnityEngine.UI.Text m_E_SkillDesText = null;
		private UnityEngine.UI.Text m_E_SkillCoinText = null;
		private UnityEngine.UI.Text m_E_SkillPointText = null;
		private UnityEngine.UI.Button m_E_SkillLearnButton = null;
		private UnityEngine.UI.Image m_E_SkillLearnImage = null;
		private UnityEngine.UI.Image m_E_SkillLearnItemsImage = null;
		private UnityEngine.UI.LoopVerticalScrollRect m_E_SkillLearnItemsLoopVerticalScrollRect = null;
		private UnityEngine.UI.Text m_E_Text_LeftSpText = null;
		private UnityEngine.UI.Button m_E_ButtonResetButton = null;
		private UnityEngine.UI.Image m_E_ButtonResetImage = null;
		public Transform uiTransform = null;
	}
}
