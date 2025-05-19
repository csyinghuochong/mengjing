
using UnityEngine;
using UnityEngine.UI;
namespace ET.Client
{
	[ComponentOf(typeof(DlgCellDungeonSettlement))]
	[EnableMethod]
	public  class DlgCellDungeonSettlementViewComponent : Entity,IAwake,IDestroy 
	{
		public UnityEngine.UI.Button E_closeButtonButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_closeButtonButton == null )
     			{
		    		this.m_E_closeButtonButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"E_closeButton");
     			}
     			return this.m_E_closeButtonButton;
     		}
     	}

		public UnityEngine.UI.Image E_closeButtonImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_closeButtonImage == null )
     			{
		    		this.m_E_closeButtonImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"E_closeButton");
     			}
     			return this.m_E_closeButtonImage;
     		}
     	}

		public UnityEngine.RectTransform EG_SelectEffectSetRectTransform
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_EG_SelectEffectSetRectTransform == null )
     			{
		    		this.m_EG_SelectEffectSetRectTransform = UIFindHelper.FindDeepChild<UnityEngine.RectTransform>(this.uiTransform.gameObject,"EG_SelectEffectSet");
     			}
     			return this.m_EG_SelectEffectSetRectTransform;
     		}
     	}

		public UnityEngine.UI.Text E_Text_LeftTimeText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_LeftTimeText == null )
     			{
		    		this.m_E_Text_LeftTimeText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Left/E_Text_LeftTime");
     			}
     			return this.m_E_Text_LeftTimeText;
     		}
     	}

		public ES_SettlementReward ES_SettlementReward_1
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			ES_SettlementReward es = this.m_es_settlementreward_1;
     			if( es == null )

     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Left/ES_SettlementReward_1");
		    	   this.m_es_settlementreward_1 = this.AddChild<ES_SettlementReward,Transform>(subTrans);
     			}
     			return this.m_es_settlementreward_1;
     		}
     	}

		public ES_SettlementReward ES_SettlementReward_2
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			ES_SettlementReward es = this.m_es_settlementreward_2;
     			if( es == null )

     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Left/ES_SettlementReward_2");
		    	   this.m_es_settlementreward_2 = this.AddChild<ES_SettlementReward,Transform>(subTrans);
     			}
     			return this.m_es_settlementreward_2;
     		}
     	}

		public ES_SettlementReward ES_SettlementReward_3
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			ES_SettlementReward es = this.m_es_settlementreward_3;
     			if( es == null )

     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Left/ES_SettlementReward_3");
		    	   this.m_es_settlementreward_3 = this.AddChild<ES_SettlementReward,Transform>(subTrans);
     			}
     			return this.m_es_settlementreward_3;
     		}
     	}

		public ES_SettlementReward ES_SettlementReward_4
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			ES_SettlementReward es = this.m_es_settlementreward_4;
     			if( es == null )

     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Left/ES_SettlementReward_4");
		    	   this.m_es_settlementreward_4 = this.AddChild<ES_SettlementReward,Transform>(subTrans);
     			}
     			return this.m_es_settlementreward_4;
     		}
     	}

		public ES_SettlementReward ES_SettlementReward_5
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			ES_SettlementReward es = this.m_es_settlementreward_5;
     			if( es == null )

     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Left/ES_SettlementReward_5");
		    	   this.m_es_settlementreward_5 = this.AddChild<ES_SettlementReward,Transform>(subTrans);
     			}
     			return this.m_es_settlementreward_5;
     		}
     	}

		public ES_SettlementReward ES_SettlementReward_6
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			ES_SettlementReward es = this.m_es_settlementreward_6;
     			if( es == null )

     			{
		    	   Transform subTrans = UIFindHelper.FindDeepChild<Transform>(this.uiTransform.gameObject,"Left/ES_SettlementReward_6");
		    	   this.m_es_settlementreward_6 = this.AddChild<ES_SettlementReward,Transform>(subTrans);
     			}
     			return this.m_es_settlementreward_6;
     		}
     	}

		public UnityEngine.UI.Image E_Star_1_liangImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Star_1_liangImage == null )
     			{
		    		this.m_E_Star_1_liangImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_Star_1_liang");
     			}
     			return this.m_E_Star_1_liangImage;
     		}
     	}

		public UnityEngine.UI.Image E_Star_2_liangImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Star_2_liangImage == null )
     			{
		    		this.m_E_Star_2_liangImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_Star_2_liang");
     			}
     			return this.m_E_Star_2_liangImage;
     		}
     	}

		public UnityEngine.UI.Image E_Star_3_liangImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Star_3_liangImage == null )
     			{
		    		this.m_E_Star_3_liangImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_Star_3_liang");
     			}
     			return this.m_E_Star_3_liangImage;
     		}
     	}

		public UnityEngine.UI.Image E_Star_1_OKImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Star_1_OKImage == null )
     			{
		    		this.m_E_Star_1_OKImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_Star_1_OK");
     			}
     			return this.m_E_Star_1_OKImage;
     		}
     	}

		public UnityEngine.UI.Image E_Star_2_OKImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Star_2_OKImage == null )
     			{
		    		this.m_E_Star_2_OKImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_Star_2_OK");
     			}
     			return this.m_E_Star_2_OKImage;
     		}
     	}

		public UnityEngine.UI.Image E_Star_3_OKImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Star_3_OKImage == null )
     			{
		    		this.m_E_Star_3_OKImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_Star_3_OK");
     			}
     			return this.m_E_Star_3_OKImage;
     		}
     	}

		public UnityEngine.UI.Button E_Button_exitButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_exitButton == null )
     			{
		    		this.m_E_Button_exitButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/E_Button_exit");
     			}
     			return this.m_E_Button_exitButton;
     		}
     	}

		public UnityEngine.UI.Image E_Button_exitImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_exitImage == null )
     			{
		    		this.m_E_Button_exitImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_Button_exit");
     			}
     			return this.m_E_Button_exitImage;
     		}
     	}

		public UnityEngine.UI.Button E_Button_continueButton
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_continueButton == null )
     			{
		    		this.m_E_Button_continueButton = UIFindHelper.FindDeepChild<UnityEngine.UI.Button>(this.uiTransform.gameObject,"Right/E_Button_continue");
     			}
     			return this.m_E_Button_continueButton;
     		}
     	}

		public UnityEngine.UI.Image E_Button_continueImage
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Button_continueImage == null )
     			{
		    		this.m_E_Button_continueImage = UIFindHelper.FindDeepChild<UnityEngine.UI.Image>(this.uiTransform.gameObject,"Right/E_Button_continue");
     			}
     			return this.m_E_Button_continueImage;
     		}
     	}

		public UnityEngine.UI.Text E_Text_ResultText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_ResultText == null )
     			{
		    		this.m_E_Text_ResultText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Right/E_Text_Result");
     			}
     			return this.m_E_Text_ResultText;
     		}
     	}

		public UnityEngine.UI.Text E_Text_expText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_expText == null )
     			{
		    		this.m_E_Text_expText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Right/E_Text_exp");
     			}
     			return this.m_E_Text_expText;
     		}
     	}

		public UnityEngine.UI.Text E_Text_goldText
     	{
     		get
     		{
     			if (this.uiTransform == null)
     			{
     				Log.Error("uiTransform is null.");
     				return null;
     			}
     			if( this.m_E_Text_goldText == null )
     			{
		    		this.m_E_Text_goldText = UIFindHelper.FindDeepChild<UnityEngine.UI.Text>(this.uiTransform.gameObject,"Right/E_Text_gold");
     			}
     			return this.m_E_Text_goldText;
     		}
     	}

		public void DestroyWidget()
		{
			this.m_E_closeButtonButton = null;
			this.m_E_closeButtonImage = null;
			this.m_EG_SelectEffectSetRectTransform = null;
			this.m_E_Text_LeftTimeText = null;
			this.m_es_settlementreward_1 = null;
			this.m_es_settlementreward_2 = null;
			this.m_es_settlementreward_3 = null;
			this.m_es_settlementreward_4 = null;
			this.m_es_settlementreward_5 = null;
			this.m_es_settlementreward_6 = null;
			this.m_E_Star_1_liangImage = null;
			this.m_E_Star_2_liangImage = null;
			this.m_E_Star_3_liangImage = null;
			this.m_E_Star_1_OKImage = null;
			this.m_E_Star_2_OKImage = null;
			this.m_E_Star_3_OKImage = null;
			this.m_E_Button_exitButton = null;
			this.m_E_Button_exitImage = null;
			this.m_E_Button_continueButton = null;
			this.m_E_Button_continueImage = null;
			this.m_E_Text_ResultText = null;
			this.m_E_Text_expText = null;
			this.m_E_Text_goldText = null;
			this.uiTransform = null;
		}

		private UnityEngine.UI.Button m_E_closeButtonButton = null;
		private UnityEngine.UI.Image m_E_closeButtonImage = null;
		private UnityEngine.RectTransform m_EG_SelectEffectSetRectTransform = null;
		private UnityEngine.UI.Text m_E_Text_LeftTimeText = null;
		private EntityRef<ES_SettlementReward> m_es_settlementreward_1 = null;
		private EntityRef<ES_SettlementReward> m_es_settlementreward_2 = null;
		private EntityRef<ES_SettlementReward> m_es_settlementreward_3 = null;
		private EntityRef<ES_SettlementReward> m_es_settlementreward_4 = null;
		private EntityRef<ES_SettlementReward> m_es_settlementreward_5 = null;
		private EntityRef<ES_SettlementReward> m_es_settlementreward_6 = null;
		private UnityEngine.UI.Image m_E_Star_1_liangImage = null;
		private UnityEngine.UI.Image m_E_Star_2_liangImage = null;
		private UnityEngine.UI.Image m_E_Star_3_liangImage = null;
		private UnityEngine.UI.Image m_E_Star_1_OKImage = null;
		private UnityEngine.UI.Image m_E_Star_2_OKImage = null;
		private UnityEngine.UI.Image m_E_Star_3_OKImage = null;
		private UnityEngine.UI.Button m_E_Button_exitButton = null;
		private UnityEngine.UI.Image m_E_Button_exitImage = null;
		private UnityEngine.UI.Button m_E_Button_continueButton = null;
		private UnityEngine.UI.Image m_E_Button_continueImage = null;
		private UnityEngine.UI.Text m_E_Text_ResultText = null;
		private UnityEngine.UI.Text m_E_Text_expText = null;
		private UnityEngine.UI.Text m_E_Text_goldText = null;
		public Transform uiTransform = null;
	}
}
