
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_PetEggChouKa : Entity,ET.IAwake<UnityEngine.Transform>,IDestroy 
	{
		public UnityEngine.UI.Button E_Btn_PetEggLucklyExplainButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_PetEggLucklyExplainButton == null )
     			{
		    		this.m_E_Btn_PetEggLucklyExplainButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Left/E_Btn_PetEggLucklyExplain");
     			}
     			return this.m_E_Btn_PetEggLucklyExplainButton;
     		}
     	}

		public UnityEngine.UI.Image E_Btn_PetEggLucklyExplainImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_PetEggLucklyExplainImage == null )
     			{
		    		this.m_E_Btn_PetEggLucklyExplainImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Left/E_Btn_PetEggLucklyExplain");
     			}
     			return this.m_E_Btn_PetEggLucklyExplainImage;
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
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Left/ES_RewardList");
		    	   this.m_es_rewardlist = this.AddChild<ES_RewardList,Transform>(subTrans);
     			}
     			return this.m_es_rewardlist;
     		}
     	}

		public UnityEngine.UI.Text E_Text_TotalNumberText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_TotalNumberText == null )
     			{
		    		this.m_E_Text_TotalNumberText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Right/E_Text_TotalNumber");
     			}
     			return this.m_E_Text_TotalNumberText;
     		}
     	}

		public UnityEngine.RectTransform EG_PetLuckyRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_PetLuckyRectTransform == null )
     			{
		    		this.m_EG_PetLuckyRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"Right/EG_PetLucky");
     			}
     			return this.m_EG_PetLuckyRectTransform;
     		}
     	}

		public UnityEngine.UI.Button E_PetEggLucklyExplainBtnButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_PetEggLucklyExplainBtnButton == null )
     			{
		    		this.m_E_PetEggLucklyExplainBtnButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/EG_PetLucky/E_PetEggLucklyExplainBtn");
     			}
     			return this.m_E_PetEggLucklyExplainBtnButton;
     		}
     	}

		public UnityEngine.UI.Image E_PetEggLucklyExplainBtnImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_PetEggLucklyExplainBtnImage == null )
     			{
		    		this.m_E_PetEggLucklyExplainBtnImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/EG_PetLucky/E_PetEggLucklyExplainBtn");
     			}
     			return this.m_E_PetEggLucklyExplainBtnImage;
     		}
     	}

		public UnityEngine.UI.Text E_Text_PetExploreLucklyText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_PetExploreLucklyText == null )
     			{
		    		this.m_E_Text_PetExploreLucklyText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Right/EG_PetLucky/E_Text_PetExploreLuckly");
     			}
     			return this.m_E_Text_PetExploreLucklyText;
     		}
     	}

		public UnityEngine.UI.Image E_ItemImageIconImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_ItemImageIconImage == null )
     			{
		    		this.m_E_ItemImageIconImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/CostItem/E_ItemImageIcon");
     			}
     			return this.m_E_ItemImageIconImage;
     		}
     	}

		public UnityEngine.UI.Text E_Text_CostNumberText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_CostNumberText == null )
     			{
		    		this.m_E_Text_CostNumberText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Right/CostItem/E_Text_CostNumber");
     			}
     			return this.m_E_Text_CostNumberText;
     		}
     	}

		public UnityEngine.UI.Button E_Btn_ChouKaNumRewardButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_ChouKaNumRewardButton == null )
     			{
		    		this.m_E_Btn_ChouKaNumRewardButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/E_Btn_ChouKaNumReward");
     			}
     			return this.m_E_Btn_ChouKaNumRewardButton;
     		}
     	}

		public UnityEngine.UI.Image E_Btn_ChouKaNumRewardImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_ChouKaNumRewardImage == null )
     			{
		    		this.m_E_Btn_ChouKaNumRewardImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_Btn_ChouKaNumReward");
     			}
     			return this.m_E_Btn_ChouKaNumRewardImage;
     		}
     	}

		public UnityEngine.UI.Button E_Btn_ChouKaButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_ChouKaButton == null )
     			{
		    		this.m_E_Btn_ChouKaButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/E_Btn_ChouKa");
     			}
     			return this.m_E_Btn_ChouKaButton;
     		}
     	}

		public UnityEngine.UI.Image E_Btn_ChouKaImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_ChouKaImage == null )
     			{
		    		this.m_E_Btn_ChouKaImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_Btn_ChouKa");
     			}
     			return this.m_E_Btn_ChouKaImage;
     		}
     	}

		public UnityEngine.UI.Button E_Btn_ChouKaTenButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_ChouKaTenButton == null )
     			{
		    		this.m_E_Btn_ChouKaTenButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/E_Btn_ChouKaTen");
     			}
     			return this.m_E_Btn_ChouKaTenButton;
     		}
     	}

		public UnityEngine.UI.Image E_Btn_ChouKaTenImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_ChouKaTenImage == null )
     			{
		    		this.m_E_Btn_ChouKaTenImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_Btn_ChouKaTen");
     			}
     			return this.m_E_Btn_ChouKaTenImage;
     		}
     	}

		public UnityEngine.UI.Text E_Text_DiamondNumberText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_DiamondNumberText == null )
     			{
		    		this.m_E_Text_DiamondNumberText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Right/E_Btn_ChouKaTen/E_Text_DiamondNumber");
     			}
     			return this.m_E_Text_DiamondNumberText;
     		}
     	}

		public UnityEngine.UI.Button E_Btn_RolePetBagButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_RolePetBagButton == null )
     			{
		    		this.m_E_Btn_RolePetBagButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/E_Btn_RolePetBag");
     			}
     			return this.m_E_Btn_RolePetBagButton;
     		}
     	}

		public UnityEngine.UI.Image E_Btn_RolePetBagImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_RolePetBagImage == null )
     			{
		    		this.m_E_Btn_RolePetBagImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_Btn_RolePetBag");
     			}
     			return this.m_E_Btn_RolePetBagImage;
     		}
     	}

		public UnityEngine.UI.Button E_Btn_RolePetHeXinButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_RolePetHeXinButton == null )
     			{
		    		this.m_E_Btn_RolePetHeXinButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/E_Btn_RolePetHeXin");
     			}
     			return this.m_E_Btn_RolePetHeXinButton;
     		}
     	}

		public UnityEngine.UI.Image E_Btn_RolePetHeXinImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_RolePetHeXinImage == null )
     			{
		    		this.m_E_Btn_RolePetHeXinImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_Btn_RolePetHeXin");
     			}
     			return this.m_E_Btn_RolePetHeXinImage;
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
			this.m_E_Btn_PetEggLucklyExplainButton = null;
			this.m_E_Btn_PetEggLucklyExplainImage = null;
			this.m_es_rewardlist = null;
			this.m_E_Text_TotalNumberText = null;
			this.m_EG_PetLuckyRectTransform = null;
			this.m_E_PetEggLucklyExplainBtnButton = null;
			this.m_E_PetEggLucklyExplainBtnImage = null;
			this.m_E_Text_PetExploreLucklyText = null;
			this.m_E_ItemImageIconImage = null;
			this.m_E_Text_CostNumberText = null;
			this.m_E_Btn_ChouKaNumRewardButton = null;
			this.m_E_Btn_ChouKaNumRewardImage = null;
			this.m_E_Btn_ChouKaButton = null;
			this.m_E_Btn_ChouKaImage = null;
			this.m_E_Btn_ChouKaTenButton = null;
			this.m_E_Btn_ChouKaTenImage = null;
			this.m_E_Text_DiamondNumberText = null;
			this.m_E_Btn_RolePetBagButton = null;
			this.m_E_Btn_RolePetBagImage = null;
			this.m_E_Btn_RolePetHeXinButton = null;
			this.m_E_Btn_RolePetHeXinImage = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.Button m_E_Btn_PetEggLucklyExplainButton = null;
		private UnityEngine.UI.Image m_E_Btn_PetEggLucklyExplainImage = null;
		private EntityRef<ES_RewardList> m_es_rewardlist = null;
		private UnityEngine.UI.Text m_E_Text_TotalNumberText = null;
		private UnityEngine.RectTransform m_EG_PetLuckyRectTransform = null;
		private UnityEngine.UI.Button m_E_PetEggLucklyExplainBtnButton = null;
		private UnityEngine.UI.Image m_E_PetEggLucklyExplainBtnImage = null;
		private UnityEngine.UI.Text m_E_Text_PetExploreLucklyText = null;
		private UnityEngine.UI.Image m_E_ItemImageIconImage = null;
		private UnityEngine.UI.Text m_E_Text_CostNumberText = null;
		private UnityEngine.UI.Button m_E_Btn_ChouKaNumRewardButton = null;
		private UnityEngine.UI.Image m_E_Btn_ChouKaNumRewardImage = null;
		private UnityEngine.UI.Button m_E_Btn_ChouKaButton = null;
		private UnityEngine.UI.Image m_E_Btn_ChouKaImage = null;
		private UnityEngine.UI.Button m_E_Btn_ChouKaTenButton = null;
		private UnityEngine.UI.Image m_E_Btn_ChouKaTenImage = null;
		private UnityEngine.UI.Text m_E_Text_DiamondNumberText = null;
		private UnityEngine.UI.Button m_E_Btn_RolePetBagButton = null;
		private UnityEngine.UI.Image m_E_Btn_RolePetBagImage = null;
		private UnityEngine.UI.Button m_E_Btn_RolePetHeXinButton = null;
		private UnityEngine.UI.Image m_E_Btn_RolePetHeXinImage = null;
		public Transform uiTransform = null;
	}
}
