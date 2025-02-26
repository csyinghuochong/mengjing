
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_ActivitySingInFree : Entity,ET.IAwake<UnityEngine.Transform>,IDestroy,IUILogic
	{
		public int CurDay;
		public List<ActivityConfig> ShowActivityConfigs = new();
		public Dictionary<int, EntityRef<Scroll_Item_ActivitySingInItem>> ScrollItemActivitySingInItems;
		
		public UnityEngine.UI.LoopVerticalScrollRect E_ActivitySingInItemsLoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ActivitySingInItemsLoopVerticalScrollRect == null )
     			{
		    		this.m_E_ActivitySingInItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopVerticalScrollRect>(this.uiTransform.gameObject,"E_ActivitySingInItems");
     			}
     			return this.m_E_ActivitySingInItemsLoopVerticalScrollRect;
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
		    		this.m_E_AlreadySingInDayText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_AlreadySingInDay");
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
		    		this.m_E_RewardProgressImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"RewardSet/E_RewardProgress");
     			}
     			return this.m_E_RewardProgressImage;
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
		    		this.m_E_Reward1EventTrigger = UIFindHelper.FindDeepChild<UnityEngine.EventSystems.EventTrigger>(this.uiTransform.gameObject,"RewardSet/E_Reward1");
     			}
     			return this.m_E_Reward1EventTrigger;
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
		    		this.m_E_Reward2EventTrigger = UIFindHelper.FindDeepChild<UnityEngine.EventSystems.EventTrigger>(this.uiTransform.gameObject,"RewardSet/E_Reward2");
     			}
     			return this.m_E_Reward2EventTrigger;
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
		    		this.m_E_Reward3EventTrigger = UIFindHelper.FindDeepChild<UnityEngine.EventSystems.EventTrigger>(this.uiTransform.gameObject,"RewardSet/E_Reward3");
     			}
     			return this.m_E_Reward3EventTrigger;
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
		    		this.m_E_Reward4EventTrigger = UIFindHelper.FindDeepChild<UnityEngine.EventSystems.EventTrigger>(this.uiTransform.gameObject,"RewardSet/E_Reward4");
     			}
     			return this.m_E_Reward4EventTrigger;
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
			this.m_E_ActivitySingInItemsLoopVerticalScrollRect = null;
			this.m_E_AlreadySingInDayText = null;
			this.m_E_RewardProgressImage = null;
			this.m_E_Reward1EventTrigger = null;
			this.m_E_Reward2EventTrigger = null;
			this.m_E_Reward3EventTrigger = null;
			this.m_E_Reward4EventTrigger = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.LoopVerticalScrollRect m_E_ActivitySingInItemsLoopVerticalScrollRect = null;
		private UnityEngine.UI.Text m_E_AlreadySingInDayText = null;
		private UnityEngine.UI.Image m_E_RewardProgressImage = null;
		private UnityEngine.EventSystems.EventTrigger m_E_Reward1EventTrigger = null;
		private UnityEngine.EventSystems.EventTrigger m_E_Reward2EventTrigger = null;
		private UnityEngine.EventSystems.EventTrigger m_E_Reward3EventTrigger = null;
		private UnityEngine.EventSystems.EventTrigger m_E_Reward4EventTrigger = null;
		public Transform uiTransform = null;
	}
}
