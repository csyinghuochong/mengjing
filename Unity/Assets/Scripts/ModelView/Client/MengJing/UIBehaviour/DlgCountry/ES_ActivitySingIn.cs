
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_ActivitySingIn : Entity,ET.IAwake<UnityEngine.Transform>,IDestroy 
	{
		public long Time = 250;
		public long ClickTime;
		public bool IsClick;
		public int SingInActivityType;
		public int LeiJiSingInActivityType;
		public int CurDay;
		public List<ActivityConfig> ShowActivityConfigs = new();
		public Dictionary<int, EntityRef<Scroll_Item_ActivitySingInItem>> ScrollItemActivitySingInItems = new();
		public List<string> AssetList { get; set; } = new();
		
		public UnityEngine.UI.ToggleGroup E_TypeSetToggleGroup
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TypeSetToggleGroup == null )
     			{
		    		this.m_E_TypeSetToggleGroup = UIFindHelper.FindDeepChild<UnityEngine.UI.ToggleGroup>(this.uiTransform.gameObject,"Center/E_TypeSet");
     			}
     			return this.m_E_TypeSetToggleGroup;
     		}
     	}

		public UnityEngine.RectTransform EG_PanelRootRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_PanelRootRectTransform == null )
     			{
		    		this.m_EG_PanelRootRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Center/EG_PanelRoot");
     			}
     			return this.m_EG_PanelRootRectTransform;
     		}
     	}

		public UnityEngine.UI.Text E_AlreadySingInDayText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_AlreadySingInDayText == null )
     			{
		    		this.m_E_AlreadySingInDayText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Center/EG_PanelRoot/E_AlreadySingInDay");
     			}
     			return this.m_E_AlreadySingInDayText;
     		}
     	}

		public UnityEngine.UI.Image E_RewardProgressImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_RewardProgressImage == null )
     			{
		    		this.m_E_RewardProgressImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Center/EG_PanelRoot/RewardSet/E_RewardProgress");
     			}
     			return this.m_E_RewardProgressImage;
     		}
     	}

		public UnityEngine.UI.Image E_Reward1Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Reward1Image == null )
     			{
		    		this.m_E_Reward1Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Center/EG_PanelRoot/RewardSet/E_Reward1");
     			}
     			return this.m_E_Reward1Image;
     		}
     	}

		public UnityEngine.EventSystems.EventTrigger E_Reward1EventTrigger
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Reward1EventTrigger == null )
     			{
		    		this.m_E_Reward1EventTrigger = UIFindHelper.FindDeepChild<UnityEngine.EventSystems.EventTrigger>(this.uiTransform.gameObject,"Center/EG_PanelRoot/RewardSet/E_Reward1");
     			}
     			return this.m_E_Reward1EventTrigger;
     		}
     	}

		public UnityEngine.UI.Image E_Reward2Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Reward2Image == null )
     			{
		    		this.m_E_Reward2Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Center/EG_PanelRoot/RewardSet/E_Reward2");
     			}
     			return this.m_E_Reward2Image;
     		}
     	}

		public UnityEngine.EventSystems.EventTrigger E_Reward2EventTrigger
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Reward2EventTrigger == null )
     			{
		    		this.m_E_Reward2EventTrigger = UIFindHelper.FindDeepChild<UnityEngine.EventSystems.EventTrigger>(this.uiTransform.gameObject,"Center/EG_PanelRoot/RewardSet/E_Reward2");
     			}
     			return this.m_E_Reward2EventTrigger;
     		}
     	}

		public UnityEngine.UI.Image E_Reward3Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Reward3Image == null )
     			{
		    		this.m_E_Reward3Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Center/EG_PanelRoot/RewardSet/E_Reward3");
     			}
     			return this.m_E_Reward3Image;
     		}
     	}

		public UnityEngine.EventSystems.EventTrigger E_Reward3EventTrigger
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Reward3EventTrigger == null )
     			{
		    		this.m_E_Reward3EventTrigger = UIFindHelper.FindDeepChild<UnityEngine.EventSystems.EventTrigger>(this.uiTransform.gameObject,"Center/EG_PanelRoot/RewardSet/E_Reward3");
     			}
     			return this.m_E_Reward3EventTrigger;
     		}
     	}

		public UnityEngine.UI.Image E_Reward4Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Reward4Image == null )
     			{
		    		this.m_E_Reward4Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Center/EG_PanelRoot/RewardSet/E_Reward4");
     			}
     			return this.m_E_Reward4Image;
     		}
     	}

		public UnityEngine.EventSystems.EventTrigger E_Reward4EventTrigger
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Reward4EventTrigger == null )
     			{
		    		this.m_E_Reward4EventTrigger = UIFindHelper.FindDeepChild<UnityEngine.EventSystems.EventTrigger>(this.uiTransform.gameObject,"Center/EG_PanelRoot/RewardSet/E_Reward4");
     			}
     			return this.m_E_Reward4EventTrigger;
     		}
     	}

		public UnityEngine.UI.ScrollRect E_ActivitySingInItemsScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ActivitySingInItemsScrollRect == null )
     			{
		    		this.m_E_ActivitySingInItemsScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.ScrollRect>(this.uiTransform.gameObject,"Center/EG_PanelRoot/E_ActivitySingInItems");
     			}
     			return this.m_E_ActivitySingInItemsScrollRect;
     		}
     	}

		public UnityEngine.UI.Image E_ActivitySingInItemsImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ActivitySingInItemsImage == null )
     			{
		    		this.m_E_ActivitySingInItemsImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Center/EG_PanelRoot/E_ActivitySingInItems");
     			}
     			return this.m_E_ActivitySingInItemsImage;
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
			this.m_E_TypeSetToggleGroup = null;
			this.m_EG_PanelRootRectTransform = null;
			this.m_E_AlreadySingInDayText = null;
			this.m_E_RewardProgressImage = null;
			this.m_E_Reward1Image = null;
			this.m_E_Reward1EventTrigger = null;
			this.m_E_Reward2Image = null;
			this.m_E_Reward2EventTrigger = null;
			this.m_E_Reward3Image = null;
			this.m_E_Reward3EventTrigger = null;
			this.m_E_Reward4Image = null;
			this.m_E_Reward4EventTrigger = null;
			this.m_E_ActivitySingInItemsScrollRect = null;
			this.m_E_ActivitySingInItemsImage = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.ToggleGroup m_E_TypeSetToggleGroup = null;
		private UnityEngine.RectTransform m_EG_PanelRootRectTransform = null;
		private UnityEngine.UI.Text m_E_AlreadySingInDayText = null;
		private UnityEngine.UI.Image m_E_RewardProgressImage = null;
		private UnityEngine.UI.Image m_E_Reward1Image = null;
		private UnityEngine.EventSystems.EventTrigger m_E_Reward1EventTrigger = null;
		private UnityEngine.UI.Image m_E_Reward2Image = null;
		private UnityEngine.EventSystems.EventTrigger m_E_Reward2EventTrigger = null;
		private UnityEngine.UI.Image m_E_Reward3Image = null;
		private UnityEngine.EventSystems.EventTrigger m_E_Reward3EventTrigger = null;
		private UnityEngine.UI.Image m_E_Reward4Image = null;
		private UnityEngine.EventSystems.EventTrigger m_E_Reward4EventTrigger = null;
		private UnityEngine.UI.ScrollRect m_E_ActivitySingInItemsScrollRect = null;
		private UnityEngine.UI.Image m_E_ActivitySingInItemsImage = null;
		public Transform uiTransform = null;
	}
}
