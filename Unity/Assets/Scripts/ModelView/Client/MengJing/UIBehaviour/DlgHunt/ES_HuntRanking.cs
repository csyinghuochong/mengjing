
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_HuntRanking : Entity,ET.IAwake<UnityEngine.Transform>,IDestroy,IUILogic
	{
		public List<RankRewardConfig> ShowRankRewardConfigs;
		public Dictionary<int, Scroll_Item_RunRaceItem> ScrollItemRunRaceItems;
		public long EndTime;
		
		public UnityEngine.UI.Text E_HuntingTimeTextText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_HuntingTimeTextText == null )
     			{
		    		this.m_E_HuntingTimeTextText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"HuntingTimeTip/E_HuntingTimeText");
     			}
     			return this.m_E_HuntingTimeTextText;
     		}
     	}

		public UnityEngine.UI.Image E_HeadImage_No1Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_HeadImage_No1Image == null )
     			{
		    		this.m_E_HeadImage_No1Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"PlayerInfo_No1/E_HeadImage_No1");
     			}
     			return this.m_E_HeadImage_No1Image;
     		}
     	}

		public UnityEngine.UI.Text E_NameText_No1Text
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_NameText_No1Text == null )
     			{
		    		this.m_E_NameText_No1Text = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"PlayerInfo_No1/E_NameText_No1");
     			}
     			return this.m_E_NameText_No1Text;
     		}
     	}

		public UnityEngine.UI.Text E_HuntNumText_No1Text
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_HuntNumText_No1Text == null )
     			{
		    		this.m_E_HuntNumText_No1Text = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"PlayerInfo_No1/E_HuntNumText_No1");
     			}
     			return this.m_E_HuntNumText_No1Text;
     		}
     	}

		public UnityEngine.RectTransform EG_HuntRankingListNodeRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_HuntRankingListNodeRectTransform == null )
     			{
		    		this.m_EG_HuntRankingListNodeRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"ScrollView/Viewport/EG_HuntRankingListNode");
     			}
     			return this.m_EG_HuntRankingListNodeRectTransform;
     		}
     	}

		public UnityEngine.RectTransform EG_UIHuntRankingPlayerInfoItemRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_UIHuntRankingPlayerInfoItemRectTransform == null )
     			{
		    		this.m_EG_UIHuntRankingPlayerInfoItemRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"ScrollView/Viewport/EG_HuntRankingListNode/EG_UIHuntRankingPlayerInfoItem");
     			}
     			return this.m_EG_UIHuntRankingPlayerInfoItemRectTransform;
     		}
     	}

		public UnityEngine.UI.LoopVerticalScrollRect E_RunRaceItemsLoopVerticalScrollRect
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
		    		this.m_E_RunRaceItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopVerticalScrollRect>(this.uiTransform.gameObject,"E_RunRaceItems");
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
			this.m_E_HuntingTimeTextText = null;
			this.m_E_HeadImage_No1Image = null;
			this.m_E_NameText_No1Text = null;
			this.m_E_HuntNumText_No1Text = null;
			this.m_EG_HuntRankingListNodeRectTransform = null;
			this.m_EG_UIHuntRankingPlayerInfoItemRectTransform = null;
			this.m_E_RunRaceItemsLoopVerticalScrollRect = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.Text m_E_HuntingTimeTextText = null;
		private UnityEngine.UI.Image m_E_HeadImage_No1Image = null;
		private UnityEngine.UI.Text m_E_NameText_No1Text = null;
		private UnityEngine.UI.Text m_E_HuntNumText_No1Text = null;
		private UnityEngine.RectTransform m_EG_HuntRankingListNodeRectTransform = null;
		private UnityEngine.RectTransform m_EG_UIHuntRankingPlayerInfoItemRectTransform = null;
		private UnityEngine.UI.LoopVerticalScrollRect m_E_RunRaceItemsLoopVerticalScrollRect = null;
		public Transform uiTransform = null;
	}
}
