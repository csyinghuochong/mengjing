
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ComponentOf(typeof(DlgChouKa))]
	[EnableMethod]
	public  class DlgChouKaViewComponent : Entity,IAwake,IDestroy 
	{
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

		public UnityEngine.UI.Button E_Btn_ChouKaProbExplainButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_ChouKaProbExplainButton == null )
     			{
		    		this.m_E_Btn_ChouKaProbExplainButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Left/E_Btn_ChouKaProbExplain");
     			}
     			return this.m_E_Btn_ChouKaProbExplainButton;
     		}
     	}

		public UnityEngine.UI.Image E_Btn_ChouKaProbExplainImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_ChouKaProbExplainImage == null )
     			{
		    		this.m_E_Btn_ChouKaProbExplainImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Left/E_Btn_ChouKaProbExplain");
     			}
     			return this.m_E_Btn_ChouKaProbExplainImage;
     		}
     	}

		public UnityEngine.UI.Button E_Btn_ChouKaOneButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_ChouKaOneButton == null )
     			{
		    		this.m_E_Btn_ChouKaOneButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/E_Btn_ChouKaOne");
     			}
     			return this.m_E_Btn_ChouKaOneButton;
     		}
     	}

		public UnityEngine.UI.Image E_Btn_ChouKaOneImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_ChouKaOneImage == null )
     			{
		    		this.m_E_Btn_ChouKaOneImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_Btn_ChouKaOne");
     			}
     			return this.m_E_Btn_ChouKaOneImage;
     		}
     	}

		public UnityEngine.UI.Text E_TextOneCostText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TextOneCostText == null )
     			{
		    		this.m_E_TextOneCostText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Right/E_Btn_ChouKaOne/E_TextOneCost");
     			}
     			return this.m_E_TextOneCostText;
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

		public UnityEngine.UI.Button E_Btn_WarehouseButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_WarehouseButton == null )
     			{
		    		this.m_E_Btn_WarehouseButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/E_Btn_Warehouse");
     			}
     			return this.m_E_Btn_WarehouseButton;
     		}
     	}

		public UnityEngine.UI.Image E_Btn_WarehouseImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_WarehouseImage == null )
     			{
		    		this.m_E_Btn_WarehouseImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_Btn_Warehouse");
     			}
     			return this.m_E_Btn_WarehouseImage;
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

		public UnityEngine.UI.Button E_Btn_ZhangJieXuanZeButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_ZhangJieXuanZeButton == null )
     			{
		    		this.m_E_Btn_ZhangJieXuanZeButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/E_Btn_ZhangJieXuanZe");
     			}
     			return this.m_E_Btn_ZhangJieXuanZeButton;
     		}
     	}

		public UnityEngine.UI.Image E_Btn_ZhangJieXuanZeImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Btn_ZhangJieXuanZeImage == null )
     			{
		    		this.m_E_Btn_ZhangJieXuanZeImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_Btn_ZhangJieXuanZe");
     			}
     			return this.m_E_Btn_ZhangJieXuanZeImage;
     		}
     	}

		public UnityEngine.UI.Text E_TextTenCostText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_TextTenCostText == null )
     			{
		    		this.m_E_TextTenCostText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Right/E_TextTenCost");
     			}
     			return this.m_E_TextTenCostText;
     		}
     	}

		public UnityEngine.UI.Text E_Text_MianFeiTime_1Text
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_MianFeiTime_1Text == null )
     			{
		    		this.m_E_Text_MianFeiTime_1Text = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Right/E_Text_MianFeiTime_1");
     			}
     			return this.m_E_Text_MianFeiTime_1Text;
     		}
     	}

		public UnityEngine.UI.Text E_Text_MianFeiTime_2Text
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_MianFeiTime_2Text == null )
     			{
		    		this.m_E_Text_MianFeiTime_2Text = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Right/E_Text_MianFeiTime_2");
     			}
     			return this.m_E_Text_MianFeiTime_2Text;
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

		public UnityEngine.UI.Text E_Text_ChapterText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_ChapterText == null )
     			{
		    		this.m_E_Text_ChapterText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Right/E_Text_Chapter");
     			}
     			return this.m_E_Text_ChapterText;
     		}
     	}

		public ES_ChouKaChapterSelect ES_ChouKaChapterSelect
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			ES_ChouKaChapterSelect es = this.m_es_choukachapterselect;
     			if( es == null )

     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"ES_ChouKaChapterSelect");
		    	   this.m_es_choukachapterselect = this.AddChild<ES_ChouKaChapterSelect,Transform>(subTrans);
     			}
     			return this.m_es_choukachapterselect;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_es_rewardlist = null;
			this.m_E_Btn_ChouKaProbExplainButton = null;
			this.m_E_Btn_ChouKaProbExplainImage = null;
			this.m_E_Btn_ChouKaOneButton = null;
			this.m_E_Btn_ChouKaOneImage = null;
			this.m_E_TextOneCostText = null;
			this.m_E_Btn_ChouKaTenButton = null;
			this.m_E_Btn_ChouKaTenImage = null;
			this.m_E_Btn_WarehouseButton = null;
			this.m_E_Btn_WarehouseImage = null;
			this.m_E_Btn_ChouKaNumRewardButton = null;
			this.m_E_Btn_ChouKaNumRewardImage = null;
			this.m_E_Btn_ZhangJieXuanZeButton = null;
			this.m_E_Btn_ZhangJieXuanZeImage = null;
			this.m_E_TextTenCostText = null;
			this.m_E_Text_MianFeiTime_1Text = null;
			this.m_E_Text_MianFeiTime_2Text = null;
			this.m_E_Text_TotalNumberText = null;
			this.m_E_Text_ChapterText = null;
			this.m_es_choukachapterselect = null;
			this.uiTransform = null;
		}

		private EntityRef<ES_RewardList> m_es_rewardlist = null;
		private UnityEngine.UI.Button m_E_Btn_ChouKaProbExplainButton = null;
		private UnityEngine.UI.Image m_E_Btn_ChouKaProbExplainImage = null;
		private UnityEngine.UI.Button m_E_Btn_ChouKaOneButton = null;
		private UnityEngine.UI.Image m_E_Btn_ChouKaOneImage = null;
		private UnityEngine.UI.Text m_E_TextOneCostText = null;
		private UnityEngine.UI.Button m_E_Btn_ChouKaTenButton = null;
		private UnityEngine.UI.Image m_E_Btn_ChouKaTenImage = null;
		private UnityEngine.UI.Button m_E_Btn_WarehouseButton = null;
		private UnityEngine.UI.Image m_E_Btn_WarehouseImage = null;
		private UnityEngine.UI.Button m_E_Btn_ChouKaNumRewardButton = null;
		private UnityEngine.UI.Image m_E_Btn_ChouKaNumRewardImage = null;
		private UnityEngine.UI.Button m_E_Btn_ZhangJieXuanZeButton = null;
		private UnityEngine.UI.Image m_E_Btn_ZhangJieXuanZeImage = null;
		private UnityEngine.UI.Text m_E_TextTenCostText = null;
		private UnityEngine.UI.Text m_E_Text_MianFeiTime_1Text = null;
		private UnityEngine.UI.Text m_E_Text_MianFeiTime_2Text = null;
		private UnityEngine.UI.Text m_E_Text_TotalNumberText = null;
		private UnityEngine.UI.Text m_E_Text_ChapterText = null;
		private EntityRef<ES_ChouKaChapterSelect> m_es_choukachapterselect = null;
		public Transform uiTransform = null;
	}
}
