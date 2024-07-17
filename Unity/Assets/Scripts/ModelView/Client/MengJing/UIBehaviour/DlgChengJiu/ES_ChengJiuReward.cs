using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_ChengJiuReward : Entity,IAwake<Transform>,IDestroy,IUILogic
	{
		public List<ChengJiuRewardConfig> ShowChengJiuRewardConfigs = new();
		public Dictionary<int, EntityRef<Scroll_Item_ChengJiuRewardItem>> ScrollItemChengJiuRewardItems;
		public int RewardId;
		
		public Text E_Text_TotalPointText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_TotalPointText == null )
     			{
		    		this.m_E_Text_TotalPointText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"Left/E_Text_TotalPoint");
     			}
     			return this.m_E_Text_TotalPointText;
     		}
     	}

		public LoopVerticalScrollRect E_ChengJiuRewardItemsLoopVerticalScrollRect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ChengJiuRewardItemsLoopVerticalScrollRect == null )
     			{
		    		this.m_E_ChengJiuRewardItemsLoopVerticalScrollRect = UIFindHelper.FindDeepChild<LoopVerticalScrollRect>(this.uiTransform.gameObject,"Left/E_ChengJiuRewardItems");
     			}
     			return this.m_E_ChengJiuRewardItemsLoopVerticalScrollRect;
     		}
     	}

		public Image E_Image_RewardJiuDiImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Image_RewardJiuDiImage == null )
     			{
		    		this.m_E_Image_RewardJiuDiImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"Right/E_Image_RewardJiuDi");
     			}
     			return this.m_E_Image_RewardJiuDiImage;
     		}
     	}

		public Image E_Image_RewardIconImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Image_RewardIconImage == null )
     			{
		    		this.m_E_Image_RewardIconImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"Right/E_Image_RewardIcon");
     			}
     			return this.m_E_Image_RewardIconImage;
     		}
     	}

		public Text E_Text_RewardPointText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_RewardPointText == null )
     			{
		    		this.m_E_Text_RewardPointText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"Right/E_Text_RewardPoint");
     			}
     			return this.m_E_Text_RewardPointText;
     		}
     	}

		public Text E_Text_RewardDescText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_RewardDescText == null )
     			{
		    		this.m_E_Text_RewardDescText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"Right/E_Text_RewardDesc");
     			}
     			return this.m_E_Text_RewardDescText;
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
     			if( es==null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Right/ES_RewardList");
		    	   this.m_es_rewardlist = this.AddChild<ES_RewardList,Transform>(subTrans);
     			}
     			return this.m_es_rewardlist;
     		}
     	}

		public Button E_Btn_LingQuButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_LingQuButton == null )
     			{
		    		this.m_E_Btn_LingQuButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"Right/E_Btn_LingQu");
     			}
     			return this.m_E_Btn_LingQuButton;
     		}
     	}

		public Image E_Btn_LingQuImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_LingQuImage == null )
     			{
		    		this.m_E_Btn_LingQuImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"Right/E_Btn_LingQu");
     			}
     			return this.m_E_Btn_LingQuImage;
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
			this.m_E_Text_TotalPointText = null;
			this.m_E_ChengJiuRewardItemsLoopVerticalScrollRect = null;
			this.m_E_Image_RewardJiuDiImage = null;
			this.m_E_Image_RewardIconImage = null;
			this.m_E_Text_RewardPointText = null;
			this.m_E_Text_RewardDescText = null;
			this.m_es_rewardlist = null;
			this.m_E_Btn_LingQuButton = null;
			this.m_E_Btn_LingQuImage = null;
			this.uiTransform = null;
		}

		private Text m_E_Text_TotalPointText = null;
		private LoopVerticalScrollRect m_E_ChengJiuRewardItemsLoopVerticalScrollRect = null;
		private Image m_E_Image_RewardJiuDiImage = null;
		private Image m_E_Image_RewardIconImage = null;
		private Text m_E_Text_RewardPointText = null;
		private Text m_E_Text_RewardDescText = null;
		private EntityRef<ES_RewardList> m_es_rewardlist = null;
		private Button m_E_Btn_LingQuButton = null;
		private Image m_E_Btn_LingQuImage = null;
		public Transform uiTransform = null;
	}
}
