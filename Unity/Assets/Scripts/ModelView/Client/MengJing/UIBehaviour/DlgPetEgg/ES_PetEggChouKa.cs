using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
	[ChildOf]
	[EnableMethod]
	public  class ES_PetEggChouKa : Entity,IAwake<Transform>,IDestroy 
	{
		public Text E_Text_TotalNumberText
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
		    		this.m_E_Text_TotalNumberText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Text_TotalNumber");
     			}
     			return this.m_E_Text_TotalNumberText;
     		}
     	}

		public RectTransform EG_PetLuckyRectTransform
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
		    		this.m_EG_PetLuckyRectTransform = UIFindHelper.FindDeepChild<RectTransform>(this.uiTransform.gameObject,"EG_PetLucky");
     			}
     			return this.m_EG_PetLuckyRectTransform;
     		}
     	}

		public Button E_PetEggLucklyExplainBtnButton
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
		    		this.m_E_PetEggLucklyExplainBtnButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"EG_PetLucky/E_PetEggLucklyExplainBtn");
     			}
     			return this.m_E_PetEggLucklyExplainBtnButton;
     		}
     	}

		public Image E_PetEggLucklyExplainBtnImage
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
		    		this.m_E_PetEggLucklyExplainBtnImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"EG_PetLucky/E_PetEggLucklyExplainBtn");
     			}
     			return this.m_E_PetEggLucklyExplainBtnImage;
     		}
     	}

		public Text E_Text_PetExploreLucklyText
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
		    		this.m_E_Text_PetExploreLucklyText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"EG_PetLucky/E_Text_PetExploreLuckly");
     			}
     			return this.m_E_Text_PetExploreLucklyText;
     		}
     	}

		public Image E_ItemImageIconImage
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
		    		this.m_E_ItemImageIconImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"CostItem/E_ItemImageIcon");
     			}
     			return this.m_E_ItemImageIconImage;
     		}
     	}

		public Text E_Text_CostNumberText
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
		    		this.m_E_Text_CostNumberText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"CostItem/E_Text_CostNumber");
     			}
     			return this.m_E_Text_CostNumberText;
     		}
     	}

		public Text E_Text_DiamondNumberText
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
		    		this.m_E_Text_DiamondNumberText = UIFindHelper.FindDeepChild<Text>(this.uiTransform.gameObject,"E_Text_DiamondNumber");
     			}
     			return this.m_E_Text_DiamondNumberText;
     		}
     	}

		public Button E_Btn_ChouKaNumRewardButton
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
		    		this.m_E_Btn_ChouKaNumRewardButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_Btn_ChouKaNumReward");
     			}
     			return this.m_E_Btn_ChouKaNumRewardButton;
     		}
     	}

		public Image E_Btn_ChouKaNumRewardImage
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
		    		this.m_E_Btn_ChouKaNumRewardImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Btn_ChouKaNumReward");
     			}
     			return this.m_E_Btn_ChouKaNumRewardImage;
     		}
     	}

		public Button E_Btn_ChouKaButton
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
		    		this.m_E_Btn_ChouKaButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_Btn_ChouKa");
     			}
     			return this.m_E_Btn_ChouKaButton;
     		}
     	}

		public Image E_Btn_ChouKaImage
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
		    		this.m_E_Btn_ChouKaImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Btn_ChouKa");
     			}
     			return this.m_E_Btn_ChouKaImage;
     		}
     	}

		public Button E_Btn_ChouKaTenButton
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
		    		this.m_E_Btn_ChouKaTenButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_Btn_ChouKaTen");
     			}
     			return this.m_E_Btn_ChouKaTenButton;
     		}
     	}

		public Image E_Btn_ChouKaTenImage
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
		    		this.m_E_Btn_ChouKaTenImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Btn_ChouKaTen");
     			}
     			return this.m_E_Btn_ChouKaTenImage;
     		}
     	}

		public Button E_Btn_RolePetBagButton
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
		    		this.m_E_Btn_RolePetBagButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_Btn_RolePetBag");
     			}
     			return this.m_E_Btn_RolePetBagButton;
     		}
     	}

		public Image E_Btn_RolePetBagImage
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
		    		this.m_E_Btn_RolePetBagImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Btn_RolePetBag");
     			}
     			return this.m_E_Btn_RolePetBagImage;
     		}
     	}

		public Button E_Btn_RolePetHeXinButton
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
		    		this.m_E_Btn_RolePetHeXinButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_Btn_RolePetHeXin");
     			}
     			return this.m_E_Btn_RolePetHeXinButton;
     		}
     	}

		public Image E_Btn_RolePetHeXinImage
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
		    		this.m_E_Btn_RolePetHeXinImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Btn_RolePetHeXin");
     			}
     			return this.m_E_Btn_RolePetHeXinImage;
     		}
     	}

		public Button E_Btn_PetEggLucklyExplainButton
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
		    		this.m_E_Btn_PetEggLucklyExplainButton = UIFindHelper.FindDeepChild<Button>(this.uiTransform.gameObject,"E_Btn_PetEggLucklyExplain");
     			}
     			return this.m_E_Btn_PetEggLucklyExplainButton;
     		}
     	}

		public Image E_Btn_PetEggLucklyExplainImage
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
		    		this.m_E_Btn_PetEggLucklyExplainImage = UIFindHelper.FindDeepChild<Image>(this.uiTransform.gameObject,"E_Btn_PetEggLucklyExplain");
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
     			if( es ==null )
     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"ES_RewardList");
		    	   this.m_es_rewardlist = this.AddChild<ES_RewardList,Transform>(subTrans);
     			}
     			return this.m_es_rewardlist;
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
			this.m_E_Text_TotalNumberText = null;
			this.m_EG_PetLuckyRectTransform = null;
			this.m_E_PetEggLucklyExplainBtnButton = null;
			this.m_E_PetEggLucklyExplainBtnImage = null;
			this.m_E_Text_PetExploreLucklyText = null;
			this.m_E_ItemImageIconImage = null;
			this.m_E_Text_CostNumberText = null;
			this.m_E_Text_DiamondNumberText = null;
			this.m_E_Btn_ChouKaNumRewardButton = null;
			this.m_E_Btn_ChouKaNumRewardImage = null;
			this.m_E_Btn_ChouKaButton = null;
			this.m_E_Btn_ChouKaImage = null;
			this.m_E_Btn_ChouKaTenButton = null;
			this.m_E_Btn_ChouKaTenImage = null;
			this.m_E_Btn_RolePetBagButton = null;
			this.m_E_Btn_RolePetBagImage = null;
			this.m_E_Btn_RolePetHeXinButton = null;
			this.m_E_Btn_RolePetHeXinImage = null;
			this.m_E_Btn_PetEggLucklyExplainButton = null;
			this.m_E_Btn_PetEggLucklyExplainImage = null;
			this.m_es_rewardlist = null;
			this.uiTransform = null;
		}

		private Text m_E_Text_TotalNumberText = null;
		private RectTransform m_EG_PetLuckyRectTransform = null;
		private Button m_E_PetEggLucklyExplainBtnButton = null;
		private Image m_E_PetEggLucklyExplainBtnImage = null;
		private Text m_E_Text_PetExploreLucklyText = null;
		private Image m_E_ItemImageIconImage = null;
		private Text m_E_Text_CostNumberText = null;
		private Text m_E_Text_DiamondNumberText = null;
		private Button m_E_Btn_ChouKaNumRewardButton = null;
		private Image m_E_Btn_ChouKaNumRewardImage = null;
		private Button m_E_Btn_ChouKaButton = null;
		private Image m_E_Btn_ChouKaImage = null;
		private Button m_E_Btn_ChouKaTenButton = null;
		private Image m_E_Btn_ChouKaTenImage = null;
		private Button m_E_Btn_RolePetBagButton = null;
		private Image m_E_Btn_RolePetBagImage = null;
		private Button m_E_Btn_RolePetHeXinButton = null;
		private Image m_E_Btn_RolePetHeXinImage = null;
		private Button m_E_Btn_PetEggLucklyExplainButton = null;
		private Image m_E_Btn_PetEggLucklyExplainImage = null;
		private EntityRef<ES_RewardList> m_es_rewardlist = null;
		public Transform uiTransform = null;
	}
}
