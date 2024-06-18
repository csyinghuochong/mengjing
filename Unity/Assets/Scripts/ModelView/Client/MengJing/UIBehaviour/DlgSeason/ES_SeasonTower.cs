
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_SeasonTower : Entity,ET.IAwake<UnityEngine.Transform>,IDestroy,IUILogic
	{
		public List<RankSeasonTowerInfo> ShowRankSeasonTowerInfos;
		public Dictionary<int, Scroll_Item_SeasonTowerRankItem> ScrollItemSeasonTowerRankItems;
		
		public UnityEngine.UI.LoopVerticalScrollRect E_SeasonTowerRankItemsLoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SeasonTowerRankItemsLoopVerticalScrollRect == null )
     			{
		    		this.m_E_SeasonTowerRankItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopVerticalScrollRect>(this.uiTransform.gameObject,"E_SeasonTowerRankItems");
     			}
     			return this.m_E_SeasonTowerRankItemsLoopVerticalScrollRect;
     		}
     	}

		public UnityEngine.UI.Button E_RewardShowBtnButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_RewardShowBtnButton == null )
     			{
		    		this.m_E_RewardShowBtnButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_RewardShowBtn");
     			}
     			return this.m_E_RewardShowBtnButton;
     		}
     	}

		public UnityEngine.UI.Image E_RewardShowBtnImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_RewardShowBtnImage == null )
     			{
		    		this.m_E_RewardShowBtnImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_RewardShowBtn");
     			}
     			return this.m_E_RewardShowBtnImage;
     		}
     	}

		public UnityEngine.UI.Text E_TimeTextText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TimeTextText == null )
     			{
		    		this.m_E_TimeTextText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_TimeText");
     			}
     			return this.m_E_TimeTextText;
     		}
     	}

		public UnityEngine.UI.Text E_LayerTextText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_LayerTextText == null )
     			{
		    		this.m_E_LayerTextText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"E_LayerText");
     			}
     			return this.m_E_LayerTextText;
     		}
     	}

		public UnityEngine.UI.Button E_EnterBtnButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_EnterBtnButton == null )
     			{
		    		this.m_E_EnterBtnButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_EnterBtn");
     			}
     			return this.m_E_EnterBtnButton;
     		}
     	}

		public UnityEngine.UI.Image E_EnterBtnImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_EnterBtnImage == null )
     			{
		    		this.m_E_EnterBtnImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_EnterBtn");
     			}
     			return this.m_E_EnterBtnImage;
     		}
     	}

		public UnityEngine.UI.Text E_Text_CengText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_CengText == null )
     			{
		    		this.m_E_Text_CengText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"TipImg (1)/E_Text_Ceng");
     			}
     			return this.m_E_Text_CengText;
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
			this.m_E_SeasonTowerRankItemsLoopVerticalScrollRect = null;
			this.m_E_RewardShowBtnButton = null;
			this.m_E_RewardShowBtnImage = null;
			this.m_E_TimeTextText = null;
			this.m_E_LayerTextText = null;
			this.m_E_EnterBtnButton = null;
			this.m_E_EnterBtnImage = null;
			this.m_E_Text_CengText = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.LoopVerticalScrollRect m_E_SeasonTowerRankItemsLoopVerticalScrollRect = null;
		private UnityEngine.UI.Button m_E_RewardShowBtnButton = null;
		private UnityEngine.UI.Image m_E_RewardShowBtnImage = null;
		private UnityEngine.UI.Text m_E_TimeTextText = null;
		private UnityEngine.UI.Text m_E_LayerTextText = null;
		private UnityEngine.UI.Button m_E_EnterBtnButton = null;
		private UnityEngine.UI.Image m_E_EnterBtnImage = null;
		private UnityEngine.UI.Text m_E_Text_CengText = null;
		public Transform uiTransform = null;
	}
}
