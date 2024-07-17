using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_HuntRanking : Entity,IAwake<Transform>,IDestroy,IUILogic
	{
		public List<RankRewardConfig> ShowRankRewardConfigs;
		public Dictionary<int, EntityRef<Scroll_Item_RunRaceItem>> ScrollItemRunRaceItems;
		public long EndTime;
		
		public Text E_HuntingTimeTextText
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
		    		this.m_E_HuntingTimeTextText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"HuntingTimeTip/E_HuntingTimeText");
     			}
     			return this.m_E_HuntingTimeTextText;
     		}
     	}

		public Image E_HeadImage_No1Image
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
		    		this.m_E_HeadImage_No1Image = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"PlayerInfo_No1/E_HeadImage_No1");
     			}
     			return this.m_E_HeadImage_No1Image;
     		}
     	}

		public Text E_NameText_No1Text
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
		    		this.m_E_NameText_No1Text = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"PlayerInfo_No1/E_NameText_No1");
     			}
     			return this.m_E_NameText_No1Text;
     		}
     	}

		public Text E_HuntNumText_No1Text
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
		    		this.m_E_HuntNumText_No1Text = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"PlayerInfo_No1/E_HuntNumText_No1");
     			}
     			return this.m_E_HuntNumText_No1Text;
     		}
     	}

		public RectTransform EG_HuntRankingListNodeRectTransform
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
		    		this.m_EG_HuntRankingListNodeRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"ScrollView/Viewport/EG_HuntRankingListNode");
     			}
     			return this.m_EG_HuntRankingListNodeRectTransform;
     		}
     	}

		public RectTransform EG_UIHuntRankingPlayerInfoItemRectTransform
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
		    		this.m_EG_UIHuntRankingPlayerInfoItemRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"ScrollView/Viewport/EG_HuntRankingListNode/EG_UIHuntRankingPlayerInfoItem");
     			}
     			return this.m_EG_UIHuntRankingPlayerInfoItemRectTransform;
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
			this.m_E_HuntingTimeTextText = null;
			this.m_E_HeadImage_No1Image = null;
			this.m_E_NameText_No1Text = null;
			this.m_E_HuntNumText_No1Text = null;
			this.m_EG_HuntRankingListNodeRectTransform = null;
			this.m_EG_UIHuntRankingPlayerInfoItemRectTransform = null;
			this.m_E_RunRaceItemsLoopVerticalScrollRect = null;
			this.uiTransform = null;
		}

		private Text m_E_HuntingTimeTextText = null;
		private Image m_E_HeadImage_No1Image = null;
		private Text m_E_NameText_No1Text = null;
		private Text m_E_HuntNumText_No1Text = null;
		private RectTransform m_EG_HuntRankingListNodeRectTransform = null;
		private RectTransform m_EG_UIHuntRankingPlayerInfoItemRectTransform = null;
		private LoopVerticalScrollRect m_E_RunRaceItemsLoopVerticalScrollRect = null;
		public Transform uiTransform = null;
	}
}
