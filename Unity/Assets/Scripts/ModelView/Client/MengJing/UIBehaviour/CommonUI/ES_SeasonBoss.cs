
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_SeasonBoss : Entity,ET.IAwake<UnityEngine.Transform>,IDestroy 
	{
		public int LastSeasonBossLevel { get; set; } = -1;
		
		public ES_ModelShow ES_ModelShow
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			ES_ModelShow es = this.m_es_modelshow;
     			if( es == null )

     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Left/ES_ModelShow");
		    	   this.m_es_modelshow = this.AddChild<ES_ModelShow,Transform>(subTrans);
     			}
     			return this.m_es_modelshow;
     		}
     	}

		public UnityEngine.UI.Image E_Img_LodingValueImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Img_LodingValueImage == null )
     			{
		    		this.m_E_Img_LodingValueImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_Img_LodingValue");
     			}
     			return this.m_E_Img_LodingValueImage;
     		}
     	}

		public UnityEngine.UI.Image E_Img_LodingImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Img_LodingImage == null )
     			{
		    		this.m_E_Img_LodingImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_Img_LodingValue/E_Img_Loding");
     			}
     			return this.m_E_Img_LodingImage;
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

		public UnityEngine.UI.Button E_DonationBtnButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_DonationBtnButton == null )
     			{
		    		this.m_E_DonationBtnButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/E_DonationBtn");
     			}
     			return this.m_E_DonationBtnButton;
     		}
     	}

		public UnityEngine.UI.Image E_DonationBtnImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_DonationBtnImage == null )
     			{
		    		this.m_E_DonationBtnImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_DonationBtn");
     			}
     			return this.m_E_DonationBtnImage;
     		}
     	}

		public UnityEngine.UI.Button E_RewardBtnButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_RewardBtnButton == null )
     			{
		    		this.m_E_RewardBtnButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/E_RewardBtn");
     			}
     			return this.m_E_RewardBtnButton;
     		}
     	}

		public UnityEngine.UI.Image E_RewardBtnImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_RewardBtnImage == null )
     			{
		    		this.m_E_RewardBtnImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_RewardBtn");
     			}
     			return this.m_E_RewardBtnImage;
     		}
     	}

		public ES_CostItem ES_CostItem
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			ES_CostItem es = this.m_es_costitem;
     			if( es == null )

     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Right/ES_CostItem");
		    	   this.m_es_costitem = this.AddChild<ES_CostItem,Transform>(subTrans);
     			}
     			return this.m_es_costitem;
     		}
     	}

		public UnityEngine.UI.Text E_SeasonExperienceTextText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SeasonExperienceTextText == null )
     			{
		    		this.m_E_SeasonExperienceTextText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Right/E_SeasonExperienceText");
     			}
     			return this.m_E_SeasonExperienceTextText;
     		}
     	}

		public UnityEngine.UI.Text E_SeasonDonateTimesText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SeasonDonateTimesText == null )
     			{
		    		this.m_E_SeasonDonateTimesText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Right/E_SeasonDonateTimes");
     			}
     			return this.m_E_SeasonDonateTimesText;
     		}
     	}

		public UnityEngine.UI.Text E_SeasonBossLevelText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_SeasonBossLevelText == null )
     			{
		    		this.m_E_SeasonBossLevelText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Right/E_SeasonBossLevel");
     			}
     			return this.m_E_SeasonBossLevelText;
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
			this.m_es_modelshow = null;
			this.m_E_Img_LodingValueImage = null;
			this.m_E_Img_LodingImage = null;
			this.m_es_rewardlist = null;
			this.m_E_DonationBtnButton = null;
			this.m_E_DonationBtnImage = null;
			this.m_E_RewardBtnButton = null;
			this.m_E_RewardBtnImage = null;
			this.m_es_costitem = null;
			this.m_E_SeasonExperienceTextText = null;
			this.m_E_SeasonDonateTimesText = null;
			this.m_E_SeasonBossLevelText = null;
			this.uiTransform = null;
		}

		private EntityRef<ES_ModelShow> m_es_modelshow = null;
		private UnityEngine.UI.Image m_E_Img_LodingValueImage = null;
		private UnityEngine.UI.Image m_E_Img_LodingImage = null;
		private EntityRef<ES_RewardList> m_es_rewardlist = null;
		private UnityEngine.UI.Button m_E_DonationBtnButton = null;
		private UnityEngine.UI.Image m_E_DonationBtnImage = null;
		private UnityEngine.UI.Button m_E_RewardBtnButton = null;
		private UnityEngine.UI.Image m_E_RewardBtnImage = null;
		private EntityRef<ES_CostItem> m_es_costitem = null;
		private UnityEngine.UI.Text m_E_SeasonExperienceTextText = null;
		private UnityEngine.UI.Text m_E_SeasonDonateTimesText = null;
		private UnityEngine.UI.Text m_E_SeasonBossLevelText = null;
		public Transform uiTransform = null;
	}
}
