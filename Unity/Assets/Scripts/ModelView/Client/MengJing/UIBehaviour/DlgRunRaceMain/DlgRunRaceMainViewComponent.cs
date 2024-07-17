using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ComponentOf(typeof(DlgRunRaceMain))]
	[EnableMethod]
	public  class DlgRunRaceMainViewComponent : Entity,IAwake,IDestroy 
	{
		public Text E_ReadyTimeTextText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ReadyTimeTextText == null )
     			{
		    		this.m_E_ReadyTimeTextText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"Top/E_ReadyTimeText");
     			}
     			return this.m_E_ReadyTimeTextText;
     		}
     	}

		public Text E_TransformTimeTextText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TransformTimeTextText == null )
     			{
		    		this.m_E_TransformTimeTextText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"Top/E_TransformTimeText");
     			}
     			return this.m_E_TransformTimeTextText;
     		}
     	}

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
		    		this.m_EG_RankingListNodeRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"Left/ScrollView/Viewport/EG_RankingListNode");
     			}
     			return this.m_EG_RankingListNodeRectTransform;
     		}
     	}

		public RectTransform EG_PlayerInfoItem_1RectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_PlayerInfoItem_1RectTransform == null )
     			{
		    		this.m_EG_PlayerInfoItem_1RectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"Left/ScrollView/Viewport/EG_RankingListNode/EG_PlayerInfoItem_1");
     			}
     			return this.m_EG_PlayerInfoItem_1RectTransform;
     		}
     	}

		public RectTransform EG_PlayerInfoItem_2RectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_PlayerInfoItem_2RectTransform == null )
     			{
		    		this.m_EG_PlayerInfoItem_2RectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"Left/ScrollView/Viewport/EG_RankingListNode/EG_PlayerInfoItem_2");
     			}
     			return this.m_EG_PlayerInfoItem_2RectTransform;
     		}
     	}

		public RectTransform EG_PlayerInfoItem_3RectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_PlayerInfoItem_3RectTransform == null )
     			{
		    		this.m_EG_PlayerInfoItem_3RectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"Left/ScrollView/Viewport/EG_RankingListNode/EG_PlayerInfoItem_3");
     			}
     			return this.m_EG_PlayerInfoItem_3RectTransform;
     		}
     	}

		public RectTransform EG_PlayerInfoItem_OtherRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_PlayerInfoItem_OtherRectTransform == null )
     			{
		    		this.m_EG_PlayerInfoItem_OtherRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"Left/ScrollView/Viewport/EG_RankingListNode/EG_PlayerInfoItem_Other");
     			}
     			return this.m_EG_PlayerInfoItem_OtherRectTransform;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_ReadyTimeTextText = null;
			this.m_E_TransformTimeTextText = null;
			this.m_EG_RankingListNodeRectTransform = null;
			this.m_EG_PlayerInfoItem_1RectTransform = null;
			this.m_EG_PlayerInfoItem_2RectTransform = null;
			this.m_EG_PlayerInfoItem_3RectTransform = null;
			this.m_EG_PlayerInfoItem_OtherRectTransform = null;
			this.uiTransform = null;
		}

		private Text m_E_ReadyTimeTextText = null;
		private Text m_E_TransformTimeTextText = null;
		private RectTransform m_EG_RankingListNodeRectTransform = null;
		private RectTransform m_EG_PlayerInfoItem_1RectTransform = null;
		private RectTransform m_EG_PlayerInfoItem_2RectTransform = null;
		private RectTransform m_EG_PlayerInfoItem_3RectTransform = null;
		private RectTransform m_EG_PlayerInfoItem_OtherRectTransform = null;
		public Transform uiTransform = null;
	}
}
