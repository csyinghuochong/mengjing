using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_SeasonTower : Entity,IAwake<Transform>,IDestroy,IUILogic
	{
		public List<RankSeasonTowerInfo> ShowRankSeasonTowerInfos;
		public Dictionary<int, EntityRef<Scroll_Item_SeasonTowerRankItem>> ScrollItemSeasonTowerRankItems;
		
		public LoopVerticalScrollRect E_SeasonTowerRankItemsLoopVerticalScrollRect
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
		    		this.m_E_SeasonTowerRankItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<LoopVerticalScrollRect>(this.uiTransform.gameObject,"E_SeasonTowerRankItems");
     			}
     			return this.m_E_SeasonTowerRankItemsLoopVerticalScrollRect;
     		}
     	}

		public Button E_RewardShowBtnButton
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
		    		this.m_E_RewardShowBtnButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_RewardShowBtn");
     			}
     			return this.m_E_RewardShowBtnButton;
     		}
     	}

		public Image E_RewardShowBtnImage
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
		    		this.m_E_RewardShowBtnImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_RewardShowBtn");
     			}
     			return this.m_E_RewardShowBtnImage;
     		}
     	}

		public Text E_TimeTextText
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
		    		this.m_E_TimeTextText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_TimeText");
     			}
     			return this.m_E_TimeTextText;
     		}
     	}

		public Text E_LayerTextText
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
		    		this.m_E_LayerTextText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_LayerText");
     			}
     			return this.m_E_LayerTextText;
     		}
     	}

		public Button E_EnterBtnButton
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
		    		this.m_E_EnterBtnButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_EnterBtn");
     			}
     			return this.m_E_EnterBtnButton;
     		}
     	}

		public Image E_EnterBtnImage
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
		    		this.m_E_EnterBtnImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_EnterBtn");
     			}
     			return this.m_E_EnterBtnImage;
     		}
     	}

		public Text E_Text_CengText
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
		    		this.m_E_Text_CengText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"TipImg (1)/E_Text_Ceng");
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

		private LoopVerticalScrollRect m_E_SeasonTowerRankItemsLoopVerticalScrollRect = null;
		private Button m_E_RewardShowBtnButton = null;
		private Image m_E_RewardShowBtnImage = null;
		private Text m_E_TimeTextText = null;
		private Text m_E_LayerTextText = null;
		private Button m_E_EnterBtnButton = null;
		private Image m_E_EnterBtnImage = null;
		private Text m_E_Text_CengText = null;
		public Transform uiTransform = null;
	}
}
