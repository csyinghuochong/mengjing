using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_UnionOrder : Entity,ET.IAwake<UnityEngine.Transform>,IDestroy, IUILogic
	{

		public long UpdateTime;
		public TaskPro SelectTaskPro;
		public Dictionary<int, EntityRef<Scroll_Item_UnionOrderItem>> ScrollItemUnionListItems;
		public List<TaskPro> ShowTaskIds = new List<TaskPro>();	
		
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
		    		this.m_E_UnionMyItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopVerticalScrollRect>(this.uiTransform.gameObject,"Left/E_UnionMyItems");
     			}
     			return this.m_E_UnionMyItemsLoopVerticalScrollRect;
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
		    		this.m_E_Button_UpgradeButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Left/E_Button_Upgrade");
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
		    		this.m_E_Button_UpgradeImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Left/E_Button_Upgrade");
     			}
     			return this.m_E_Button_UpgradeImage;
     		}
     	}

		public UnityEngine.UI.Text E_Text_OrderCDText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_OrderCDText == null )
     			{
		    		this.m_E_Text_OrderCDText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Left/E_Text_OrderCD");
     			}
     			return this.m_E_Text_OrderCDText;
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
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Right/ES_CommonItem");
		    	   this.m_es_commonitem = this.AddChild<ES_CommonItem,Transform>(subTrans);
     			}
     			return this.m_es_commonitem;
     		}
     	}

		public ES_RewardList ES_RewardList
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			ES_RewardList es = this.m_es_rewardlist;
     			if( es == null )

     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Right/ES_RewardList");
		    	   this.m_es_rewardlist = this.AddChild<ES_RewardList,Transform>(subTrans);
     			}
     			return this.m_es_rewardlist;
     		}
     	}

		public UnityEngine.UI.Button E_Button_CommitButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_CommitButton == null )
     			{
		    		this.m_E_Button_CommitButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/E_Button_Commit");
     			}
     			return this.m_E_Button_CommitButton;
     		}
     	}

		public UnityEngine.UI.Image E_Button_CommitImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_CommitImage == null )
     			{
		    		this.m_E_Button_CommitImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_Button_Commit");
     			}
     			return this.m_E_Button_CommitImage;
     		}
     	}

		public UnityEngine.UI.Text E_Text_NeedText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_NeedText == null )
     			{
		    		this.m_E_Text_NeedText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Right/E_Text_Need");
     			}
     			return this.m_E_Text_NeedText;
     		}
     	}

		public UnityEngine.UI.Text E_Text_HaveText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_HaveText == null )
     			{
		    		this.m_E_Text_HaveText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Right/E_Text_Have");
     			}
     			return this.m_E_Text_HaveText;
     		}
     	}

		public UnityEngine.UI.Text E_Text_TaskDesText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_TaskDesText == null )
     			{
		    		this.m_E_Text_TaskDesText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Right/E_Text_TaskDes");
     			}
     			return this.m_E_Text_TaskDesText;
     		}
     	}
		//
		public UnityEngine.UI.Text E_Text_TodayNumber
		{
			get
			{
				if (this.uiTransform == null)
				{
					Log.Error("uiTransform is null.");
					return null;
				}
				if( this.m_E_Text_TodayNumber == null )
				{
					this.m_E_Text_TodayNumber = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Left/E_Text_TodayNumber");
				}
				return this.m_E_Text_TodayNumber;
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
			this.m_E_UnionMyItemsLoopVerticalScrollRect = null;
			this.m_E_Button_UpgradeButton = null;
			this.m_E_Button_UpgradeImage = null;
			this.m_E_Text_OrderCDText = null;
			this.m_es_commonitem = null;
			this.m_es_rewardlist = null;
			this.m_E_Button_CommitButton = null;
			this.m_E_Button_CommitImage = null;
			this.m_E_Text_NeedText = null;
			this.m_E_Text_HaveText = null;
			this.m_E_Text_TaskDesText = null;
			this.m_E_Text_TodayNumber = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.LoopVerticalScrollRect m_E_UnionMyItemsLoopVerticalScrollRect = null;
		private UnityEngine.UI.Button m_E_Button_UpgradeButton = null;
		private UnityEngine.UI.Image m_E_Button_UpgradeImage = null;
		private UnityEngine.UI.Text m_E_Text_OrderCDText = null;
		private EntityRef<ES_CommonItem> m_es_commonitem = null;
		private EntityRef<ES_RewardList> m_es_rewardlist = null;
		private UnityEngine.UI.Button m_E_Button_CommitButton = null;
		private UnityEngine.UI.Image m_E_Button_CommitImage = null;
		private UnityEngine.UI.Text m_E_Text_NeedText = null;
		private UnityEngine.UI.Text m_E_Text_HaveText = null;
		private UnityEngine.UI.Text m_E_Text_TaskDesText = null;
		private UnityEngine.UI.Text m_E_Text_TodayNumber = null;
		public Transform uiTransform = null;
	}
}
