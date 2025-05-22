using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_TrialRank : Entity,IAwake<Transform>,IDestroy,IUILogic
	{
		public int Page;
		public Dictionary<int, EntityRef<Scroll_Item_RankItem>> ScrollItemRankItems;
		public List<RankingTrialInfo> ShowRankingTrialInfos = new();
		public int CurrentItemType;
		
		public UnityEngine.RectTransform EG_RightRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_RightRectTransform == null )
     			{
		    		this.m_EG_RightRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_Right");
     			}
     			return this.m_EG_RightRectTransform;
     		}
     	}

		public UnityEngine.UI.LoopVerticalScrollRect E_RankItemsLoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_RankItemsLoopVerticalScrollRect == null )
     			{
		    		this.m_E_RankItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<UnityEngine.UI.LoopVerticalScrollRect>(this.uiTransform.gameObject,"EG_Right/E_RankItems");
     			}
     			return this.m_E_RankItemsLoopVerticalScrollRect;
     		}
     	}

		public UnityEngine.UI.Text E_Text_MyRankText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_MyRankText == null )
     			{
		    		this.m_E_Text_MyRankText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EG_Right/E_Text_MyRank");
     			}
     			return this.m_E_Text_MyRankText;
     		}
     	}

		public UnityEngine.UI.Text E_Text_RewardTimeText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_RewardTimeText == null )
     			{
		    		this.m_E_Text_RewardTimeText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"EG_Right/E_Text_RewardTime");
     			}
     			return this.m_E_Text_RewardTimeText;
     		}
     	}

		public UnityEngine.UI.Button E_Button_RewardButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_RewardButton == null )
     			{
		    		this.m_E_Button_RewardButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"EG_Right/E_Button_Reward");
     			}
     			return this.m_E_Button_RewardButton;
     		}
     	}

		public UnityEngine.UI.Image E_Button_RewardImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_RewardImage == null )
     			{
		    		this.m_E_Button_RewardImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_Right/E_Button_Reward");
     			}
     			return this.m_E_Button_RewardImage;
     		}
     	}

		public UnityEngine.UI.ToggleGroup E_ItemTypeSetToggleGroup
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ItemTypeSetToggleGroup == null )
     			{
		    		this.m_E_ItemTypeSetToggleGroup = UIFindHelper.FindDeepChild<UnityEngine.UI.ToggleGroup>(this.uiTransform.gameObject,"EG_Right/E_ItemTypeSet");
     			}
     			return this.m_E_ItemTypeSetToggleGroup;
     		}
     	}

		public UnityEngine.UI.Image E_HeadIcomImage1Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_HeadIcomImage1Image == null )
     			{
		    		this.m_E_HeadIcomImage1Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_Right/E_ItemTypeSet/Type_0/E_HeadIcomImage1");
     			}
     			return this.m_E_HeadIcomImage1Image;
     		}
     	}

		public UnityEngine.UI.Image E_HeadIcomImage2Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_HeadIcomImage2Image == null )
     			{
		    		this.m_E_HeadIcomImage2Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_Right/E_ItemTypeSet/Type_1/E_HeadIcomImage2");
     			}
     			return this.m_E_HeadIcomImage2Image;
     		}
     	}

		public UnityEngine.UI.Image E_HeadIcomImage3Image
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_HeadIcomImage3Image == null )
     			{
		    		this.m_E_HeadIcomImage3Image = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"EG_Right/E_ItemTypeSet/Type_2/E_HeadIcomImage3");
     			}
     			return this.m_E_HeadIcomImage3Image;
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
			this.m_EG_RightRectTransform = null;
			this.m_E_RankItemsLoopVerticalScrollRect = null;
			this.m_E_Text_MyRankText = null;
			this.m_E_Text_RewardTimeText = null;
			this.m_E_Button_RewardButton = null;
			this.m_E_Button_RewardImage = null;
			this.m_E_ItemTypeSetToggleGroup = null;
			this.m_E_HeadIcomImage1Image = null;
			this.m_E_HeadIcomImage2Image = null;
			this.m_E_HeadIcomImage3Image = null;
			this.uiTransform = null;
		}

		private UnityEngine.RectTransform m_EG_RightRectTransform = null;
		private UnityEngine.UI.LoopVerticalScrollRect m_E_RankItemsLoopVerticalScrollRect = null;
		private UnityEngine.UI.Text m_E_Text_MyRankText = null;
		private UnityEngine.UI.Text m_E_Text_RewardTimeText = null;
		private UnityEngine.UI.Button m_E_Button_RewardButton = null;
		private UnityEngine.UI.Image m_E_Button_RewardImage = null;
		private UnityEngine.UI.ToggleGroup m_E_ItemTypeSetToggleGroup = null;
		private UnityEngine.UI.Image m_E_HeadIcomImage1Image = null;
		private UnityEngine.UI.Image m_E_HeadIcomImage2Image = null;
		private UnityEngine.UI.Image m_E_HeadIcomImage3Image = null;
		public Transform uiTransform = null;
	}
}
