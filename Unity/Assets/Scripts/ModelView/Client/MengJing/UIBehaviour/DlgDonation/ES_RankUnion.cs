using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_RankUnion : Entity,IAwake<Transform>,IDestroy,IUILogic
	{
		public List<RankRewardConfig> ShowRankRewardConfigs;
		public Dictionary<int, EntityRef<Scroll_Item_RunRaceItem>> ScrollItemRunRaceItems;
		public List<TaskPro> ShowTaskPros = new();
		public Dictionary<int, EntityRef<Scroll_Item_RankUnionTaskItem>> ScrollItemRankUnionTaskItems;
		
		public RectTransform EG_RankingListNodeRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_RankingListNodeRectTransform == null )
     			{
		    		this.m_EG_RankingListNodeRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"ScrollView/Viewport/EG_RankingListNode");
     			}
     			return this.m_EG_RankingListNodeRectTransform;
     		}
     	}

		public RectTransform EG_UIRankUnionItemRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_UIRankUnionItemRectTransform == null )
     			{
		    		this.m_EG_UIRankUnionItemRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"ScrollView/Viewport/EG_RankingListNode/EG_UIRankUnionItem");
     			}
     			return this.m_EG_UIRankUnionItemRectTransform;
     		}
     	}

		public LoopVerticalScrollRect E_RankUnionTaskItemsLoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_RankUnionTaskItemsLoopVerticalScrollRect == null )
     			{
		    		this.m_E_RankUnionTaskItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<LoopVerticalScrollRect>(this.uiTransform.gameObject,"E_RankUnionTaskItems");
     			}
     			return this.m_E_RankUnionTaskItemsLoopVerticalScrollRect;
     		}
     	}

		public LoopVerticalScrollRect E_RunRaceItemsLoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_RunRaceItemsLoopVerticalScrollRect == null )
     			{
		    		this.m_E_RunRaceItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<LoopVerticalScrollRect>(this.uiTransform.gameObject,"E_RunRaceItems");
     			}
     			return this.m_E_RunRaceItemsLoopVerticalScrollRect;
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
			this.m_EG_RankingListNodeRectTransform = null;
			this.m_EG_UIRankUnionItemRectTransform = null;
			this.m_E_RankUnionTaskItemsLoopVerticalScrollRect = null;
			this.m_E_RunRaceItemsLoopVerticalScrollRect = null;
			this.uiTransform = null;
		}

		private RectTransform m_EG_RankingListNodeRectTransform = null;
		private RectTransform m_EG_UIRankUnionItemRectTransform = null;
		private LoopVerticalScrollRect m_E_RankUnionTaskItemsLoopVerticalScrollRect = null;
		private LoopVerticalScrollRect m_E_RunRaceItemsLoopVerticalScrollRect = null;
		public Transform uiTransform = null;
	}
}
